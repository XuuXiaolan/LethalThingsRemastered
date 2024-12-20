using System;

namespace LethalThingsRemastered.src.Util.AssetLoading;

[AttributeUsage(AttributeTargets.Property)]
public class LoadFromBundleAttribute(string bundleFile) : Attribute
{
	public string BundleFile { get; private set; } = bundleFile;
}
