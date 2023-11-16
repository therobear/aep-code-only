//MD5Hash:4e5008a1f03d86910e37296df0fc1772;
using UnityEngine;
using Vuforia;
using System;
using System.Text;


public class OnTrack_Taco : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject geoRoot = null;


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
	public override void animate(bool animate)
	{
		switch (animate)
		{
			case true:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(geoRoot, "Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(geoRoot, "Taco_Start");
				AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
				MenuController.ShowTapActivateImage(false);
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(geoRoot, "Taco_Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(geoRoot, "Start");
				break;
			default:
				break;
		}
		
	}
	public override void onScan(bool track)
	{
		switch (allowTracking)
		{
			case true:
				switch (track)
				{
					case true:
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
						MenuController.ShowScanImage(false);
						MenuController.ShowTapActivateImage(true);
						break;
					case false:
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
						MenuController.ShowScanImage(true);
						MenuController.ShowTapActivateImage(false);
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
	public void OnDestroy()
	{
		Vuforia.TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
		Main.EnableLoader(loaderName);
	}
	public void init()
	{
		if (testing)
		{
		}
		else
		{
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			AEP_Utilities.MaterialUtils.SetObjectShader("MD_PMD_01", true, "Resources/Shaders/Unlit_Color");
			AEP_Utilities.MaterialUtils.SetObjectShader("MD_PMD_Body", false, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("MD_PMD_Taco", false, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("MD_PMD_Head_PT01", true, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("MD_PMD_Body_Top_PT01", true, "Mobile/Unlit (Supports Lightmap)");
		}

		geoRoot = UnityEngine.GameObject.Find("MD_PMD_01");
		allowTracking = true;
		MenuController.ShowScanImage(true);
		onScan(false);
	}
}

