using System;
using HarmonyLib;
using LethalThingsRemastered.src.Util;
using UnityEngine;

namespace LethalThingsRemastered.src.Patches;
[HarmonyPatch(typeof(MenuManager))]
static class MenuManagerPatch
{
    public static bool alreadyPatched = false;

    public static void Init()
    {
        On.MenuManager.Start += MenuManager_StartPatch;
    }

    private static void MenuManager_StartPatch(On.MenuManager.orig_Start orig, MenuManager self)
    {
        orig(self);
        if (alreadyPatched)
        {
            return;
        }

        var enemyArray = Resources.FindObjectsOfTypeAll<EnemyType>();
        foreach (EnemyType enemy in enemyArray)
        {
            if (String.IsNullOrEmpty(enemy.enemyName)) continue;
            Plugin.ExtendedLogging($"{enemy.enemyName} has been found!");

            if (!LethalThingsRemasteredUtils.EnemyTypes.Contains(enemy)) LethalThingsRemasteredUtils.EnemyTypes.Add(enemy);
        }

        alreadyPatched = true;
    }
}