using Il2CppTLD.Gear;
using UnityEngine.AddressableAssets;

namespace Leatherworks
{
    internal static class LWUtilities
    {
        public static InsulatedFlaskLiquidTypeConstraint liquidRestriction = Addressables.LoadAssetAsync<GameObject>("GEAR_InsulatedFlask_A").WaitForCompletion().GetComponent<InsulatedFlask>().m_ItemConstraints;
        public static GearItem Flask = Addressables.LoadAssetAsync<GameObject>("GEAR_ImprovisedFlask").WaitForCompletion().GetComponent<GearItem>();
        public static GameObject Bark = Addressables.LoadAssetAsync<GameObject>("GEAR_TreeBark").WaitForCompletion();
        public static GameObject MeatMat = Addressables.LoadAssetAsync<GameObject>("GEAR_UncookedBannock").WaitForCompletion();
        public static GameObject Liquid = Addressables.LoadAssetAsync<GameObject>("GEAR_CoffeeCup").WaitForCompletion();

        public static Mesh LoadMesh(string name)
        {
            return LWMain.LWTexturesBundle.LoadAsset<Mesh>(name);
        }

        public static Texture2D Texture(string textureName)
        {
            return LWMain.LWTexturesBundle.LoadAsset<Texture2D>(textureName);
        }

