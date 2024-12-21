﻿using LethalThingsRemastered.src.Util;
using LethalThingsRemastered.src.Util.AssetLoading;

namespace LethalThingsRemastered.src.Content.Items;
public class ItemHandler : ContentHandler<ItemHandler>
{
    public class ArsonPlushieAssets(string bundleName) : AssetBundleLoader<ArsonPlushieAssets>(bundleName)
    {
        [LoadFromBundle("ArsonPlushieDef.asset")]
        public Item ArsonPlushieDef { get; private set; } = null!;

        [LoadFromBundle("ArsonPlushieDirtyDef.asset")]
        public Item ArsonPlushieDirtyDef { get; private set; } = null!;
    }

    public class CookieFumoAssets(string bundleName) : AssetBundleLoader<CookieFumoAssets>(bundleName)
    {
        [LoadFromBundle("CookieFumoDef.asset")]
        public Item CookieFumoDef { get; private set; } = null!;
    }

    public class ToimariPlushieAssets(string bundleName) : AssetBundleLoader<ToimariPlushieAssets>(bundleName)
    {
        [LoadFromBundle("ToimariPlushieDef.asset")]
        public Item ToimariPlushieDef { get; private set; } = null!;
    }

    public class HamisPlushieAssets(string bundleName) : AssetBundleLoader<HamisPlushieAssets>(bundleName)
    {
        [LoadFromBundle("HamisPlushieDef.asset")]
        public Item HamisPlushieDef { get; private set; } = null!;
    }

    public class MaxwellAssets(string bundleName) : AssetBundleLoader<MaxwellAssets>(bundleName)
    {
        [LoadFromBundle("MaxwellDef.asset")]
        public Item MaxwellDef { get; private set; } = null!;
    }

    public class GlizzyAssets(string bundleName) : AssetBundleLoader<GlizzyAssets>(bundleName)
    {
        [LoadFromBundle("GlizzyDef.asset")]
        public Item GlizzyDef { get; private set; } = null!;
    }

    public class RevolverAssets(string bundleName) : AssetBundleLoader<RevolverAssets>(bundleName)
    {
        [LoadFromBundle("RevolverDef.asset")]
        public Item RevolverDef { get; private set; } = null!;
    }

    public class GremlinEnergyAssets(string bundleName) : AssetBundleLoader<GremlinEnergyAssets>(bundleName)
    {
        [LoadFromBundle("GremlinEnergyDef.asset")]
        public Item GremlinEnergyDef { get; private set; } = null!;
    }

    public class ToyHammerAssets(string bundleName) : AssetBundleLoader<ToyHammerAssets>(bundleName)
    {
        [LoadFromBundle("ToyHammerDef.asset")]
        public Item ToyHammerDef { get; private set; } = null!;
    }

    public class GnarpyPlushieAssets(string bundleName) : AssetBundleLoader<GnarpyPlushieAssets>(bundleName)
    {
        [LoadFromBundle("GnarpyPlushieDef.asset")]
        public Item GnarpyPlushieDef { get; private set; } = null!;
    }

    public class RocketLauncherAssets(string bundleName) : AssetBundleLoader<RocketLauncherAssets>(bundleName)
    {
        [LoadFromBundle("RocketLauncherDef.asset")]
        public Item RocketLauncherDef { get; private set; } = null!;
    }


    public class FlaregunAssets(string bundleName) : AssetBundleLoader<FlaregunAssets>(bundleName)
    {
        [LoadFromBundle("FlaregunDef.asset")]
        public Item FlaregunDef { get; private set; } = null!;
    }

    public class RemoteRadarAssets(string bundleName) : AssetBundleLoader<RemoteRadarAssets>(bundleName)
    {
        [LoadFromBundle("HandheldRadarDef.asset")]
        public Item RemoteRadarDef { get; private set; } = null!;
    }

    public class PouchyBeltAssets(string bundleName) : AssetBundleLoader<PouchyBeltAssets>(bundleName)
    {
        [LoadFromBundle("PouchDef.asset")]
        public Item PouchyBeltDef { get; private set; } = null!;
    }

    public class HackingToolAssets(string bundleName) : AssetBundleLoader<HackingToolAssets>(bundleName)
    {
        [LoadFromBundle("HackingToolDef.asset")]
        public Item HackingToolDef { get; private set; } = null!;
    }

    public class PingerAssets(string bundleName) : AssetBundleLoader<PingerAssets>(bundleName)
    {
        [LoadFromBundle("PingToolDef.asset")]
        public Item PingerDef { get; private set; } = null!;
    }

