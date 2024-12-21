﻿using System.Collections.Generic;
using LethalThingsRemastered.src.Util;
using LethalThingsRemastered.src.Util.AssetLoading;
using UnityEngine;

namespace LethalThingsRemastered.src.Content.Maps;
public class MapObjectHandler : ContentHandler<MapObjectHandler>
{
	public static List<GameObject> hazardPrefabs = new List<GameObject>();

	public class TeleporterTrapAssets(string bundleName) : AssetBundleLoader<TeleporterTrapAssets>(bundleName)
	{
		[LoadFromBundle("TeleporterTrap.prefab")]
		public GameObject TeleporterTrapPrefab { get; private set; } = null!;
	}

	public TeleporterTrapAssets TeleporterTrap { get; private set; } = null!;

    public MapObjectHandler()
	{
		if (Plugin.ModConfig.ConfigTeleporterTrapEnabled.Value) RegisterTeleporterTrap();
	}

	private void RegisterTeleporterTrap()
	{
		TeleporterTrap = new TeleporterTrapAssets("TeleporterTrap");
		hazardPrefabs.Add(TeleporterTrap.TeleporterTrapPrefab);
		RegisterInsideMapObjectWithConfig(TeleporterTrap.TeleporterTrapPrefab, Plugin.ModConfig.ConfigTeleporterTrapCurveSpawnWeight.Value);
	}
}