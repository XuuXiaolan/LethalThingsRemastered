using LethalThingsRemastered.src.Content.Items;
using UnityEngine;

namespace LethalThingsRemastered.src.Patches;
static class ShowerTriggerPatch
{
    public static void Init()
    {
        On.ShowerTrigger.CheckBoundsForPlayers += ShowerTrigger_CheckBoundsForPlayers;
    }

    private static void ShowerTrigger_CheckBoundsForPlayers(On.ShowerTrigger.orig_CheckBoundsForPlayers orig, ShowerTrigger self)
    {
        if (Time.realtimeSinceStartup - self.cleanInterval < 1.5f) return;

        Collider collider = self.showerCollider;

        foreach (var arson in ArsonPlushie.Instances)
        {
            if (arson.arsonBeingShowered || !arson.isCleanable)
            {
                continue;
            }

            Plugin.ExtendedLogging("Checking arson " + arson.gameObject.name);

            var arsonCollider = arson.GetComponent<BoxCollider>();

            if (collider.bounds.Intersects(arsonCollider.bounds))
            {
                arson.arsonBeingShowered = true;
                arson.currentShower = self;
                Plugin.ExtendedLogging("Eww!! stinky arson.");
            }
            else
            {
                arson.arsonBeingShowered = false;
                arson.showerTime = 0f;
            }
        }
        orig(self);
    }
}