    public ArsonPlushieAssets ArsonPlushie { get; private set; } = null!;
    public CookieFumoAssets CookieFumo { get; private set; } = null!;
    public ToimariPlushieAssets ToimariPlushie { get; private set; } = null!;
    public HamisPlushieAssets HamisPlushie { get; private set; } = null!;
    public MaxwellAssets Maxwell { get; private set; } = null!;
    public GlizzyAssets Glizzy { get; private set; } = null!;
    public RevolverAssets Revolver { get; private set; } = null!;
    public GremlinEnergyAssets GremlinEnergy { get; private set; } = null!;
    public ToyHammerAssets ToyHammer { get; private set; } = null!;
    public GnarpyPlushieAssets GnarpyPlushie { get; private set; } = null!;

    public RocketLauncherAssets RocketLauncher { get; private set; } = null!;
    public FlaregunAssets Flaregun { get; private set; } = null!;
    public RemoteRadarAssets RemoteRadar { get; private set; } = null!;
    public PouchyBeltAssets PouchyBelt { get; private set; } = null!;
    public HackingToolAssets HackingTool { get; private set; } = null!;
    public PingerAssets Pinger { get; private set; } = null!;
    public ItemHandler()
    {
        if (Plugin.ModConfig.ConfigArsonPlushieEnabled.Value) RegisterArsonPlushie();
        if (Plugin.ModConfig.ConfigCookieFumoEnabled.Value) RegisterCookieFumo();
        if (Plugin.ModConfig.ConfigToimariPlushieEnabled.Value) RegisterToimariPlushie();
        if (Plugin.ModConfig.ConfigHamisPlushieEnabled.Value) RegisterHamisPlushie();
        if (Plugin.ModConfig.ConfigMaxwellEnabled.Value) RegisterMaxwell();
        if (Plugin.ModConfig.ConfigGlizzyEnabled.Value) RegisterGlizzy();
        if (Plugin.ModConfig.ConfigRevolverEnabled.Value) RegisterRevolver();
        if (Plugin.ModConfig.ConfigGremlinEnergyEnabled.Value) RegisterGremlinEnergy();
        if (Plugin.ModConfig.ConfigToyHammerEnabled.Value) RegisterToyHammer();
        if (Plugin.ModConfig.ConfigGnarpyPlushieEnabled.Value) RegisterGnarpyPlushie();
        if (Plugin.ModConfig.ConfigRocketLauncherEnabled.Value) RegisterRocketLauncher();
        if (Plugin.ModConfig.ConfigFlaregunEnabled.Value) RegisterFlaregun();
        if (Plugin.ModConfig.ConfigRemoteRadarEnabled.Value) RegisterRemoteRadar();
        if (Plugin.ModConfig.ConfigPouchyBeltEnabled.Value) RegisterPouchyBelt();
        if (Plugin.ModConfig.ConfigHackingToolEnabled.Value) RegisterHackingTool();
        if (Plugin.ModConfig.ConfigPingerEnabled.Value) RegisterPinger();
    }

    private void RegisterArsonPlushie()
    {
        ArsonPlushie = new ArsonPlushieAssets("arsonplushieassets");
        int[] scrapValues1 = ChangeItemValues(Plugin.ModConfig.ConfigArsonPlushieWorth.Value);
        RegisterScrapWithConfig(Plugin.ModConfig.ConfigArsonPlushieSpawnWeight.Value, ArsonPlushie.ArsonPlushieDef, scrapValues1[0], scrapValues1[1]);
    }

