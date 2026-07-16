using Il2Cpp;
using Il2CppNodeCanvas.Tasks.Actions;
using Il2CppProCore.Decals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Il2CppMono.Security.X509.X520;

namespace Leatherworks
{
    internal class LWFunctionalities
    {

        internal static string scrapeText;
        private static GameObject scrapeButton;
        internal static GearItem furItem;
        internal static string furName;

        internal static string addLeatherText;
        private static GameObject addLeatherButton;
        internal static GearItem recipientBoxItem;
        internal static string recipientBoxItemName;

        internal static string addTanningText;
        private static GameObject addTanningButton;
        internal static GearItem tanningItem;
        internal static string tanningName;

        internal static string crushBarkText;
        private static GameObject crushBarkButton;
        internal static GearItem barkItem;
        internal static string barkName;

        internal static string makeRopeText;
        private static GameObject makeRopeButton;
        internal static GearItem ropeItem;
        internal static string ropeName;

        internal static string makeStringText;
        private static GameObject makeStringButton;
        internal static GearItem stringItem;
        internal static string stringName;

        internal static string pileBarkText;
        private static GameObject pileBarkButton;
        internal static GearItem pileItem;
        internal static string pileName;

        internal static string unPileBarkText;
        private static GameObject unPileBarkButton;
        internal static GearItem unPileItem;
        internal static string unPileName;

        internal static string placeBoxText;
        private static GameObject placeBoxButton;
        internal static GearItem placeBoxItem;

        internal static string fryBirchText;
        private static GameObject fryBirchButton;
        internal static GearItem fryBirchItem;
        internal static GearItem fryBirchReplaceItem;
        internal static string fryBirchName;

        internal static string returnBirchText;
        private static GameObject returnBirchButton;
        internal static GearItem returnBirchItem;
        internal static string returnBirchName;

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

            GameObject equipButton = itemDescriptionPage.m_MouseButtonEquip;
            scrapeButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            scrapeButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(scrapeButton).text = scrapeText;

            addLeatherButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            addLeatherButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(addLeatherButton).text = addLeatherText;

            addTanningButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            addTanningButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(addTanningButton).text = addTanningText;

            crushBarkButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            crushBarkButton.transform.Translate(0, -0.1f, 0);
            Utils.GetComponentInChildren<UILabel>(crushBarkButton).text = crushBarkText;

            pileBarkButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            pileBarkButton.transform.Translate(0.36f, 0, 0);
            Utils.GetComponentInChildren<UILabel>(pileBarkButton).text = pileBarkText;

            unPileBarkButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            unPileBarkButton.transform.Translate(0.36f, 0, 0);
            Utils.GetComponentInChildren<UILabel>(unPileBarkButton).text = unPileBarkText;

            fryBirchButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            fryBirchButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(fryBirchButton).text = fryBirchText;

            returnBirchButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            returnBirchButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(returnBirchButton).text = returnBirchText;

            placeBoxButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            placeBoxButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(placeBoxButton).text = placeBoxText;

            makeRopeButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            makeRopeButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(makeRopeButton).text = makeRopeText;

            makeStringButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            makeStringButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(makeStringButton).text = makeStringText;

            AddAction(scrapeButton, new System.Action(OnScrapeFur));
            AddAction(addLeatherButton, new System.Action(OnLeatherAdd));
            AddAction(addTanningButton, new System.Action(OnTanningAdd));
            AddAction(crushBarkButton, new System.Action(OnCrushBark));
            AddAction(pileBarkButton, new System.Action(OnPileBark));
            AddAction(unPileBarkButton, new System.Action(OnUnPileBark));
            AddAction(fryBirchButton, new System.Action(OnFryBirch));
            AddAction(returnBirchButton, new System.Action(OnReturnBirch));
            AddAction(placeBoxButton, new System.Action(OnPlaceBox));
            AddAction(makeRopeButton, new System.Action(OnMakeRope));
            AddAction(makeStringButton, new System.Action(OnMakeString));

