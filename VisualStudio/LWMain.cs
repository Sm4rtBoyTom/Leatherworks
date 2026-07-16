using Il2Cpp;
using MelonLoader;
using UnityEngine;
using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;

namespace Leatherworks
{
    internal sealed class LWMain : MelonMod
    {
        public static bool isLoaded;

        private static bool addedCustomComponents; 

        public override void OnInitializeMelon()
        {
            MelonLoader.MelonLogger.Msg(System.ConsoleColor.Yellow, "Scraping hides...");
            MelonLoader.MelonLogger.Msg(System.ConsoleColor.Yellow, "Distributing tree bark...");
            MelonLoader.MelonLogger.Msg(System.ConsoleColor.Yellow, "Filling bottles...");
            MelonLoader.MelonLogger.Msg(System.ConsoleColor.Green, "Leatherworks Loaded!");
            Settings.instance.AddToModSettings("Leatherworks");
        }
        public override void OnSceneWasInitialized(int level, string name)
        {


            if (LeatherworksUtils.IsScenePlayable(name))
            {
                isLoaded = true;

                DoStuffWithGear();

            }

        }

        /// <summary>
        /// Needs Re-work, OnSceneWasInitialized is most likely broken and unreliable, should use Harmony Patches Instead...
        /// </summary>

        private static void DoStuffWithGear()
        {
            if (!addedCustomComponents)
            {
                GameObject gear;
                GearItem itemGear;
                InsulatedFlaskLiquidTypeConstraint liquidRestriction;
                //var validtools = GearItem.LoadGearItemPrefab("GEAR_ToolBelt").GetComponent<WeightReductionBuff>().m_ValidTargets;
                //var tools = GearItem.LoadGearItemPrefab("GEAR_ToolBelt").GetComponent<WeightReductionBuff>().m_Targets;
                //var tools2 = GearItem.LoadGearItemPrefab("GEAR_ToolBelt").GetComponent<WeightReductionBuff>().m_OperationHandle;

                

                //string tanning = "CookedTanning";
                string gear1 = "CookedBirchBarkNoodles";
                string gear2 = "CookedBirchBarkBannock";
                string gear3 = "BirchBarkPreparedFriedPile";
                string gear4 = "BarkPreparedFriedPile";
                string gear5 = "CookedBarkNoodles";
                string gear6 = "CookedBarkBannock";
                string gear7 = "AcornCookedBig";
                string gear8 = "ImprovisedFlask";
                string gear9 = "InsulatedFlask_Paint";
                string gear10 = "InsulatedFlask_T_A";
                string gear11 = "InsulatedFlask_T_B";
                string gear12 = "InsulatedFlask_T_C";
                //string gear13 = "ToolbeltJeans";
                //string gear14 = "ToolbeltCombatPants";
                
                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear1).gameObject;

                gear.AddComponent<ConditionOverTimeBuff>();
                gear.GetComponent<ConditionOverTimeBuff>().m_ConditionIncreasePerHour = 1.75f;
                gear.GetComponent<ConditionOverTimeBuff>().m_NumHours = 2f;


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear2).gameObject;

                gear.AddComponent<ConditionOverTimeBuff>();
                gear.GetComponent<ConditionOverTimeBuff>().m_ConditionIncreasePerHour = 2f;
                gear.GetComponent<ConditionOverTimeBuff>().m_NumHours = 3f;


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear3).gameObject;

