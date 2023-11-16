//MD5Hash:35251c6ca94023f8025ae431e6fe47a0;
using UnityEngine;
using Vuforia;
using System;
using System.Text;


public class OnTrack_ElTele : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject teleObject = null;


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
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(teleObject, "Idle");
				growTele();
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(teleObject, "Start");
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(teleObject, "ScaleDown");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(teleObject, "Idle");
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
			AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Shader Forge/Reg_Color+Spec+Gloss+DS");
		}

		///Finished
		teleObject = UnityEngine.GameObject.Find("Loteria_LaTele_01");
		///Finished
		allowTracking = true;
		///Finished
		MenuController.ShowScanImage(true);
		///Finished
		onScan(false);
	}
	public void growTele()
	{
		AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(teleObject, "ScaleDown");
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(teleObject, "Start");
		AEP_Utilities.Delay.DelayFunction(this, shrinkTele, 7f);
	}
	public void shrinkTele()
	{
		AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(teleObject, "Start");
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(teleObject, "ScaleDown");
		AEP_Utilities.Delay.DelayFunction(this, growTele, 5f);
	}
}
