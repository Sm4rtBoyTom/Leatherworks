namespace Leatherworks
{
    internal class LWMain : MelonMod
    {
        private static AssetBundle? assetBundle;
        internal static AssetBundle LWTexturesBundle
        {
            get => assetBundle ?? throw new System.NullReferenceException(nameof(assetBundle));
        }
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg(System.ConsoleColor.Yellow, "Scraping hides...");
            MelonLogger.Msg(System.ConsoleColor.Yellow, "Distributing tree bark...");
            MelonLogger.Msg(System.ConsoleColor.Yellow, "Filling bottles...");
            MelonLogger.Msg(System.ConsoleColor.Green, "Leatherworks Loaded!");
            assetBundle = LWUtilities.LoadFromStream("Leatherworks.Resources.Assets.leatherworksassets");
            Settings.instance.AddToModSettings("Leatherworks");
        }
    }
}