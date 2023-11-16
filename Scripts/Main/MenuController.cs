using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine.UI;
using SVGImporter;
using TMPro;
using AEP_Utilities;

public class MenuController : MonoBehaviour
{
    public GameObject CanvasAEP;
    public GameObject panelContent;
    public XmlDocument xmlMediaList = new XmlDocument();

    private static MenuController self;
    private GameObject panelContentBtns;
    private GameObject panelHelp;
    private GameObject panelMedia;
    private GameObject panelAbout;
    private GameObject panelThanks;
    private GameObject panelSponsors;
    private GameObject panelMainButtons;
    private GameObject pvMainButtons;
    private string stringIntSVG;
    private GridLayoutGroup gridLayoutCMedia;
    private float floatPanelContentsY;
    private float floatHiddenPanelsX;
    private float floatFontSize;
    private string stringActivePanel;
    private Button buttonDownloadSelected;
    private Button buttonDownloadAll;
    private TMP_Text tmpResolution;
    private int downloadCount;
    public List<MediaButton> downloadList;

    public static GridLayoutGroup GridLayoutCMedia;

#region Global Functions ------------------------------------------------------------------------------------
    void Start()
	{
        SceneManager.sceneLoaded += OnSceneLoaded;
        InitMenu();
        //Invoke("Tmp", 5.0f);
	}

//------------------------------------------------------------------------------------
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        for (int i = 0; i < gridLayoutCMedia.transform.childCount; i++)
        {
            if (PlayerPrefs.GetString(gridLayoutCMedia.transform.GetChild(i).GetComponent<MediaButton>().playerPrefsValue) == "Yes")
            {
                gridLayoutCMedia.transform.GetChild(i).GetComponent<MediaButton>().setDownloadedState();
            }
        }
    }
#endregion

