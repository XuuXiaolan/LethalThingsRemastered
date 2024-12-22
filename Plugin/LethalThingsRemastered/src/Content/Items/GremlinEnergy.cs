using System.Collections;
using System.Linq;
using GameNetcodeStuff;
using LethalThingsRemastered.src.Util;
using LethalThingsRemastered.src.Util.Extensions;
using Unity.Netcode;
using UnityEngine;

namespace LethalThingsRemastered.src.Content.Items;
public class GremlinEnergy : GrabbableObject
{
    public AudioSource audioSource;
    public AudioClip[] drinkClips;
    private float transformChance = 5f;
    private float timeToDeathMin = 5f;
    private float timeToDeathMax = 10f;
    private System.Random gremlinRandom = new();
    public override void Start()
    {
        base.Start();
        gremlinRandom = new System.Random(StartOfRound.Instance.randomMapSeed + 2);
    }

    public override void ItemActivate(bool used, bool buttonDown = true)
    {
        base.ItemActivate(used, buttonDown);

        int index = gremlinRandom.Next(0, drinkClips.Length);

        audioSource.PlayOneShot(drinkClips[index]);
        WalkieTalkie.TransmitOneShotAudio(audioSource, drinkClips[index], 1f);
        RoundManager.Instance.PlayAudibleNoise(base.transform.position, 20, 1f, 0, isInElevator && StartOfRound.Instance.hangarDoorsClosed);

        if (!StartOfRound.Instance.inShipPhase && gremlinRandom.Next(0, 100) < transformChance)
        {
            // transform into a slime
            StartCoroutine(DelayedDeath(gremlinRandom.NextFloat(timeToDeathMin, timeToDeathMax), playerHeldBy));
            HUDManager.Instance.DisplayTip("Anomaly detected in vital signs.", "", true);
        }
    }

    public IEnumerator DelayedDeath(float timeToDeath, PlayerControllerB lastPlayerHeldBy)
    {
        yield return new WaitForSeconds(timeToDeath);
        lastPlayerHeldBy.activatingItem = false;
        lastPlayerHeldBy.playerBodyAnimator.SetBool("useTZPItem", false);
        lastPlayerHeldBy.movementAudio.PlayOneShot(StartOfRound.Instance.bloodGoreSFX);
        WalkieTalkie.TransmitOneShotAudio(lastPlayerHeldBy.movementAudio, StartOfRound.Instance.bloodGoreSFX);

        if (!IsOwner) yield break;
        HandleKillSpawnServerRpc();
        lastPlayerHeldBy.DiscardHeldObject();
        lastPlayerHeldBy.DropBlood();
        lastPlayerHeldBy.KillPlayer(lastPlayerHeldBy.velocityLastFrame, true, CauseOfDeath.Unknown, 1);
    }

    [ServerRpc(RequireOwnership = false)]
    public void HandleKillSpawnServerRpc()
    {
        RoundManager.Instance.SpawnEnemyGameObject(playerHeldBy.transform.position, -1, -1, LethalThingsRemasteredUtils.EnemyTypes.Where(x => x.enemyPrefab.GetComponent<BlobAI>() is not null).First());
    }

}