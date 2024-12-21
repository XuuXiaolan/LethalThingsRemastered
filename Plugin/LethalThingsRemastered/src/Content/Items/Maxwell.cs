using LethalLib.Modules;
using LethalThingsRemastered.src.MiscScripts;
using System.Collections;
using Unity.Netcode;
using UnityEngine;

namespace LethalThingsRemastered.src.Content.Items;
public class Dingus : GrabbableObject
{
    public AudioSource noiseAudio;
    public AudioSource noiseAudioFar;
    public AudioSource musicAudio;
    public AudioSource musicAudioFar;

    [Space(3f)]
    public AudioClip[] noiseSFX;
    public AudioClip[] noiseSFXFar;
    public AudioClip evilNoise;

    [Space(3f)]
    public Animator animator;
    public GameObject evilObject;

    private bool exploding = false;
    private float noiseInterval = 1f;
    private int timesPlayedWithoutTurningOff = 0;
    private NetworkVariable<bool> isEvil = new(false, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    private NetworkVariable<bool> isPlayingMusic = new(true, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    private NetworkVariable<bool> isPipebomb = new(false, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    private System.Random maxwellRandom = new();

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        maxwellRandom = new System.Random(StartOfRound.Instance.randomMapSeed + 85);
        if (IsHost)
        {
            isPlayingMusic.Value = !(StartOfRound.Instance.inShipPhase && StartOfRound.Instance.shipBounds.bounds.Contains(transform.position));
            isEvil.Value = UnityEngine.Random.Range(0f, 100f) <= Plugin.ModConfig.ConfigEvilMaxwellChance.Value;
        }
    }

    public override void Start()
    {
        base.Start();
        if (isEvil.Value)
        {
            Plugin.ExtendedLogging($"Maxwell is evil!! (should logs on everyones end)");
            grabbable = false;
            grabbableToEnemies = false;
        }

        if (!isPlayingMusic.Value)
        {
            animator.SetBool("idle", true);
            animator.SetBool("dancing", false);
            return;
        }
        animator.SetBool("dancing", true);
        animator.SetBool("idle", false);
    }

    public override void Update()
    {
        base.Update();
        if (isPlayingMusic.Value && !exploding)
        {
            musicAudio.volume = 1f;
            musicAudioFar.volume = 1f;

            if (noiseInterval <= 0f)
            {
                noiseInterval = 1f;
                timesPlayedWithoutTurningOff++;
                RoundManager.Instance.PlayAudibleNoise(transform.position, 16f, 0.9f, timesPlayedWithoutTurningOff, noiseIsInsideClosedShip: false, 5);
            }
            else
            {
                noiseInterval -= Time.deltaTime;
            }
        }
        else
        {
            timesPlayedWithoutTurningOff = 0;
            animator.SetBool("idle", true);
            animator.SetBool("dancing", false);

            musicAudio.volume = 0f;
            musicAudioFar.volume = 0f;
        }

    }

    public override void ItemActivate(bool used, bool buttonDown = true)
    {
        base.ItemActivate(used, buttonDown);

        int randomAudioClip = maxwellRandom.Next(0, noiseSFX.Length);
        float randomLoudness = maxwellRandom.Next((int)(0.8 * 100f), (int)(1.2 * 100f)) / 100f;
        float randomPitch = maxwellRandom.Next((int)(0.8 * 100f), (int)(1.2 * 100f)) / 100f;

        noiseAudio.pitch = randomPitch;
        noiseAudio.PlayOneShot(noiseSFX[randomAudioClip], randomLoudness);
        noiseAudioFar.pitch = randomPitch;
        noiseAudioFar.PlayOneShot(noiseSFXFar[randomAudioClip], randomLoudness);

        animator.SetBool("dancing", true);
        animator.SetBool("idle", false);

        WalkieTalkie.TransmitOneShotAudio(noiseAudio, noiseSFX[randomAudioClip], randomLoudness);
        RoundManager.Instance.PlayAudibleNoise(transform.position, 13, randomLoudness, 0, isInElevator && StartOfRound.Instance.hangarDoorsClosed);
    }

    public override void EquipItem()
    {
        base.EquipItem();
        animator.SetBool("dancing", false);
        animator.SetBool("idle", true);
    }

    public override void ItemInteractLeftRight(bool right)
    {
        base.ItemInteractLeftRight(right);

        Plugin.ExtendedLogging($"Hit button: {right} with owner: {IsOwner}");
        if (right || !IsOwner) return;
        isPlayingMusic.Value = !isPlayingMusic.Value;
    }

    public override void InteractItem()
    {
        base.InteractItem();
        if (isEvil.Value && !exploding && !isPipebomb.Value) 
        {
            EvilMaxwellServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    public void EvilMaxwellServerRpc()
    {
        isPipebomb.Value = true;
        EvilMaxwellClientRpc();
    }

    [ClientRpc]
    public void EvilMaxwellClientRpc()
    {
        animator.SetBool("idle", true);
        animator.SetBool("dancing", false);
        StartCoroutine(EvilMaxwellMoment());
        exploding = true;
        if (IsOwner)
        {
            isPlayingMusic.Value = false;
        }
        timesPlayedWithoutTurningOff = 0;

        Plugin.ExtendedLogging("Evil maxwell moment");
    }

    public IEnumerator EvilMaxwellMoment()
    {
        yield return new WaitForSeconds(1f);
        evilObject.SetActive(true);
        mainObjectRenderer.enabled = false;

        animator.SetBool("dancing", true);
        animator.SetBool("idle", false);

        noiseAudio.PlayOneShot(evilNoise, 1);
        noiseAudioFar.PlayOneShot(evilNoise, 1);
        WalkieTalkie.TransmitOneShotAudio(noiseAudio, evilNoise, 1);
        RoundManager.Instance.PlayAudibleNoise(transform.position, 13, 1, 0, StartOfRound.Instance.shipBounds.bounds.Contains(transform.position) && StartOfRound.Instance.hangarDoorsClosed);

        yield return new WaitForSeconds(1.5f);

        LTRUtilities.CreateExplosion(transform.position, true, 100, 0f, 6.4f, 3, playerHeldBy, null);

        // Set rigidbodies to non-kinematic.
        foreach (var rb in evilObject.GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;
            rb.AddExplosionForce(1000f, evilObject.transform.position, 10f);
        }

        if (!IsServer) yield break;
        yield return new WaitForSeconds(2f);

        NetworkObject.Despawn();
    }
}