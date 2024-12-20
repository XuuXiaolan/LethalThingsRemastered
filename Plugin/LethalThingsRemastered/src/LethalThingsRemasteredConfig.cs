using System.Collections.Generic;
using System.Reflection;
using BepInEx.Configuration;

namespace LethalThingsRemastered.src;
public class LethalThingsRemasteredConfig
{
    #region Enables/Disables
    #endregion
    #region Spawn Weights
    #endregion
    #region Misc
    #endregion 
    #region Value
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