//MD5Hash:ebb4f653a98269985d6a719e88e7f770;
using UnityEngine;
using System.Collections.Generic;
using Vuforia;
using System;
using System.Text;


public class OnTrack_GuardinaLiths : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject geoRoot = null;
	public System.Collections.Generic.List<UnityEngine.GameObject> lithsPieces = new System.Collections.Generic.List<UnityEngine.GameObject>();


	void Awake()
	{
		if (testing)
		{
			init();
		}

	}
	void Start()
	{
		mTrackableBehaviour = gameObject.GetComponent<Vuforia.TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
			if (testing)
			{
			}
			else
			{
				AEP_Utilities.AssetBundleUtils.GetAssetBundle(this, playerPrefsValue, assetBundle, asset, init);
			}

			MenuController.HideInfoGraphics();
		}

	}
	public void OnDestroy()
	{
		Vuforia.TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
		Main.EnableLoader(loaderName);
	}
	public override void onScan(bool track)
	{
		switch (allowTracking)
		{
			case true:
				switch (track)
				{
					case true:
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
						MenuController.ShowScanImage(false);
						animate(true);
						break;
					case false:
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
						MenuController.ShowScanImage(true);
						animate(false);
						break;
					default:
						break;
				}
				
				break;
			case false:
				UnityEngine.Debug.Log(new System.Text.StringBuilder("Asset not ready yet!"));
				break;
			default:
				onScan(false);
				break;
		}
		
	}
	public override void animate(bool animate)
	{
		switch (animate)
		{
			case true:
				startGuardianLiths();
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(geoRoot, "Fade_In");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(geoRoot, "Start");
				AEP_Utilities.MaterialUtils.SetObjectShader(geoRoot, true, "Legacy Shaders/Transparent/Diffuse");
				AEP_Utilities.Delay.CancelAllDelays(this);
				break;
			default:
				break;
		}
		
	}
	public void init()
	{
		if (testing)
		{
		}
		else
		{
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Legacy Shaders/Transparent/Diffuse");
		}

		geoRoot = UnityEngine.GameObject.Find("GL_01");
		lithsPieces.Add(UnityEngine.GameObject.Find("GL_PT_01"));
		lithsPieces.Add(UnityEngine.GameObject.Find("GL_PT_010"));
		lithsPieces.Add(UnityEngine.GameObject.Find("GL_PT_012"));
		lithsPieces.Add(UnityEngine.GameObject.Find("GL_PT_016"));
		lithsPieces.Add(UnityEngine.GameObject.Find("GL_PT_014"));
		lithsPieces.Add(UnityEngine.GameObject.Find("GL_PT_008"));
		allowTracking = true;
		MenuController.ShowScanImage(true);
		onScan(false);
	}
	public void startGuardianLiths()
	{
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(geoRoot, "Fade_In");
		AEP_Utilities.Delay.DelayFunction(this, fadeInSet01, 0.5f);
	}
	public void fadeInSet01()
	{
		AEP_Utilities.MaterialUtils.SetObjectShader(lithsPieces[0], true, "Mobile/Bumped Specular");
		AEP_Utilities.Delay.DelayFunction(this, fadeInSet02, 0.5f);
	}
	public void fadeInSet02()
	{
		AEP_Utilities.MaterialUtils.SetObjectShader(lithsPieces[1], true, "Mobile/Bumped Specular");
		AEP_Utilities.Delay.DelayFunction(this, fadeInSet03, 0.5f);
	}
	public void fadeInSet03()
	{
		AEP_Utilities.MaterialUtils.SetObjectShader(lithsPieces[2], true, "Mobile/Bumped Specular");
		AEP_Utilities.Delay.DelayFunction(this, fadeInSet04, 0.5f);
	}
	public void fadeInSet04()
	{
		AEP_Utilities.MaterialUtils.SetObjectShader(lithsPieces[3], true, "Mobile/Bumped Specular");
		AEP_Utilities.Delay.DelayFunction(this, fadeInSet05, 0.5f);
	}
	public void fadeInSet05()
	{
		AEP_Utilities.MaterialUtils.SetObjectShader(lithsPieces[4], true, "Mobile/Bumped Specular");
		AEP_Utilities.Delay.DelayFunction(this, fadeInSet06, 0.5f);
	}
	public void fadeInSet06()
	{
		AEP_Utilities.MaterialUtils.SetObjectShader(lithsPieces[5], true, "Mobile/Bumped Specular");
	}
}

