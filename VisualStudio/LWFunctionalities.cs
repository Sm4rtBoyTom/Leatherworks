
namespace Leatherworks
{
    internal class LWFunctionalities
    {
        // === Currently selected item (field names kept for backwards compatibility) ===
        internal static GearItem? furItem;
        internal static GearItem? recipientBoxItem;
        internal static GearItem? tanningItem;
        internal static GearItem? barkItem;
        internal static GearItem? ropeItem;
        internal static GearItem? stringItem;
        internal static GearItem? pileItem;
        internal static GearItem? unPileItem;
        internal static GearItem? placeBoxItem;
        internal static GearItem? fryBirchItem;
        internal static GearItem? returnBirchItem;

        internal static string furName = "";
        internal static string recipientBoxItemName = "";
        internal static string tanningName = "";
        internal static string barkName = "";
        internal static string ropeName = "";
        internal static string stringName = "";
        internal static string pileName = "";
        internal static string unPileName = "";

        internal static string scrapeText = "";
        internal static string addLeatherText = "";
        internal static string addTanningText = "";
        internal static string crushBarkText = "";
        internal static string makeRopeText = "";
        internal static string makeStringText = "";
        internal static string pileBarkText = "";
        internal static string unPileBarkText = "";
        internal static string placeBoxText = "";
        internal static string fryBirchText = "";
        internal static string returnBirchText = "";

        private const int PileSize = 5;
        private const int LeatherPerBox = 5;
        private const int BarkPerRope = 3;
        private const int RopePerString = 3;
        private sealed class LWButton
        {
            private readonly GameObject button;
            private readonly string locKey;

            internal LWButton(ItemDescriptionPage itemDescriptionPage, string locKey, float x, float y, System.Action action)
            {
                this.locKey = locKey;

                GameObject equipButton = itemDescriptionPage.m_MouseButtonEquip;
                button = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
                button.transform.Translate(x, y, 0f);

                Il2CppSystem.Collections.Generic.List<EventDelegate> placeHolderList = new Il2CppSystem.Collections.Generic.List<EventDelegate>();
                placeHolderList.Add(new EventDelegate(action));
                Utils.GetComponentInChildren<UIButton>(button).onClick = placeHolderList;

                SetActive(false);
            }

            internal void SetActive(bool active)
            {
                if (button == null) return;

                UILabel label = Utils.GetComponentInChildren<UILabel>(button);
                if (label != null)
                {
                    label.text = Localization.Get(locKey);
                }
                NGUITools.SetActive(button, active);
            }
        }

        private static LWButton? scrapeButton;
        private static LWButton? addLeatherButton;
        private static LWButton? addTanningButton;
        private static LWButton? crushBarkButton;
        private static LWButton? pileBarkButton;
        private static LWButton? unPileBarkButton;
        private static LWButton? fryBirchButton;
        private static LWButton? returnBirchButton;
        private static LWButton? placeBoxButton;
        private static LWButton? makeRopeButton;
        private static LWButton? makeStringButton;

        internal static void InitializeMTB(ItemDescriptionPage itemDescriptionPage)
        {
            scrapeText = Localization.Get("GAMEPLAY_LW_ScrapeLabel");
            addLeatherText = Localization.Get("GAMEPLAY_LW_AddLeatherLabel");
            addTanningText = Localization.Get("GAMEPLAY_LW_AddTanningLabel");
            crushBarkText = Localization.Get("GAMEPLAY_LW_CrushBarkLabel");
            pileBarkText = Localization.Get("GAMEPLAY_LW_PileBarkLabel");
            unPileBarkText = Localization.Get("GAMEPLAY_LW_UnPileBarkLabel");
            fryBirchText = Localization.Get("GAMEPLAY_LW_FryBirchLabel");
            returnBirchText = Localization.Get("GAMEPLAY_LW_ReturnBirchLabel");
            placeBoxText = Localization.Get("GAMEPLAY_LW_PlaceBoxLabel");
            makeRopeText = Localization.Get("GAMEPLAY_LW_MakeRopeLabel");
            makeStringText = Localization.Get("GAMEPLAY_LW_MakeStringLabel");

            scrapeButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_ScrapeLabel", 0f, 0f, new System.Action(OnScrapeFur));
            addLeatherButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_AddLeatherLabel", 0f, 0f, new System.Action(OnLeatherAdd));
            addTanningButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_AddTanningLabel", 0f, 0f, new System.Action(OnTanningAdd));
            crushBarkButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_CrushBarkLabel", 0f, -0.1f, new System.Action(OnCrushBark));
            pileBarkButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_PileBarkLabel", 0.4f, 0f, new System.Action(OnPileBark));
            unPileBarkButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_UnPileBarkLabel", 0.4f, 0f, new System.Action(OnUnPileBark));
            fryBirchButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_FryBirchLabel", 0f, 0f, new System.Action(OnFryBirch));
            returnBirchButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_ReturnBirchLabel", 0f, 0f, new System.Action(OnReturnBirch));
            placeBoxButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_PlaceBoxLabel", 0f, 0f, new System.Action(OnPlaceBox));
            makeRopeButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_MakeRopeLabel", 0f, 0f, new System.Action(OnMakeRope));
            makeStringButton = new LWButton(itemDescriptionPage, "GAMEPLAY_LW_MakeStringLabel", 0f, 0f, new System.Action(OnMakeString));
        }

