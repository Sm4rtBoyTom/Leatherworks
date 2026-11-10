
using UnityEngine.AddressableAssets;

namespace Leatherworks
{
    internal static class LWGear
    {
        internal const string Treebark = "GEAR_Treebark";

        internal const string Knife = "GEAR_Knife";
        internal const string KnifeImprovised = "GEAR_KnifeImprovised";
        internal const string JeremiahKnife = "GEAR_JeremiahKnife";
        internal const string KnifeScrapMetal = "GEAR_KnifeScrapMetal";
        internal const string KnifeSurvival = "GEAR_SurvivalKnife";
        internal const string KnifeCougarClaw = "GEAR_CougarClawKnife";
        internal const string Hammer = "GEAR_Hammer";
        internal const string Stone = "GEAR_Stone";

        internal const string LeatherScraped = "GEAR_LeatherScraped";
        internal const string Flour = "GEAR_Flour";
        internal const string StringBundle = "GEAR_StringBundle";
        internal const string BarkRope = "GEAR_BarkRope";
        internal const string CookedTanning = "GEAR_CookedTanning";

        internal const string MetalBoxForge = "GEAR_MetalBoxForge";
        internal const string MetalBoxTanning = "GEAR_MetalBoxTanning";
        internal const string MetalBoxTanFilled = "GEAR_MetalBoxTanFilled";

        internal const string BarkPrepared = "GEAR_BarkPrepared";
        internal const string BarkPreparedPile = "GEAR_BarkPreparedPile";
        internal const string BarkPreparedFried = "GEAR_BarkPreparedFried";
        internal const string BarkPreparedFriedPile = "GEAR_BarkPreparedFriedPile";

        internal const string BirchPrepared = "GEAR_BirchbarkPrepared";
        internal const string BirchPreparedPile = "GEAR_BirchBarkPreparedPile";
        internal const string BirchPreparedFried = "GEAR_BirchBarkPreparedFried";
        internal const string BirchPreparedFriedPile = "GEAR_BirchBarkPreparedFriedPile";
        internal const string BirchPreparedFryable = "GEAR_BirchBarkPreparedFryable";

        internal static readonly string[] FursDried =
        {
            "GEAR_MooseHideDried",
            "GEAR_LeatherHideDried",
            "GEAR_RabbitPeltDried",
            "GEAR_WolfPeltDried",
            "GEAR_BearHideDried",
            "GEAR_CougarHideDried"
        };
        internal static readonly string[] FursRaw =
        {
            "GEAR_MooseHide",
            "GEAR_LeatherHide",
            "GEAR_RabbitPelt",
            "GEAR_WolfPelt",
            "GEAR_BearHide",
            "GEAR_CougarHide"
        };
    }

    internal static class LeatherworksUtils
    {

        private static readonly System.Collections.Generic.Dictionary<string, GearItem> prefabCache =
            new System.Collections.Generic.Dictionary<string, GearItem>();

