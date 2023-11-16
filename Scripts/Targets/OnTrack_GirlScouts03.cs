using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using metaio;

public class OnTrack_GirlScouts03 : MonoBehaviour
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
	}
#endregion

#region Tracking Functions ------------------------------------------------------------------------------------
	protected override void onTrackingEvent(List<TrackingValues> trackingValues)
	{
		foreach (TrackingValues tv in trackingValues)
		{
			if (b_AllowTracking)
			{
				if (tv.state.isTrackingState())
				{
					AnimateAugmentedPiece(true);
					
					Main.EnableRootLoader(false);
					
					Debug.Log("Trackable " + tv.cosName + " Found!");
				}
				else if (!tv.state.isTrackingState())
				{
					AnimateAugmentedPiece(false);
					
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
#endregion

#region Custom Functions ------------------------------------------------------------------------------------
	public void DisableLoader()
	{
		Main.DisableSpecificLoader(loaderToDisable);
	}

//------------------------------------------------------------------------------------
	public void AnimateAugmentedPiece(bool animate)
	{
		switch (animate)
		{
			case true:
				Utilities.PlayAnimation("Root_GS03(Clone)/GS-3_01", "GS-3_01", false, "Loop");
				break;

			case false:
				Utilities.RewindAnimation("Root_GS03(Clone)/GS-3_01", "GS-3_01", "Default");
				break;
		}
	}

//------------------------------------------------------------------------------------
	public void InitAugmentedPiece()
	{
		Utilities.SetObjectShader("Root_GS03(Clone)", true, "Shader Forge/Unlit_OpClip");
	}
#endregion
*/
}