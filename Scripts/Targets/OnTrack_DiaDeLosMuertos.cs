using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTrack_DiaDeLosMuertos : MonoBehaviour
{
	public string loaderToDisable;
	public float delay;

	private bool b_AllowTracking;
	private GameObject go_OrangeEyes;
	private GameObject go_GoldFill;
	private GameObject go_OrangeTeeth;
	private GameObject go_RidgeLeft;
	private GameObject go_RidgeRight;
	private GameObject go_PurpleTeeth;
	private GameObject go_Root;

	public bool AllowTracking
	{
		get { return b_AllowTracking; }
		set { b_AllowTracking = value; }
	}

#region Global Functions ------------------------------------------------------------------------------------
	void Awake()
	{
		Invoke ("DisableLoader", 1.0f);

        MenuController.ShowScanImage(false);
        MenuController.ShowTapActivateImage(false);
        MenuController.ShowTapColor(false);
        MenuController.ShowTapColorMagic(false);
        MenuController.ShowTapDrag(false);
	}

//------------------------------------------------------------------------------------
    void OnEnable()
    {
        //MainTracker.trackingHandler += OnScan;
    }

//------------------------------------------------------------------------------------
    void OnDisable()
    {
        //MainTracker.trackingHandler -= OnScan;
    }
#endregion

#region Tracking Functions ------------------------------------------------------------------------------------
    /*
	protected override void onTrackingEvent(List<TrackingValues> trackingValues)
	{
		foreach (TrackingValues tv in trackingValues)
		{
			if (b_AllowTracking)
			{
				if (tv.state.isTrackingState())
				{
					AnimateAugmentedPiece(true);

					Utilities.EnableCollider("Target_DDM", false, true);
					
					Main.EnableRootLoader(false);
					
					Debug.Log("Trackable " + tv.cosName + " Found!");
				}
				else if (!tv.state.isTrackingState())
				{
					AnimateAugmentedPiece(false);

					Utilities.EnableCollider("Target_DDM", false, false);
					
					Main.EnableRootLoader(true);
					
					Debug.Log("Trackable " + tv.cosName + " Lost!");
				}
			}
			else if (!b_AllowTracking)
			{
				Debug.Log("Asset not downloaded yet!");
			}
		}
	}
    */

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

                        Utilities.EnableCollider("Target_DDM", false, true);

                        MenuController.ShowScanImage(false);

                        Main.EnableRootLoader(false);
                        break;

                    case false:
                        MenuController.ShowScanImage(true);

                        AnimateAugmentedPiece(false);

                        Utilities.EnableCollider("Target_DDM", false, false);

                         Main.EnableRootLoader(true);
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
		Main.DisableSpecificLoader(loaderToDisable);

        MenuController.ShowScanImage(true);

        InitAugmentedPiece();
	}

//------------------------------------------------------------------------------------
	public void AnimateAugmentedPiece(bool animate)
	{
		switch(animate)
		{
		case true:
			DDM_PlayEyes();
			break;

		case false:
			//RewindSequence();
			break;
		}
	}

//------------------------------------------------------------------------------------
	public void InitAugmentedPiece()
	{
		go_Root = GameObject.Find("Root_DiaDeMuertos");
		go_OrangeEyes = GameObject.Find("DDM_Flower_Orange_Eyes");
		go_GoldFill = GameObject.Find("DDM_Flower_Gold_Fill");
		go_OrangeTeeth = GameObject.Find("DDM_Flower_Orange_Teeth");
		go_RidgeLeft = GameObject.Find("DDM_Flower_Purple_OuterRidge_Left");
		go_RidgeRight = GameObject.Find("DDM_Flower_Purple_OuterRidge_Right");
		go_PurpleTeeth = GameObject.Find("DDM_Flower_Purple_Teeth");

		b_AllowTracking = true;
	}

//------------------------------------------------------------------------------------
	void RewindSequence()
	{
		Animation[] anim = go_Root.GetComponentsInChildren<Animation>();

		foreach (Animation clip in anim)
		{
			Utilities.RewindAnimation(clip.gameObject.name, "Take 001", "Default");
		}
	}

//------------------------------------------------------------------------------------
	void DDM_PlayEyes()
	{
		Utilities.EnableCollider("Target_DDM", false, false);

		Animation[] anim = go_OrangeEyes.GetComponentsInChildren<Animation>();

		foreach (Animation clip in anim)
		{
			clip.Play("Take 001");
		}
		Invoke("DDM_PlayGoldFill", delay);
	}

//------------------------------------------------------------------------------------
	void DDM_PlayGoldFill()
	{
		Animation[] anim = go_GoldFill.GetComponentsInChildren<Animation>();

		foreach (Animation clip in anim)
		{
			clip.Play("Take 001");
		}

		Invoke("DDM_PlayRidgeLeft", delay);
		Invoke("DDM_PlayRidgeRight", delay);
		Invoke("DDM_PlayPurpleTeeth", delay);
		Invoke("DDM_PlayOrangeTeeth", delay);
	}

//------------------------------------------------------------------------------------
	void DDM_PlayRidgeLeft()
	{
		Animation[] anim = go_RidgeLeft.GetComponentsInChildren<Animation>();

		foreach(Animation clip in anim)
		{
			clip.Play("Take 001");
		}
	}

//------------------------------------------------------------------------------------
	void DDM_PlayRidgeRight()
	{
		Animation[] anim = go_RidgeRight.GetComponentsInChildren<Animation>();

		foreach (Animation clip in anim)
		{
			clip.Play("Take 001");
		}
	}

//------------------------------------------------------------------------------------
	void DDM_PlayPurpleTeeth()
	{
		Animation[] anim = go_PurpleTeeth.GetComponentsInChildren<Animation>();

		foreach (Animation clip in anim)
		{
			clip.Play("Take 001");
		}
	}

//------------------------------------------------------------------------------------
	void DDM_PlayOrangeTeeth()
	{
		Animation[] anim = go_OrangeTeeth.GetComponentsInChildren<Animation>();

		foreach (Animation clip in anim)
		{
			clip.Play("Take 001");
		}

		Utilities.EnableCollider("Target_DDM", false, true);
	}
#endregion
}
