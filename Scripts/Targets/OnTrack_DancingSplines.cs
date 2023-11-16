using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using metaio;

public class OnTrack_DancingSplines : MonoBehaviour
{
	/*
	public string loaderToDisable;
	public Light[] beaconLightGroup01;
	public Light[] beaconLightGroup02;
	public Light[] fillLights;

#region Global Functions ------------------------------------------------------------------------------------
	void Awake()
	{
		Invoke ("DisableLoader", 1.0f);
		InitBeaconLights();
	}
#endregion

#region Tracking Funcitons ------------------------------------------------------------------------------------
	override protected void onTrackingEvent(List<TrackingValues> trackingValues)
	{
		foreach (TrackingValues tv in trackingValues)
		{
			if (tv.state.isTrackingState())
			{
				EnableFillLights(true);

				EnablePointLights(true);

				SpineLightCall();

				Main.EnableRootLoader(false);

				Debug.Log ("Trackable " + tv.cosName + " Found!");
			}
			else if (!tv.state.isTrackingState())
			{
				LeanTween.cancelAll(true);

				EnableFillLights(false);

				EnablePointLights(false);

				Main.EnableRootLoader(true);

				Debug.Log ("Trackable " + tv.cosName + " Lost!");
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
	void EnableFillLights(bool enable)
	{
		for (int i = 0; i < fillLights.Length; i++)
		{
			fillLights[i].enabled = enable;
		}
	}

//------------------------------------------------------------------------------------
	void EnablePointLights(bool enable)
	{
		foreach (Light bLight in beaconLightGroup01)
		{
			bLight.enabled = enable;
		}

		foreach (Light bLight in beaconLightGroup02)
		{
			bLight.enabled = enable;
		}
	}

//------------------------------------------------------------------------------------
	void SpineLightCall()
	{
		float intensity01 = 0.0f;
		float intensity02 = 0.87f;

		foreach (Light bLight in beaconLightGroup01)
		{
			LeanTween.value(bLight.gameObject, bLight.intensity, intensity02, 1.5f)
				.setEase(LeanTweenType.linear)
				.setLoopPingPong()
				.setRepeat(-1)
				.setOnUpdate(
						(float val)=>{bLight.intensity = val;});
		}

		foreach  (Light bLight in beaconLightGroup02)
		{
			LeanTween.value (bLight.gameObject, bLight.intensity, intensity01, 1.5f)
				.setEase(LeanTweenType.linear)
				.setLoopPingPong()
				.setRepeat(-1)
				.setOnUpdate(
						(float val)=>{bLight.intensity = val;});
		}

		Debug.Log ("Called!");
	}

//------------------------------------------------------------------------------------
	void InitBeaconLights()
	{
		foreach (Light bLight in beaconLightGroup01)
		{
			bLight.intensity = 0.0f;
		}

		foreach (Light bLight in beaconLightGroup02)
		{
			bLight.intensity = 0.87f;
		}
	}
#endregion
*/
}
	