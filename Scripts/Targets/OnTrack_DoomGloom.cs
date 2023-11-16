//MD5Hash:a1c3187aa02fc563b6a9c416a304b287;
using UnityEngine;
using Vuforia;
using System;
using System.Text;


public class OnTrack_DoomGloom : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject skullParticles = null;
	public UnityEngine.GameObject doomGloomObject = null;


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
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(doomGloomObject, "Idle");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(doomGloomObject, "Start");
				AEP_Utilities.AnimationUtils.PlayParticles(skullParticles, true);
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(doomGloomObject, "Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(doomGloomObject, "Idle");
				AEP_Utilities.AnimationUtils.PlayParticles(skullParticles, true);
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
			///False
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Mobile/Unlit (Supports Lightmap)");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("DG_Particles_Blue", false, "Mobile/Particles/Multiply");
		}

		///Finished
		skullParticles = UnityEngine.GameObject.Find("DG_Particles_Blue");
		doomGloomObject = UnityEngine.GameObject.Find("DG2_01");
		///Finished
		allowTracking = true;
		///Finished
		MenuController.ShowScanImage(true);
		///Finished
		onScan(false);
	}
}
