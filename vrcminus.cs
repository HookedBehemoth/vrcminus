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
                    try { GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_VRCPlusExperiment").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/NewFeatureCallouts").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/Panel_MM_Wallet").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Panel_MM_Header/HeaderRight/Cell_Wallet_Contents/").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Viewport/VerticalLayoutGroup/VRC+ Upsell").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Header_MM_H2/RightItemContainer/ExpiredBtn").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Profile/User profile ScrollRect/Viewport/VerticalLayoutGroup/Row1/Profile/DetailsArea/ScrollRect/Viewport/VerticalLayoutGroup/Field_AgeVerification").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_UserDetail/ScrollRect/Viewport/VerticalLayoutGroup/Row1/Profile/DetailsArea/ScrollRect/Viewport/VerticalLayoutGroup/Field_AgeVerification").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Modal_MM_InviteResponse/MenuPanel/ScrollRect/Viewport/VerticalLayoutGroup/Panel_AddPhotoPrompt/Photo_VRCPlus_Message").SetActive(false); } catch {}
                    try { GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_InviteResponse/ScrollRect/Viewport/VerticalLayoutGroup/Panel_AddPhotoPrompt/Photo_VRCPlus_Message").SetActive(false); } catch {}
                    //n menu compatibility
                    try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Wing_Right/Container/InnerContainer/Explore/ScrollRect/Viewport/VerticalLayoutGroup/Cell_Wing_Explore_HelpArticle(Clone)")); } catch {}
                    try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Wing_Right/Container/InnerContainer/Explore/ScrollRect/Viewport/VerticalLayoutGroup/Cell_Wing_Explore_HelpTopic(Clone)")); } catch {}
                    try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Wing_Left/Container/InnerContainer/Explore/ScrollRect/Viewport/VerticalLayoutGroup/Cell_Wing_Explore_HelpArticle(Clone)")); } catch {}
                    try { GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Wing_Left/Container/InnerContainer/Explore/ScrollRect/Viewport/VerticalLayoutGroup/Cell_Wing_Explore_HelpTopic(Clone)")); } catch {}
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
        while (GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners") == null)
            yield return new WaitForSeconds(1f);

        VM.Logger.LogInfo("VRCMinus Nuking!");

        GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners"));
        GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Dashboard/ScrollRect_MM/Viewport/Content/Panel"));
        GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Viewport/VerticalLayoutGroup/VRC+ Upsell"));
        GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Page_VRCPlusHighlight"));
        GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Page_Marketplace"));
        GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Page_Help&Info"));
        GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_QM_SocialIdentity/Panel_MM_Wallet/Cell_Wallet_Contents"));
        GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Settings/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Viewport/VerticalLayoutGroup/UserInterface/BackgroundDesigns"));
        GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions/Button_GiftVRCPlus"));
        GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_AvatarDetail/Panel_MM_ScrollRect/Viewport/VerticalLayoutGroup/Cell_MM_AvatarDetails/Horizontal Layout Group/Button_Favorite/Badge"));
        GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_Dashboard/ScrollRect_MM/Viewport/Content/Panel/Carousel_Banners"));
        GameObject.Destroy(GameObject.Find("Canvas_MainMenu(Clone)/Container/PageButtons/HorizontalLayoutGroup/Marketplace_Button_Tab"));
        GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_WorldActions/Button_GiftDrop"));
        GameObject.Destroy(GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Camera/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/Button_PrintCamera"));

        VM.Logger.LogInfo("VRCMinus Dumbass special case shit!");

        //Dumbass special case shit
        GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_UserDetail/ScrollRect/Viewport/VerticalLayoutGroup/Row3/CellGrid_MM_Content/GiftBtn").transform.localScale = new Vector3(0,0,0); //can't delete this at all or shit breaks, so just hide it :)
        GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_UserDetail/ScrollRect/Viewport/VerticalLayoutGroup/Row2/Badges").transform.localScale = new Vector3(0,0,0); //Also can't be removed or the whole profile menu dies
        GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/HeaderOffset/Menu_MM_Profile/User profile ScrollRect/Viewport/VerticalLayoutGroup/Row2/Badges").transform.localScale = new Vector3(0,0,0); //Also can't be removed or the whole profile menu dies
        GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Header_MM_H2/RightItemContainer/ExpiredBtn/Background_Button").SetActive(false); //started breaking the avatar menu when deleted
        GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_Avatars/Menu_MM_DynamicSidePanel/Panel_SectionList/ScrollRect_Navigation_Container/ScrollRect_Content/Header_MM_H2/RightItemContainer/ExpiredBtn/Text_ButtonName").SetActive(false); //started breaking the avatar menu when deleted
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