                gear.AddComponent<ConditionOverTimeBuff>();
                gear.GetComponent<ConditionOverTimeBuff>().m_ConditionIncreasePerHour = 0.125f;
                gear.GetComponent<ConditionOverTimeBuff>().m_NumHours = 0.25f;


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear4).gameObject;

                gear.AddComponent<IngestedCarryCapacityBuff>();
                gear.GetComponent<IngestedCarryCapacityBuff>().m_CarryCapacityBuffDurationInHours = 0.125f;
                gear.GetComponent<IngestedCarryCapacityBuff>().m_CarryCapacityChange = ItemWeight.FromKilograms(0.25f);


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear5).gameObject;

                gear.AddComponent<IngestedCarryCapacityBuff>();
                gear.GetComponent<IngestedCarryCapacityBuff>().m_CarryCapacityBuffDurationInHours = 1f;
                gear.GetComponent<IngestedCarryCapacityBuff>().m_CarryCapacityChange = ItemWeight.FromKilograms(0.75f);


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear6).gameObject;

                gear.AddComponent<IngestedCarryCapacityBuff>();
                gear.GetComponent<IngestedCarryCapacityBuff>().m_CarryCapacityBuffDurationInHours = 1.5f;
                gear.GetComponent<IngestedCarryCapacityBuff>().m_CarryCapacityChange = ItemWeight.FromKilograms(2);

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear7).gameObject;

                gear.AddComponent<FatigueBuff>();
                gear.GetComponent<FatigueBuff>().m_DurationHours = 0.25f;
                gear.GetComponent<FatigueBuff>().m_InitialPercentDecrease = 2.5f;
                gear.GetComponent<FatigueBuff>().m_RateOfIncreaseScale = 0.9f;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear8).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear8);
                liquidRestriction = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_A").GetComponent<InsulatedFlask>().m_ItemConstraints;


                gear.AddComponent<InsulatedFlask>();
                gear.GetComponent<InsulatedFlask>().m_ItemConstraints = liquidRestriction;
                gear.GetComponent<InsulatedFlask>().m_Capacity = ItemLiquidVolume.FromLiters(0.4f);
                gear.GetComponent<InsulatedFlask>().m_GearItem = itemGear;
                gear.GetComponent<InsulatedFlask>().m_FallDamagePerMeter = 2;
                gear.GetComponent<InsulatedFlask>().m_PercentHeatLossPerMinuteIndoors = 0.35f;
                gear.GetComponent<InsulatedFlask>().m_PercentHeatLossPerMinuteOutdoors = 0.6f;
                gear.GetComponent<InsulatedFlask>().m_RangeToPreventHeatLossWhenNextToFire = 10;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear9).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear9);
                liquidRestriction = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_A").GetComponent<InsulatedFlask>().m_ItemConstraints;


                gear.AddComponent<InsulatedFlask>();
                gear.GetComponent<InsulatedFlask>().m_ItemConstraints = liquidRestriction;
                gear.GetComponent<InsulatedFlask>().m_Capacity = ItemLiquidVolume.FromLiters(0.1f);
                gear.GetComponent<InsulatedFlask>().m_GearItem = itemGear;
                gear.GetComponent<InsulatedFlask>().m_FallDamagePerMeter = 2;
                gear.GetComponent<InsulatedFlask>().m_PercentHeatLossPerMinuteIndoors = 0.01f;
                gear.GetComponent<InsulatedFlask>().m_PercentHeatLossPerMinuteOutdoors = 0.01f;
                gear.GetComponent<InsulatedFlask>().m_RangeToPreventHeatLossWhenNextToFire = 10;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear10).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear10);
                liquidRestriction = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_A").GetComponent<InsulatedFlask>().m_ItemConstraints;


                gear.AddComponent<InsulatedFlask>();
                gear.GetComponent<InsulatedFlask>().m_ItemConstraints = liquidRestriction;
                gear.GetComponent<InsulatedFlask>().m_Capacity = ItemLiquidVolume.FromLiters(0.8f);
                gear.GetComponent<InsulatedFlask>().m_GearItem = itemGear;
                gear.GetComponent<InsulatedFlask>().m_FallDamagePerMeter = 2;
                gear.GetComponent<InsulatedFlask>().m_PercentHeatLossPerMinuteIndoors = 0.25f;
                gear.GetComponent<InsulatedFlask>().m_PercentHeatLossPerMinuteOutdoors = 0.5f;
                gear.GetComponent<InsulatedFlask>().m_RangeToPreventHeatLossWhenNextToFire = 10;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear11).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear11);
                liquidRestriction = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_A").GetComponent<InsulatedFlask>().m_ItemConstraints;


                gear.AddComponent<InsulatedFlask>();
                gear.GetComponent<InsulatedFlask>().m_ItemConstraints = liquidRestriction;
                gear.GetComponent<InsulatedFlask>().m_Capacity = ItemLiquidVolume.FromLiters(0.8f);
                gear.GetComponent<InsulatedFlask>().m_GearItem = itemGear;
                gear.GetComponent<InsulatedFlask>().m_FallDamagePerMeter = 2;
                gear.GetComponent<InsulatedFlask>().m_PercentHeatLossPerMinuteIndoors = 0.25f;
                gear.GetComponent<InsulatedFlask>().m_PercentHeatLossPerMinuteOutdoors = 0.5f;
                gear.GetComponent<InsulatedFlask>().m_RangeToPreventHeatLossWhenNextToFire = 10;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear12).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear12);
                liquidRestriction = GearItem.LoadGearItemPrefab("GEAR_InsulatedFlask_A").GetComponent<InsulatedFlask>().m_ItemConstraints;


                gear.AddComponent<InsulatedFlask>();
                gear.GetComponent<InsulatedFlask>().m_ItemConstraints = liquidRestriction;
                gear.GetComponent<InsulatedFlask>().m_Capacity = ItemLiquidVolume.FromLiters(0.8f);
                gear.GetComponent<InsulatedFlask>().m_GearItem = itemGear;
                gear.GetComponent<InsulatedFlask>().m_FallDamagePerMeter = 2;
                gear.GetComponent<InsulatedFlask>().m_PercentHeatLossPerMinuteIndoors = 0.25f;
                gear.GetComponent<InsulatedFlask>().m_PercentHeatLossPerMinuteOutdoors = 0.5f;
                gear.GetComponent<InsulatedFlask>().m_RangeToPreventHeatLossWhenNextToFire = 10;



                //gear = GearItem.LoadGearItemPrefab("GEAR_" + gear13).gameObject;
                //itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear13);

                //gear.AddComponent<WeightReductionBuff>();
                //gear.GetComponent<WeightReductionBuff>().m_GearItem = itemGear;
                //gear.GetComponent<WeightReductionBuff>().m_ValidTargets = validtools;
                //gear.GetComponent<WeightReductionBuff>().m_Targets = tools;
                //gear.GetComponent<WeightReductionBuff>().m_OperationHandle = tools2;
                //gear.GetComponent<WeightReductionBuff>().m_AffectedItems = 3;
                //gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 0.5f;

                //gear = GearItem.LoadGearItemPrefab("GEAR_" + gear14).gameObject;
                //itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear14);

                //gear.AddComponent<WeightReductionBuff>();
                //gear.GetComponent<WeightReductionBuff>().m_GearItem = itemGear;
                //gear.GetComponent<WeightReductionBuff>().m_ValidTargets = validtools;
                //gear.GetComponent<WeightReductionBuff>().m_Targets = tools;
                //gear.GetComponent<WeightReductionBuff>().m_OperationHandle = tools2;
                //gear.GetComponent<WeightReductionBuff>().m_AffectedItems = 3;
                //gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 0.5f;



                addedCustomComponents = true;
            }

        }

    }
}