        internal static GearItem? GetPrefab(string gearName)
        {
            if (prefabCache.TryGetValue(gearName, out GearItem cached) && cached != null)
            {
                return cached;
            }

            GearItem prefab = Addressables.LoadAssetAsync<GameObject>(gearName).WaitForCompletion().GetComponent<GearItem>();

            if (prefab == null)
            {
                MelonLogger.Warning($"[Leatherworks] Prefab '{gearName}' could not be loaded.");
                return null;
            }

            prefabCache[gearName] = prefab;
            return prefab;
        }
        public static GearItem? leatherParts => GetPrefab(LWGear.LeatherScraped);
        public static GearItem? knife1 => GetPrefab(LWGear.Knife);
        public static GearItem? knife2 => GetPrefab(LWGear.KnifeImprovised);
        public static GearItem? knifeJeremiah => GetPrefab(LWGear.JeremiahKnife);
        public static GearItem? KnifeScrapMetal => GetPrefab(LWGear.KnifeScrapMetal);
        public static GearItem? KnifeSurvival => GetPrefab(LWGear.KnifeSurvival);
        public static GearItem? KnifeCougarClaw => GetPrefab(LWGear.KnifeCougarClaw);
        public static GearItem? hammer1 => GetPrefab(LWGear.Hammer);
        public static GearItem? hammer2 => GetPrefab(LWGear.Stone);
        public static GearItem? tanFilledBox => GetPrefab(LWGear.MetalBoxTanFilled);
        public static GearItem? boxTanStart => GetPrefab(LWGear.MetalBoxTanning);
        public static GearItem? flour => GetPrefab(LWGear.Flour);
        public static GearItem? bark => GetPrefab(LWGear.BarkPrepared);
        public static GearItem? barkPile => GetPrefab(LWGear.BarkPreparedPile);
        public static GearItem? barkFried => GetPrefab(LWGear.BarkPreparedFried);
        public static GearItem? barkFriedPile => GetPrefab(LWGear.BarkPreparedFriedPile);
        public static GearItem? birchClassic => GetPrefab(LWGear.BirchPrepared);
        public static GearItem? birchPile => GetPrefab(LWGear.BirchPreparedPile);
        public static GearItem? birchFried => GetPrefab(LWGear.BirchPreparedFried);
        public static GearItem? birchFriedPile => GetPrefab(LWGear.BirchPreparedFriedPile);
        public static GearItem? birchFry => GetPrefab(LWGear.BirchPreparedFryable);
        public static GearItem? stringbundle => GetPrefab(LWGear.StringBundle);
        public static GearItem? barkrope => GetPrefab(LWGear.BarkRope);
        public static GearItem? knifecamp1 => GetPrefab(LWGear.JeremiahKnife);
        public static GearItem? knifecamp2 => GetPrefab(LWGear.KnifeScrapMetal);

        private static bool Matches(string gearItemName, string[] list)
        {
            if (string.IsNullOrEmpty(gearItemName)) return false;

            for (int i = 0; i < list.Length; i++)
            {
                if (gearItemName == list[i]) return true;
            }
            return false;
        }
        public static bool IsFur(string gearItemName)
        {
            if (Settings.instance.noCured)
            {
                return Matches(gearItemName, LWGear.FursRaw) || Matches(gearItemName, LWGear.FursDried);
            }
            return Matches(gearItemName, LWGear.FursDried);
        }
        public static bool IsFriedBark(string gearItemName)
        {
            return gearItemName == LWGear.BarkPreparedFried;
        }
        public static bool IsFriedBarkPile(string gearItemName)
        {
            return gearItemName == LWGear.BarkPreparedFriedPile;
        }
        public static bool IsFriedBarkPileable(string gearItemName)
        {
            return gearItemName == LWGear.BarkPrepared || gearItemName == LWGear.BarkPreparedFried || gearItemName == LWGear.BirchPrepared || gearItemName == LWGear.BirchPreparedFried;
        }
        public static bool IsFriedBarkUnPileable(string gearItemName)
        {
            return gearItemName == LWGear.BarkPreparedPile || gearItemName == LWGear.BarkPreparedFriedPile || gearItemName == LWGear.BirchPreparedPile || gearItemName == LWGear.BirchPreparedFriedPile;
        }
        public static bool IsTanFilled(string gearItemName)
        {
            return gearItemName == LWGear.MetalBoxTanFilled;
        }

        public static bool IsTanEmpty(string gearItemName)
        {
            return gearItemName == LWGear.MetalBoxForge;
        }

        public static bool IsBirchFryable(string gearItemName)
        {
            return gearItemName == LWGear.BirchPrepared;
        }

        public static bool IsBirchReturnable(string gearItemName)
        {
            return gearItemName == LWGear.BirchPreparedFryable;
        }

        public static bool IsRopeMaterial(string gearItemName)
        {
            return gearItemName == LWGear.BarkPrepared;
        }

        public static bool IsRope(string gearItemName)
        {
            return gearItemName == LWGear.BarkRope;
        }
    }
}
