
namespace Leatherworks
{
    internal static class LWUtilities
    {
        public static Material TanningLiquidMaterial()
        {
            Texture2D LiquidTexture = LWMain.LWTexturesBundle.LoadAsset<Texture2D>("T_Tanning_Cooking");
            Material LiquidMaterial = new Material(GearItem.LoadGearItemPrefab("GEAR_CoffeeCup").gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }
        public static Material BarkNoodlesLiquidMaterial()
        {
            Texture2D LiquidTexture = LWMain.LWTexturesBundle.LoadAsset<Texture2D>("T_BarkNoodles_Cooking");
            Material LiquidMaterial = new Material(GearItem.LoadGearItemPrefab("GEAR_CoffeeCup").gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }
        public static Material BirchBarkNoodlesLiquidMaterial()
        {
            Texture2D LiquidTexture = LWMain.LWTexturesBundle.LoadAsset<Texture2D>("T_BirchBarkNoodles_Cooking");
            Material LiquidMaterial = new Material(GearItem.LoadGearItemPrefab("GEAR_CoffeeCup").gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }
        public static Material BarkBannockRawGrubMaterial()
        {
            Texture2D LiquidTexture = LWMain.LWTexturesBundle.LoadAsset<Texture2D>("T_BarkBannock_Raw");
            Material LiquidMaterial = new Material(GearItem.LoadGearItemPrefab("GEAR_UncookedBannock").gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }

        public static AssetBundle LoadFromStream(string name) // Asset Bundle Loader
        {
            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
            {
                MemoryStream? memory = new((int)stream.Length);
                stream!.CopyTo(memory);

                Il2CppSystem.IO.MemoryStream memoryStream = new Il2CppSystem.IO.MemoryStream(memory.ToArray());

                AssetBundle loadFromMemoryInternal = AssetBundle.LoadFromStream(memoryStream);
                return loadFromMemoryInternal;
            }
        }

    }
}

