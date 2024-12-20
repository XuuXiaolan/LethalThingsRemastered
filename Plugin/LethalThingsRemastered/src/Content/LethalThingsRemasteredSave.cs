using System;
using System.Collections.Generic;
using LethalThingsRemastered.src.Util;

namespace LethalThingsRemastered.src.Content;

// PER HOST SAVE, VALUES ARE SYNCED FROM HOST, ONLY EDITABLE ON HOST.
class LethalThingsRemasteredSave(string fileName) : SaveableData(fileName)
{
	public static LethalThingsRemasteredSave Current = null!;


	public Dictionary<ulong, LethalThingsRemasteredLocalSave> PlayerData { get; private set; } = [];

	
	public override void Save()
	{
		EnsureHost();
		base.Save();
	}

	private void EnsureHost()
	{
		if (!LethalThingsRemasteredUtils.Instance.IsHost && !LethalThingsRemasteredUtils.Instance.IsServer) throw new InvalidOperationException("Only the host should save LethalThingsRemasteredSave.");
	}
}

// PER PLAYER
class LethalThingsRemasteredLocalSave
{

}