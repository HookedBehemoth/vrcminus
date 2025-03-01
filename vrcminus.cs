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
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using BepInEx.Unity.IL2CPP.Utils.Collections;
using UnityEngine;

namespace VRCMinus;

public class PluginComponent : MonoBehaviour
{
    public void Start()
    {
        VM.Logger.LogInfo("VRCMinus loaded!");
        StartCoroutine(WaitForUiManager().WrapToIl2Cpp());
    }

    public void Update()
    {
        try
        {
            //Shit that may re-appear so we just re-delete it all the time :)
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_VRCPlusExperiment").SetActive(false);
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/NewFeatureCallouts").SetActive(false);
            GameObject.Find("Canvas_MainMenu(Clone)/Container/Panel_MM_Wallet").SetActive(false);
            GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_MM_Profile/ScrollRect/Viewport/VerticalLayoutGroup/Row2/Badges").SetActive(false);
            GameObject.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_InviteResponse/ScrollRect/Viewport/VerticalLayoutGroup/Panel_AddPhotoPrompt").SetActive(false);
            GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Modal_MM_InviteResponse/MenuPanel/ScrollRect/Viewport/VerticalLayoutGroup/Panel_AddPhotoPrompt").SetActive(false);
            GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_MM_Profile/ScrollRect/Viewport/VerticalLayoutGroup/Row1/Profile/DetailsArea/UserIconAndCredits/Panel_MM_CreditsButton").SetActive(false);
        }
        catch { }
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

        VM.Logger.LogInfo("VRCMinus Dumbass special case shit!");

        //Dumbass special case shit
        GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_UserDetail/ScrollRect/Viewport/VerticalLayoutGroup/Row3/CellGrid_MM_Content/GiftBtn").transform.localScale = new Vector3(0,0,0); //can't delete this at all or shit breaks, so just hide it :)
        GameObject.Find("Canvas_MainMenu(Clone)/Container/MMParent/Menu_UserDetail/ScrollRect/Viewport/VerticalLayoutGroup/Row2/Badges").transform.localScale = new Vector3(0,0,0); //Also can't be removed or the whole profile menu dies
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
