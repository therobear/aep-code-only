//MD5Hash:e4e1dd8ea18dfde8f4f621926ba7a16a;
using UnityEngine;
using Vuforia;
using System;
using System.Text;


public class OnTrack_AguaEsVida : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject[] nanAnimationObjects = null;
	public UnityEngine.GameObject particles01 = null;
	public UnityEngine.GameObject particles02 = null;
	public UnityEngine.GameObject particles03 = null;
	public UnityEngine.GameObject particles04 = null;


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
				for (int i_278 = 0; i_278 < nanAnimationObjects.Length; i_278++)
				{
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(nanAnimationObjects[i_278], "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(nanAnimationObjects[i_278], "Start");
					AEP_Utilities.AnimationUtils.PlayParticles(particles01, true);
					AEP_Utilities.AnimationUtils.PlayParticles(particles02, true);
					AEP_Utilities.AnimationUtils.PlayParticles(particles03, true);
					AEP_Utilities.AnimationUtils.PlayParticles(particles04, true);
					AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, true);
				}
				break;
			case false:
				for (int i_283 = 0; i_283 < nanAnimationObjects.Length; i_283++)
				{
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(nanAnimationObjects[i_283], "Start");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(nanAnimationObjects[i_283], "Idle");
					AEP_Utilities.AnimationUtils.PlayParticles(particles01, false);
					AEP_Utilities.AnimationUtils.PlayParticles(particles02, false);
					AEP_Utilities.AnimationUtils.PlayParticles(particles03, false);
					AEP_Utilities.AnimationUtils.PlayParticles(particles04, false);
					AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, false);
				}
				break;
			default:
				break;
		}
		
	}
	public void init()
	{
		string rootName = "";

		if (testing)
		{
			rootName = asset;
		}
		else
		{
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), true, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("NAN_AEV_Background", false, "Shaders/NAN_AEV_Clouds");
			AEP_Utilities.MaterialUtils.SetObjectShader("NAN_AEV_Part_0", false, "Particles/Alpha Blended Premultiply");
			AEP_Utilities.MaterialUtils.SetObjectShader("NAN_AEV_Part_1", false, "Mobile/Particles/Additive");
			AEP_Utilities.MaterialUtils.SetObjectShader("NAN_AEV_Part_2", false, "Mobile/Particles/Additive");
			AEP_Utilities.MaterialUtils.SetObjectShader("NAN_AEV_Part_3", false, "Mobile/Particles/Additive");
			rootName = new System.Text.StringBuilder(asset).Append("(Clone)").ToString();
		}

		particles01 = UnityEngine.GameObject.Find("NAN_AEV_Part_0");
		particles02 = UnityEngine.GameObject.Find("NAN_AEV_Part_1");
		particles03 = UnityEngine.GameObject.Find("NAN_AEV_Part_2");
		particles04 = UnityEngine.GameObject.Find("NAN_AEV_Part_3");
		nanAnimationObjects[0] = UnityEngine.GameObject.Find("NAN_AEV_Fish");
		nanAnimationObjects[1] = UnityEngine.GameObject.Find("NAN_AEV_Plant_Static");
		nanAnimationObjects[2] = UnityEngine.GameObject.Find(new System.Text.StringBuilder(rootName).Append("/NAN_AEV_Water1").ToString());
		nanAnimationObjects[3] = UnityEngine.GameObject.Find("NAN_AEV_Plant_P3");
		nanAnimationObjects[4] = UnityEngine.GameObject.Find("NAN_AEV_Plant_P3");
		nanAnimationObjects[5] = UnityEngine.GameObject.Find("NAN_AEV_Plant_G7");
		nanAnimationObjects[6] = UnityEngine.GameObject.Find("NAN_AEV_Plant_G6");
		nanAnimationObjects[7] = UnityEngine.GameObject.Find("NAN_AEV_Water2");
		nanAnimationObjects[8] = UnityEngine.GameObject.Find("NAN_AEV_Water3");
		nanAnimationObjects[9] = UnityEngine.GameObject.Find("NAN_AEV_Plant_F2");
		nanAnimationObjects[10] = UnityEngine.GameObject.Find("NAN_AEV_Plant_W1");
		nanAnimationObjects[11] = UnityEngine.GameObject.Find("NAN_AEV_Plant_F3+F4");
		nanAnimationObjects[12] = UnityEngine.GameObject.Find("NAN_AEV_Plant_G5");
		nanAnimationObjects[13] = UnityEngine.GameObject.Find(new System.Text.StringBuilder(rootName).Append("/NAN_AEV_Woman").ToString());
		allowTracking = true;
		onScan(false);
	}
}