#region Custom Functions ------------------------------------------------------------------------------------
	void InitMenu()
	{
        CanvasAEP = GameObject.Find("AEP_Menu_Canvas");
        self = this;
        panelContentBtns = GameObject.Find("Pnl_ContentBtns");
        panelMainButtons = GameObject.Find("Pnl_Main_Buttons");
        pvMainButtons = GameObject.Find("Pv_Main_Buttons");
        panelContent = GameObject.Find("Pnl_Content");
        panelHelp = GameObject.Find("Pnl_Help");
        panelMedia = GameObject.Find("Pnl_Media");
        panelAbout = GameObject.Find("Pnl_About");
        panelThanks = GameObject.Find("Pnl_Thanks");
        gridLayoutCMedia = GameObject.Find("C_Media").GetComponent<GridLayoutGroup>();
        buttonDownloadSelected = GameObject.Find("Btn_DownloadSelected").GetComponent<Button>();
        buttonDownloadAll = GameObject.Find("Btn_DownloadAll").GetComponent<Button>();
        tmpResolution = GameObject.Find("TMP_ScreenResolution").GetComponent<TMP_Text>();

        GridLayoutCMedia = gridLayoutCMedia;

        downloadList = new List<MediaButton>();

        //Temp, remove when Sponsors panel is finished
        GameObject.Find("Btn_Sponsors").SetActive(false);

        if (CanvasAEP)
        {
            //Setting panel positions
            floatHiddenPanelsX = CanvasAEP.GetComponent<RectTransform>().rect.width;
            Debug.Log(floatHiddenPanelsX);

            if (panelContent)
            {
                
                panelContent.GetComponent<RectTransform>().position = new Vector2(panelContent.GetComponent<RectTransform>().position.x,
                                                                          -panelContent.GetComponent<RectTransform>().position.y);
                floatPanelContentsY = panelContent.GetComponent<RectTransform>().anchoredPosition.y;
                Debug.Log(floatPanelContentsY);
            }
            else if (!panelContent)
            {
                Debug.LogError("MenuController - InitMenu: pnl_Contents is empty!!!");
            }

            SetPanelPositionX(panelHelp, floatHiddenPanelsX);
            SetPanelPositionX(panelMedia, floatHiddenPanelsX);
            SetPanelPositionX(panelAbout, floatHiddenPanelsX);
            SetPanelPositionX(panelThanks, floatHiddenPanelsX);

            //V2 Init buttons
            //Temporary disabling Image, Object, and GPS buttons
            EnableImageButton("Btn_ImageScan", false);
            EnableImageButton("Btn_ObjectScan", false);
            EnableImageButton("Btn_GPS", false);

            //Disable Info Panel Interactivity
            EnablePanelInteractivity("Pnl_Info", false);

            //Hiding Info items
            EnableSVGImage("Img_Unable", false);
            EnableSVGImage("Img_Download", false);
            EnableSVGImage("Img_ScanStart", false);
            EnableSVGImage("Img_TapActivate", false);
            EnableSVGImage("Img_TapColor", false);
            EnableSVGImage("Img_TapColorMagic", false);
            EnableSVGImage("Img_TapDrag", false);

            //TweenScaleImage("Img_ScanStart", 1.5f, 2.0f, LeanTweenType.easeInOutElastic, -1, 3.0f);
            EnablePanel("Pnl_Loading", false);

            //Disable the Downloaded Selected button
            EnableButton(buttonDownloadSelected, false);

            if (Debug.isDebugBuild || Application.isEditor)
            {
                tmpResolution.gameObject.SetActive(true);
                tmpResolution.text = Screen.width.ToString() + "x" + Screen.height.ToString();
            }
            else
            {
                tmpResolution.gameObject.SetActive(false);
            }

            xmlMediaList = getXML((TextAsset)Resources.Load("Media List/MediaList"));

            XmlNodeList mediaItems = xmlMediaList.GetElementsByTagName("Piece");

            downloadCount = mediaItems.Count;
            
            foreach (XmlNode mediaPiece in mediaItems)
            {
                XmlNodeList pieceContent = mediaPiece.ChildNodes;

                string stringPieceName = "";
                string stringThumbnail = "";
                string stringAssetBundle = "";
                string stringPlayerPref = "";

                for (int i = 0; i < pieceContent.Count; i++)
                {
                    if (pieceContent[i].Name == "Name")
                    {
                        stringPieceName = pieceContent[i].InnerText;
                    }
                    else if (pieceContent[i].Name == "Thumbnail")
                    {
                        stringThumbnail = pieceContent[i].InnerText;
                    }
                    else if (pieceContent[i].Name == "Bundle")
                    {
                        stringAssetBundle = pieceContent[i].InnerText;
                    }
                    else if (pieceContent[i].Name == "PlayerPrefs")
                    {
                        stringPlayerPref = pieceContent[i].InnerText;
                    }
                }

                MediaButton mediaButton = new MediaButton(stringPieceName, stringThumbnail, stringAssetBundle, stringPlayerPref);
            }

            gridLayoutCMedia.GetComponent<RectTransform>().sizeDelta = new Vector2(gridLayoutCMedia.GetComponent<RectTransform>().sizeDelta.x,
                (gridLayoutCMedia.transform.childCount * 75) + (gridLayoutCMedia.transform.childCount * 8));
            
            //Checking if this is the first time the app has been opened
            CheckFirstRun();

            for (int i = 0; i < gridLayoutCMedia.transform.childCount; i++)
            {
                if (PlayerPrefs.GetString(gridLayoutCMedia.transform.GetChild(i).GetComponent<MediaButton>().playerPrefsValue) == "Yes")
                {
                    downloadCount--;
                }
            }

            if (downloadCount == 0)
            {
                EnableButton(buttonDownloadAll, false);
            }
        }
        else if (!CanvasAEP)
        {
            Debug.LogError("MenuController: CanvasAEP is empty!!!");
        }
	}

