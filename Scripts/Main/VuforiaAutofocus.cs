using UnityEngine;
using Vuforia;
using System.Collections;

public class VuforiaAutofocus : MonoBehaviour
{
    private bool _VuforiaStarted = false;

//------------------------------------------------------------------------------------
    void Start()
    {
        VuforiaARController vuforia = VuforiaARController.Instance;

        if (vuforia != null)
        {
            vuforia.RegisterVuforiaStartedCallback(startAfterVuforia);
        }
    }

//------------------------------------------------------------------------------------
    private void startAfterVuforia()
    {
        _VuforiaStarted = true;
        setAutofocus();
    }

//------------------------------------------------------------------------------------
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            if (_VuforiaStarted)
            {
                setAutofocus();
            }
        }
    }

//------------------------------------------------------------------------------------
    private void setAutofocus()
    {
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
        {
            Debug.Log("Autofocus set.");
        }
        else
        {
            Debug.Log("This device doesn't support auto focus!");
        }
    }
}