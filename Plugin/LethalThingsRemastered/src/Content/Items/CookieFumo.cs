using System.Linq;
using LethalThingsRemastered.src.MiscScripts;
using Unity.Netcode;
using UnityEngine;

namespace LethalThingsRemastered.src.Content.Items;
public class CookieFumo : ThrowableNoisemaker
{
    public AudioClip[] cookieSpecialAudio;

    [HideInInspector] public bool wasThrown = false;
    private const float explodePercentage = 0.04f;
    private const float oooPennyPercentage = 0.2f;
    private System.Random cookieFumoRandom = new();

    public override void Start()
    {
        base.Start();
        cookieFumoRandom = new System.Random(StartOfRound.Instance.randomMapSeed + 3);
    }
    public override void ItemInteractLeftRight(bool right)
    {
        base.ItemInteractLeftRight(right);

        Plugin.ExtendedLogging($"Attempted to throw cookie!!");

        Plugin.ExtendedLogging($"Cookie thrown with right: {right} - {throwWithRight}");

        if ((throwWithRight && right) || !right)
        {
            wasThrown = true;
            PlayCookieAudio(0);
        }
    }

    public override void OnHitGround()
    {
        if (!wasThrown) return;
        wasThrown = false;

        if (cookieFumoRandom.Next(0, 100) <= explodePercentage*100)
        {
            Boom();
        }
        else
        {
            // if random chance
            if (cookieFumoRandom.Next(0, 100) <= oooPennyPercentage*100)
            {
                StopPlayingCookieAudio();
                PlayCookieAudio(1);
            }
        }
    }

    public void PlayCookieAudio(int index)
    {
        noiseAudio.PlayOneShot(cookieSpecialAudio[index]);

        WalkieTalkie.TransmitOneShotAudio(noiseAudio, cookieSpecialAudio[index], 0.5f);
        RoundManager.Instance.PlayAudibleNoise(base.transform.position, noiseRange, 0.5f, 0, isInElevator && StartOfRound.Instance.hangarDoorsClosed);
    }

    public void StopPlayingCookieAudio()
    {
        noiseAudio.Stop();
    }

    public void CreateExplosion()
    {
        var player = StartOfRound.Instance.allPlayerScripts.FirstOrDefault(x => x.OwnerClientId == OwnerClientId);
        LTRUtilities.CreateExplosion(transform.position, true, 20, 0, 4, 2, player, null);
    }

    public void Boom()
    {
        CreateExplosion();

        if (IsHost)
        {
            NetworkObject.Despawn();
        }
    }
}