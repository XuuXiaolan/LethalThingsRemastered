using LethalLib.Extras;
using static LethalLib.Modules.Unlockables;
using LethalThingsRemastered.src.Util;
using LethalThingsRemastered.src.Util.AssetLoading;
using LethalLib.Modules;

namespace LethalThingsRemastered.src.Content.Unlockables;
public class UnlockableHandler : ContentHandler<UnlockableHandler>
{
	public class SmallRugAssets(string bundleName) : AssetBundleLoader<SmallRugAssets>(bundleName)
	{
		[LoadFromBundle("SmallRugUnlockable.asset")]
		public UnlockableItemDef SmallRugUnlockable { get; private set; } = null!;
	}
    
    public class LargeRugAssets(string bundleName) : AssetBundleLoader<LargeRugAssets>(bundleName)
    {
        [LoadFromBundle("LargeRugUnlockable.asset")]
        public UnlockableItemDef LargeRugUnlockable { get; private set; } = null!;
    }

    public class FatalitiesSignAssets(string bundleName) : AssetBundleLoader<FatalitiesSignAssets>(bundleName)
    {
        [LoadFromBundle("FatalitiesSignUnlockable.asset")]
        public UnlockableItemDef FatalitiesSignUnlockable { get; private set; } = null!;
    }

    public class DartboardAssets(string bundleName) : AssetBundleLoader<DartboardAssets>(bundleName)
    {
        [LoadFromBundle("DartboardUnlockable.asset")]
        public UnlockableItemDef DartboardUnlockable { get; private set; } = null!;
    }

    public class DeliveryRoverAssets(string bundleName) : AssetBundleLoader<DeliveryRoverAssets>(bundleName)
    {
        [LoadFromBundle("DeliveryRoverUnlockable.asset")]
        public UnlockableItemDef DeliveryRoverUnlockable { get; private set; } = null!;
    }

    public SmallRugAssets SmallRug { get; private set; } = null!;
    public LargeRugAssets LargeRug { get; private set; } = null!;
    public FatalitiesSignAssets FatalitiesSign { get; private set; } = null!;
    public DartboardAssets Dartboard { get; private set; } = null!;
    public DeliveryRoverAssets DeliveryRover { get; private set; } = null!;

    public UnlockableHandler()
	{
		if (Plugin.ModConfig.ConfigSmallRugEnabled.Value) RegisterSmallRug();
        if (Plugin.ModConfig.ConfigLargeRugEnabled.Value) RegisterLargeRug();
        if (Plugin.ModConfig.ConfigFatalitiesSignEnabled.Value) RegisterFatalitiesSign();
        if (Plugin.ModConfig.ConfigDartboardEnabled.Value) RegisterDartboard();
        if (Plugin.ModConfig.ConfigDeliveryRoverEnabled.Value) RegisterDeliveryRover();
	}

	private void RegisterSmallRug()
	{
		SmallRug = new SmallRugAssets("smallrugassets");
		RegisterUnlockable(SmallRug.SmallRugUnlockable, Plugin.ModConfig.ConfigSmallRugCost.Value, StoreType.Decor);
	}

    private void RegisterLargeRug()
    {
        LargeRug = new LargeRugAssets("largerugassets");
        RegisterUnlockable(LargeRug.LargeRugUnlockable, Plugin.ModConfig.ConfigLargeRugCost.Value, StoreType.Decor);
    }

    private void RegisterFatalitiesSign()
    {
        FatalitiesSign = new FatalitiesSignAssets("fatalitiessignassets");
        RegisterUnlockable(FatalitiesSign.FatalitiesSignUnlockable, Plugin.ModConfig.ConfigFatalitiesSignCost.Value, StoreType.Decor);
    }

    private void RegisterDartboard()
    {
        Dartboard = new DartboardAssets("dartboardassets");
        RegisterUnlockable(Dartboard.DartboardUnlockable, Plugin.ModConfig.ConfigDartboardCost.Value, StoreType.Decor);
    }

    private void RegisterDeliveryRover()
    {
        DeliveryRover = new DeliveryRoverAssets("deliveryroverassets");
        RegisterUnlockable(DeliveryRover.DeliveryRoverUnlockable, Plugin.ModConfig.ConfigDeliveryRoverCost.Value, StoreType.ShipUpgrade);
    }
}