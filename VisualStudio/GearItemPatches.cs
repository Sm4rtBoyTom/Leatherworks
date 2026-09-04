using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;

namespace Leatherworks
{
    internal class GearItemPatches
    {

        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class CookedBirchBarkNoodles
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_CookedBirchBarkNoodles")
                {
                    ConditionOverTimeBuff conditionOverTimeBuff = __instance.gameObject.GetComponent<ConditionOverTimeBuff>() ?? __instance.gameObject.AddComponent<ConditionOverTimeBuff>();
                    if (conditionOverTimeBuff != null)
                    {
                        conditionOverTimeBuff.m_ConditionIncreasePerHour = 1.75f;
                        conditionOverTimeBuff.m_NumHours = 2f;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class CookedBirchBarkBannock
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_CookedBirchBarkBannock")
                {
                    ConditionOverTimeBuff conditionOverTimeBuff = __instance.gameObject.GetComponent<ConditionOverTimeBuff>() ?? __instance.gameObject.AddComponent<ConditionOverTimeBuff>();
                    if (conditionOverTimeBuff != null)
                    {
                        conditionOverTimeBuff.m_ConditionIncreasePerHour = 2f;
                        conditionOverTimeBuff.m_NumHours = 3f;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class BirchBarkPreparedFriedPile
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_BirchBarkPreparedFriedPile")
                {
                    ConditionOverTimeBuff conditionOverTimeBuff = __instance.gameObject.GetComponent<ConditionOverTimeBuff>() ?? __instance.gameObject.AddComponent<ConditionOverTimeBuff>();
                    if (conditionOverTimeBuff != null)
                    {
                        conditionOverTimeBuff.m_ConditionIncreasePerHour = 0.125f;
                        conditionOverTimeBuff.m_NumHours = 0.25f;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class BarkPreparedFriedPile
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_BarkPreparedFriedPile")
                {
                    IngestedCarryCapacityBuff ingestedCarryCapacityBuff = __instance.gameObject.GetComponent<IngestedCarryCapacityBuff>() ?? __instance.gameObject.AddComponent<IngestedCarryCapacityBuff>();
                    if (ingestedCarryCapacityBuff != null)
                    {
                        ingestedCarryCapacityBuff.m_CarryCapacityBuffDurationInHours = 0.125f;
                        ingestedCarryCapacityBuff.m_CarryCapacityChange = ItemWeight.FromKilograms(0.25f);
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class CookedBarkNoodles
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_CookedBarkNoodles")
                {
                    IngestedCarryCapacityBuff ingestedCarryCapacityBuff = __instance.gameObject.GetComponent<IngestedCarryCapacityBuff>() ?? __instance.gameObject.AddComponent<IngestedCarryCapacityBuff>();
                    if (ingestedCarryCapacityBuff != null)
                    {
                        ingestedCarryCapacityBuff.m_CarryCapacityBuffDurationInHours = 1f;
                        ingestedCarryCapacityBuff.m_CarryCapacityChange = ItemWeight.FromKilograms(0.75f);
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class CookedBarkBannock
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_CookedBarkBannock")
                {
                    IngestedCarryCapacityBuff ingestedCarryCapacityBuff = __instance.gameObject.GetComponent<IngestedCarryCapacityBuff>() ?? __instance.gameObject.AddComponent<IngestedCarryCapacityBuff>();
                    if (ingestedCarryCapacityBuff != null)
                    {
                        ingestedCarryCapacityBuff.m_CarryCapacityBuffDurationInHours = 1.5f;
                        ingestedCarryCapacityBuff.m_CarryCapacityChange = ItemWeight.FromKilograms(2);
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class AcornCookedBig
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_AcornCookedBig")
                {
                    FatigueBuff fatigueBuff = __instance.gameObject.GetComponent<FatigueBuff>() ?? __instance.gameObject.AddComponent<FatigueBuff>();
                    if (fatigueBuff != null)
                    {
                        fatigueBuff.m_DurationHours = 0.25f;
                        fatigueBuff.m_InitialPercentDecrease = 2.5f;
                        fatigueBuff.m_RateOfIncreaseScale = 0.9f;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class ImprovisedFlask
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_ImprovisedFlask")
                {
                    GearItem gi;
                    gi = GearItem.LoadGearItemPrefab("GEAR_ImprovisedFlask");
                    InsulatedFlaskLiquidTypeConstraint liquidRestriction;
                    liquidRestriction = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_A").GetComponent<InsulatedFlask>().m_ItemConstraints;

                    InsulatedFlask flask = __instance.gameObject.GetComponent<InsulatedFlask>() ?? __instance.gameObject.AddComponent<InsulatedFlask>();
                    if (flask != null)
                    {
                        flask.m_ItemConstraints = liquidRestriction;
                        flask.m_Capacity = ItemLiquidVolume.FromLiters(0.4f);
                        flask.m_GearItem = gi;
                        flask.m_FallDamagePerMeter = 2;
                        flask.m_PercentHeatLossPerMinuteIndoors = 0.35f;
                        flask.m_PercentHeatLossPerMinuteOutdoors = 0.65f;
                        flask.m_RangeToPreventHeatLossWhenNextToFire = 10;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class InsulatedFlask_Paint
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_InsulatedFlask_Paint")
                {
                    GearItem gi;
                    gi = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_Paint");
                    InsulatedFlaskLiquidTypeConstraint liquidRestriction;
                    liquidRestriction = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_A").GetComponent<InsulatedFlask>().m_ItemConstraints;

                    InsulatedFlask flask = __instance.gameObject.GetComponent<InsulatedFlask>() ?? __instance.gameObject.AddComponent<InsulatedFlask>();
                    if (flask != null)
                    {
                        flask.m_ItemConstraints = liquidRestriction;
                        flask.m_Capacity = ItemLiquidVolume.FromLiters(0.1f);
                        flask.m_GearItem = gi;
                        flask.m_FallDamagePerMeter = 2;
                        flask.m_PercentHeatLossPerMinuteIndoors = 0.01f;
                        flask.m_PercentHeatLossPerMinuteOutdoors = 0.01f;
                        flask.m_RangeToPreventHeatLossWhenNextToFire = 10;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class InsulatedFlask_T_A
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_InsulatedFlask_T_A")
                {
                    GearItem gi;
                    gi = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_T_A");
                    InsulatedFlaskLiquidTypeConstraint liquidRestriction;
                    liquidRestriction = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_A").GetComponent<InsulatedFlask>().m_ItemConstraints;

                    InsulatedFlask flask = __instance.gameObject.GetComponent<InsulatedFlask>() ?? __instance.gameObject.AddComponent<InsulatedFlask>();
                    if (flask != null)
                    {
                        flask.m_ItemConstraints = liquidRestriction;
                        flask.m_Capacity = ItemLiquidVolume.FromLiters(0.8f);
                        flask.m_GearItem = gi;
                        flask.m_FallDamagePerMeter = 2;
                        flask.m_PercentHeatLossPerMinuteIndoors = 0.25f;
                        flask.m_PercentHeatLossPerMinuteOutdoors = 0.5f;
                        flask.m_RangeToPreventHeatLossWhenNextToFire = 10;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class InsulatedFlask_T_B
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_InsulatedFlask_T_B")
                {
                    GearItem gi;
                    gi = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_T_B");
                    InsulatedFlaskLiquidTypeConstraint liquidRestriction;
                    liquidRestriction = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_A").GetComponent<InsulatedFlask>().m_ItemConstraints;

                    InsulatedFlask flask = __instance.gameObject.GetComponent<InsulatedFlask>() ?? __instance.gameObject.AddComponent<InsulatedFlask>();
                    if (flask != null)
                    {
                        flask.m_ItemConstraints = liquidRestriction;
                        flask.m_Capacity = ItemLiquidVolume.FromLiters(0.8f);
                        flask.m_GearItem = gi;
                        flask.m_FallDamagePerMeter = 2;
                        flask.m_PercentHeatLossPerMinuteIndoors = 0.25f;
                        flask.m_PercentHeatLossPerMinuteOutdoors = 0.5f;
                        flask.m_RangeToPreventHeatLossWhenNextToFire = 10;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class InsulatedFlask_T_C
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_InsulatedFlask_T_C")
                {
                    GearItem gi;
                    gi = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_T_C");
                    InsulatedFlaskLiquidTypeConstraint liquidRestriction;
                    liquidRestriction = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_A").GetComponent<InsulatedFlask>().m_ItemConstraints;

                    InsulatedFlask flask = __instance.gameObject.GetComponent<InsulatedFlask>() ?? __instance.gameObject.AddComponent<InsulatedFlask>();
                    if (flask != null)
                    {
                        flask.m_ItemConstraints = liquidRestriction;
                        flask.m_Capacity = ItemLiquidVolume.FromLiters(0.8f);
                        flask.m_GearItem = gi;
                        flask.m_FallDamagePerMeter = 2;
                        flask.m_PercentHeatLossPerMinuteIndoors = 0.25f;
                        flask.m_PercentHeatLossPerMinuteOutdoors = 0.5f;
                        flask.m_RangeToPreventHeatLossWhenNextToFire = 10;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class ImprovedInsulationCollider
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;
                if (__instance.name == "GEAR_ImprovedDownInsulation")
                {
                    BoxCollider collider = __instance.gameObject.GetComponent<BoxCollider>() ?? __instance.gameObject.AddComponent<BoxCollider>();
                    if (collider != null)
                    {
                        collider.center = new Vector3(-0.0021f, 0.0351f, -0.0004f);
                        collider.extents = new Vector3(0.2123f, 0.0437f, 0.181f);
                        collider.size = new Vector3(0.4246f, 0.0873f, 0.362f);

                        //FYI, I'm just too lazy to rebuilt a whole unity project just for a missing collider. (Coppied the values off of Improvised Insulation)
                    }
                }
            }
        }

        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class CookingPotMaterials
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;

                Cookable cookable = __instance.gameObject.GetComponent<Cookable>();
                if (cookable != null)
                {
                    if (__instance.name.Contains("GEAR_UncookedTanning"))
                    {
                        cookable.m_CookingPotMaterialsList = new Material[1] { LWUtilities.TanningLiquidMaterial() };
                        cookable.m_CanBePickedUpWhileCooking = false;
                    }
                    if (__instance.name.Contains("GEAR_UncookedBarkNoodles"))
                    {
                        cookable.m_CookingPotMaterialsList = new Material[1] { LWUtilities.BarkNoodlesLiquidMaterial() };
                        cookable.m_CanBePickedUpWhileCooking = false;
                    }
                    if (__instance.name.Contains("GEAR_UncookedBirchBarkNoodles"))
                    {
                        cookable.m_CookingPotMaterialsList = new Material[1] { LWUtilities.BirchBarkNoodlesLiquidMaterial() };
                        cookable.m_CanBePickedUpWhileCooking = false;
                    }
                    if (__instance.name.Contains("GEAR_UncookedBirchBarkBannock"))
                    {
                        cookable.m_CookingPotMaterialsList = new Material[1] { LWUtilities.BarkBannockRawGrubMaterial() };
                        cookable.m_CanBePickedUpWhileCooking = false;
                    }
                    if (__instance.name.Contains("GEAR_UncookedBarkBannock"))
                    {
                        cookable.m_CookingPotMaterialsList = new Material[1] { LWUtilities.BarkBannockRawGrubMaterial() };
                        cookable.m_CanBePickedUpWhileCooking = false;
                    }
                }
            }
        }
    }
}

