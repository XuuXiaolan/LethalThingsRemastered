using System;
using HarmonyLib;
using LethalThingsRemastered.src.Content;
using LethalThingsRemastered.src.Util;
using LethalThingsRemastered.src.Util.Extensions;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LethalThingsRemastered.src.Patches;
static class StartOfRoundPatch
{
    public static void Init()
    {
        On.StartOfRound.Awake += StartOfRound_Awake;
        On.StartOfRound.AutoSaveShipData += StartOfRound_AutoSaveShipData;
    }

    private static void StartOfRound_Awake(On.StartOfRound.orig_Awake orig, StartOfRound self)
    {
        orig(self);
        Plugin.ExtendedLogging("StartOfRound.Awake");
		self.NetworkObject.OnSpawn(CreateNetworkManager);
    }

    private static void StartOfRound_AutoSaveShipData(On.StartOfRound.orig_AutoSaveShipData orig, StartOfRound self)
    {
        orig(self);
		if (LethalThingsRemasteredUtils.Instance.IsHost || LethalThingsRemasteredUtils.Instance.IsServer) LethalThingsRemasteredSave.Current.Save();
    }
	
	private static void CreateNetworkManager()
	{
		if (StartOfRound.Instance.IsServer || StartOfRound.Instance.IsHost)
		{
			if (LethalThingsRemasteredUtils.Instance == null)
			{
				GameObject utilsInstance = GameObject.Instantiate(Plugin.Assets.UtilsPrefab);
				SceneManager.MoveGameObjectToScene(utilsInstance, StartOfRound.Instance.gameObject.scene);
				utilsInstance.GetComponent<NetworkObject>().Spawn();
				Plugin.ExtendedLogging($"Created LethalThingsRemasteredUtils. Scene is: '{utilsInstance.scene.name}'");
			}
			else
			{
				Plugin.Logger.LogWarning("LethalThingsRemasteredUtils already exists?");
			}
		}
	}

	[HarmonyPatch(nameof(StartOfRound.ResetShip)), HarmonyPostfix]
	static void ResetSave()
	{
		LethalThingsRemasteredSave.Current = new LethalThingsRemasteredSave(LethalThingsRemasteredSave.Current.FileName);
		if(LethalThingsRemasteredUtils.Instance.IsHost || LethalThingsRemasteredUtils.Instance.IsServer) LethalThingsRemasteredSave.Current.Save();
	}
}