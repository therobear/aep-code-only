using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public delegate void SetProgressValue (float value);
public delegate void SetMediaSelected();
public delegate void SetMediaVisible();

public class MediaScrollerData
{
    public string mediaName;
    public string mediaIconName;
    public string mediaAssetBundle;
    public string mediaPlayerPrefs;
    public int mediaID;
    public SetProgressValue setProgressValue;
    public SetMediaSelected setMediaSelected;
    public SetMediaVisible setMediaVisible;
    public bool mediaDownloaded;
    private float _mediaProgress;
    private bool _mediaSelected;
    private bool _mediaVisible;

    public float mediaProgress
    {
        get { return _mediaProgress; }
        set
        {
            if (_mediaProgress != value)
            {
                _mediaProgress = value;
                if (setProgressValue != null)
                {
                    setProgressValue(_mediaProgress);
                }
            }
        }
    }

    public bool mediaSelected
    {
        get { return _mediaSelected; }
        set
        {
            if (_mediaSelected != value)
            {
                _mediaSelected = value;
                if (setMediaSelected != null)
                {
                    setMediaSelected();
                }
            }
        }
    }

    public bool mediaVisible
    {
        get { return _mediaVisible; }
        set 
        {
            if (_mediaVisible != value)
            {
                _mediaVisible = value;
                if (setMediaVisible != null)
                {
                    setMediaVisible();
                }
                else if (setMediaVisible == null)
                {
                    return;
                }
            }
        }
    }
}