        internal static void SetScrapeFurActive(bool active) => scrapeButton?.SetActive(active);
        internal static void SetLeatherAddActive(bool active) => addLeatherButton?.SetActive(active);
        internal static void SetTanningAddActive(bool active) => addTanningButton?.SetActive(active);
        internal static void SetCrushBarkActive(bool active) => crushBarkButton?.SetActive(active);
        internal static void SetPileBarkActive(bool active) => pileBarkButton?.SetActive(active);
        internal static void SetUnPileBarkActive(bool active) => unPileBarkButton?.SetActive(active);
        internal static void SetFryBirchActive(bool active) => fryBirchButton?.SetActive(active);
        internal static void SetReturnBirchActive(bool active) => returnBirchButton?.SetActive(active);
        internal static void SetPlaceBoxActive(bool active) => placeBoxButton?.SetActive(active);
        internal static void SetMakeRopeActive(bool active) => makeRopeButton?.SetActive(active);
        internal static void SetMakeStringActive(bool active) => makeStringButton?.SetActive(active);
        internal static void UpdateButtons(GearItem gi)
        {
            string name = gi != null ? gi.name : "";

            furItem = gi;
            recipientBoxItem = gi;
            tanningItem = gi;
            barkItem = gi;
            pileItem = gi;
            unPileItem = gi;
            fryBirchItem = gi;
            returnBirchItem = gi;
            placeBoxItem = gi;
            ropeItem = gi;
            stringItem = gi;

            SetScrapeFurActive(LeatherworksUtils.IsFur(name));
            SetLeatherAddActive(LeatherworksUtils.IsTanFilled(name));
            SetTanningAddActive(LeatherworksUtils.IsTanEmpty(name));
            SetCrushBarkActive(LeatherworksUtils.IsFriedBark(name));
            SetPileBarkActive(LeatherworksUtils.IsFriedBarkPileable(name));
            SetUnPileBarkActive(LeatherworksUtils.IsFriedBarkUnPileable(name));
            SetFryBirchActive(LeatherworksUtils.IsBirchFryable(name));
            SetReturnBirchActive(LeatherworksUtils.IsBirchReturnable(name));
            SetPlaceBoxActive(LeatherworksUtils.IsPlaceableBox(name));
            SetMakeRopeActive(LeatherworksUtils.IsRopeMaterial(name));
            SetMakeStringActive(LeatherworksUtils.IsRope(name));
        }

        // === Helpers ==========================================================
        private static void Fail(string locKey)
        {
            HUDMessage.AddMessage(Localization.Get(locKey));
            GameAudioManager.PlayGUIError();
        }
        private static GearItem? GetBestKnife()
        {
            var inv = GameManager.GetInventoryComponent();

            if (inv.GearInInventory(LWGear.Knife, 1))
            {
                return inv.GetBestGearItemWithName(LWGear.Knife);
            }
            if (inv.GearInInventory(LWGear.KnifeCougarClaw, 1))
            {
                return inv.GetBestGearItemWithName(LWGear.KnifeCougarClaw);
            }
            if (inv.GearInInventory(LWGear.JeremiahKnife, 1))
            {
                return inv.GetBestGearItemWithName(LWGear.JeremiahKnife);
            }
            if (inv.GearInInventory(LWGear.KnifeSurvival, 1))
            {
                return inv.GetBestGearItemWithName(LWGear.KnifeSurvival);
            }
            if (inv.GearInInventory(LWGear.KnifeImprovised, 1))
            {
                return inv.GetBestGearItemWithName(LWGear.KnifeImprovised);
            }
            if (inv.GearInInventory(LWGear.KnifeScrapMetal, 1))
            {
                return inv.GetBestGearItemWithName(LWGear.KnifeScrapMetal);
            }

            return null;
        }
        
