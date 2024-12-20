using UnityEngine;

namespace LethalThingsRemastered.src.Content.Weapons;
public class LethalThingsRemasteredWeapons : Shovel
{
    public int defaultForce = 0;
    public Transform weaponTip = null!;

    public void Awake()
    {
        defaultForce = shovelHitForce;
        // canBreakTrees = Plugin.ModConfig.ConfigCanBreakTrees.Value;
        // critChance = Plugin.ModConfig.ConfigCritChance.Value;
    }
}