            SetScrapeFurActive(false);
            SetLeatherAddActive(false);
            SetTanningAddActive(false);
            SetCrushBarkActive(false);
            SetPileBarkActive(false);
            SetUnPileBarkActive(false);
            SetFryBirchActive(false);
            SetReturnBirchActive(false);
            SetPlaceBoxActive(false);
            SetMakeRopeActive(false);
            SetMakeStringActive(false);

        }
        private static void AddAction(GameObject button, System.Action action)
        {
            Il2CppSystem.Collections.Generic.List<EventDelegate> placeHolderList = new Il2CppSystem.Collections.Generic.List<EventDelegate>();
            placeHolderList.Add(new EventDelegate(action));
            Utils.GetComponentInChildren<UIButton>(button).onClick = placeHolderList;
        }
        internal static void SetScrapeFurActive(bool active)
        {
            NGUITools.SetActive(scrapeButton, active);
        }
        internal static void SetLeatherAddActive(bool active)
        {
            NGUITools.SetActive(addLeatherButton, active);
        }

        internal static void SetTanningAddActive(bool active)
        {
            NGUITools.SetActive(addTanningButton, active);
        }

        internal static void SetCrushBarkActive(bool active)
        {
            NGUITools.SetActive(crushBarkButton, active);
        }

        internal static void SetPileBarkActive(bool active)
        {
            NGUITools.SetActive(pileBarkButton, active);
        }

        internal static void SetUnPileBarkActive(bool active)
        {
            NGUITools.SetActive(unPileBarkButton, active);
        }

        internal static void SetFryBirchActive(bool active)
        {
            NGUITools.SetActive(fryBirchButton, active);
        }

        internal static void SetReturnBirchActive(bool active)
        {
            NGUITools.SetActive(returnBirchButton, active);
        }

        internal static void SetPlaceBoxActive(bool active)
        {
            NGUITools.SetActive(placeBoxButton, active);
        }

        internal static void SetMakeRopeActive(bool active)
        {
            NGUITools.SetActive(makeRopeButton, active);
        }

        internal static void SetMakeStringActive(bool active)
        {
            NGUITools.SetActive(makeStringButton, active);
        }

        private static void OnScrapeFur()
        {
            var knife1 = LeatherworksUtils.knife1;
            var knife2 = LeatherworksUtils.knife2;
            //var knife3 = LeatherworksUtils.knifecamp1;
            //var knife4 = LeatherworksUtils.knifecamp2;
            var thisGearItem = LWFunctionalities.furItem;
            furName = thisGearItem.gameObject.name;        
        
            if (thisGearItem == null) return;
            if (GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1) || GameManager.GetInventoryComponent().GearInInventory("GEAR_KnifeImprovised", 1))
            {
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_ScrapeProgressBar"), 5f, 0f, 0f,
                                "PLAY_HARVESTINGLEATHER", null, false, true, new System.Action<bool, bool, float>(OnScrapeFurFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(furName, 1);
            }
            else
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoScrape"));
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnScrapeFurFinished(bool success, bool playerCancel, float progress)
        {
            var knife1 = GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1);
            var knife2 = GameManager.GetInventoryComponent().GearInInventory("GEAR_KnifeImprovised", 1);
            //var knife3 = GameManager.GetInventoryComponent().GearInInventory(LeatherworksUtils.knifecamp1, 1);
            //var knife4 = GameManager.GetInventoryComponent().GearInInventory(LeatherworksUtils.knifecamp2, 1);


            float rabbitamount = Settings.instance.rabbitYield;
            int rabbityield = Convert.ToInt32(rabbitamount);

            float wolfdeeramount = Settings.instance.wolfdeerYield;
            int wolfdeeryield = Convert.ToInt32(wolfdeeramount);

            float moosebearamount = Settings.instance.moosebearYield;
            int moosebearyield = Convert.ToInt32(moosebearamount);

            if (furName.ToLowerInvariant().Contains("wolf") || furName.ToLowerInvariant().Contains("leatherhide"))
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.leatherParts, wolfdeeryield);

