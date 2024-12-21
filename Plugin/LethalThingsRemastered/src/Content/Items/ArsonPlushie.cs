using System.Collections.Generic;
using UnityEngine;

namespace LethalThingsRemastered.src.Content.Items;
public class ArsonPlushie : GrabbableObject
{
    public AudioSource noiseAudio;

    [Space(3f)]
    public AudioClip[] noiseSFX;

    [Space(3f)]
    public Renderer arsonPlushieRenderer = null!;
    public Material cleanArsonMaterial = null!;
    public float totalShowerTime = 5f;

    private System.Random arsonPlushieRandom = new();
    [HideInInspector] public bool isCleanable;
    [HideInInspector] public bool arsonBeingShowered = false;
    [HideInInspector] public float showerTime = 0f;
    [HideInInspector] public ShowerTrigger? currentShower = null;
    [HideInInspector] public static List<ArsonPlushie> Instances = new();

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Instances.Add(this);
        arsonPlushieRandom = new System.Random(StartOfRound.Instance.randomMapSeed + Instances.Count);
        if (arsonPlushieRandom.Next(0, 100) <= 75)
        {
            isCleanable = true;
            this.SetScrapValue((int)(scrapValue/1.35));
        }
        else
        {
            isCleanable = false;
            arsonPlushieRenderer.SetMaterial(cleanArsonMaterial);
        }
        // do the check and stuff for making it clean or not and calculate value accordingly.
    }

    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        Instances.Remove(this);
    }

    public override void Update()
    {
        base.Update();
        if (!arsonBeingShowered) return;
        if(currentShower == null || !currentShower.showerOn)
        {
            arsonBeingShowered = false;
            return;
        }

        showerTime += Time.deltaTime;

        if (showerTime < totalShowerTime) return;
        arsonBeingShowered = false;
        showerTime = 0f;

        isCleanable = false;
        arsonPlushieRenderer.SetMaterial(cleanArsonMaterial);
        this.SetScrapValue((int)(scrapValue*1.35f));
    }

    public override void ItemActivate(bool used, bool buttonDown = true)
    {
        base.ItemActivate(used, buttonDown);
        int randomAudioClip = arsonPlushieRandom.Next(0, noiseSFX.Length);
        float randomVolume = (float)arsonPlushieRandom.Next((int)(0.8 * 100f), (int)(1.2 * 100f)) / 100f;
        float randomPitch = (float)arsonPlushieRandom.Next((int)(0.8 * 100f), (int)(1.2 * 100f)) / 100f;

        noiseAudio.pitch = randomPitch;
        noiseAudio.PlayOneShot(noiseSFX[randomAudioClip], randomVolume);

        WalkieTalkie.TransmitOneShotAudio(noiseAudio, noiseSFX[randomAudioClip], randomVolume);
        RoundManager.Instance.PlayAudibleNoise(base.transform.position, 14, randomVolume, 0, playerHeldBy.isInHangarShipRoom && StartOfRound.Instance.hangarDoorsClosed);

        if (!IsOwner) return;
        if (!noiseSFX[randomAudioClip].name.Contains("chomp")) return;

        playerHeldBy.DamagePlayer(30, causeOfDeath: CauseOfDeath.Mauling);
        playerHeldBy.DiscardHeldObject();
    }
}