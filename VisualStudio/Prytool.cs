using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace Leatherworks
{
    internal static class PrytoolFunctionality
    {
        private const string PryToolname = "GEAR_PryTool";
        private const float IceFishingHPDecreaseToClear = 50f;
        private const int IceFishingMinutesToClear = 60;
        private static GameObject _PryToolGameObject;
        public static GameObject GetPryToolGameObject()
        {
            if (_PryToolGameObject != null)
            {
                return _PryToolGameObject;
            }

            Il2CppArrayBase<GearItem>allGearItems = Resources.FindObjectsOfTypeAll<GearItem>();

            GameObject firstFound = null;

            foreach (GearItem gearItem in allGearItems)
            {
                if (gearItem == null || gearItem.gameObject == null)
                {
                    continue;
                }

                if (gearItem.gameObject.name != PryToolname)
                {
                    continue;
                }

                Initialize(gearItem);

                if (firstFound == null)
                {
                    firstFound = gearItem.gameObject;
                }
            }

            _PryToolGameObject = firstFound;

            return _PryToolGameObject;
        }
        public static GearItem GetPrybarGearItem()
        {
            return _PryToolGameObject == null ? null : _PryToolGameObject.GetComponent<GearItem>();
        }
        public static void Initialize(GearItem gearItem)
        {
            if (gearItem == null || gearItem.gameObject == null) return;
            if (gearItem.gameObject.name != PryToolname) return;

            _PryToolGameObject = gearItem.gameObject;
            ApplyForceLockItem(gearItem);
            ApplyIceFishingHoleClear(gearItem);
        }
        private static void ApplyForceLockItem(GearItem gearItem)
        {
            ForceLockItem forceLockItem = gearItem.m_ForceLockItem;
            if (forceLockItem == null)
            {
                forceLockItem = gearItem.gameObject.GetComponent<ForceLockItem>();
            }
            if (forceLockItem == null)
            {
                forceLockItem = gearItem.gameObject.AddComponent<ForceLockItem>();
            }

            forceLockItem.m_ForceLockAudio = "PLAY_LOCKERPRYOPEN1";
            forceLockItem.m_LocalizedProgressText = new LocalizedString() { m_LocalizationID = "GAMEPLAY_Forcing" };
            gearItem.m_ForceLockItem = forceLockItem;
        }
        private static void ApplyIceFishingHoleClear(GearItem gearItem)
        {
            IceFishingHoleClearItem iceFishing = gearItem.m_IceFishingHoleClearItem;
            if (iceFishing == null)
            {
                iceFishing = gearItem.gameObject.GetComponent<IceFishingHoleClearItem>();
            }
            if (iceFishing == null)
            {
                iceFishing = gearItem.gameObject.AddComponent<IceFishingHoleClearItem>();
            }

            iceFishing.m_BreakIceAudio = "Play_IceBreakingChopping";
            iceFishing.m_HPDecreaseToClear = IceFishingHPDecreaseToClear;
            iceFishing.m_NumGameMinutesToClear = IceFishingMinutesToClear;
            gearItem.m_IceFishingHoleClearItem = iceFishing;
        }
        public static void ResetCache()
        {
            _PryToolGameObject = null;
        }
        public static void EnsurePrybarComponents(GameObject targetGameObject)
        {
            if (targetGameObject == null)
            {
                return;
            }

            GearItem gearItem = targetGameObject.GetComponent<GearItem>();

            if (gearItem == null)
            {
                return;
            }

            ApplyForceLockItem(gearItem);
            ApplyIceFishingHoleClear(gearItem);
        }

        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        internal static class PrytoolPatch
        {
            private static void Postfix(GearItem __instance)
            {
                Initialize(__instance);
            }
        }

        [HarmonyPatch(typeof(Panel_IceFishingHoleClear), "InitializeFilteredUsableTools")]
        internal static class IceFishingHoleClearPatch
        {
            private static void Prefix(Panel_IceFishingHoleClear __instance)
            {
                Il2CppSystem.Collections.Generic.List<GameObject> usableTools = __instance.m_UsableToolItems;
                if (usableTools == null) return;

                bool hasHatchetType = false;
                bool hasPryTool = false;
                foreach (GameObject go in usableTools)
                {
                    if (go == null) continue;
                    if (go.name == "GEAR_Hatchet") hasHatchetType = true;
                    if (go.name == "GEAR_PryTool") hasPryTool = true;
                }

                if (!hasHatchetType || hasPryTool) return;

                GameObject prybarGo = GetPryToolGameObject();
                if (prybarGo != null) usableTools.Add(prybarGo);
            }
        }
        internal static class PryToolForceLock
        {
            private const string VanillaPrybarName = "GEAR_Prybar";

            public static GearItem GerPryToolFromInventory()
            {
                Inventory inventory = GameManager.GetInventoryComponent();

                if (inventory == null)
                {
                    return null;
                }

                GearItem PryTool = inventory.GetHighestConditionGearThatMatchesName("GEAR_PryTool");

                if (PryTool != null && PryTool.gameObject != null)
                {
                    EnsurePrybarComponents(PryTool.gameObject);
                }

                return PryTool;
            }
            public static bool IsPrybarLock(Lock lockInstance)
            {
                if (lockInstance == null) return false;
                GearItem requiredTool = lockInstance.m_GearPrefabToForceLock;
                if (requiredTool == null || requiredTool.gameObject == null) return false;
                return requiredTool.gameObject.name == VanillaPrybarName;
            }

            [HarmonyPatch(typeof(Lock), nameof(Lock.PlayerHasRequiredToolToUnlock))]
            internal static class PlayerHasRequiredToolToUnlockPatch
            {
                private static void Postfix(Lock __instance, ref bool __result)
                {
                    if (__result || !IsPrybarLock(__instance)) return;
                    GearItem improvisedPrybar = GerPryToolFromInventory();
                    if (improvisedPrybar == null) return;
                    __result = true;
                }
            }
            [HarmonyPatch(typeof(Lock), nameof(Lock.CanForceLock))]
            internal static class CanForceLockPatch
            {
                private static void Postfix(Lock __instance, ref bool __result)
                {
                    if (__result || !IsPrybarLock(__instance)) return;
                    GearItem PryTool = GerPryToolFromInventory();
                    if (PryTool == null) return;
                    __result = true;
                }
            }
            [HarmonyPatch(typeof(Lock), nameof(Lock.GetGearItemToForceLock))]
            internal static class GetGearItemToForceLockPatch
            {
                private static void Postfix(Lock __instance, ref GearItem __result)
                {
                    if (!IsPrybarLock(__instance)) return;
                    GearItem PryTool = GerPryToolFromInventory();
                    if (PryTool == null) return;
                    __result = PryTool;
                }
            }
        }
    }
}