        public static Material LiquidMaterial(string textureName)
        {
            Material liquid = new Material(Liquid.gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            liquid.SetTexture("_Main_texture2", Texture(textureName));
            return liquid;
        }

        public static Material MeatMaterial(string textureName)
        {
            Material meat = new Material(MeatMat.gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            meat.SetTexture("_MainTex", Texture(textureName));
            return meat;
        }

        public static Material TanningLiquidMaterial() => LiquidMaterial("T_Tanning_Cooking");
        public static Material BarkNoodlesLiquidMaterial() => LiquidMaterial("T_BarkNoodles_Cooking");
        public static Material BirchBarkNoodlesLiquidMaterial() => LiquidMaterial("T_BirchBarkNoodles_Cooking");
        public static Material BirchBarkBannockRawMeatMaterial() => MeatMaterial("CKN_Uncooked_Bannock_Birch_Bark");
        public static Material BirchBarkBannockCookedMeatMaterial() => MeatMaterial("CKN_Cooked_BirchBarkBannock");
        public static Material BarkBannockRawMeatMaterial() => MeatMaterial("CKN_Uncooked_Bannock_Bark");
        public static Material BarkBannockCookedMeatMaterial() => MeatMaterial("CKN_Cooked_BarkBannock");
        public static Material BarkBannockBurntMeatMaterial() => MeatMaterial("CKN_Burnt_Bannock");
        public static Material BarkRawMeatMaterial() => MeatMaterial("CKN_UncookedBark");
        public static Material BarkCookedMeatMaterial() => MeatMaterial("CNK_CookedBark");
        public static Material BirchBarkRawMeatMaterial() => MeatMaterial("CKN_UncookedBirchBark");
        public static Material BirchBarkCookedMeatMaterial() => MeatMaterial("CKN_CookedBirchBark");

        // ----------------------------------------CookingTextures----------------------------------------//

        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class CookingPotMaterialsPatches
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;

                string name = __instance.name;
                string lower = name.ToLowerInvariant();

                Cookable cookable = __instance.gameObject.GetComponent<Cookable>();
                if (cookable == null) return;

                if (name.Contains("GEAR_UncookedTanning"))
                {
                    cookable.m_CookingPotMaterialsList = new Material[1] { TanningLiquidMaterial() };
                    cookable.m_CanBePickedUpWhileCooking = false;
                }
                if (name.Contains("BarkNoodles"))
                {
                    cookable.m_CookingPotMaterialsList = new Material[1] { BarkNoodlesLiquidMaterial() };
                    
                    if (lower.Contains("uncookedbarknoodles"))
                    {
                        cookable.m_CanBePickedUpWhileCooking = false;
                    }
                }
                if (name.Contains("BirchBarkNoodles"))
                {
                    cookable.m_CookingPotMaterialsList = new Material[1] { BirchBarkNoodlesLiquidMaterial() };

                    if (lower.Contains("uncookedbirchbarknoodles"))
                    {
                        cookable.m_CanBePickedUpWhileCooking = false;
                    }
                }
                if (name.Contains("GEAR_UncookedBirchBarkBannock"))
                {
                    cookable.m_CookingPotRawMaterialsList = new Material[1] { BirchBarkBannockRawMeatMaterial() };
                    cookable.m_CookingPotMaterialsList = new Material[1] { BirchBarkBannockCookedMeatMaterial() };
                    cookable.m_RuinedMaterials = new Material[1] { BarkBannockBurntMeatMaterial() };
                    cookable.m_CanBePickedUpWhileCooking = false;
                    cookable.m_MeshRawFryingPanStyle = LoadMesh("OBJ_Bannock");
                    cookable.m_MeshFryingPanStyle = LoadMesh("OBJ_Bannock");
                }
                if (name.Contains("GEAR_UncookedBarkBannock"))
                {
                    cookable.m_CookingPotRawMaterialsList = new Material[1] { BarkBannockRawMeatMaterial() };
                    cookable.m_CookingPotMaterialsList = new Material[1] { BarkBannockCookedMeatMaterial() };
                    cookable.m_RuinedMaterials = new Material[1] { BarkBannockBurntMeatMaterial() };
                    cookable.m_CanBePickedUpWhileCooking = false;
                    cookable.m_MeshRawFryingPanStyle = LoadMesh("OBJ_Bannock");
                    cookable.m_MeshFryingPanStyle = LoadMesh("OBJ_Bannock");
                }

                if (name.Contains("BarkPrepared"))
                {
                    cookable.m_MeshPotStyle = LoadMesh("OBJ_BirchBark");
                    cookable.m_MeshRawPotStyle = LoadMesh("OBJ_BirchBark");
                    cookable.m_MeshFryingPanStyle = LoadMesh("OBJ_BirchBark");
                    cookable.m_MeshRawFryingPanStyle = LoadMesh("OBJ_BirchBark");

                    cookable.m_CookingPotRawMaterialsList = new Material[1] { BarkRawMeatMaterial() };
                    cookable.m_CookingPotMaterialsList = new Material[1] { BarkCookedMeatMaterial() };
                    cookable.m_RuinedMaterials = new Material[1] { BarkBannockBurntMeatMaterial() };

                    if (lower.Contains("birch"))
                    {
                        cookable.m_CookingPotRawMaterialsList = new Material[1] { BirchBarkRawMeatMaterial() };
                        cookable.m_CookingPotMaterialsList = new Material[1] { BirchBarkCookedMeatMaterial() };
                        cookable.m_RuinedMaterials = new Material[1] { BarkBannockBurntMeatMaterial() };
                    }
                }
                if (name.Contains("BarkPreparedPile"))
                {
                    cookable.m_MeshPotStyle = LoadMesh("OBJ_BirchBarkPile");
                    cookable.m_MeshRawPotStyle = LoadMesh("OBJ_BirchBarkPile");
                    cookable.m_MeshFryingPanStyle = LoadMesh("OBJ_BirchBarkPile");
                    cookable.m_MeshRawFryingPanStyle = LoadMesh("OBJ_BirchBarkPile");

                    cookable.m_CookingPotRawMaterialsList = new Material[1] { BarkRawMeatMaterial() };
                    cookable.m_CookingPotMaterialsList = new Material[1] { BarkCookedMeatMaterial() };
                    cookable.m_RuinedMaterials = new Material[1] { BarkBannockBurntMeatMaterial() };

                    if (lower.Contains("birch"))
                    {
                        cookable.m_CookingPotRawMaterialsList = new Material[1] { BirchBarkRawMeatMaterial() };
                        cookable.m_CookingPotMaterialsList = new Material[1] { BirchBarkCookedMeatMaterial() };
                        cookable.m_RuinedMaterials = new Material[1] { BarkBannockBurntMeatMaterial() };
                    }
                }
            }
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