        private static int UnitsInInventory(string gearName)
        {
            GearItem item = GameManager.GetInventoryComponent().GetBestGearItemWithName(gearName);
            if (item == null) return 0;
            return item.m_StackableItem != null ? item.m_StackableItem.m_Units : 1;
        }
        private static void GiveItem(string gearName, int count)
        {
            GearItem? prefab = LeatherworksUtils.GetPrefab(gearName);
            if (prefab == null) return;

            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(prefab, count);
        }
        // === Scrape fur =======================================================
        private static string tempFurName = "";
        private static void OnScrapeFur()
        {
            GearItem? thisGearItem = furItem;
            if (thisGearItem == null) return;  

            furName = thisGearItem.name;

            if (!LeatherworksUtils.IsFur(furName))
            {
                Fail("GAMEPLAY_LW_NoScrape");
                return;
            }
            if (GetBestKnife() == null)
            {
                Fail("GAMEPLAY_LW_NoScrape");
                return;
            }

            tempFurName = furName;

            GameAudioManager.PlayGuiConfirm();
            InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_ScrapeProgressBar"), 5f, 0f, 0f,
                            "PLAY_HARVESTINGLEATHER", null, false, true, new System.Action<bool, bool, float>(OnScrapeFurFinished));
            GameManager.GetInventoryComponent().RemoveGearFromInventory(tempFurName, 1);
        }
        private static void DamageTool(GearItem? tool, float amount)
        {
            if (tool == null) return;
            tool.Degrade(amount);
        }
        private static void OnScrapeFurFinished(bool success, bool playerCancel, float progress)
        {
            if (!success || playerCancel) return;

            string name = tempFurName.ToLowerInvariant();

            int yield;
            float knifeDamage;

            if (name.Contains("rabbit"))
            {
                yield = Settings.instance.rabbitYield;
                knifeDamage = 5f;
            }
            else if (name.Contains("moose") || name.Contains("bear"))
            {
                yield = Settings.instance.moosebearYield;
                knifeDamage = 15f;
            }
            else if (name.Contains("cougar"))
            {
                yield = Settings.instance.cougarYield;
                knifeDamage = 15f;
            }
            else
            {
                yield = Settings.instance.wolfdeerYield;
                knifeDamage = 10f;
            }

             DamageTool(GetBestKnife(), knifeDamage);
            GiveItem(LWGear.LeatherScraped, yield);
        }
        // === Add scraped leather to a tan-filled box =========================
        private static void OnLeatherAdd()
        {
            GearItem? thisGearItem = recipientBoxItem;
            if (thisGearItem == null) return;

            if (thisGearItem.name != LWGear.MetalBoxTanFilled)
            {
                Fail("GAMEPLAY_LW_NoLeatherScraped");
                return;
            }

            recipientBoxItemName = thisGearItem.name;

            if (UnitsInInventory(LWGear.LeatherScraped) < LeatherPerBox)
            {
                Fail("GAMEPLAY_LW_NoLeatherScraped");
                return;
            }

            GameAudioManager.PlayGuiConfirm();
            InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_TanLeatherProgressBar"), 5f, 0f, 0f,
                            "PLAY_PUTINPOTWATERACORNSSHELLED", null, false, true, new System.Action<bool, bool, float>(OnLeatherAddFinished));

