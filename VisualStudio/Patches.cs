using Il2Cpp;
using HarmonyLib;
using UnityEngine;

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
                LWFunctionalities.furItem = gi?.GetComponent<GearItem>();
                LWFunctionalities.recipientBoxItem = gi?.GetComponent<GearItem>();
                LWFunctionalities.tanningItem = gi?.GetComponent<GearItem>();
                LWFunctionalities.barkItem = gi?.GetComponent<GearItem>();
                LWFunctionalities.pileItem = gi?.GetComponent<GearItem>();
                LWFunctionalities.unPileItem = gi?.GetComponent<GearItem>();
                LWFunctionalities.fryBirchItem = gi?.GetComponent<GearItem>();
                LWFunctionalities.placeBoxItem = gi?.GetComponent<GearItem>();
                LWFunctionalities.ropeItem = gi?.GetComponent<GearItem>();
                LWFunctionalities.stringItem = gi?.GetComponent<GearItem>();

                if (gi != null && LeatherworksUtils.IsFur(gi.name) == true)
                {
                    LWFunctionalities.SetScrapeFurActive(true);
                }
                else
                {
                    LWFunctionalities.SetScrapeFurActive(false);
                }

                
               
                if (gi != null && LeatherworksUtils.IsTanFilled(gi.name) == true)
                {
                    LWFunctionalities.SetLeatherAddActive(true);
                }
                else
                {
                    LWFunctionalities.SetLeatherAddActive(false);
                }

                
                
                if (gi != null && LeatherworksUtils.IsTanEmpty(gi.name) == true)
                {
                    LWFunctionalities.SetTanningAddActive(true);
                }
                else
                {
                    LWFunctionalities.SetTanningAddActive(false);
                }

                
                
                if (gi != null && LeatherworksUtils.IsFriedBark(gi.name) == true)
                {
                    LWFunctionalities.SetCrushBarkActive(true);
                }
                else
                {
                    LWFunctionalities.SetCrushBarkActive(false);
                }

                if (gi.name == "GEAR_BarkPrepared")
                {
                    LWFunctionalities.SetMakeRopeActive(true);
                }
                else
                {
                    LWFunctionalities.SetMakeRopeActive(false);
                }

                if (gi.name == "GEAR_BarkRope")
                {
                    LWFunctionalities.SetMakeStringActive(true);
                }
                else
                {
                    LWFunctionalities.SetMakeStringActive(false);
                }



                if (gi != null && LeatherworksUtils.IsFriedBarkPileable(gi.name) == true)
                {
                    LWFunctionalities.SetPileBarkActive(true);
                }
                else
                {
                    LWFunctionalities.SetPileBarkActive(false);
                }

                if (gi != null && LeatherworksUtils.IsFriedBarkUnPileable(gi.name) == true)
                {
                    LWFunctionalities.SetUnPileBarkActive(true);
                }
                else
                {
                    LWFunctionalities.SetUnPileBarkActive(false);
                }



                if (gi != null && gi.name.ToLowerInvariant().Contains("boxtanning"))
                {
                    LWFunctionalities.SetPlaceBoxActive(true);
                }
                else
                {
                    LWFunctionalities.SetPlaceBoxActive(false);
                }

                if (gi.name == "GEAR_BirchbarkPrepared")
                {
                    LWFunctionalities.SetFryBirchActive(true);
                }
                else
                {
                    LWFunctionalities.SetFryBirchActive(false);
                }

                if (gi.name == "GEAR_BirchBarkPreparedFryable")
                {
                    LWFunctionalities.SetReturnBirchActive(true);
                }
                else
                {
                    LWFunctionalities.SetReturnBirchActive(false);
                }

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
    