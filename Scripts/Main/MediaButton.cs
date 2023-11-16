using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using TMPro;
using SVGImporter;

public class MediaButton : MonoBehaviour
{
    private string _buttonName;
    private string _thumbnail;
    private string _assetBundle;
    private string _playerPrefsValue;
    private bool added;
    private bool _downloaded;
    private EnergyBar progressBar;
    private Image imageThumbnail;
    private TextMeshProUGUI tmpTitle;
    private Toggle toggleSelected;
    private SVGImage svgDownloaded;
    private MenuController menuController;

    public string buttonName
    {
        get { return _buttonName; }
        set { _buttonName = value; }
    }

    public string thumbnail
    {
        get { return _thumbnail; }
        set { _thumbnail = value; }
    }

    public string assetBundle
    {
        get { return _assetBundle; }
        set { _assetBundle = value; }
    }

    public string playerPrefsValue
    {
        get { return _playerPrefsValue; }
        set { _playerPrefsValue = value; }
    }

    public bool downloaded
    {
        get { return _downloaded; }
        set { _downloaded = value; }
    }

//------------------------------------------------------------------------------------
    public MediaButton(string buttonName, string thumbnail, string bundle, string playerPrefsValue)
    {
        _buttonName = buttonName;
        _thumbnail = thumbnail;
        
        GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/Pnl_MediaCell")) as GameObject;
        obj.name = _buttonName;
        obj.transform.SetParent(GameObject.Find("C_Media").transform, false);

        obj.GetComponent<MediaButton>().progressBar = obj.transform.GetChild(0).GetComponent<EnergyBar>();

        obj.GetComponent<MediaButton>().imageThumbnail = obj.transform.GetChild(1).GetComponent<Image>();
        obj.GetComponent<MediaButton>().imageThumbnail.sprite = Resources.Load<Sprite>("Scene Thumbnails/" + _thumbnail);

        obj.GetComponent<MediaButton>().tmpTitle = obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        obj.GetComponent<MediaButton>().tmpTitle.text = _buttonName;

        obj.GetComponent<MediaButton>().toggleSelected = obj.transform.GetChild(3).GetComponent<Toggle>();

        obj.GetComponent<MediaButton>().svgDownloaded = obj.transform.GetChild(4).GetComponent<SVGImage>();

        obj.GetComponent<MediaButton>().playerPrefsValue = playerPrefsValue;
        obj.GetComponent<MediaButton>().assetBundle = bundle;

        obj.GetComponent<MediaButton>().menuController = GameObject.Find("AEP_Menu").GetComponent<MenuController>();

        obj.GetComponent<MediaButton>().setDownloadedState();
    }

//------------------------------------------------------------------------------------
    public void setToggleState(bool state)
    {
        toggleSelected.isOn = state;
    }

//------------------------------------------------------------------------------------
    public void addToDownloadList()
    {
        switch (added)
        {
            case true:
                menuController.addToDownloadList(this, false);
                added = false;
                break;

            case false:
                menuController.addToDownloadList(this, true);
                added = true;
                break;
        }
    }

//------------------------------------------------------------------------------------
    public IEnumerator eDownloadAssetBundle()
    {
        if (PlayerPrefs.GetString(_playerPrefsValue) == string.Empty ||
            PlayerPrefs.GetString(_playerPrefsValue) == "")
        {
            if (Main.internetActive)
            {
                string bundleFile = _assetBundle + ".assetBundle";

                string[] bundleProgress = new string[] { bundleFile };

                DownloadManager.Instance.StartDownload(bundleFile);
                
                while (DownloadManager.Instance.GetWWW(bundleFile) == null)
                {
                    progressBar.SetValueF(DownloadManager.Instance.ProgressOfBundles(bundleProgress));

                    yield return null;
                }

                PlayerPrefs.SetString(_playerPrefsValue, "Yes");

                setDownloadedState();
            }
        }
    }

//------------------------------------------------------------------------------------
    public void downloadAssetBundle()
    {
        StartCoroutine(eDownloadAssetBundle());
    }

//------------------------------------------------------------------------------------
    public void setDownloadedState()
    {
        if (PlayerPrefs.GetString(_playerPrefsValue) == "Yes")
        {
            if (menuController.downloadList.Contains(this))
            {
                toggleSelected.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
            else
            {
                toggleSelected.isOn = false;
            }
            
            toggleSelected.interactable = false;

            progressBar.SetValueF(0);

            svgDownloaded.enabled = true;

            MenuController.SetImageColor(this.name, new Color(0.12f, 0.61f, 0.61f));
            return;
        }

        toggleSelected.isOn = false;
        toggleSelected.interactable = true;

        progressBar.SetValueF(0);

        svgDownloaded.enabled = false;
    }
}
