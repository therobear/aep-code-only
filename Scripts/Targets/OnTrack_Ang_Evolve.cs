//MD5Hash:dd1b49583ccf3465649fc2d87bf679a9;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


public class OnTrack_Ang_Evolve : UnityEngine.MonoBehaviour, Vuforia.ITrackableEventHandler
{
	public bool testing = false;
	public string loaderName = "";
	public string playerPrefsValue = "";
	public string assetBundle = "";
	public string asset = "";
	public UnityEngine.RuntimeAnimatorController textController = null;
	public UnityEngine.RuntimeAnimatorController logoController = null;
	private bool allowTracking = false;
	private Vuforia.TrackableBehaviour mTrackableBehaviour = null;


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
	public void onScan(bool track)
	{
		switch (allowTracking)
		{
			case true:
				switch (track)
				{
					case true:
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
	public void animate(bool animate)
	{
		switch (animate)
		{
			case true:
				AEP_Utilities.ObjectUtils.ShowObject("ANG_EVO_Fish", false, true);
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("ANG_EVO_Logo", "SkateIn");
				AEP_Utilities.Delay.DelayFunction(this, showText, 0.5f);
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("ANG_EVO_Logo", "SkateIn");
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("ANG_EVO_Txt", "Ani_Text");
				AEP_Utilities.AnimationUtils.PlayParticles("ANG_EVL_Part_Smoke", false);
				AEP_Utilities.AnimationUtils.PlayParticles("ANG_EVL_Part_Fire1", false);
				AEP_Utilities.AnimationUtils.PlayParticles("ANG_EVL_Part_Fire2", false);
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
			AEP_Utilities.MaterialUtils.SetObjectShader("ANG_EVO_Logo", true, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("ANG_EVL_Part_Smoke", false, "Mobile/Particles/Multiply");
			AEP_Utilities.MaterialUtils.SetObjectShader("ANG_EVL_Part_Fire1", false, "Mobile/Particles/Additive");
			AEP_Utilities.MaterialUtils.SetObjectShader("ANG_EVL_Part_Fire2", false, "Mobile/Particles/Additive");
		}

		AEP_Utilities.AnimationUtils.addAnimatorController("ANG_EVO_Logo", logoController);
		AEP_Utilities.AnimationUtils.addAnimatorController("ANG_EVO_Txt", textController);
		allowTracking = true;
		onScan(false);
	}
	public void OnTrackableStateChanged(Vuforia.TrackableBehaviour.Status previousStatus, Vuforia.TrackableBehaviour.Status newStatus)
	{
		if ((((newStatus == Vuforia.TrackableBehaviour.Status.DETECTED) || (newStatus == Vuforia.TrackableBehaviour.Status.TRACKED)) || (newStatus == Vuforia.TrackableBehaviour.Status.EXTENDED_TRACKED)))
		{
			onScan(true);
		}
		else
		{
			onScan(false);
		}

	}
	public void showText()
	{
		AEP_Utilities.ObjectUtils.ShowObject("ANG_EVO_Txt", true, true);
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("ANG_EVO_Txt", "Ani_Text");
		AEP_Utilities.Delay.DelayFunction(this, playParticles, 1.1f);
	}
	public void playParticles()
	{
		AEP_Utilities.ObjectUtils.ShowObject("ANG_EVO_Particles", true, true);
		AEP_Utilities.AnimationUtils.PlayParticles("ANG_EVL_Part_Smoke", true);
		AEP_Utilities.AnimationUtils.PlayParticles("ANG_EVL_Part_Fire1", true);
		AEP_Utilities.AnimationUtils.PlayParticles("ANG_EVL_Part_Fire2", true);
	}
}

