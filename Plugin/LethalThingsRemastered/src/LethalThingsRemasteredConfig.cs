using System.Collections.Generic;
using System.Reflection;
using BepInEx.Configuration;

namespace LethalThingsRemastered.src;
public class LethalThingsRemasteredConfig
{
    #region Enables/Disables
    public ConfigEntry<bool> ConfigBoombaEnabled { get; private set; }
    public ConfigEntry<bool> ConfigMaggieEnabled { get; private set; }
    public ConfigEntry<bool> ConfigCrystalRayEnabled { get; private set; }
    public ConfigEntry<bool> ConfigTeleporterTrapEnabled { get; private set; }
    public ConfigEntry<bool> ConfigArsonPlushieEnabled { get; private set; }
    public ConfigEntry<bool> ConfigCookieFumoEnabled { get; private set; }
    public ConfigEntry<bool> ConfigToimariPlushieEnabled { get; private set; }
    public ConfigEntry<bool> ConfigHamisPlushieEnabled { get; private set; }
    public ConfigEntry<bool> ConfigMaxwellEnabled { get; private set; }
    public ConfigEntry<bool> ConfigGlizzyEnabled { get; private set; }
    public ConfigEntry<bool> ConfigRevolverEnabled { get; private set; }
    public ConfigEntry<bool> ConfigGremlinEnergyEnabled { get; private set; }
    public ConfigEntry<bool> ConfigToyHammerEnabled { get; private set; }
    public ConfigEntry<bool> ConfigGnarpyPlushieEnabled { get; private set; }
    public ConfigEntry<bool> ConfigRocketLauncherEnabled { get; private set; }
    public ConfigEntry<bool> ConfigRocketLauncherScrapEnabled { get; private set; }
    public ConfigEntry<bool> ConfigFlaregunEnabled { get; private set; }
    public ConfigEntry<bool> ConfigFlaregunScrapEnabled { get; private set; }
    public ConfigEntry<bool> ConfigRemoteRadarEnabled { get; private set; }
    public ConfigEntry<bool> ConfigRemoteRadarScrapEnabled { get; private set; }
    public ConfigEntry<bool> ConfigPouchyBeltEnabled { get; private set; }
    public ConfigEntry<bool> ConfigPouchyBeltScrapEnabled { get; private set; }
    public ConfigEntry<bool> ConfigHackingToolEnabled { get; private set; }
    public ConfigEntry<bool> ConfigHackingToolScrapEnabled { get; private set; }
    public ConfigEntry<bool> ConfigPingerEnabled { get; private set; }
    public ConfigEntry<bool> ConfigPingerScrapEnabled { get; private set; }
    public ConfigEntry<bool> ConfigSmallRugEnabled { get; private set; }
    public ConfigEntry<bool> ConfigLargeRugEnabled { get; private set; }
    public ConfigEntry<bool> ConfigFatalitiesSignEnabled { get; private set; }
    public ConfigEntry<bool> ConfigDartboardEnabled { get; private set; }
    public ConfigEntry<bool> ConfigDeliveryRoverEnabled { get; private set; }

    #endregion
    #region Spawn Weights
    public ConfigEntry<string> ConfigBoombaSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigMaggieSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigCrystalRaySpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigTeleporterTrapCurveSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigArsonPlushieSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigCookieFumoSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigToimariPlushieSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigHamisPlushieSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigMaxwellSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigGlizzySpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigRevolverSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigGremlinEnergySpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigToyHammerSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigGnarpyPlushieSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigRocketLauncherSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigFlaregunSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigRemoteRadarSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigPouchyBeltSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigHackingToolSpawnWeight { get; private set; }
    public ConfigEntry<string> ConfigPingerSpawnWeight { get; private set; }
    #endregion
    #region Misc
    public ConfigEntry<int> ConfigBoombaPowerLevel { get; private set; }
    public ConfigEntry<int> ConfigBoombaMaxSpawnCount { get; private set; }
    public ConfigEntry<int> ConfigMaggiePowerLevel { get; private set; }
    public ConfigEntry<int> ConfigMaggieMaxSpawnCount { get; private set; }
    public ConfigEntry<int> ConfigCrystalRayPowerLevel { get; private set; }
    public ConfigEntry<int> ConfigCrystalRayMaxSpawnCount { get; private set; }
    public ConfigEntry<int> ConfigRocketLauncherCost { get; private set; }
    public ConfigEntry<int> ConfigFlaregunCost { get; private set; }
    public ConfigEntry<int> ConfigRemoteRadarCost { get; private set; }
    public ConfigEntry<int> ConfigPouchyBeltCost { get; private set; }
    public ConfigEntry<int> ConfigHackingToolCost { get; private set; }
    public ConfigEntry<int> ConfigPingerCost { get; private set; }
    public ConfigEntry<int> ConfigSmallRugCost { get; private set; }
    public ConfigEntry<int> ConfigLargeRugCost { get; private set; }
    public ConfigEntry<int> ConfigFatalitiesSignCost { get; private set; }
    public ConfigEntry<int> ConfigDartboardCost { get; private set; }
    public ConfigEntry<int> ConfigDeliveryRoverCost { get; private set; }