//------------------------------------------------------------------------------------
    /// <summary>
    /// Shows or hides a panel. Panel must have the Canvas Group component
    /// </summary>
    /// <param name="panelName">Name of the panel as a string.</param>
    /// <param name="enable">If true, the panel is visable and interactable.</param>
    public static void EnablePanel(string panelName, bool enable)
    {
        CanvasGroup panel = GameObject.Find(panelName).GetComponent<CanvasGroup>();

        if (panel)
        {
            switch (enable)
            {
                case true:
                    panel.alpha = 1;
                    panel.interactable = true;
                    break;

                case false:
                    panel.alpha = 0;
                    panel.interactable = false;
                    break;
            }
        }
        else if (!panel)
        {
            Debug.LogError("MenuController - EnablePanel: " + panelName + " does not have a Canvas Group component!!!");
        }
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Shows or hides a panel. Panel must have the 
    /// </summary>
    /// <param name="panelName">The Game Object variable of the panel.</param>
    /// <param name="enable">If true, the panel is visable and interactable.</param>
    public static void EnablePanel(GameObject panelName, bool enable)
    {
        CanvasGroup panel = panelName.GetComponent<CanvasGroup>();
        
        try
        {
            switch (enable)
            {
                case true:
                    panel.alpha = 1;
                panel.interactable = true;
                break;

                case false:
                    panel.alpha = 0;
                panel.interactable = false;
                break;
            }
        }
        catch(MissingReferenceException)
        {
            Debug.LogError("MenuController - EnablePanel: " + panelName.name + " does not have a Canvas Group component!!!");
        }
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the currently active panel
    /// </summary>
    /// <param name="panelName">The name of the panel</param>
    public void SetActivePanel(string panelName)
    {
        stringActivePanel = panelName;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the alpha of a panel
    /// </summary>
    /// <param name="panelName">The name of the panel</param>
    /// <param name="alpha">Value to set the alpha to, must be between 0 and 1</param>
    public static void SetPanelAlpha(string panelName, float alpha)
    {
        CanvasGroup panel = GameObject.Find(panelName).GetComponent<CanvasGroup>();

        panel.alpha = alpha;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the alpha of a panel
    /// </summary>
    /// <param name="panelName">The GameObject variable of the panel</param>
    /// <param name="alpha">Value to set the alpha to, must be between 0 and 1</param>
    public static void SetPanelAlpha(GameObject panelName, float alpha)
    {
        CanvasGroup panel = panelName.GetComponent<CanvasGroup>();

        panel.alpha = alpha;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Enables/disables the Panel Interactivity option of a panel
    /// </summary>
    /// <param name="panelName">The name of a panel</param>
    /// <param name="enable">If true, enable the Panel Interactivity option</param>
    public static void EnablePanelInteractivity(string panelName, bool enable)
    {
        CanvasGroup panel = GameObject.Find(panelName).GetComponent<CanvasGroup>();

        panel.interactable = enable;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Enables/disables the Panel Interactivity option of a panel
    /// </summary>
    /// <param name="panelName">The GameObject variable of a panel</param>
    /// <param name="enable">If true, enable the Panel Interactivity option</param>
    public static void EnablePanelInteractivity(GameObject panelName, bool enable)
    {
        CanvasGroup panel = panelName.GetComponent<CanvasGroup>();

        panel.interactable = enable;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Enables/disables the Block Raytracing option of a panel
    /// </summary>
    /// <param name="panelName">The name of the panel</param>
    /// <param name="enable">If true, enables the Block Raytracking option</param>
    public static void EnablePanelBlockRaytrace(string panelName, bool enable)
    {
        CanvasGroup panel = GameObject.Find(panelName).GetComponent<CanvasGroup>();

        panel.blocksRaycasts = enable;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Enables/disables an image
    /// </summary>
    /// <param name="obj">The name of the object that has the Image component</param>
    /// <param name="enable">If true, enables the image</param>
    public static void EnableImage(string obj, bool enable)
    {
        GameObject go = GameObject.Find(obj);
        Image image = go.GetComponent<Image>();

        image.enabled = enable;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Enables/disables an SVG image
    /// </summary>
    /// <param name="obj">The name of the object that has the SVG image component</param>
    /// <param name="enable">If true, enables the SVG image</param>
    public static void EnableSVGImage(string obj, bool enable)
    {
        GameObject go = GameObject.Find(obj);
        SVGImage svgImage = go.GetComponent<SVGImage>();

        svgImage.enabled = enable;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Enables/disables a button
    /// </summary>
    /// <param name="obj">The name of the button</param>
    /// <param name="enable">If true, enables the button</param>
    public static void EnableButton(string obj, bool enable)
    {
        GameObject go = GameObject.Find(obj);

        Button button = go.GetComponent<Button>();

        button.interactable = enable;

        if (go.GetComponentInChildren<TextMeshProUGUI>())
        {
            //go.GetComponentInChildren<TextMeshProUGUI>().enabled = enable;
            AEPButtonTextColor(go.name);
        }
    }

//------------------------------------------------------------------------------------
    public static void EnableButton(Button button, bool enable)
    {
        button.interactable = enable;

        if (button.GetComponentInChildren<TextMeshProUGUI>())
        {
            //go.GetComponentInChildren<TextMeshProUGUI>().enabled = enable;
            AEPButtonTextColor(button.name);
        }
    }

//------------------------------------------------------------------------------------
    public static void ShowButton(string obj, bool enable)
    {
        Button button = GameObject.Find(obj).GetComponent<Button>();

        try
        {
            if (button.GetComponent<Image>())
            {
                button.GetComponent<Image>().enabled = enable;
            }
            else if (button.GetComponent<SVGImage>())
            {
                button.GetComponent<SVGImage>().enabled = enable;
            }
        }
        catch (NullReferenceException)
        {
            Debug.LogError("MenuController - ShowButton: " + obj + " canot be found! Check your spelling or if the object is in the scene.");
        }
    }

//------------------------------------------------------------------------------------
    public static void ShowButton(Button button, bool enable)
    {
        try
        {
            if (button.GetComponent<Image>())
            {
                button.GetComponent<Image>().enabled = enable;
            }
            else if (button.GetComponent<SVGImage>())
            {
                button.GetComponent<SVGImage>().enabled = enable;
            }
        }
        catch (NullReferenceException)
        {
            Debug.LogError("MenuController - ShowButton: " + button.name + " canot be found! Check your spelling or if the object is in the scene.");
        }
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Enables/disables a Button that contains a Unity GUI Image
    /// </summary>
    /// <param name="obj">The name of the button</param>
    /// <param name="enable">If true, enables the button and the image</param>
    public static void EnableImageButton(string obj, bool enable)
    {
        GameObject go = GameObject.Find(obj);

        if (go.GetComponent<Image>())
        {
            EnableImage(obj, enable);
        }
        else if (go.GetComponent<SVGImage>())
        {
            EnableSVGImage(obj, enable);
        }

        EnableButton(obj, enable);
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Enables/disables a Button that contains an SVG image
    /// </summary>
    /// <param name="obj">The name of the button</param>
    /// <param name="enable">If true, enables the button and the SVG image</param>
    public static void EnableSVGImageButton(string obj, bool enable)
    {
        GameObject go = GameObject.Find(obj);

        EnableSVGImage(obj, enable);

        EnableButton(obj, enable);
    }

//------------------------------------------------------------------------------------
    public static bool GetButtonState(string button)
    {
        Button btn = GameObject.Find(button).GetComponent<Button>();

        return btn.interactable;
    }

//------------------------------------------------------------------------------------
    public static void AEPButtonTextColor(string button)
    {
        if (GetButtonState(button))
        {
            GameObject.Find(button).GetComponentInChildren<TextMeshProUGUI>().color =
                /*new Color(0.36f, 0.75f, 0.64f);*/ Color.white;
        }
        else if (!GetButtonState(button))
        {
            GameObject.Find(button).GetComponentInChildren<TextMeshProUGUI>().color =
                new Color(0.69f, 0.9f, 0.84f);
        }
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the color of a Unity GUI Image
    /// </summary>
    /// <param name="obj">The name of the object that contains the Image component</param>
    /// <param name="color">The color you want to use</param>
    public static void SetImageColor(string obj, Color color)
    {
        Image image = GameObject.Find(obj).GetComponent<Image>();

        image.color = color;
    }

    public static void SetTMPTextColor(TextMeshProUGUI text, Color color)
    {
        text.color = color;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the color of an SVG Image
    /// </summary>
    /// <param name="obj">The name of the object that contains the SVG Image component</param>
    /// <param name="color">THe color you want to use</param>
    public static void SetSVGColor(string obj, Color color)
    {
        SVGImage svgImage = GameObject.Find(obj).GetComponent<SVGImage>();

        svgImage.color = color;
    }

//------------------------------------------------------------------------------------
    public static void TweenScaleImage(string obj, float value, float time, LeanTweenType tweenType, int repeat, float waitTime)
    {
        RectTransform go = GameObject.Find(obj).GetComponent<RectTransform>();

        LeanTween.scale(go, go.localScale * value, time).setEase(tweenType).setRepeat(repeat).setDelay(waitTime);
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Shows or hides the main buttons.
    /// </summary>
    /// <param name="enable">If true, shows the main buttons.</param>
    public void EnableMainButtonPanel(bool enable)
    {
        //EnablePanel(pnl_MainButtons, enable);

        //Disabled Temporarily
        EnableImageButton("Btn_ImageScan", false);
        EnableImageButton("Btn_ObjectScan", false);
        EnableImageButton("Btn_GPS", false);

        EnableImageButton("Btn_Menu", enable);
        EnableImageButton("Btn_Snapshot", enable);
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// For use with LeanTween ShowContentsPanel function and TakeScreenShot
    /// </summary>
    void EnableMainButtonPanel()
    {
        EnableMainButtonPanel(true);
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Shows/hides the Contents Panel
    /// </summary>
    /// <param name="show">If true, slines the Contents panel into view</param>
    public void ShowContentsPanel(bool show)
    {
        switch (show)
        {
            case true:
                LeanTween.moveLocalY(panelContent.gameObject, 0, 0.25f).setEase(LeanTweenType.linear);
                EnableImageButton("Btn_Back", false);
                EnableImage("Img_Divider", false);
                if (GameObject.Find("Btn_EXP_Info"))
                {
                    MenuController.EnableButton("Btn_EXP_Info", false);
                    MenuController.ShowButton("Btn_EXP_Info", false);
                }
                break;

            case false:
                LeanTween.moveLocalY(panelContent.gameObject, floatPanelContentsY, 0.25f).setEase(LeanTweenType.linear)
                    .setOnComplete(EnableMainButtonPanel);
                if (GameObject.Find("Btn_EXP_Info"))
                {
                    MenuController.EnableButton("Btn_EXP_Info", true);
                    MenuController.ShowButton("Btn_EXP_Info", true);
                }
                break;
        }
    }

//------------------------------------------------------------------------------------
    public void ShowContentBtnsPanel(bool show)
    {
        switch (show)
        {
            case true:
                ShowPanel(panelContentBtns, true, 0.25f);
                EnableImageButton("Btn_Back", false);
                EnableImage("Img_Divider", false);
                break;

            case false:
                LeanTween.moveLocalX(panelContentBtns, -floatHiddenPanelsX, 0.2f);
                EnableImageButton("Btn_Back", true);
                EnableImage("Img_Divider", true);
                break;
        }
    }

//------------------------------------------------------------------------------------
    public void ShowHelpPanel(bool show)
    {
        ShowPanel(panelHelp, show, 0.25f);
    }

//------------------------------------------------------------------------------------
    public void ShowMediaPanel(bool show)
    {
        ShowPanel(panelMedia, show, 0.25f);
    }

//------------------------------------------------------------------------------------
    public void ShowAboutPanel(bool show)
    {
        ShowPanel(panelAbout, show, 0.25f);
    }

//------------------------------------------------------------------------------------
    public void ShowThanksPanel(bool show)
    {
        ShowPanel(panelThanks, show, 0.25f);
    }

//------------------------------------------------------------------------------------
    public void ShowPanel(string panelName, bool show, float time)
    {
        GameObject panel = GameObject.Find(panelName);

        if (panel)
        {
            switch (show)
            {
                case true:
                    LeanTween.moveLocalX(panel, 0, time);
                    if (panel.GetComponent<Animator>())
                    {
                        Utilities.SetAnimatorBoolState(panel, "Show", true);
                    }
                    break;

                case false:
                    LeanTween.moveLocalX(panel, floatHiddenPanelsX, time);
                    if (panel.GetComponent<Animator>())
                    {
                        Utilities.SetAnimatorBoolState(panel, "Show", false);
                    }
                    break;
            }
        }
        else if (!panel)
        {
            Debug.LogError("MenuController - ShowPanel: " + panelName + " cannot be found!!!");
        }
    }

//------------------------------------------------------------------------------------
    public void ShowPanel(GameObject panel, bool show, float time)
    {
        if (panel)
        {
            switch (show)
            {
                case true:
                    LeanTween.moveLocalX(panel, 0, time);
                    if (panel.GetComponent<Animator>())
                    {
                        Utilities.SetAnimatorBoolState(panel, "Show", true);
                    }
                    break;

                case false:
                    LeanTween.moveLocalX(panel, floatHiddenPanelsX, time);
                    if (panel.GetComponent<Animator>())
                    {
                        Utilities.SetAnimatorBoolState(panel, "Show", false);
                    }
                    break;
            }
        }
        else if (!panel)
        {
            Debug.LogError("MenuController - ShowPanel: " + panel.name + " cannot be found!!!");
        }
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the panel's RectTransform top, bottom, left, and right values.
    /// </summary>
    /// <param name="panelName">Name of the target panel as a string.</param>
    /// <param name="position">Vector2 values for the new position.</param>
    public void SetPanelPosition(string panelName, Vector2 position)
    {
        RectTransform rect = GameObject.Find(panelName).GetComponent<RectTransform>();
        rect.anchoredPosition = position;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the panel's RectTransform top, bottom, left, and right values.
    /// </summary>
    /// <param name="panel">Game Object variable of the target panel.</param>
    /// <param name="position">Vector2 values for the new position.</param>
    public void SetPanelPosition(GameObject panel, Vector2 position)
    {
        RectTransform rect = panel.GetComponent<RectTransform>();
        rect.anchoredPosition = position;
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the left and right values of a panel's RectTransform.
    /// </summary>
    /// <param name="panelName">Name of the target panel as a string.</param>
    /// <param name="xValue">X Value you want the panel to be set to.</param>
    public void SetPanelPositionX(string panelName, float xValue)
    {
        RectTransform rect = GameObject.Find(panelName).GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(
            xValue,
            rect.anchoredPosition.y);
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the left and right values of a panel's RectTransform.
    /// </summary>
    /// <param name="panel">Game Object variable of the target panel.</param>
    /// <param name="xValue">X Value you want the panel to be set to.</param>
    public void SetPanelPositionX(GameObject panel, float xValue)
    {
        RectTransform rect = panel.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(
            xValue,
            rect.anchoredPosition.y);
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the top and bottom values of a panel's RectTransform.
    /// </summary>
    /// <param name="panelName">Name of the target panel as a string.</param>
    /// <param name="yValue">Y Value you want the panel to be set to.</param>
    public void SetPanelPositionY(string panelName, float yValue)
    {
        RectTransform rect = GameObject.Find(panelName).GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(
            rect.anchoredPosition.x,
            yValue);
    }

//------------------------------------------------------------------------------------
    /// <summary>
    /// Sets the top and bottom values of a panel's RectTransform.
    /// </summary>
    /// <param name="panel">Game Object variable of the target panel.</param>
    /// <param name="yValue">Y Value you want the panel to be set to.</param>
    public void SetPanelPositionY(GameObject panel, float yValue)
    {
        RectTransform rect = panel.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(
            rect.anchoredPosition.x,
            yValue);
    }

//------------------------------------------------------------------------------------
    //Controlls what happens when you tap on the back button.
    public void BackButtonHandler()
    {
        ShowContentBtnsPanel(true);
        ShowPanel(stringActivePanel, false, 0.25f);
    }

//------------------------------------------------------------------------------------
    //For use with the Screenshot button
    public void TakeScreenShot()
    {
        EnableMainButtonPanel(false);
        //StartCoroutine(ScreenshotManager.Save("AEP", "Augment El Paso", false));
        ScreenshotManager.SaveScreenshot("AEP", "Augment El Paso");
        Invoke("EnableMainButtonPanel", 1.5f);
    }

//------------------------------------------------------------------------------------
    void CheckFirstRun()
    {
        if (Main.s_FirstRun == string.Empty || Main.s_FirstRun == "")
        {
            //Show the Start Panel;
            EnablePanel("Pnl_Start", true);

            //Enable the Start Panel's Next and Close buttons
            EnableButton("Btn_Start_Next", true);
            EnableButton("Btn_Start_Close", true);

            //Init the Start Images
            /*
            EnableImage("Img_Start_01_BG", true);
            EnableImage("Img_Start_02_BG", false);
            EnableImage("Img_Start_03_BG", false);
            */

            EnablePanel("Pnl_Start_01", true);
            EnablePanel("Pnl_Start_02", false);
            EnablePanel("Pnl_Start_03", false);

            //Disabling the Menu and Snapshot buttons
            EnableButton("Btn_Menu", false);
            EnableButton("Btn_Snapshot", false);

            //Hiding the Info panel
            EnablePanel("Pnl_Info", false);
        }
        else if (Main.s_FirstRun == "No")
        {
            EnablePanel("Pnl_Start", false);
			EnablePanelInteractivity("Pnl_Start", false);
			EnablePanelBlockRaytrace("Pnl_Start", false);

            EnableButton("Btn_Menu", true);
            EnableButton("Btn_Snapshot", true);

            EnablePanel("Pnl_Info", true);
            EnablePanelInteractivity("Pnl_Info", false);
        }
    }

//------------------------------------------------------------------------------------
    public void StartNextButtonHandler()
    {
        /*
        if (GetImageState("Img_Start_01_BG"))
        {
            EnableImage("Img_Start_01_BG", false);
            EnableImage("Img_Start_02_BG", true);
        }
        else if (GetImageState("Img_Start_02_BG"))
        {
            EnableImage("Img_Start_02_BG", false);
            EnableImage("Img_Start_03_BG", true);
        }
        */
        if (GetPanelState("Pnl_Start_01"))
        {
            EnablePanel("Pnl_Start_01", false);
            EnablePanel("Pnl_Start_02", true);
        }
        else if (GetPanelState("Pnl_Start_02"))
        {
            EnablePanel("Pnl_Start_02", false);
            EnablePanel("Pnl_Start_03", true);
            EnableButton("Btn_Start_Next", false);
        }
    }

//------------------------------------------------------------------------------------
    public void StartCloseButtonHandler()
    {
        EnablePanel("Pnl_Start", false);
		EnablePanelInteractivity("Pnl_Start", false);
		EnablePanelBlockRaytrace("Pnl_Start", false);

        EnableMainButtonPanel(true);

		EnablePanel("Pnl_Info", true);
		EnablePanelInteractivity("Pnl_Info", false);
		EnablePanelBlockRaytrace("Pnl_Info", false);

        PlayerPrefs.SetString("First Run", "No");
    }

//------------------------------------------------------------------------------------
    public bool GetImageState(string obj)
    {
        GameObject go = GameObject.Find(obj);

        Image image = go.GetComponent<Image>();

        return image.enabled;
    }

//------------------------------------------------------------------------------------
    public bool GetPanelState(string obj)
    {
        GameObject go = GameObject.Find(obj);

        bool panelEnabled = false;

        CanvasGroup cg = go.GetComponent<CanvasGroup>();

        if (cg.alpha == 0)
        {
            panelEnabled = false;
        }
        else if (cg.alpha == 1)
        {
            panelEnabled = true;
        }

        return panelEnabled;
    }

//------------------------------------------------------------------------------------
    public static void ShowLoadingPanel(bool show)
    {
        try
        {
            switch (show)
            {
                case true:
                    MenuController.EnablePanel("Pnl_Loading", true);
                    Utilities.PlayAnimation("AEP_LI", "Take 001", false, "Loop");
                    break;

                case false:
                    MenuController.EnablePanel("Pnl_Loading", false);
                    Utilities.RewindAnimation("AEP_LI", "Take 001", "Default");
                    break;
            }
        }
        catch (NullReferenceException)
        {
            Debug.Log("Catching Null at ShowLoadingPlane");
        }
    }

//------------------------------------------------------------------------------------
    public static void ShowScanImage(bool show)
    {
        try
        {
            switch (show)
            {
                case true:
                    //TweenScaleImage("Img_ScanStart", 1.5f, 2.0f, LeanTweenType.easeInOutElastic, -1, 3.0f);
                    //EnableImage("Img_ScanStart", true);
                    EnableSVGImage("Img_ScanStart", true);
                    break;

                case false:
                    //LeanTween.cancel(GameObject.Find("Img_ScanStart"));
                    //EnableImage("Img_ScanStart", false);
                    EnableSVGImage("Img_ScanStart", false);
                    break;
            }
        }
        catch (NullReferenceException)
        {
            Debug.Log("Catching Null on ShowScanImage");
        }
    }

//------------------------------------------------------------------------------------
    public static void ShowTapActivateImage(bool show)
    {
        try
        {
            switch (show)
            {
                case true:
                    //TweenScaleImage("Img_TapActivate", 1.5f, 2.0f, LeanTweenType.easeInOutElastic, -1, 3.0f);
                    EnableSVGImage("Img_TapActivate", true);
                    break;

                case false:
                    //LeanTween.cancel(GameObject.Find("Img_TapActivate"));
                    EnableSVGImage("Img_TapActivate", false);
                    break;
            }
        }
        catch (NullReferenceException)
        {
            Debug.Log("Catching Null on ShowTapActiveImage");
        }
    }

//------------------------------------------------------------------------------------
    public static void ShowTapColor(bool show)
    {
        switch (show)
        {
            case true:
                //TweenScaleImage("Img_TapColor", 1.5f, 2.0f, LeanTweenType.easeInOutElastic, -1, 3.0f);
                EnableSVGImage("Img_TapColor", true);
                break;

            case false:
                //LeanTween.cancel(GameObject.Find("Img_TapColor"));
                EnableSVGImage("Img_TapColor", false);
                break;
        }
    }

//------------------------------------------------------------------------------------
    public static void ShowTapColorMagic(bool show)
    {
        switch (show)
        {
            case true:
                //TweenScaleImage("Img_TapColorMagic", 1.5f, 2.0f, LeanTweenType.easeInOutElastic, -1, 3.0f);
                EnableSVGImage("Img_TapColorMagic", true);
                break;

            case false:
                //LeanTween.cancel(GameObject.Find("Img_TapColorMagic"));
                EnableSVGImage("Img_TapColorMagic", false);
                break;
        }
    }

//------------------------------------------------------------------------------------
    public static void ShowTapDrag(bool show)
    {
        switch (show)
        {
            case true:
                //TweenScaleImage("Img_TapDrag", 1.5f, 2.0f, LeanTweenType.easeInOutElastic, -1, 3.0f);
                EnableSVGImage("Img_TapDrag", true);
                break;

            case false:
                //LeanTween.cancel(GameObject.Find("Img_TapDrag"));
                EnableSVGImage("Img_TapDrag", false);
                break;
        }
    }

//------------------------------------------------------------------------------------
    public static void AnimateMainButtons(string direction, string showImage)
    {
        switch (direction)
        {
            case "Left":
                self.stringIntSVG = showImage;
                LeanTween.moveLocalX(self.pvMainButtons, self.floatHiddenPanelsX * -0.029f, 0.5f).setEase(LeanTweenType.linear)
                    .setOnComplete(self.ShowIntSVG);
                break;

            case "Center":
                LeanTween.moveLocalX(self.pvMainButtons, 0.0f, 0.5f).setEase(LeanTweenType.linear);
                EnableSVGImage(showImage, false);
                break;
        }
    }

//------------------------------------------------------------------------------------
    void ShowIntSVG()
    {
        EnableSVGImage(stringIntSVG, true);
        stringIntSVG = string.Empty;
    }

//------------------------------------------------------------------------------------
    public static void SetPanelScale(string obj, Vector3 scale)
    {
        try
        {
            RectTransform gObject = GameObject.Find(obj).GetComponent<RectTransform>();

            gObject.localScale = scale;
        }
        catch(NullReferenceException)
        {

        }
    }

//------------------------------------------------------------------------------------
    public static void HideInfoGraphics()
    {
        ShowScanImage(false);
        ShowTapActivateImage(false);
        ShowTapColor(false);
        ShowTapColorMagic(false);
        ShowTapDrag(false);
    }

//------------------------------------------------------------------------------------
    void Tmp()
    {
        AnimateMainButtons("Left", "Img_TapActivate");
        Invoke("Tmp2", 5.0f);
    }

//------------------------------------------------------------------------------------
    void Tmp2()
    {
        AnimateMainButtons("Center", "Img_TapActivate");
    }

//------------------------------------------------------------------------------------
    public void addToDownloadList(MediaButton mediaButton, bool add)
    {
        switch (add)
        {
            case true:
                downloadList.Add(mediaButton);

                EnableButton(buttonDownloadSelected, true);
                SetTMPTextColor(buttonDownloadSelected.transform.GetChild(0).GetComponent<TextMeshProUGUI>(), new Color(0.36f, 0.75f, 0.64f));
                Debug.Log("Added " + mediaButton.buttonName);
                break;

            case false:
                downloadList.Remove(mediaButton);

                Debug.Log("Removed " + mediaButton.buttonName);
                break;
        }
    }

//------------------------------------------------------------------------------------
    public IEnumerator eDownloadSelectedPieces()
    {
        EnableButton(buttonDownloadSelected, false);

        for (int i = 0; i < downloadList.Count; i++)
        {
            downloadList[i].downloadAssetBundle();

            while (PlayerPrefs.GetString(downloadList[i].playerPrefsValue) != "Yes")
            {
                yield return null;
            }
        }

        downloadList.Clear();
    }

//------------------------------------------------------------------------------------
    public void downloadSelectedPieces()
    {
        StartCoroutine(eDownloadSelectedPieces());
    }

//------------------------------------------------------------------------------------
    public void downloadAll()
    {
        EnableButton(buttonDownloadAll, false);

        for (int i = 0; i < gridLayoutCMedia.transform.childCount; i++)
        {
            gridLayoutCMedia.transform.GetChild(i).GetComponent<MediaButton>().addToDownloadList();
        }

        downloadSelectedPieces();
    }

//------------------------------------------------------------------------------------
    public XmlDocument getXML(TextAsset xmlFile)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlFile.text);

        return xmlDoc;
    }

//------------------------------------------------------------------------------------
    public static void setMediaButtonState(string playerPref)
    {
        for (int i = 0; i < MenuController.GridLayoutCMedia.transform.childCount; i++)
        {
            if (MenuController.GridLayoutCMedia.transform.GetChild(i).GetComponent<MediaButton>().playerPrefsValue.Contains(playerPref))
            {
                MenuController.GridLayoutCMedia.transform.GetChild(i).GetComponent<MediaButton>().setDownloadedState();
            }
        }
    }
#endregion
}