                if (GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1))
                {
                    knife1.m_CurrentHP = knife1.m_CurrentHP - 10;
                }
                else if (GameManager.GetInventoryComponent().GearInInventory("GEAR_KnifeImprovised", 1))
                {
                    knife2.m_CurrentHP = knife2.m_CurrentHP - 10;
                }
                //else if (GameManager.GetInventoryComponent().GearInInventory(knife3, 1))
                //{
                //    knife3.m_CurrentHP = knife3.m_CurrentHP - 10;
                //}
                //else if (GameManager.GetInventoryComponent().GearInInventory(knife4, 1))
                //{
                //    knife4.m_CurrentHP = knife4.m_CurrentHP - 20;
                //}
            }
            else if (furName.ToLowerInvariant().Contains("rabbit"))
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.leatherParts, rabbityield);
                
                if (GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1))
                {
                    knife1.m_CurrentHP = knife1.m_CurrentHP - 5;
                }
                else if (GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1))
                {
                    knife2.m_CurrentHP = knife2.m_CurrentHP - 5;
                }
                //else if (GameManager.GetInventoryComponent().GearInInventory(knife3, 1))
                //{
                //    knife3.m_CurrentHP = knife3.m_CurrentHP - 5;
                //}
                //else if (GameManager.GetInventoryComponent().GearInInventory(knife4, 1))
                //{
                //    knife4.m_CurrentHP = knife4.m_CurrentHP - 15;
                //}
            }
            else if (furName.ToLowerInvariant().Contains("moose") || furName.ToLowerInvariant().Contains("bear"))
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.leatherParts, moosebearyield);

                if (GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1))
                {
                    knife1.m_CurrentHP = knife1.m_CurrentHP - 15;
                }
                else if (GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1))
                {
                    knife2.m_CurrentHP = knife2.m_CurrentHP - 15;
                }
                //else if (GameManager.GetInventoryComponent().GearInInventory(knife3, 1))
                //{
                //    knife3.m_CurrentHP = knife3.m_CurrentHP - 15;
                //}
                //else if (GameManager.GetInventoryComponent().GearInInventory(knife4, 1))
                //{
                //    knife4.m_CurrentHP = knife4.m_CurrentHP - 25;
                //}
            }


        }
        private static void OnLeatherAdd()
        {
            var thisGearItem = LWFunctionalities.recipientBoxItem;
            GearItem leatherScraped = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_LeatherScraped");

            if (thisGearItem == null) return;
            if (leatherScraped == null)
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoLeatherScraped"));
                GameAudioManager.PlayGUIError();
                return;
            }
            if (thisGearItem.name == "GEAR_MetalBoxTanFilled")
            {
                recipientBoxItemName = thisGearItem.name;
                if (leatherScraped.m_StackableItem.m_Units < 5)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoLeatherScraped"));
                    GameAudioManager.PlayGUIError();
                    return;
                }
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_TanLeatherProgressBar"), 5f, 0f, 0f,
                                "PLAY_PUTINPOTWATERACORNSSHELLED", null, false, true, new System.Action<bool, bool, float>(OnLeatherAddFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(leatherScraped.name, 5);
                GearItem.Destroy(thisGearItem);
            }
            else
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoLeatherScraped"));
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnLeatherAddFinished(bool success, bool playerCancel, float progress)
        {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.boxTanStart, 1);
        }

        private static void OnTanningAdd()
        {
            var thisGearItem = LWFunctionalities.tanningItem;
            GearItem tanningliquid = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_CookedTanning");

            float amount = Settings.instance.tanningAmount;
            int amountint = Convert.ToInt32(amount);


            if (thisGearItem == null) return;
            if (tanningliquid == null)
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoTanning"));
                GameAudioManager.PlayGUIError();
                return;
            }
            if (thisGearItem.name == "GEAR_MetalBoxForge")
            {
                tanningName = thisGearItem.name;
                if (tanningliquid.m_StackableItem.m_Units < amountint)
                {
                    HUDMessage.AddMessage("You need " + Settings.instance.tanningAmount + " bottles of tanning for this action");
                    GameAudioManager.PlayGUIError();
                    return;
                }
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_AddTanningProgressBar"), 5f, 0f, 0f,
                                "PLAY_PUTINPOTWATER", null, false, true, new System.Action<bool, bool, float>(OnTanningAddFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(tanningliquid.name, amountint);
                GearItem.Destroy(thisGearItem);
            }
            else
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoTanning"));
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnTanningAddFinished(bool success, bool playerCancel, float progress)
        {
            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.tanFilledBox, 1);
        }
        private static void OnCrushBark()
        {

             var thisGearItem = LWFunctionalities.barkItem;
             float amount = Settings.instance.flourAmount;
             int amountint = Convert.ToInt32(amount);
             

            GearItem fried1 = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BarkPreparedFried");
            GearItem fried2 = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BarkPreparedFriedPile");

            if (thisGearItem == null) return;
            if (Settings.instance.noGrind == true)
            {
                if (GameManager.GetInventoryComponent().GearInInventory("GEAR_Stone", 1) || GameManager.GetInventoryComponent().GearInInventory("GEAR_Hammer", 1))
                {
                    if (thisGearItem.name == "GEAR_BarkPreparedFried")
                    {
                        barkName = thisGearItem.name;

                        if (fried1.m_StackableItem.m_Units < amountint)
                        {
                            HUDMessage.AddMessage("You requires " + Settings.instance.flourAmount + " pieces for this action");
                            GameAudioManager.PlayGUIError();
                            return;
                        }
                        GameAudioManager.PlayGuiConfirm();
                        InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_CrushProgressBar"), 3f, 0f, 0f,
                                        "PLAY_CRAFTINGACORNSGRINDING", null, false, true, new System.Action<bool, bool, float>(OnCrushBarkFinished));
                        GameManager.GetInventoryComponent().RemoveGearFromInventory(fried1.name, amountint);
                    }
                    else if (thisGearItem.name == "GEAR_BarkPreparedFriedPile")
                    {
                        barkName = thisGearItem.name;

                        if (fried2.m_StackableItem.m_Units < amountint / 5)
                        {
                            HUDMessage.AddMessage("You requires " + Settings.instance.flourAmount / 5 + " pieces for this action");
                            GameAudioManager.PlayGUIError();
                            return;
                        }
                        GameAudioManager.PlayGuiConfirm();
                        InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_CrushProgressBar"), 3f, 0f, 0f,
                                        "PLAY_CRAFTINGACORNSGRINDING", null, false, true, new System.Action<bool, bool, float>(OnCrushBarkFinished));
                        GameManager.GetInventoryComponent().RemoveGearFromInventory(fried2.name, amountint / 5);
                    }
                }
                else
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBark"));
                    GameAudioManager.PlayGUIError();
                }
            }
            else
            {
                if (GameManager.GetInventoryComponent().GearInInventory("GEAR_Hammer", 1))
                {
                    if (thisGearItem.name == "GEAR_BarkPreparedFried")
                    {
                        barkName = thisGearItem.name;

                        if (fried1.m_StackableItem.m_Units < amountint)
                        {
                            HUDMessage.AddMessage("You requires " + Settings.instance.flourAmount + " pieces for this action");
                            GameAudioManager.PlayGUIError();
                            return;
                        }
                        GameAudioManager.PlayGuiConfirm();
                        InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_CrushProgressBar"), 3f, 0f, 0f,
                                        "PLAY_CRAFTINGACORNSGRINDING", null, false, true, new System.Action<bool, bool, float>(OnCrushBarkFinished));
                        GameManager.GetInventoryComponent().RemoveGearFromInventory(fried1.name, amountint);
                    }
                    else if (thisGearItem.name == "GEAR_BarkPreparedFriedPile")
                    {
                        barkName = thisGearItem.name;

                        if (fried2.m_StackableItem.m_Units < amountint / 5)
                        {
                            HUDMessage.AddMessage("You requires " + Settings.instance.flourAmount / 5 + " pieces for this action");
                            GameAudioManager.PlayGUIError();
                            return;
                        }
                        GameAudioManager.PlayGuiConfirm();
                        InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_CrushProgressBar"), 3f, 0f, 0f,
                                        "PLAY_CRAFTINGACORNSGRINDING", null, false, true, new System.Action<bool, bool, float>(OnCrushBarkFinished));
                        GameManager.GetInventoryComponent().RemoveGearFromInventory(fried2.name, amountint / 5);
                    }
                }
                else
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBark"));
                    GameAudioManager.PlayGUIError();
                }
            }
        }
        private static void OnCrushBarkFinished(bool success, bool playerCancel, float progress)
        {
            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.flour, 1);
        }
        private static void OnPileBark()
        {

            var thisGearItem = LWFunctionalities.pileItem;

            GearItem birch = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BirchbarkPrepared");
            GearItem birchfried = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BirchbarkPreparedFried");
            GearItem notfried = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BarkPrepared");
            GearItem fried = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BarkPreparedFried");

            if (thisGearItem == null) return;

            if (thisGearItem.name == "GEAR_BarkPreparedFried")
            {
                pileName = thisGearItem.name;

                if (fried.m_StackableItem.m_Units < 5)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBarkSmallPile"));
                    GameAudioManager.PlayGUIError();
                    return;
                }
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_PileProgressBar"), 1f, 0f, 0f,
                                "PLAY_CRAFTINGACORNSSHELLING", null, false, true, new System.Action<bool, bool, float>(OnPileBarkFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(fried.name, 5);
            }
            else if (thisGearItem.name == "GEAR_BarkPrepared")
            {
                pileName = thisGearItem.name;

                if (notfried.m_StackableItem.m_Units < 5)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBarkSmallPile"));
                    GameAudioManager.PlayGUIError();
                    return;
                }
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_PileProgressBar"), 1f, 0f, 0f,
                                "PLAY_CRAFTINGACORNSSHELLING", null, false, true, new System.Action<bool, bool, float>(OnPileBarkFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(notfried.name, 5);
            }
            else if (thisGearItem.name == "GEAR_BirchbarkPrepared")
            {
                pileName = thisGearItem.name;

                if (birch.m_StackableItem.m_Units < 5)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBarkSmallPile"));
                    GameAudioManager.PlayGUIError();
                    return;
                }
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_PileProgressBar"), 1f, 0f, 0f,
                                "PLAY_CRAFTINGACORNSSHELLING", null, false, true, new System.Action<bool, bool, float>(OnPileBarkFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(birch.name, 5);
            }
            else if (thisGearItem.name == "GEAR_BirchbarkPreparedFried")
            {
                pileName = thisGearItem.name;

                if (birchfried.m_StackableItem.m_Units < 5)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBarkSmallPile"));
                    GameAudioManager.PlayGUIError();
                    return;
                }
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_PileProgressBar"), 1f, 0f, 0f,
                                "PLAY_CRAFTINGACORNSSHELLING", null, false, true, new System.Action<bool, bool, float>(OnPileBarkFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(birchfried.name, 5);
            }
            else
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBark"));
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnPileBarkFinished(bool success, bool playerCancel, float progress)
        {
            
            if (pileName == "GEAR_BarkPreparedFried")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.barkFriedPile, 1);
            }
            else if (pileName == "GEAR_BirchbarkPrepared")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.birchPile, 1);
            }
            else if (pileName == "GEAR_BirchbarkPreparedFried")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.birchFriedPile, 1);
            }
            else
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.barkPile, 1);
            }
        }

        private static void OnUnPileBark()
        {

            var thisGearItem = LWFunctionalities.unPileItem;

            GearItem birch = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BirchbarkPreparedPile");
            GearItem birchfried = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BirchbarkPreparedFriedPile");
            GearItem notfried = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BarkPreparedPile");
            GearItem fried = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BarkPreparedFriedPile");

            if (thisGearItem == null) return;

            if (thisGearItem.name == "GEAR_BarkPreparedFriedPile")
            {
                unPileName = thisGearItem.name;

                if (fried.m_StackableItem.m_Units < 1)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBarkSmallPile"));
                    GameAudioManager.PlayGUIError();
                    return;
                }

                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_UnPileProgressBar"), 1f, 0f, 0f,
                                "PLAY_CRAFTINGACORNSSHELLING", null, false, true, new System.Action<bool, bool, float>(OnUnPileBarkFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(fried.name, 1);
            }
            else if (thisGearItem.name == "GEAR_BarkPreparedPile")
            {
                unPileName = thisGearItem.name;

                if (notfried.m_StackableItem.m_Units < 1)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBarkSmallPile"));
                    GameAudioManager.PlayGUIError();
                    return;
                }

                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_UnPileProgressBar"), 1f, 0f, 0f,
                                "PLAY_CRAFTINGACORNSSHELLING", null, false, true, new System.Action<bool, bool, float>(OnUnPileBarkFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(notfried.name, 1);
            }
            else if (thisGearItem.name == "GEAR_BirchBarkPreparedPile")
            {
                unPileName = thisGearItem.name;

                if (birch.m_StackableItem.m_Units < 1)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBarkSmallPile"));
                    GameAudioManager.PlayGUIError();
                    return;
                }

                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_UnPileProgressBar"), 1f, 0f, 0f,
                                "PLAY_CRAFTINGACORNSSHELLING", null, false, true, new System.Action<bool, bool, float>(OnUnPileBarkFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(birch.name, 1);
            }
            else if (thisGearItem.name == "GEAR_BirchBarkPreparedFriedPile")
            {
                unPileName = thisGearItem.name;

                if (birchfried.m_StackableItem.m_Units < 1)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBarkSmallPile"));
                    GameAudioManager.PlayGUIError();
                    return;
                }

                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_UnPileProgressBar"), 1f, 0f, 0f,
                                "PLAY_CRAFTINGACORNSSHELLING", null, false, true, new System.Action<bool, bool, float>(OnUnPileBarkFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(birchfried.name, 1);
            }
            else
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoBark"));
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnUnPileBarkFinished(bool success, bool playerCancel, float progress)
        {

            if (unPileName == "GEAR_BarkPreparedFriedPile")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.barkFried, 5);
            }
            else if (unPileName == "GEAR_BirchBarkPreparedPile")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.birchClassic, 5);
            }
            else if (unPileName == "GEAR_BirchBarkPreparedFriedPile")
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.birchFried, 5);
            }
            else
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.bark, 5);
            }
        }

        private static void OnFryBirch()
        {

            var thisGearItem = LWFunctionalities.fryBirchItem;


            GearItem birch = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BirchbarkPrepared");

            if (thisGearItem == null) return;
           
            if (thisGearItem.name == "GEAR_BirchbarkPrepared")
            {
                GameAudioManager.PlayGuiConfirm();
                GameManager.GetInventoryComponent().RemoveGearFromInventory(birch.name, 1);
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.birchFry, 1);
            }
        }

        private static void OnReturnBirch()
        {

            var thisGearItem = LWFunctionalities.returnBirchItem;


            GearItem birchFry = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BirchbarkPreparedFryable");

            if (thisGearItem == null) return;

            if (thisGearItem.name == "GEAR_BirchBarkPreparedFryable")
            {
                GameAudioManager.PlayGuiConfirm();
                GameManager.GetInventoryComponent().RemoveGearFromInventory(birchFry.name, 1);
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.birchClassic, 1);

            }
        }

        private static void OnPlaceBox()
        {
            var toDrop = placeBoxItem?.m_StackableItem?.m_Units ?? 1;
            toDrop = Mathf.Clamp(toDrop, 0, placeBoxItem?.m_StackableItem?.m_Units ?? 1);
            var dropped = placeBoxItem.Drop(toDrop);
            LeatherworksUtils.inventory.OnBack();
            dropped.PerformAlternativeInteraction();
        }

        private static void OnMakeRope()
        {
            var knife1 = GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1);
            var knife2 = GameManager.GetInventoryComponent().GearInInventory("GEAR_KnifeImprovised", 1);
            //var knife3 = GameManager.GetInventoryComponent().GearInInventory(LeatherworksUtils.knifecamp1, 1);
            //var knife4 = GameManager.GetInventoryComponent().GearInInventory(LeatherworksUtils.knifecamp2, 1);
            var thisGearItem = LWFunctionalities.ropeItem;
            GearItem bark = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BarkPrepared");

            if (thisGearItem == null) return;
            if (GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1) || GameManager.GetInventoryComponent().GearInInventory("GEAR_KnifeImprovised", 1))
            {
                
                
                if (bark == null)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoRope"));
                    GameAudioManager.PlayGUIError();
                    return;
                }
                if (thisGearItem.name == "GEAR_BarkPrepared")
                {
                    if (bark.m_StackableItem.m_Units < 4)
                    {
                        HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoRope"));
                        GameAudioManager.PlayGUIError();
                        return;
                    }
                    GameAudioManager.PlayGuiConfirm();
                    InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_MakeRopeProgressBar"), 2f, 3f, 0f,
                                    "PLAY_HARVESTINGLEATHER", null, false, true, new System.Action<bool, bool, float>(OnMakeRopeFinished));
                    GameManager.GetInventoryComponent().RemoveGearFromInventory(bark.name, 4);
                }
                else
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoRope"));
                    GameAudioManager.PlayGUIError();
                }
            }
            else
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoScrape"));
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnMakeRopeFinished(bool success, bool playerCancel, float progress)
        {
            var knife1 = GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1);
            var knife2 = GameManager.GetInventoryComponent().GearInInventory("GEAR_KnifeImprovised", 1);
            //var knife3 = GameManager.GetInventoryComponent().GearInInventory(LeatherworksUtils.knifecamp1, 1);
            //var knife4 = GameManager.GetInventoryComponent().GearInInventory(LeatherworksUtils.knifecamp2, 1);
            if (GameManager.GetInventoryComponent().GearInInventory("GEAR_Knife", 1))
            {
                knife1.m_CurrentHP = knife1.m_CurrentHP - 3;
            }    
            else if (GameManager.GetInventoryComponent().GearInInventory("GEAR_KnifeImprovised", 1))
            {
                knife2.m_CurrentHP = knife2.m_CurrentHP - 4;
            }
            //else if (GameManager.GetInventoryComponent().GearInInventory(knife3, 1))
            //{
            //    knife3.m_CurrentHP = knife3.m_CurrentHP - 3;
            //}
            //else if (GameManager.GetInventoryComponent().GearInInventory(knife4, 1))
            //{
            //    knife4.m_CurrentHP = knife4.m_CurrentHP - 7;
            //}

            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.barkrope, 1);
        }

        private static void OnMakeString()
        {
            var thisGearItem = LWFunctionalities.stringItem;
            GearItem rope  = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_BarkRope");

            if (thisGearItem == null) return;
            if (rope == null)
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoString"));
                GameAudioManager.PlayGUIError();
                return;
            }
            if (thisGearItem.name == "GEAR_BarkRope")
            {
                recipientBoxItemName = thisGearItem.name;
                if (rope.m_StackableItem.m_Units < 3)
                {
                    HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoString"));
                    GameAudioManager.PlayGUIError();
                    return;
                }
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_LW_MakeStringProgressBar"), 2f, 0f, 0f,
                                "PLAY_HARVESTINGLEATHER", null, false, true, new System.Action<bool, bool, float>(OnMakeStringFinished));
                GameManager.GetInventoryComponent().RemoveGearFromInventory(rope.name, 3);
            }
            else
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_LW_NoString"));
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnMakeStringFinished(bool success, bool playerCancel, float progress)
        {
            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(LeatherworksUtils.stringbundle, 1);
        }

    }
}