    #endregion 
    #region Value
    public ConfigEntry<string> ConfigArsonPlushieWorth { get; private set; }
    public ConfigEntry<string> ConfigCookieFumoWorth { get; private set; }
    public ConfigEntry<string> ConfigToimariPlushieWorth { get; private set; }
    public ConfigEntry<string> ConfigHamisPlushieWorth { get; private set; }
    public ConfigEntry<string> ConfigMaxwellWorth { get; private set; }
    public ConfigEntry<string> ConfigGlizzyWorth { get; private set; }
    public ConfigEntry<string> ConfigRevolverWorth { get; private set; }
    public ConfigEntry<string> ConfigGremlinEnergyWorth { get; private set; }
    public ConfigEntry<string> ConfigToyHammerWorth { get; private set; }
    public ConfigEntry<string> ConfigGnarpyPlushieWorth { get; private set; }
    public ConfigEntry<string> ConfigRocketLauncherWorth { get; private set; }
    public ConfigEntry<string> ConfigFlaregunWorth { get; private set; }
    public ConfigEntry<string> ConfigRemoteRadarWorth { get; private set; }
    public ConfigEntry<string> ConfigPouchyBeltWorth { get; private set; }
    public ConfigEntry<string> ConfigHackingToolWorth { get; private set; }
    public ConfigEntry<string> ConfigPingerWorth { get; private set; }

