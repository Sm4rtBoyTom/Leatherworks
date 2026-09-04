namespace Leatherworks
{
    internal class Patches
    {
        [HarmonyPatch(typeof(Panel_Inventory), nameof(Panel_Inventory.Initialize))]
        internal class LeatherworksInitialization
        {
            private static void Postfix(Panel_Inventory __instance)
            {
                LeatherworksUtils.inventory = __instance;
                LWFunctionalities.InitializeMTB(__instance.m_ItemDescriptionPage);
            }
        }

        [HarmonyPatch(typeof(ItemDescriptionPage), nameof(ItemDescriptionPage.UpdateGearItemDescription))]
        internal class UpdateInventoryButton
        {
            private static void Postfix(ItemDescriptionPage __instance, GearItem gi)
            {
                if (__instance != InterfaceManager.GetPanel<Panel_Inventory>()?.m_ItemDescriptionPage) return;

                LWFunctionalities.UpdateButtons(gi);
            }
        }

        [HarmonyPatch(typeof(RadialObjectSpawner), "GetNextPrefabToSpawn")]
        internal class AddTreebark
        {
            private static void Postfix(RadialObjectSpawner __instance, ref GameObject __result)
            {
                if (__instance != null && __instance.name.Contains("RadialSpawn_sticks") && LeatherworksUtils.treebark != null)
                {
                    if (Utils.RollChance(Settings.instance.treebarkChance))
                    {
                        __result = LeatherworksUtils.treebark;
                    }
                }
            }
        }
    }
}
