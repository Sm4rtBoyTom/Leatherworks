using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;

namespace Leatherworks
{
    internal class GearItemPatches
    {
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal class CookedBarkNoodles
        {
            private static void Postfix(GearItem __instance)
            {
                if (__instance == null) return;

                string name = __instance.name;

                if (name.Contains("GEAR_CookedBarkNoodles"))
                {
                    IngestedCarryCapacityBuff ingestedCarryCapacityBuff = __instance.gameObject.GetComponent<IngestedCarryCapacityBuff>() ?? __instance.gameObject.AddComponent<IngestedCarryCapacityBuff>();
                    if (ingestedCarryCapacityBuff == null) return;
                    
                    ingestedCarryCapacityBuff.m_CarryCapacityBuffDurationInHours = 1f;
                    ingestedCarryCapacityBuff.m_CarryCapacityChange = ItemWeight.FromKilograms(0.75f);
                    
                    FreezingBuff FB = __instance.gameObject.GetComponent<FreezingBuff>() ?? __instance.gameObject.AddComponent<FreezingBuff>();
                    if (FB == null) return;
                    
                    FB.m_DurationHours = 1.25f;
                    FB.m_InitialPercentDecrease = 33;
                    FB.m_RateOfIncreaseScale = 0.4f;
                    
                    FoodItem food = __instance.gameObject.GetComponent<FoodItem>() ?? __instance.gameObject.AddComponent<FoodItem>();
                    if (food == null) return;
                    
                    food.m_HeatedWhenCooked = true;
                    food.m_PercentHeatLossPerMinuteIndoors = 0.75f;
                    food.m_PercentHeatLossPerMinuteOutdoors = 1.5f;
                }

                if (name.Contains("GEAR_CookedBirchBarkNoodles"))
                {
                    ConditionOverTimeBuff conditionOverTimeBuff = __instance.gameObject.GetComponent<ConditionOverTimeBuff>() ?? __instance.gameObject.AddComponent<ConditionOverTimeBuff>();
                    if (conditionOverTimeBuff == null) return;

                    conditionOverTimeBuff.m_ConditionIncreasePerHour = 1.75f;
                    conditionOverTimeBuff.m_NumHours = 2f;

                    FreezingBuff FB = __instance.gameObject.GetComponent<FreezingBuff>() ?? __instance.gameObject.AddComponent<FreezingBuff>();
                    if (FB == null) return;

                    FB.m_DurationHours = 1.25f;
                    FB.m_InitialPercentDecrease = 33;
                    FB.m_RateOfIncreaseScale = 0.4f;

                    FoodItem food = __instance.gameObject.GetComponent<FoodItem>() ?? __instance.gameObject.AddComponent<FoodItem>();
                    if (food == null) return;

                    food.m_HeatedWhenCooked = true;
                    food.m_PercentHeatLossPerMinuteIndoors = 0.75f;
                    food.m_PercentHeatLossPerMinuteOutdoors = 1.5f;
                }

                if (name.Contains("GEAR_CookedBirchBarkBannock"))
                {
                    ConditionOverTimeBuff conditionOverTimeBuff = __instance.gameObject.GetComponent<ConditionOverTimeBuff>() ?? __instance.gameObject.AddComponent<ConditionOverTimeBuff>();
                    if (conditionOverTimeBuff == null) return;

                    conditionOverTimeBuff.m_ConditionIncreasePerHour = 1.5f;
                    conditionOverTimeBuff.m_NumHours = 1f;
                }

                if (name.Contains("GEAR_CookedBarkBannock"))
                {
                    IngestedCarryCapacityBuff ingestedCarryCapacityBuff = __instance.gameObject.GetComponent<IngestedCarryCapacityBuff>() ?? __instance.gameObject.AddComponent<IngestedCarryCapacityBuff>();
                    if (ingestedCarryCapacityBuff == null) return;

                    ingestedCarryCapacityBuff.m_CarryCapacityBuffDurationInHours = 1f;
                    ingestedCarryCapacityBuff.m_CarryCapacityChange = ItemWeight.FromKilograms(0.75f);
                }

                if (name.Contains("GEAR_ImprovisedFlask"))
                {
                    InsulatedFlask flask = __instance.gameObject.GetComponent<InsulatedFlask>() ?? __instance.gameObject.AddComponent<InsulatedFlask>();
                    if (flask == null) return;

                    flask.m_ItemConstraints = LWUtilities.liquidRestriction;
                    flask.m_Capacity = ItemLiquidVolume.FromLiters(0.4f);
                    flask.m_GearItem = LWUtilities.Flask;
                    flask.m_FallDamagePerMeter = 2;
                    flask.m_PercentHeatLossPerMinuteIndoors = 0.35f;
                    flask.m_PercentHeatLossPerMinuteOutdoors = 0.65f;
                    flask.m_RangeToPreventHeatLossWhenNextToFire = 10;
                }
            }
        }
    }
}