    #endregion
    #region Debug
    public ConfigEntry<bool> ConfigDebugMode { get; private set; }
    public ConfigEntry<bool> ConfigEnableExtendedLogging { get; private set; }
    #endregion
    public LethalThingsRemasteredConfig(ConfigFile configFile)
    {
        configFile.SaveOnConfigSet = false;

        #region Debug
        ConfigDebugMode = configFile.Bind("Debug Options",
                                            "Debug Mode | Hazard Spawning Enabled",
                                            false,
                                            "Whether debug mode is enabled (for hazard spawning stuff).");
        ConfigEnableExtendedLogging = configFile.Bind("Debug Options",
                                            "Debug Mode | Enable Extended Logging",
                                            false,
                                            "Whether extended logging is enabled.");
        #endregion

        #region Boomba
        ConfigBoombaEnabled = configFile.Bind("Boomba Enemy",
                                            "Boomba | Enabled",
                                            true,
                                            "Whether Boomba is enabled.");
        ConfigBoombaSpawnWeight = configFile.Bind("Boomba Enemy",
                                            "Boomba | Spawn Weight",
                                            "Vanilla:20,Custom:20",
                                            "The MoonName:spawnweight for Boombas.");
        ConfigBoombaPowerLevel = configFile.Bind("Boomba Enemy",
                                            "Boomba | Power Level",
                                            2,
                                            "The moon's PowerLevel for Boombas.");
        ConfigBoombaMaxSpawnCount = configFile.Bind("Boomba Enemy",
                                            "Boomba | Max Spawn Count",
                                            3,
                                            "The maximum number of Boombas to spawn.");
        
        #endregion

        #region Maggie
        ConfigMaggieEnabled = configFile.Bind("Maggie Enemy",
                                            "Maggie | Enabled",
                                            true,
                                            "Whether Maggie is enabled.");
        ConfigMaggiePowerLevel = configFile.Bind("Maggie Enemy",
                                            "Maggie | Power Level",
                                            2,
                                            "The moon's PowerLevel for Maggies.");
        ConfigMaggieMaxSpawnCount = configFile.Bind("Maggie Enemy",
                                            "Maggie | Max Spawn Count",
                                            3,
                                            "The maximum number of Maggies to spawn.");
        #endregion

        #region Crystal Ray
        ConfigCrystalRayEnabled = configFile.Bind("Crystal Ray Enemy",
                                            "Crystal Ray | Enabled",
                                            true,
                                            "Whether Crystal Ray is enabled.");
        ConfigCrystalRayPowerLevel = configFile.Bind("Crystal Ray Enemy",
                                            "Crystal Ray | Power Level",
                                            2,
                                            "The moon's PowerLevel for CrystalRays.");
        ConfigCrystalRayMaxSpawnCount = configFile.Bind("Crystal Ray Enemy",
                                            "Crystal Ray | Max Spawn Count",
                                            3,
                                            "The maximum number of CrystalRays to spawn.");
        #endregion
        
        #region Teleporter Trap
        ConfigTeleporterTrapEnabled = configFile.Bind("Teleporter Trap",
                                            "Teleporter Trap | Enabled",
                                            true,
                                            "Whether Teleporter Trap is enabled.");
        ConfigTeleporterTrapCurveSpawnWeight = configFile.Bind("Teleporter Trap",
                                            "Teleporter Trap | Curve Spawn Weight",
                                            "Vanilla - 0.00,0.00 ; 0.11,3.20 ; 0.22,6.14 ; 0.33,8.87 ; 0.44,10.89 ; 0.56,11.51 ; 0.67,11.39 ; 0.78,11.12 ; 0.89,12.04 ; 1.00,18.00 | Custom - 0.00,0.00 ; 0.11,3.20 ; 0.22,6.14 ; 0.33,8.87 ; 0.44,10.89 ; 0.56,11.51 ; 0.67,11.39 ; 0.78,11.12 ; 0.89,12.04 ; 1.00,18.00",
                                            "The MoonName - CurveSpawnWeight for the Teleporter Trap.");
        #endregion

        #region Arson Plushie
        ConfigArsonPlushieEnabled = configFile.Bind("Arson Plushie",
                                            "Arson Plushie | Enabled",
                                            true,
                                            "Whether Arson Plushie is enabled.");
        ConfigArsonPlushieSpawnWeight = configFile.Bind("Arson Plushie",
                                            "Arson Plushie | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Arson Plushies.");
        ConfigArsonPlushieWorth = configFile.Bind("Arson Plushie",
                                            "Arson Plushie | Worth",
                                            "-1,-1",
                                            "The min,max value of the Arson Plushie (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Cookie Fumo
        ConfigCookieFumoEnabled = configFile.Bind("Cookie Fumo",
                                            "Cookie Fumo | Enabled",
                                            true,
                                            "Whether Cookie Fumo is enabled.");
        ConfigCookieFumoSpawnWeight = configFile.Bind("Cookie Fumo",
                                            "Cookie Fumo | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Cookie Fumos.");
        ConfigCookieFumoWorth = configFile.Bind("Cookie Fumo",
                                            "Cookie Fumo | Worth",
                                            "-1,-1",
                                            "The min,max value of the Cookie Fumo (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Toimari Plushie
        ConfigToimariPlushieEnabled = configFile.Bind("Toimari Plushie",
                                            "Toimari Plushie | Enabled",
                                            true,
                                            "Whether Toimari Plushie is enabled.");
        ConfigToimariPlushieSpawnWeight = configFile.Bind("Toimari Plushie",
                                            "Toimari Plushie | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Toimari Plushies.");
        ConfigToimariPlushieWorth = configFile.Bind("Toimari Plushie",
                                            "Toimari Plushie | Worth",
                                            "-1,-1",
                                            "The min,max value of the Toimari Plushie (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Hamis Plushie
        ConfigHamisPlushieEnabled = configFile.Bind("Hamis Plushie",
                                            "Hamis Plushie| Enabled",
                                            true,
                                            "Whether Hamis Plushie is enabled.");
        ConfigHamisPlushieSpawnWeight = configFile.Bind("Hamis Plushie",
                                            "Hamis Plushie | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Hamis Plushies.");
        ConfigHamisPlushieWorth = configFile.Bind("Hamis Plushie",
                                            "Hamis Plushie | Worth",
                                            "-1,-1",
                                            "The min,max value of the Hamis Plushie (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Maxwell
        ConfigMaxwellEnabled = configFile.Bind("Maxwell",
                                            "Maxwell | Enabled",
                                            true,
                                            "Whether Maxwell is enabled.");
        ConfigMaxwellSpawnWeight = configFile.Bind("Maxwell",
                                            "Maxwell | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Maxwells.");
        ConfigMaxwellWorth = configFile.Bind("Maxwell",
                                            "Maxwell | Worth",
                                            "-1,-1",
                                            "The min,max value of the Maxwell (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Glizzy
        ConfigGlizzyEnabled = configFile.Bind("Glizzy",
                                            "Glizzy | Enabled",
                                            true,
                                            "Whether Glizzy is enabled.");
        ConfigGlizzySpawnWeight = configFile.Bind("Glizzy",
                                            "Glizzy | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Glizzies.");
        ConfigGlizzyWorth = configFile.Bind("Glizzy",
                                            "Glizzy | Worth",
                                            "-1,-1",
                                            "The min,max value of the Glizzy (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Revolver
        ConfigRevolverEnabled = configFile.Bind("Revolver",
                                            "Revolver | Enabled",
                                            true,
                                            "Whether Revolver is enabled.");
        ConfigRevolverSpawnWeight = configFile.Bind("Revolver",
                                            "Revolver | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Revolvers.");
        ConfigRevolverWorth = configFile.Bind("Revolver",
                                            "Revolver | Worth",
                                            "-1,-1",
                                            "The min,max value of the Revolver (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Gremlin Energy
        ConfigGremlinEnergyEnabled = configFile.Bind("Gremlin Energy",
                                            "Gremlin Energy | Enabled",
                                            true,
                                            "Whether Gremlin Energy is enabled.");
        ConfigGremlinEnergySpawnWeight = configFile.Bind("Gremlin Energy",
                                            "Gremlin Energy | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Gremlin Energies.");
        ConfigGremlinEnergyWorth = configFile.Bind("Gremlin Energy",
                                            "Gremlin Energy | Worth",
                                            "-1,-1",
                                            "The min,max value of the Gremlin Energy (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Toy Hammer
        ConfigToyHammerEnabled = configFile.Bind("Toy Hammer",
                                            "Toy Hammer | Enabled",
                                            true,
                                            "Whether Toy Hammer is enabled.");
        ConfigToyHammerSpawnWeight = configFile.Bind("Toy Hammer",
                                            "Toy Hammer | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Toy Hammers.");
        ConfigToyHammerWorth = configFile.Bind("Toy Hammer",
                                            "Toy Hammer | Worth",
                                            "-1,-1",
                                            "The min,max value of the Toy Hammer (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Gnarpy Plushie
        ConfigGnarpyPlushieEnabled = configFile.Bind("Gnarpy Plushie",
                                            "Gnarpy Plushie | Enabled",
                                            true,
                                            "Whether Gnarpy Plushie is enabled.");
        ConfigGnarpyPlushieSpawnWeight = configFile.Bind("Gnarpy Plushie",
                                            "Gnarpy Plushie | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Gnarpy Plushies.");
        ConfigGnarpyPlushieWorth = configFile.Bind("Gnarpy Plushie",
                                            "Gnarpy Plushie | Worth",
                                            "-1,-1",
                                            "The min,max value of the Gnarpy Plushie (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Rocket Launcher
        ConfigRocketLauncherEnabled = configFile.Bind("Rocket Launcher",
                                            "Rocket Launcher | Enabled",
                                            true,
                                            "Whether Rocket Launcher is enabled.");
        ConfigRocketLauncherCost = configFile.Bind("Rocket Launcher",
                                            "Rocket Launcher | Cost",
                                            200,
                                            "The cost of the Rocket Launcher.");
        ConfigRocketLauncherScrapEnabled = configFile.Bind("Rocket Launcher",
                                            "Rocket Launcher | Scrap Enabled",
                                            false,
                                            "Whether Rocket Launcher Scrap is enabled.");
        ConfigRocketLauncherSpawnWeight = configFile.Bind("Rocket Launcher",
                                            "Rocket Launcher | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Rocket Launchers.");
        ConfigRocketLauncherWorth = configFile.Bind("Rocket Launcher",
                                            "Rocket Launcher | Worth",
                                            "-1,-1",
                                            "The min,max value of the Rocket Launcher (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Flaregun
        ConfigFlaregunEnabled = configFile.Bind("Flaregun",
                                            "Flaregun | Enabled",
                                            true,
                                            "Whether Flaregun is enabled.");
        ConfigFlaregunCost = configFile.Bind("Flaregun",
                                            "Flaregun | Cost",
                                            200,
                                            "The cost of the Flaregun.");
        ConfigFlaregunScrapEnabled = configFile.Bind("Flaregun",
                                            "Flaregun | Scrap Enabled",
                                            false,
                                            "Whether Flaregun Scrap is enabled.");
        ConfigFlaregunSpawnWeight = configFile.Bind("Flaregun",
                                            "Flaregun | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Flareguns.");
        ConfigFlaregunWorth = configFile.Bind("Flaregun",
                                            "Flaregun | Worth",
                                            "-1,-1",
                                            "The min,max value of the Flaregun (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Remote Radar
        ConfigRemoteRadarEnabled = configFile.Bind("Remote Radar",
                                            "Remote Radar | Enabled",
                                            true,
                                            "Whether Remote Radar is enabled.");
        ConfigRemoteRadarCost = configFile.Bind("Remote Radar",
                                            "Remote Radar | Cost",
                                            200,
                                            "The cost of the Remote Radar.");
        ConfigRemoteRadarScrapEnabled = configFile.Bind("Remote Radar",
                                            "Remote Radar | Scrap Enabled",
                                            false,
                                            "Whether Remote Radar Scrap is enabled.");
        ConfigRemoteRadarSpawnWeight = configFile.Bind("Remote Radar",
                                            "Remote Radar | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Remote Radars.");
        ConfigRemoteRadarWorth = configFile.Bind("Remote Radar",
                                            "Remote Radar | Worth",
                                            "-1,-1",
                                            "The min,max value of the Remote Radar (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Pouchy Belt
        ConfigPouchyBeltEnabled = configFile.Bind("Pouchy Belt",
                                            "Pouchy Belt | Enabled",
                                            true,
                                            "Whether Pouchy Belt is enabled.");
        ConfigPouchyBeltCost = configFile.Bind("Pouchy Belt",
                                            "Pouchy Belt | Cost",
                                            200,
                                            "The cost of the Pouchy Belt.");
        ConfigPouchyBeltScrapEnabled = configFile.Bind("Pouchy Belt",
                                            "Pouchy Belt | Scrap Enabled",
                                            false,
                                            "Whether Pouchy Belt Scrap is enabled.");
        ConfigPouchyBeltSpawnWeight = configFile.Bind("Pouchy Belt",
                                            "Pouchy Belt | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Pouchy Belts.");
        ConfigPouchyBeltWorth = configFile.Bind("Pouchy Belt",
                                            "Pouchy Belt | Worth",
                                            "-1,-1",
                                            "The min,max value of the Pouchy Belt (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Hacking Tool
        ConfigHackingToolEnabled = configFile.Bind("Hacking Tool",
                                            "Hacking Tool | Enabled",
                                            true,
                                            "Whether Hacking Tool is enabled.");
        ConfigHackingToolCost = configFile.Bind("Hacking Tool",
                                            "Hacking Tool | Cost",
                                            200,
                                            "The cost of the Hacking Tool.");
        ConfigHackingToolScrapEnabled = configFile.Bind("Hacking Tool",
                                            "Hacking Tool | Scrap Enabled",
                                            false,
                                            "Whether Hacking Tool Scrap is enabled.");
        ConfigHackingToolSpawnWeight = configFile.Bind("Hacking Tool",
                                            "Hacking Tool | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Hacking Tools.");
        ConfigHackingToolWorth = configFile.Bind("Hacking Tool",
                                            "Hacking Tool | Worth",
                                            "-1,-1",
                                            "The min,max value of the Hacking Tool (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion

        #region Pinger
        ConfigPingerEnabled = configFile.Bind("Pinger",
                                            "Pinger | Enabled",
                                            true,
                                            "Whether Pinger is enabled.");
        ConfigPingerCost = configFile.Bind("Pinger",
                                            "Pinger | Cost",
                                            200,
                                            "The cost of the Pinger.");
        ConfigPingerScrapEnabled = configFile.Bind("Pinger",
                                            "Pinger | Scrap Enabled",
                                            false,
                                            "Whether Pinger Scrap is enabled.");
        ConfigPingerSpawnWeight = configFile.Bind("Pinger",
                                            "Pinger | Spawn Weight",
                                            "Vanilla:10,Custom:10",
                                            "The MoonName:spawnweight for Pingers.");
        ConfigPingerWorth = configFile.Bind("Pinger",
                                            "Pinger | Worth",
                                            "-1,-1",
                                            "The min,max value of the Pinger (multiplied by 0.4), leave at a default of -1 to not affect the value.");
        #endregion
        #region Small Rug
        ConfigSmallRugEnabled = configFile.Bind("Small Rug",
                                            "Small Rug | Enabled",
                                            true,
                                            "Whether Small Rug is enabled.");
        ConfigSmallRugCost = configFile.Bind("Small Rug",
                                            "Small Rug | Cost",
                                            20,
                                            "The cost of the Small Rug.");
        #endregion
        
        #region Large Rug
        ConfigLargeRugEnabled = configFile.Bind("Large Rug",
                                            "Large Rug | Enabled",
                                            true,
                                            "Whether Large Rug is enabled.");
        ConfigLargeRugCost = configFile.Bind("Large Rug",
                                            "Large Rug | Cost",
                                            100,
                                            "The cost of the Large Rug.");
        #endregion

        #region Fatalities Sign
        ConfigFatalitiesSignEnabled = configFile.Bind("Fatalities Sign",
                                            "Fatalities Sign | Enabled",
                                            true,
                                            "Whether Fatalities Sign is enabled.");
        ConfigFatalitiesSignCost = configFile.Bind("Fatalities Sign",
                                            "Fatalities Sign | Cost",
                                            200,
                                            "The cost of the Fatalities Sign.");
        #endregion

        #region Dartboard
        ConfigDartboardEnabled = configFile.Bind("Dartboard",
                                            "Dartboard | Enabled",
                                            true,
                                            "Whether Dartboard is enabled.");
        ConfigDartboardCost = configFile.Bind("Dartboard",
                                            "Dartboard | Cost",
                                            200,
                                            "The cost of the Dartboard.");
        #endregion

        #region Delivery Rover
        ConfigDeliveryRoverEnabled = configFile.Bind("Delivery Rover",
                                            "Delivery Rover | Enabled",
                                            true,
                                            "Whether Delivery Rover is enabled.");
        ConfigDeliveryRoverCost = configFile.Bind("Delivery Rover",
                                            "Delivery Rover | Cost",
                                            999,
                                            "The cost of the Delivery Rover.");
        #endregion

        configFile.SaveOnConfigSet = true;
        ClearUnusedEntries(configFile);
    }

    private void ClearUnusedEntries(ConfigFile configFile)
    {
        // Normally, old unused config entries don't get removed, so we do it with this piece of code. Credit to Kittenji.
        PropertyInfo orphanedEntriesProp = configFile.GetType().GetProperty("OrphanedEntries", BindingFlags.NonPublic | BindingFlags.Instance);
        var orphanedEntries = (Dictionary<ConfigDefinition, string>)orphanedEntriesProp.GetValue(configFile, null);
        orphanedEntries.Clear(); // Clear orphaned entries (Unbinded/Abandoned entries)
        configFile.Save(); // Save the config file to save these changes
    }
}