            GameManager.GetInventoryComponent().RemoveGearFromInventory(LWGear.LeatherScraped, LeatherPerBox);
            GameManager.GetInventoryComponent().RemoveGearFromInventory(LWGear.MetalBoxTanFilled, 1);
        }
        private static void OnLeatherAddFinished(bool success, bool playerCancel, float progress)
        {
            if (!success || playerCancel) return;

            GiveItem(LWGear.MetalBoxTanning, 1);
        }
        // === Add tanning liquid to an empty box ==============================
        private static void OnTanningAdd()
        {
            GearItem? thisGearItem = tanningItem;
            if (thisGearItem == null) return;

            if (thisGearItem.name != LWGear.MetalBoxForge)
            {
                Fail("GAMEPLAY_LW_NoTanning");
                return;
            }

            tanningName = thisGearItem.name;

            if (UnitsInInventory(LWGear.CookedTanning) < Settings.instance.tanningAmount)
            {
                HUDMessage.AddMessage($"{Settings.instance.tanningAmount} {Localization.Get("GAMEPLAY_LW_NeedTanningAmount")} ");
                GameAudioManager.PlayGUIError();
                return;
            }

            GameAudioManager.PlayGuiConfirm();
            InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_AddTanningProgressBar"), 5f, 0f, 0f,
                            "PLAY_PUTINPOTWATER", null, false, true, new System.Action<bool, bool, float>(OnTanningAddFinished));

            GameManager.GetInventoryComponent().RemoveGearFromInventory(LWGear.CookedTanning, Settings.instance.tanningAmount);
            GameManager.GetInventoryComponent().RemoveGearFromInventory(LWGear.MetalBoxForge, 1);
        }
        private static void OnTanningAddFinished(bool success, bool playerCancel, float progress)
        {
            if (!success || playerCancel) return;

            GiveItem(LWGear.MetalBoxTanFilled, 1);
        }
        // === Crush bark into flour ===========================================
        private static void OnCrushBark()
        {
            GearItem? thisGearItem = barkItem;
            if (thisGearItem == null) return;

            var inv = GameManager.GetInventoryComponent();

            bool hasTool = inv.GearInInventory(LWGear.Hammer, 1) || (Settings.instance.noGrind && inv.GearInInventory(LWGear.Stone, 1));

            if (!hasTool)
            {
                Fail("GAMEPLAY_LW_NoBark");
                return;
            }

            if (UnitsInInventory(barkName) < Settings.instance.flourAmount)
            {
                HUDMessage.AddMessage($"{Settings.instance.flourAmount} {Localization.Get("GAMEPLAY_LW_NeedPieces")} ");
                GameAudioManager.PlayGUIError();
                return;
            }

            GameAudioManager.PlayGuiConfirm();
            InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_CrushProgressBar"), 3f, 0f, 0f,
                            "PLAY_CRAFTINGACORNSGRINDING", null, false, true, new System.Action<bool, bool, float>(OnCrushBarkFinished));
            GameManager.GetInventoryComponent().RemoveGearFromInventory(barkName, Settings.instance.flourAmount);
        }
        private static void OnCrushBarkFinished(bool success, bool playerCancel, float progress)
        {
            if (!success || playerCancel) return;

            GiveItem(LWGear.Flour, 1);
        }

        // === Piles ===========================================================

        private static string? GetPileResult(string gearName) => gearName switch
        {
            LWGear.BarkPrepared => LWGear.BarkPreparedPile,
            LWGear.BarkPreparedFried => LWGear.BarkPreparedFriedPile,
            LWGear.BirchPrepared => LWGear.BirchPreparedPile,
            LWGear.BirchPreparedFried => LWGear.BirchPreparedFriedPile,
            _ => null
        };
        private static string? GetUnPileResult(string gearName) => gearName switch
        {
            LWGear.BarkPreparedPile => LWGear.BarkPrepared,
            LWGear.BarkPreparedFriedPile => LWGear.BarkPreparedFried,
            LWGear.BirchPreparedPile => LWGear.BirchPrepared,
            LWGear.BirchPreparedFriedPile => LWGear.BirchPreparedFried,
            _ => null
        };
        private static string tempPileResult = "";
        private static string tempUnPileResult = "";

        private static void OnPileBark()
        {
            GearItem? thisGearItem = pileItem;
            if (thisGearItem == null) return;

            pileName = thisGearItem.name;
            string? result = GetPileResult(pileName);

            if (result == null)
            {
                Fail("GAMEPLAY_LW_NoBark");
                return;
            }
            if (UnitsInInventory(pileName) < PileSize)
            {
                Fail("GAMEPLAY_LW_NoBarkSmallPile");
                return;
            }

            tempPileResult = result;

            GameAudioManager.PlayGuiConfirm();
            InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_PileProgressBar"), 1f, 0f, 0f,
                            "PLAY_CRAFTINGACORNSSHELLING", null, false, true, new System.Action<bool, bool, float>(OnPileBarkFinished));
            GameManager.GetInventoryComponent().RemoveGearFromInventory(pileName, PileSize);
        }
        private static void OnPileBarkFinished(bool success, bool playerCancel, float progress)
        {
            if (!success || playerCancel) return;

            GiveItem(tempPileResult, 1);
        }
        private static void OnUnPileBark()
        {
            GearItem? thisGearItem = unPileItem;
            if (thisGearItem == null) return;

            unPileName = thisGearItem.name;
            string? result = GetUnPileResult(unPileName);

            if (result == null)
            {
                Fail("GAMEPLAY_LW_NoBark");
                return;
            }
            if (UnitsInInventory(unPileName) < 1)
            {
                Fail("GAMEPLAY_LW_NoBarkSmallPile");
                return;
            }

            tempUnPileResult = result;

            GameAudioManager.PlayGuiConfirm();
            InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_UnPileProgressBar"), 1f, 0f, 0f,
                            "PLAY_CRAFTINGACORNSSHELLING", null, false, true, new System.Action<bool, bool, float>(OnUnPileBarkFinished));
            GameManager.GetInventoryComponent().RemoveGearFromInventory(unPileName, 1);
        }

        private static void OnUnPileBarkFinished(bool success, bool playerCancel, float progress)
        {
            if (!success || playerCancel) return;

            GiveItem(tempUnPileResult, PileSize);
        }

        // === Birch bark: make fryable and revert ==============================

        private static void OnFryBirch()
        {
            GearItem? thisGearItem = fryBirchItem;
            if (thisGearItem == null) return;

            if (thisGearItem.name != LWGear.BirchPrepared || UnitsInInventory(LWGear.BirchPrepared) < 1)
            {
                Fail("GAMEPLAY_LW_NoBark");
                return;
            }

            GameAudioManager.PlayGuiConfirm();
            GameManager.GetInventoryComponent().RemoveGearFromInventory(LWGear.BirchPrepared, 1);
            GiveItem(LWGear.BirchPreparedFryable, 1);
        }
        private static void OnReturnBirch()
        {
            GearItem? thisGearItem = returnBirchItem;
            if (thisGearItem == null) return;

            if (thisGearItem.name != LWGear.BirchPreparedFryable || UnitsInInventory(LWGear.BirchPreparedFryable) < 1)
            {
                Fail("GAMEPLAY_LW_NoBark");
                return;
            }

            GameAudioManager.PlayGuiConfirm();
            GameManager.GetInventoryComponent().RemoveGearFromInventory(LWGear.BirchPreparedFryable, 1);
            GiveItem(LWGear.BirchPrepared, 1);
        }
        // === Place box =======================================================
        private static void OnPlaceBox()
        {
            GearItem? box = placeBoxItem;
            if (box == null) return;

            Panel_Inventory? panel = LeatherworksUtils.inventory ?? InterfaceManager.GetPanel<Panel_Inventory>();
            if (panel == null) return;

            int units = box.m_StackableItem != null ? box.m_StackableItem.m_Units : 1;

            GearItem dropped = box.Drop(units);
            if (dropped == null) return;

            panel.OnBack();
            dropped.PerformAlternativeInteraction();
        }

        // === Rope and string ==================================================

        private static void OnMakeRope()
        {
            GearItem? thisGearItem = ropeItem;
            if (thisGearItem == null) return;

            if (GetBestKnife() == null)
            {
                Fail("GAMEPLAY_LW_NoScrape");
                return;
            }
            if (thisGearItem.name != LWGear.BarkPrepared || UnitsInInventory(LWGear.BarkPrepared) < BarkPerRope)
            {
                Fail("GAMEPLAY_LW_NoRope");
                return;
            }

            ropeName = thisGearItem.name;

            GameAudioManager.PlayGuiConfirm();
            InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_MakeRopeProgressBar"), 2f, 3f, 0f,
                            "PLAY_HARVESTINGLEATHER", null, false, true, new System.Action<bool, bool, float>(OnMakeRopeFinished));
            GameManager.GetInventoryComponent().RemoveGearFromInventory(LWGear.BarkPrepared, BarkPerRope);
        }
        private static void OnMakeRopeFinished(bool success, bool playerCancel, float progress)
        {
            if (!success || playerCancel) return;

            DamageTool(GetBestKnife(), 3f);
            GiveItem(LWGear.BarkRope, 1);
        }
        private static void OnMakeString()
        {
            GearItem? thisGearItem = stringItem;
            if (thisGearItem == null) return;

            if (thisGearItem.name != LWGear.BarkRope || UnitsInInventory(LWGear.BarkRope) < RopePerString)
            {
                Fail("GAMEPLAY_LW_NoString");
                return;
            }

            stringName = thisGearItem.name;   // the old code wrote this into recipientBoxItemName

            GameAudioManager.PlayGuiConfirm();
            InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_MakeStringProgressBar"), 2f, 0f, 0f,
                            "PLAY_HARVESTINGLEATHER", null, false, true, new System.Action<bool, bool, float>(OnMakeStringFinished));
            GameManager.GetInventoryComponent().RemoveGearFromInventory(LWGear.BarkRope, RopePerString);
        }
        private static void OnMakeStringFinished(bool success, bool playerCancel, float progress)
        {
            if (!success || playerCancel) return;

            GiveItem(LWGear.StringBundle, 1);
        }
    }
}
