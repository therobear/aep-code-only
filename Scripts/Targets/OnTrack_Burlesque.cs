using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using metaio;

public class OnTrack_Burlesque : MonoBehaviour
{
	/*
    public string loaderToDisable;

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

        //Testing
        b_AllowTracking = true;
    }
#endregion

#region Tracking Functions ------------------------------------------------------------------------------------
    override protected void onTrackingEvent(List<TrackingValues> trackingValues)
    {
        foreach (TrackingValues tv in trackingValues)
        {
            if (b_AllowTracking)
            {
                if (tv.state.isTrackingState())
                {
                    Utilities.EnableCollider(this.gameObject.name, false, true);

                    Main.EnableRootLoader(false);

                    AnimateBurlesque(true);

                    Debug.Log("Trackable " + tv.cosName + " Found!");
                }
                else if (!tv.state.isTrackingState())
                {
                    Utilities.EnableCollider(this.gameObject.name, false, false);

                    Main.EnableRootLoader(true);

                    AnimateBurlesque(false);

                    Debug.Log("Trackable " + tv.cosName + " Lost!");
                }
            }
            else if (!b_AllowTracking)
            {
                Debug.Log("Asset not downloaded yet!");
            }
        }
    }
#endregion

#region Custom Functions ------------------------------------------------------------------------------------
    void DisableLoader()
    {
        Main.DisableSpecificLoader(loaderToDisable);
    }

//------------------------------------------------------------------------------------
    void AnimateBurlesque(bool animate)
    {
        switch (animate)
        {
            case true:
                /*
                Utilities.PlayAnimation("BOTR_Lights_OutterRidge", "Take 001", false, "Loop");
                Utilities.PlayAnimation(" ", "Take 001", false, "Loop");
                Utilities.PlayAnimation("BOTR_Lights_Loop", "Take 001", false, "Loop");

                Utilities.SetAnimatorTriggerState("Root_BOTR/BOTR_Lights_Loop", "Light_Loop");
                Utilities.SetAnimatorTriggerState("Root_BOTR/BOTR_Lights_OutterRidge", "Outer_Ridge");
                Utilities.SetAnimatorTriggerState("Root_BOTR/BOTR_Lights_Points", "Light_Points");
                Debug.Log("Animate");
                break;

            case false:
                /*
                Utilities.RewindAnimation("BOTR_Lights_OutterRidge", "Take 001", "Default");
                Utilities.RewindAnimation("BOTR_Lights_Points", "Take 001", "Default");
                Utilities.RewindAnimation("BOTR_Lights_Loop", "Take 001", "Default");

                Utilities.ResetAnimatorTriggerState("Root_BOTR/BOTR_Lights_Loop", "Light_Loop");
                Utilities.ResetAnimatorTriggerState("Root_BOTR/BOTR_Lights_OutterRidge", "Outer_Ridge");
                Utilities.ResetAnimatorTriggerState("Root_BOTR/BOTR_Lights_Points", "Light_Points");
                break;
        }
    }

//------------------------------------------------------------------------------------
    public void AnimateTassle()
    {

        Utilities.SetAnimatorTriggerState("Root_BOTR/BOTR_Tassle", "Tassle");
    }

//------------------------------------------------------------------------------------
    void EnableTargetCollider()
    {
        Utilities.EnableCollider(this.gameObject.name, false, true);
    }
#endregion
*/
}