// Negative buffs don't seem to work through this, figure out alternative

//    gear = GearItem.LoadGearItemPrefab("GEAR_" + tanning).gameObject;
//    cure = GearItem.LoadGearItemPrefab("GEAR_ReishiTea").gameObject;

//    gear.AddComponent<FoodPoisoning>();
//    gear.GetComponent<FoodPoisoning>().m_Active = true;
//    gear.GetComponent<FoodPoisoning>().m_StartHasBeenCalled = true;
//    gear.GetComponent<FoodPoisoning>().m_FatigueIncreasePerHour = 5;
//    gear.GetComponent<FoodPoisoning>().m_StopDegradingConditionAtPercent = 15;
//    gear.GetComponent<FoodPoisoning>().m_DurationHoursMin = 5;
//    gear.GetComponent<FoodPoisoning>().m_DurationHoursMax = 10;
//    gear.GetComponent<FoodPoisoning>().m_DurationHours = 5;
//    gear.GetComponent<FoodPoisoning>().m_HPDrainPerHour = 25;
//    gear.GetComponent<FoodPoisoning>().m_NumHoursRestForCure = 3;
//    gear.GetComponent<FoodPoisoning>().m_AntibioticsPrefab = cure.gameObject;

//gear.AddComponent<Dysentery>();
//gear.GetComponent<Dysentery>().m_Active = true;
//gear.GetComponent<Dysentery>().m_DurationHours = 5;
//gear.GetComponent<Dysentery>().m_HPDrainPerHour = 5;
//gear.GetComponent<Dysentery>().m_NumHoursRestForCure = 2;
//gear.GetComponent<Dysentery>().m_NumLitersCleanWaterForCure = 2;

//Works great
//gear.AddComponent<EnergyBoostItem>();
//gear.GetComponent<EnergyBoostItem>().m_BoostDurationHours = 6;
//gear.GetComponent<EnergyBoostItem>().m_GearItem = gearI;
//gear.GetComponent<EnergyBoostItem>().m_FatigueInitialDecrease = 100;
//gear.GetComponent<EnergyBoostItem>().m_FatigueEndingIncrease = 0;
//gear.GetComponent<EnergyBoostItem>().m_PulseFrequencyStart = 0;
//gear.GetComponent<EnergyBoostItem>().m_PulseFrequencyEnd = 0;
//gear.GetComponent<EnergyBoostItem>().m_StaminaInitialIncrease = 100;
//gear.GetComponent<EnergyBoostItem>().m_StaminaEndingDecrease = 0;


//Don't know what this is exactly, broken ribs?
//gear.AddComponent<WeightReductionBuff>();
//gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 1;

//gear.AddComponent<FreezingBuff>();
//gear.AddComponent<ClimbingBuff>();
//gear.AddComponent<WeightReductionBuff>();

//Didn't seem to work, maybe was missing some variables
//gear.AddComponent<ResistInsomniaBuff>();
//gear.GetComponent<ResistInsomniaBuff>().m_SleepInterruptionMultiplier = 20f;

//Works, but I think this can be done through MC already anyway
//gear.AddComponent<FatigueBuff>();
//gear.GetComponent<FatigueBuff>().m_InitialPercentDecrease = 10f;
//gear.GetComponent<FatigueBuff>().m_DurationHours = 2f;

//Haven't tested
//gear.GetComponent<CabinFever>();

//Component itself doesn't have a timer, need to make one. Doesn't seem to work in food context
//gear.AddComponent<ProtectionBuff>();
//gear.GetComponent<ProtectionBuff>().m_AfflicationBodyArea = AfflictionBodyArea.Chest;
//gear.GetComponent<ProtectionBuff>().m_AnimalDamageModifier = 1.5f;
//gear.GetComponent<ProtectionBuff>().m_ProtectionType = ProtectionType.BallisticVest;

//FoodMaxStatBuff
//CabinFeverReductionBuff
//ConditionRestBuff
//Scent
//FreezingBuff
//CausesHeadacheDebuff
//FoodStatEffect
//