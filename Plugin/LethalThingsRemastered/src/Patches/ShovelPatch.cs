using System;
using LethalThingsRemastered.src.Util;
using UnityEngine;

namespace LethalThingsRemastered.src.Patches;
static class ShovelPatch
{
    public static bool alreadyPatched = false;

    public static void Init()
    {
        On.Shovel.HitShovel += Shovel_HitShovel;
    }

    private static void Shovel_HitShovel(On.Shovel.orig_HitShovel orig, Shovel self, bool cancel)
    {
        orig(self, cancel);
    }
}