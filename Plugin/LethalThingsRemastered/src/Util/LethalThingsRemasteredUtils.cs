using System;
using System.Collections;
using Unity.Netcode;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine.AI;
using LethalThingsRemastered.src.Content;
using LethalThingsRemastered.src.Util.Extensions;
using LethalThingsRemastered.src.Content.Maps;

namespace LethalThingsRemastered.src.Util;
internal class LethalThingsRemasteredUtils : NetworkBehaviour
{
    [NonSerialized] public static List<EnemyType> EnemyTypes = new();
    private static System.Random random = new();
    internal static LethalThingsRemasteredUtils Instance { get; private set; } = null!;

    private void Awake()
    {
        Instance = this;
    }

    [ServerRpc(RequireOwnership = false)]
    public void SpawnHazardServerRpc(Vector3 position)
    {
        // Get a random prefab to spawn from the hazard prefabs list
        GameObject prefabToSpawn = MapObjectHandler.hazardPrefabs[0];

        // Remove the prefab from the list to prevent re-spawning it directly
        MapObjectHandler.hazardPrefabs.RemoveAt(0);

        // Get a random position on the NavMesh
        NavMeshHit hit = default;
        Vector3 positionToSpawn = RoundManager.Instance.GetRandomNavMeshPositionInRadiusSpherical(position, 2f, hit);

        // Instantiate a new instance of the prefab
        GameObject spawnedObject = GameObject.Instantiate(prefabToSpawn, positionToSpawn, Quaternion.identity);
        
        // Align the object's up direction with the hit normal
        spawnedObject.transform.up = hit.normal;

        // Get the NetworkObject component and spawn it on the network
        NetworkObject networkObject = spawnedObject.GetComponent<NetworkObject>();
        if (networkObject != null)
        {
            networkObject.Spawn();
        }
        
        // Optionally, you can re-add the prefab back to the list if needed
        MapObjectHandler.hazardPrefabs.Add(prefabToSpawn);
    }

    [ServerRpc(RequireOwnership = false)]
    public void SpawnEnemyServerRpc(Vector3 position, string enemyName)
    {
        if (position == Vector3.zero)
        {
            Plugin.Logger.LogError("Trying to spawn an enemy at Vector3.zero!");
            return;
        }

        foreach (EnemyType enemyType in EnemyTypes)
        {
            Plugin.ExtendedLogging("Trying to spawn: " + enemyType.enemyName);
            if (enemyType.enemyName == enemyName)
            {
                RoundManager.Instance.SpawnEnemyGameObject(position, -1, 0, enemyType);
                return;
            }
        }
        Plugin.Logger.LogError($"Couldn't find enemy of name '{enemyName}'!");
    }

    [ServerRpc(RequireOwnership = false)]
    public void SpawnScrapServerRpc(string itemName, Vector3 position, bool defaultRotation, int valueIncrease)
    {
        if (itemName == string.Empty)
        {
            return;
        }
        Plugin.samplePrefabs.TryGetValue(itemName, out Item item);
        if (item == null)
        {
            // throw for stacktrace
            Plugin.Logger.LogError($"'{itemName}' either isn't a LethalThingsRemastered scrap or not registered! This method only handles LethalThingsRemastered scrap!");
            return;
        }
        SpawnScrap(item, position, defaultRotation, valueIncrease);
    }

    public NetworkObjectReference SpawnScrap(Item item, Vector3 position, bool defaultRotation, int valueIncrease)
    {
        if (StartOfRound.Instance == null)
        {
            return default;
        }
        
        random ??= new System.Random(StartOfRound.Instance.randomMapSeed + 85);

        Transform? parent = null;
        if (parent == null)
        {
            parent = StartOfRound.Instance.propsContainer;
        }
        GameObject go = Instantiate(item.spawnPrefab, position + Vector3.up * 0.2f, defaultRotation == true ? Quaternion.Euler(item.restingRotation) : Quaternion.identity, parent);
        go.GetComponent<NetworkObject>().Spawn();
        int value = (int)(random.NextInt(item.minValue, item.maxValue) * RoundManager.Instance.scrapValueMultiplier) + valueIncrease;
        var scanNode = go.GetComponentInChildren<ScanNodeProperties>();
        scanNode.scrapValue = value;
        scanNode.subText = $"Value: ${value}";
        go.GetComponent<GrabbableObject>().scrapValue = value;
        UpdateScanNodeClientRpc(new NetworkObjectReference(go), value);
        return new NetworkObjectReference(go);
    }



    [ClientRpc]
    public void UpdateScanNodeClientRpc(NetworkObjectReference go, int value)
    {
        go.TryGet(out NetworkObject netObj);
        if(netObj != null)
        {
            if (netObj.gameObject.TryGetComponent(out GrabbableObject grabbableObject))
            {
                grabbableObject.SetScrapValue(value);
                Plugin.ExtendedLogging($"Scrap Value: {value}");
            }
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void RequestLoadSaveDataServerRPC(int playerID)
    {
        ulong steamID = StartOfRound.Instance.allPlayerScripts[playerID].playerSteamId;
        if (!LethalThingsRemasteredSave.Current.PlayerData.ContainsKey(steamID)) { LethalThingsRemasteredSave.Current.PlayerData[steamID] = new(); LethalThingsRemasteredSave.Current.Save();}
        SetSaveDataClientRPC(playerID, JsonConvert.SerializeObject(LethalThingsRemasteredSave.Current));
    }

    [ClientRpc]
    private void SetSaveDataClientRPC(int playerID, string saveData)
    {
        Plugin.ExtendedLogging("Received save data from host!");

        if (!IsHost && !IsServer)
        {
            LethalThingsRemasteredSave.Current = JsonConvert.DeserializeObject<LethalThingsRemasteredSave>(saveData, new JsonSerializerSettings{ContractResolver = new IncludePrivateSetterContractResolver()})!;
        }
    }

    public override void OnNetworkSpawn()
    {
        if (IsHost || IsServer)
        {
            LethalThingsRemasteredSave.Current = PersistentDataHandler.Load<LethalThingsRemasteredSave>($"LTRSave{GameNetworkManager.Instance.saveFileNum}");
        }
        Plugin.ExtendedLogging($"Attempting to get save data over RPC!");
        Plugin.ExtendedLogging($"LocalClientId: {NetworkManager.Singleton.LocalClientId}");
        Plugin.ExtendedLogging($"StartOfRound.Instance.ClientPlayerList: {{{string.Join(", ",StartOfRound.Instance.ClientPlayerList)}}}");

        if (!StartOfRound.Instance.ClientPlayerList.ContainsKey(NetworkManager.Singleton.LocalClientId)) {
            StartCoroutine(DelayLoadRequestRPC());
            return;
        }
        
        Plugin.ExtendedLogging("ClientPlayerList already contained the local client id, hooray :3");
        RequestLoadSaveDataServerRPC(StartOfRound.Instance.ClientPlayerList[NetworkManager.Singleton.LocalClientId]);
    }

    IEnumerator DelayLoadRequestRPC()
    {
        Plugin.Logger.LogInfo("ClientPlayerList did not contain LocalClientId, delaying save data request!");
        
        yield return new WaitUntil(() => StartOfRound.Instance.ClientPlayerList.ContainsKey(NetworkManager.Singleton.LocalClientId)); // ensure some of it has been populated ig?
        RequestLoadSaveDataServerRPC(StartOfRound.Instance.ClientPlayerList[NetworkManager.Singleton.LocalClientId]);
    }

    private void OnDisable()
    {
        LethalThingsRemasteredSave.Current = null!;
    }
}