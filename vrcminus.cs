/*
 * Copyright (c) 2021-2022 HookedBehemoth
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms and conditions of the GNU General Public License,
 * version 3, as published by the Free Software Foundation.
 *
 * This program is distributed in the hope it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
 * more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using BepInEx.Unity.IL2CPP.Utils.Collections;
using UnityEngine;
using System.Linq;
using System.Linq.Expressions;

namespace VRCMinus;

public class PluginComponent : MonoBehaviour
{
    public void Start()
    {
        VM.Logger.LogInfo("VRCMinus loaded!");
        StartCoroutine(WaitForUiManager().WrapToIl2Cpp());
        StartCoroutine(UiThread().WrapToIl2Cpp());
    }

    private static System.Collections.IEnumerator UiThread()
    {
        while (true) {
            try {
                if(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window").GetComponent<UnityEngine.UI.GraphicRaycaster>().IsActive() || GameObject.Find("UserInterface/Canvas_MainMenu(Clone)").GetComponent<UnityEngine.UI.GraphicRaycaster>().IsActive()) {
                    //Shit that may re-appear so we just re-delete it all the time :)
                    try { GameObject.Find("InventoryVRCPlusPanel").SetActive(false); } catch {}
                    try { GameObject.Find("InventoryVRCPlusWarning(Clone)").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_UserDetail(Clone)/ScrollRect/Viewport/VerticalLayoutGroup/Row3/CellGrid_MM_Content/GiftBtn").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Profile(Clone)/User profile ScrollRect/Viewport/VerticalLayoutGroup/Row2/Badges").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_UserDetail(Clone)/ScrollRect/Viewport/VerticalLayoutGroup/Row2/Badges").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Header_MM_H2/RightItemContainer/ExpiredBtn/Background_Button").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Header_MM_H2/RightItemContainer/ExpiredBtn/Text_ButtonName").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_VRCPlus_Unsubscribed").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/NewFeatureCallouts").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/Panel_MM_Wallet").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Panel_MM_Header/Content/HeaderRight/Cell_Wallet_Contents").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Viewport/VerticalLayoutGroup/VRC+ Upsell").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Header_MM_H2/RightItemContainer/ExpiredBtn").SetActive(false); } catch {}
                    try { GameObject.Find("Profile/UserIconAndCredits").SetActive(false); } catch {}
                    try { GameObject.Find("VerticalLayoutGroup/Field_AgeVerification").SetActive(false); } catch {}
                    try { GameObject.Find("ScrollRect/Viewport/VerticalLayoutGroup/Panel_AddPhotoPrompt").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Avatars_AVM(Clone)/Dynamic_Content_Container/Viewport/Vertical_Layout_Group/Content_Container/Panel_My_Avatars_Panel/Panel_SectionList/ScrollRect_Navigation_Container/Navigation_Container/Banner_MoreFavoriteAvatars").SetActive(false); } catch {}
                    try { GameObject.Destroy(GameObject.Find("Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Stickers")); } catch {}
                    // _Application 4e86df1c-b936-40d6-a115-379ae54aac4c/UserInterface/Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_Dashboard(Clone)/ScrollRect_MM/Viewport/Content/Panel/Carousel_Banners
                    // try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_QM_Launchpad(Clone)/ScrollRect_MM/Viewport/Content/Panel/Carousel_Banners").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_Dashboard(Clone)/ScrollRect_MM/Viewport/Content/Panel/Carousel_Banners").SetActive(false); } catch {}
                    try { GameObject.Find("Page_MM_Inventory_Emoji/Upsell_Buttons").SetActive(false); } catch {}
                    try { GameObject.Find("Page_MM_Inventory_Emoji/Inventory_Info").SetActive(false); } catch {}
                    try { GameObject.Find("Page_MM_Inventory_Stickers/Upsell_Buttons").SetActive(false); } catch {}
                    try { GameObject.Find("Page_MM_Inventory_Stickers/Inventory_Info").SetActive(false); } catch {}
                    try { GameObject.Find("Page_MM_Inventory_Items/Upsell_Buttons").SetActive(false); } catch {}
                    try { GameObject.Find("Page_MM_Inventory_Items/Inventory_Info").SetActive(false); } catch {}
                    try { GameObject.Find("Page_MM_Inventory_Cosmetics/Upsell_Buttons").SetActive(false); } catch {}
                    try { GameObject.Find("Page_MM_Inventory_Cosmetics/Inventory_Info").SetActive(false); } catch {}
                    //n mod compatibility
                    try { GameObject.Destroy(GameObject.Find("Container/InnerContainer/Explore/ScrollRect/Viewport/VerticalLayoutGroup/Cell_Wing_Explore_HelpArticle(Clone)")); } catch {}
                    try { GameObject.Destroy(GameObject.Find("Container/InnerContainer/Explore/ScrollRect/Viewport/VerticalLayoutGroup/Cell_Wing_Explore_HelpTopic(Clone)")); } catch {}
                    // New Avatar Explore Menu
                    try {
                        if (GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Avatars_AVM(Clone)/Dynamic_Content_Container/Viewport/Vertical_Layout_Group/Content_Container/Panel_Explore_Avatars_Panel/Content_Scroll/Viewport/Vertical_Layout_Group/Content_Avatars/Avatar_Categories/wholesomechungus") == null) {
                            var avatarsMenu = GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Avatars_AVM(Clone)/Dynamic_Content_Container/Viewport/Vertical_Layout_Group/Content_Container/Panel_Explore_Avatars_Panel/Content_Scroll/Viewport/Vertical_Layout_Group/Content_Avatars/Avatar_Categories");
                            for (int i = avatarsMenu.transform.childCount -3; i >= 0; i--) { // The last two are probably always going to be the free ones, fuck vrchat btw
                                GameObject.Destroy(avatarsMenu.transform.GetChild(i).gameObject);
                            }
                            for (int i = avatarsMenu.transform.childCount + 1; i >= 0; i--) {
                                avatarsMenu.transform.GetChild(i).gameObject.name = "wholesomechungus";
                            }
                        }
                    } catch {}
                    // Avatars List Categories
                    try {
                        var avatarsMenu = GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Avatars_AVM(Clone)/Dynamic_Content_Container/Viewport/Vertical_Layout_Group/Content_Container/Panel_My_Avatars_Panel/Panel_SectionList/ScrollRect_Navigation_Container/Navigation_Container/ScrollRect_Navigation/Viewport/VerticalLayoutGroup/Categories");
                        avatarsMenu.transform.GetChild(8).gameObject.SetActive(false);
                        avatarsMenu.transform.GetChild(7).gameObject.SetActive(false);
                        avatarsMenu.transform.GetChild(6).gameObject.SetActive(false);
                        avatarsMenu.transform.GetChild(5).gameObject.SetActive(false);
                        avatarsMenu.transform.GetChild(4).gameObject.SetActive(false);
                        avatarsMenu.transform.GetChild(1).gameObject.SetActive(false);
                    } catch {}
                    // Silly haha clock menu xd
                    try {
                        var clockMenu = GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_QM_ClockMode/ScrollRect/Viewport/VerticalLayoutGroup");
                        clockMenu.transform.GetChild(3).gameObject.SetActive(false);
                        clockMenu.transform.GetChild(5).gameObject.SetActive(false);
                    } catch {}
                }
            } catch {}
            // Nameplates
            try {
                GameObject nameplateManager = GameObject.Find("NameplateManager");

                // Hide Pronoun Text
                var nameplateTexts = nameplateManager.GetComponentsInChildren<TextMeshProUGUI1PublicObBoMaUnique>();
                foreach (var nameplateText in nameplateTexts) {
                    try {
                        if (nameplateText.name == "Pronouns Text") { nameplateText.enabled = false; }
                    } catch {}
                }
                
                // Hide Icons
                var nameplateRects = nameplateManager.GetComponentsInChildren<UnityEngine.RectTransform>();
                foreach (var nameplateRect in nameplateRects) {
                    try {
                        if (nameplateRect.transform.parent.gameObject.name == "Contents" && nameplateRect.gameObject.name == "Icon") {
                            nameplateRect.gameObject.active = false;
                        }
                    } catch {}
                }
            } catch {}
            yield return new WaitForSeconds(0.25f);
        }
    }

    private static System.Collections.IEnumerator WaitForUiManager()
    {
        VM.Logger.LogInfo("VRCMinus Waiting!");

        /* Wait for VRCUiManager init */
        while (GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_QM_Launchpad/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners") == null)
            yield return new WaitForSeconds(1f);

        // _Application 4e86df1c-b936-40d6-a115-379ae54aac4c/UserInterface/Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_QM_Launchpad/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners

        VM.Logger.LogInfo("VRCMinus Nuking!");

        // try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_QM_Launchpad/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners")); } catch { }
        try { GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_QM_Launchpad/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners").SetActive(false); } catch {}
        // try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_QM_Launchpad/ScrollRect_MM/Viewport/Content/Panel")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Viewport/VerticalLayoutGroup/VRC+ Upsell")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Page_VRC_Plus_Unsubscribed_Button_Tab")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Page_Marketplace")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Page_Help&Info")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_QM_SocialIdentity/Layout/Panel_MM_Wallet/Cell_Wallet_Contents")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Settings/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Viewport/VerticalLayoutGroup/UserInterface/BackgroundDesigns")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions/Button_GiftVRCPlus")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_AvatarDetail/Panel_MM_ScrollRect/Viewport/VerticalLayoutGroup/Cell_MM_AvatarDetails/Horizontal Layout Group/Button_Favorite/Badge")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Marketplace_Button_Tab")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_WorldActions/Button_GiftDrop")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Camera/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/Button_PrintCamera")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_Settings/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Viewport/VerticalLayoutGroup/TrackingAndIk/CameraTracking")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_Settings/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Viewport/VerticalLayoutGroup/UserInterface/BackgroundDesigns")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_QM_SocialIdentity/User/UserIcon")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Panel_MM_Header/HeaderLeft/User/UserIcon")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Modal_MM_EditUserProfile/MenuPanel/ScrollRect/Viewport/VerticalLayoutGroup/Header_Pronouns")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Modal_MM_EditUserProfile/MenuPanel/ScrollRect/Viewport/VerticalLayoutGroup/EditPronouns")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Camera/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/Button_Drone")); } catch {}
        // try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_QM_Launchpad/Header_H1/RightItemContainer/Button_QM_Inventory")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Groups(Clone)/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Viewport/Panel_GroupLandingPage/InfoHeader")); } catch {}
        // _Application 4e86df1c-b936-40d6-a115-379ae54aac4c/UserInterface/Canvas_MainMenu(Clone)/Container/PageButtons/Shop_Button_Tab
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Live_Now_Button_Tab")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Shop_Button_Tab")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/CentralMarketplace_Button_Tab")); } catch {}
        try { GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Profile(Clone)/Navigation_Container/Navigation_Toggles/Wallet_Toggle/")); } catch {}
        
        //These don't seem like they re-enable themselves on their own, but we'll see I guess lole
        try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Profile(Clone)/Inventory_Container/ScrollRect_Navigation/Viewport/VerticalLayoutGroup/Cell_MM_SidebarListItem - Photo Gallery").SetActive(false); } catch {}
        try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Profile(Clone)/Inventory_Container/ScrollRect_Navigation/Viewport/VerticalLayoutGroup/Cell_MM_SidebarListItem - Prints").SetActive(false); } catch {}
        try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Profile(Clone)/Inventory_Container/ScrollRect_Navigation/Viewport/VerticalLayoutGroup/Cell_MM_SidebarListItem - User Icons").SetActive(false); } catch {}
    }
}


[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess("VRChat.exe")]
public class VM : BasePlugin
{
    public static ManualLogSource Logger { get; private set; }
    public override void Load()
    {
        Logger = Log;
        AddComponent<PluginComponent>();
    }
}
