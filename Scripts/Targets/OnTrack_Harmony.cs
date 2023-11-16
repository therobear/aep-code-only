//MD5Hash:8f5a5d8a0e10848937821e91cb8488b8;
using UnityEngine;
using Vuforia;
using System;
using System.Text;


public class OnTrack_Harmony : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject harmonyObject = null;


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
	public override void animate(bool animate)
	{
		switch (animate)
		{
			case true:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(harmonyObject, "Idle");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(harmonyObject, "Start");
				AEP_Utilities.AudioVideoUtils.PlayAudioSource(harmonyObject, true);
				AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(harmonyObject, "Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(harmonyObject, "Idle");
				AEP_Utilities.AudioVideoUtils.PlayAudioSource(harmonyObject, false);
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
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
						MenuController.ShowScanImage(false);
						break;
					case false:
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
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
	public void init()
	{
		if (testing)
		{
		}
		else
		{
			///False
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Mobile/Unlit (Supports Lightmap)");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LHH_Background", true, "Unlit/Texture");
		}

		///Finished
		harmonyObject = UnityEngine.GameObject.Find("LH_Harmony_Whole");
		///Finished
		allowTracking = true;
		///Finished
		onScan(false);
	}
}
