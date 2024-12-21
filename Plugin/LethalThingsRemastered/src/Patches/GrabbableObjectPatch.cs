

using LethalThingsRemastered.src.MiscScripts;

namespace LethalThingsRemastered.src.Patches;
static class GrabbableObjectPatch
{
    public static void Init()
    {
        On.GrabbableObject.RequireCooldown += GrabbableObject_RequireCooldown;
        On.GrabbableObject.ItemInteractLeftRightOnClient += GrabbableObject_ItemInteractLeftRightOnClient;
        On.GrabbableObject.UseItemBatteries += GrabbableObject_UseItemBatteries1;
    }

    private static bool GrabbableObject_UseItemBatteries1(On.GrabbableObject.orig_UseItemBatteries orig, GrabbableObject self, bool isToggle, bool buttonDown)
    {
        if (self is ThrowableNoisemaker noisemaker)
        {
            if (noisemaker.beingThrown)
            {
                return true;
            }
        }

        return orig(self, isToggle, buttonDown);
    }


    private static void GrabbableObject_ItemInteractLeftRightOnClient(On.GrabbableObject.orig_ItemInteractLeftRightOnClient orig, GrabbableObject self, bool right)
    {
        if (self is ThrowableNoisemaker noisemaker)
        {
            if ((noisemaker.throwWithRight && right) || !right)
            {
                noisemaker.beingThrown = true;
                orig(self, right);
                noisemaker.beingThrown = false;
                return;
            }
        }
        orig(self, right);

    }

    private static bool GrabbableObject_RequireCooldown(On.GrabbableObject.orig_RequireCooldown orig, GrabbableObject self)
    {
        if (self is ThrowableNoisemaker noisemaker)
        {
            if (noisemaker.beingThrown)
            {
                return false;
            }
        }
        return orig(self);
    }
}