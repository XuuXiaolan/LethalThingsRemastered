﻿using LethalThingsRemastered.src.Util;
using LethalThingsRemastered.src.Util.AssetLoading;
using UnityEngine;

namespace LethalThingsRemastered.src.Content.Enemies;
public class EnemyHandler : ContentHandler<EnemyHandler>
{
    public class BoombaAssets(string bundleName) : AssetBundleLoader<BoombaAssets>(bundleName)
    {
        [LoadFromBundle("Boomba.asset")]
        public EnemyType BoombaDef { get; private set; } = null!;

        [LoadFromBundle("BoombaTN.asset")]
        public TerminalNode BoombaTN { get; private set; } = null!;

        [LoadFromBundle("BoombaTK.asset")]
        public TerminalKeyword BoombaTK { get; private set; } = null!;
    }

    public class MaggieAssets(string bundleName) : AssetBundleLoader<MaggieAssets>(bundleName)
    {
        [LoadFromBundle("Maggie.asset")]
        public EnemyType MaggieDef { get; private set; } = null!;

        [LoadFromBundle("MaggieTN.asset")]
        public TerminalNode MaggieTN { get; private set; } = null!;

        [LoadFromBundle("MaggieTK.asset")]
        public TerminalKeyword MaggieTK { get; private set; } = null!;
    }

    public class CrystalRayAssets(string bundleName) : AssetBundleLoader<CrystalRayAssets>(bundleName)
    {
        [LoadFromBundle("CrystalRay.asset")]
        public EnemyType CrystalRayDef { get; private set; } = null!;

        [LoadFromBundle("CrystalRayTN.asset")]
        public TerminalNode CrystalRayTN { get; private set; } = null!;

        [LoadFromBundle("CrystalRayTK.asset")]
        public TerminalKeyword CrystalRayTK { get; private set; } = null!;
    }

    public BoombaAssets Boomba { get; private set; } = null!;
    public MaggieAssets Maggie { get; private set; } = null!;
    public CrystalRayAssets CrystalRay { get; private set; } = null!;

    public EnemyHandler()
    {
        if (Plugin.ModConfig.ConfigBoombaEnabled.Value) RegisterBoomba();
        if (Plugin.ModConfig.ConfigMaggieEnabled.Value) RegisterMaggie();
        if (Plugin.ModConfig.ConfigCrystalRayEnabled.Value) RegisterCrystalRay();
    }

    private void RegisterBoomba()
    {
        Boomba = new BoombaAssets("boombaassets");
        RegisterEnemyWithConfig(Plugin.ModConfig.ConfigBoombaSpawnWeight.Value, Boomba.BoombaDef, Boomba.BoombaTN, Boomba.BoombaTK, Plugin.ModConfig.ConfigBoombaPowerLevel.Value, Plugin.ModConfig.ConfigBoombaMaxSpawnCount.Value);
    }

    private void RegisterMaggie()
    {
        Maggie = new MaggieAssets("maggieassets");
        RegisterEnemyWithConfig(Plugin.ModConfig.ConfigMaggieSpawnWeight.Value, Maggie.MaggieDef, Maggie.MaggieTN, Maggie.MaggieTK, Plugin.ModConfig.ConfigMaggiePowerLevel.Value, Plugin.ModConfig.ConfigMaggieMaxSpawnCount.Value);
    }

    private void RegisterCrystalRay()
    {
        CrystalRay = new CrystalRayAssets("crystalrayassets");
        RegisterEnemyWithConfig(Plugin.ModConfig.ConfigCrystalRaySpawnWeight.Value, CrystalRay.CrystalRayDef, CrystalRay.CrystalRayTN, CrystalRay.CrystalRayTK, Plugin.ModConfig.ConfigCrystalRayPowerLevel.Value, Plugin.ModConfig.ConfigCrystalRayMaxSpawnCount.Value);
    }
}