using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTrack_AdInLearn : MonoBehaviour
{
    public string loaderToDisable;
    public bool TestInEditor;

    private bool b_AllowTracking;

    public bool AllowTracking
    {
        get { return b_AllowTracking; }
        set { b_AllowTracking = value; }
    }

#region Global Functions ------------------------------------------------------------------------------------
    void Awake()
    {
        Invoke("DisableLoader", 1.0f);

        if (TestInEditor)
        {
            b_AllowTracking = true;
            Invoke("InitAugmentedPiece", 1.0f);
        }
    }

//------------------------------------------------------------------------------------
    public void OnEnable()
    {
        //MainTracker.trackingHandler += OnScan;
    }

//------------------------------------------------------------------------------------
    public void OnDisable()
    {
        //MainTracker.trackingHandler -= OnScan;
    }
#endregion

#region Tracking Functions ------------------------------------------------------------------------------------
    void OnScan(bool track)
    {
		/*
        if (b_AllowTracking)
        {
            if (MainTracker.trackingId == this.GetComponent<metaioTracker>().cosID)
            {
                switch (track)
                {
                    case true:
                        AnimateAugmentedPiece(true);

                        Main.EnableRootLoader(false);

                        MenuController.ShowScanImage(false);
                        break;

                    case false:
                        AnimateAugmentedPiece(false);

                        Main.EnableRootLoader(true);

                        MenuController.ShowScanImage(true);
                        break;
                }
            }
        }
        else if (!b_AllowTracking)
        {
            Debug.Log("Asset not downloaded yet!");
        }
*/
    }
#endregion

#region Custom Functions ------------------------------------------------------------------------------------
    public void DisableLoader()
    {
        //Main.DisableSpecificLoader(loaderToDisable);
    }

//------------------------------------------------------------------------------------
    public void AnimateAugmentedPiece(bool animate)
    {
        switch (animate)
        {
            case true:
                Utilities.PlayAnimation(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)/AIL_DP", "AIL_DP_Congrats", false, "PingPong");

                Utilities.PlayParticles(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)/AIL_DP_Particles/AIL_DP_Particles_Yellow", true);
                Utilities.PlayParticles(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)/AIL_DP_Particles/AIL_DP_Particles_Flower", true);
                Utilities.PlayParticles(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)/AIL_DP_Particles/AIL_DP_Particles_Compass", true);
                break;

            case false:
                Utilities.RewindAnimation(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)/AIL_DP", "AIL_DP_Congrats", "Default");

                Utilities.PlayParticles(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)/AIL_DP_Particles/AIL_DP_Particles_Yellow", false);
                Utilities.PlayParticles(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)/AIL_DP_Particles/AIL_DP_Particles_Flower", false);
                Utilities.PlayParticles(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)/AIL_DP_Particles/AIL_DP_Particles_Compass", false);
                break;
        }
    }

//------------------------------------------------------------------------------------
    public void InitAugmentedPiece()
    {
        Utilities.ShowObject(this.name, true, false);

        Utilities.SetObjectScale(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)", new Vector3(240.0f, 240.0f, 240.0f));

        Utilities.SetObjectShader(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)/AIL_DP", true, "Shader Forge/Unlit_DS_ALP");
        Utilities.SetObjectShader(gameObject.name + "/Root_AIL_DP_Congrats_" + gameObject.name + "(Clone)/AIL_DP_Particles", true, "Mobile/Particles/Alpha Blended");

        MenuController.ShowScanImage(true);
    }
#endregion
}