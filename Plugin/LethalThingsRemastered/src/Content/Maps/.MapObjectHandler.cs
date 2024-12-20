﻿using System;
using System.Collections.Generic;
using LethalLib.Extras;
using LethalLib.Modules;
using LethalThingsRemastered.src.Util;
using UnityEngine;

namespace LethalThingsRemastered.src.Content.Maps;
public class MapObjectHandler : ContentHandler<MapObjectHandler>
{
	public static List<GameObject> hazardPrefabs = new List<GameObject>();

    public MapObjectHandler()
	{
	}
}