    private void RegisterCookieFumo()
    {
        CookieFumo = new CookieFumoAssets("cookiefumoassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigCookieFumoWorth.Value);
        RegisterScrapWithConfig(Plugin.ModConfig.ConfigCookieFumoSpawnWeight.Value, CookieFumo.CookieFumoDef, scrapValues[0], scrapValues[1]);
    }


    private void RegisterToimariPlushie()
    {
        ToimariPlushie = new ToimariPlushieAssets("toimariplushieassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigToimariPlushieWorth.Value);
        RegisterScrapWithConfig(Plugin.ModConfig.ConfigToimariPlushieSpawnWeight.Value, ToimariPlushie.ToimariPlushieDef, scrapValues[0], scrapValues[1]);
    }

    private void RegisterHamisPlushie()
    {
        HamisPlushie = new HamisPlushieAssets("hamisplushieassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigHamisPlushieWorth.Value);
        RegisterScrapWithConfig(Plugin.ModConfig.ConfigHamisPlushieSpawnWeight.Value, HamisPlushie.HamisPlushieDef, scrapValues[0], scrapValues[1]);
    }

    private void RegisterMaxwell()
    {
        Maxwell = new MaxwellAssets("maxwellassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigMaxwellWorth.Value);
        RegisterScrapWithConfig(Plugin.ModConfig.ConfigMaxwellSpawnWeight.Value, Maxwell.MaxwellDef, scrapValues[0], scrapValues[1]);
    }

    private void RegisterGlizzy()
    {
        Glizzy = new GlizzyAssets("glizzyassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigGlizzyWorth.Value);
        RegisterScrapWithConfig(Plugin.ModConfig.ConfigGlizzySpawnWeight.Value, Glizzy.GlizzyDef, scrapValues[0], scrapValues[1]);
    }

    private void RegisterRevolver()
    {
        Revolver = new RevolverAssets("revolverassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigRevolverWorth.Value);
        RegisterScrapWithConfig(Plugin.ModConfig.ConfigRevolverSpawnWeight.Value, Revolver.RevolverDef, scrapValues[0], scrapValues[1]);
    }

    private void RegisterGremlinEnergy()
    {
        GremlinEnergy = new GremlinEnergyAssets("greminenergyassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigGremlinEnergyWorth.Value);
        RegisterScrapWithConfig(Plugin.ModConfig.ConfigGremlinEnergySpawnWeight.Value, GremlinEnergy.GremlinEnergyDef, scrapValues[0], scrapValues[1]);
    }

    private void RegisterGnarpyPlushie()
    {
        GnarpyPlushie = new GnarpyPlushieAssets("gnarpyplushieassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigGnarpyPlushieWorth.Value);
        RegisterScrapWithConfig(Plugin.ModConfig.ConfigGnarpyPlushieSpawnWeight.Value, GnarpyPlushie.GnarpyPlushieDef, scrapValues[0], scrapValues[1]);
    }

    private void RegisterToyHammer()
    {
        ToyHammer = new ToyHammerAssets("toyhammerassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigToyHammerWorth.Value);
        RegisterScrapWithConfig(Plugin.ModConfig.ConfigToyHammerSpawnWeight.Value, ToyHammer.ToyHammerDef, scrapValues[0], scrapValues[1]);
    }

    private void RegisterRocketLauncher()
    {
        RocketLauncher = new RocketLauncherAssets("rocketlauncherassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigRocketLauncherWorth.Value);
        RegisterShopItemWithConfig(Plugin.ModConfig.ConfigRocketLauncherScrapEnabled.Value, RocketLauncher.RocketLauncherDef, null, Plugin.ModConfig.ConfigRocketLauncherCost.Value, Plugin.ModConfig.ConfigRocketLauncherSpawnWeight.Value, scrapValues[0], scrapValues[1]);
    }

    private void RegisterFlaregun()
    {
        Flaregun = new FlaregunAssets("flaregunassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigFlaregunWorth.Value);
        RegisterShopItemWithConfig(Plugin.ModConfig.ConfigFlaregunScrapEnabled.Value, Flaregun.FlaregunDef, null, Plugin.ModConfig.ConfigFlaregunCost.Value, Plugin.ModConfig.ConfigFlaregunSpawnWeight.Value, scrapValues[0], scrapValues[1]);
    }

    private void RegisterRemoteRadar()
    {
        RemoteRadar = new RemoteRadarAssets("remoteradarassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigRemoteRadarWorth.Value);
        RegisterShopItemWithConfig(Plugin.ModConfig.ConfigRemoteRadarScrapEnabled.Value, RemoteRadar.RemoteRadarDef, null, Plugin.ModConfig.ConfigRemoteRadarCost.Value, Plugin.ModConfig.ConfigRemoteRadarSpawnWeight.Value, scrapValues[0], scrapValues[1]);
    }

    private void RegisterPouchyBelt()
    {
        PouchyBelt = new PouchyBeltAssets("pouchybeltassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigPouchyBeltWorth.Value);
        RegisterShopItemWithConfig(Plugin.ModConfig.ConfigPouchyBeltScrapEnabled.Value, PouchyBelt.PouchyBeltDef, null, Plugin.ModConfig.ConfigPouchyBeltCost.Value, Plugin.ModConfig.ConfigPouchyBeltSpawnWeight.Value, scrapValues[0], scrapValues[1]);
    }

    private void RegisterHackingTool()
    {
        HackingTool = new HackingToolAssets("hackingtoolassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigHackingToolWorth.Value);
        RegisterShopItemWithConfig(Plugin.ModConfig.ConfigHackingToolScrapEnabled.Value, HackingTool.HackingToolDef, null, Plugin.ModConfig.ConfigHackingToolCost.Value, Plugin.ModConfig.ConfigHackingToolSpawnWeight.Value, scrapValues[0], scrapValues[1]);
    }

    private void RegisterPinger()
    {
        Pinger = new PingerAssets("pingerassets");
        int[] scrapValues = ChangeItemValues(Plugin.ModConfig.ConfigPingerWorth.Value);
        RegisterShopItemWithConfig(Plugin.ModConfig.ConfigPingerScrapEnabled.Value, Pinger.PingerDef, null, Plugin.ModConfig.ConfigPingerCost.Value, Plugin.ModConfig.ConfigPingerSpawnWeight.Value, scrapValues[0], scrapValues[1]);
    }
}