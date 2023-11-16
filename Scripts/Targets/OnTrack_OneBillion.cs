//MD5Hash:c053be630735e5a197e695fbcebee98a;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


public class OnTrack_OneBillion : Vuforia.AEPImageTrackerBase
{
	public System.Collections.Generic.List<UnityEngine.GameObject> animControllerObjects = null;


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
				for (int i_282 = 0; i_282 < animControllerObjects.Count; i_282++)
				{
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(animControllerObjects[i_282], "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(animControllerObjects[i_282], "Start");
				}
				break;
			case false:
				for (int i_288 = 0; i_288 < animControllerObjects.Count; i_288++)
				{
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(animControllerObjects[i_288], "Start");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(animControllerObjects[i_288], "Idle");
				}
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
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), true, "Unlit/Texture Double Sided");
			AEP_Utilities.MaterialUtils.SetObjectShaderMultiMat("OBR_Fist_01_MeshPart0", "Unlit/Texture Double Sided");
			AEP_Utilities.MaterialUtils.SetObjectShader("OBR_Blockout", false, "Mask/DepthMask");
		}

		animControllerObjects.Add(UnityEngine.GameObject.Find("OBR_Fragments"));
		animControllerObjects.Add(UnityEngine.GameObject.Find("OBR_Women"));
		allowTracking = true;
		MenuController.ShowScanImage(true);
		onScan(false);
	}
}

