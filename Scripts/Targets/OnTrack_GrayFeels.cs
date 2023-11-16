//MD5Hash:d2f176424bdddd40b7f4640d0f2dd1b9;
using UnityEngine;
using System;
using Vuforia;
using System.Text;


public class OnTrack_GrayFeels : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject ghostObject = null;
	public UnityEngine.GameObject eyesObject = null;
	public UnityEngine.GameObject particlesObject = null;
	public float eyesLoopTime = 0f;


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
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(ghostObject, "Idle");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(ghostObject, "Start");
				playEyesAnimation();
				AEP_Utilities.AnimationUtils.PlayParticles(particlesObject, true);
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(ghostObject, "Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(ghostObject, "Idle");
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(eyesObject, "Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(eyesObject, "Idle");
				AEP_Utilities.AnimationUtils.PlayParticles(particlesObject, false);
				AEP_Utilities.Delay.CancelAllDelays(this);
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
			AEP_Utilities.MaterialUtils.SetObjectShader("GF_Cloud", false, "Unlit/Transparent");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("GF_Shadow", false, "Unlit/Transparent");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("GF_ParticleSystem", false, "Mobile/Particles/Additive");
		}

		///Finished
		particlesObject = UnityEngine.GameObject.Find("GF_ParticleSystem");
		///Finished
		ghostObject = UnityEngine.GameObject.Find("GrayFeels2_01");
		///Finished
		eyesObject = UnityEngine.GameObject.Find("GF_Eyes_01");
		///Finished
		allowTracking = true;
		///Finished
		MenuController.ShowScanImage(true);
		///Finished
		onScan(false);
	}
	public void playEyesAnimation()
	{
		AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(eyesObject, "Idle");
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(eyesObject, "Start");
		AEP_Utilities.Delay.DelayFunction(this, playEyesAnimation, eyesLoopTime);
	}
}
