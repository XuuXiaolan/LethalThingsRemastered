using System;
using System.Collections.Generic;
using GameNetcodeStuff;
using HarmonyLib;
using LethalThingsRemastered.src.MiscScripts;
using UnityEngine;

namespace LethalThingsRemastered.src.Patches;
static class PlayerControllerBPatch
{
    public static List<SmartAgentNavigator> smartAgentNavigators = new();

    public static void Init()
    {
        On.GameNetcodeStuff.PlayerControllerB.TeleportPlayer += PlayerControllerB_TeleportPlayer;
    }

    private static void PlayerControllerB_TeleportPlayer(On.GameNetcodeStuff.PlayerControllerB.orig_TeleportPlayer orig, PlayerControllerB self, Vector3 pos, bool withRotation, float rot, bool allowInteractTrigger, bool enableController)
    {
        foreach (var navigator in smartAgentNavigators)
        {
            Plugin.ExtendedLogging($"Setting SmartAgentNavigator.positionsOfPlayersBeforeTeleport[self] to {self.transform.position}");
            navigator.positionsOfPlayersBeforeTeleport[self] = self.transform.position;
        }
        orig(self, pos, withRotation, rot, allowInteractTrigger, enableController);
    }
}