//MD5Hash:1a111605140e9a8122f34d9d71f10fc4;
using UnityEngine;
using System.Collections.Generic;
using System;
using Vuforia;
using System.Text;


public class OnTrack_Fusion : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.Texture fusionTexture = null;
	public UnityEngine.GameObject rootController = null;
	public System.Collections.Generic.List<UnityEngine.GameObject> particles = null;
	public float videoLoopWaitTime = 0f;


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

		}

	}
	public override void animate(bool animate)
	{
		switch (animate)
		{
			case true:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(rootController, "Idle");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(rootController, "Start");
				for (int i_307 = 0; i_307 < particles.Count; i_307++)
				{
					AEP_Utilities.AnimationUtils.PlayParticles(particles[i_307], true);
				}
				AEP_Utilities.AudioVideoUtils.SetMovieTextureProperties(gameObject, "Loop", false);
				AEP_Utilities.AudioVideoUtils.openVideoFromFile(gameObject, RenderHeads.Media.AVProVideo.MediaPlayer.FileLocation.AbsolutePathOrURL, "", false);
				AEP_Utilities.AudioVideoUtils.openVideoFromFile(gameObject, RenderHeads.Media.AVProVideo.MediaPlayer.FileLocation.AbsolutePathOrURL, "http://therobear.com/VideoTextures/Fusion/Fusion71Start.mp4", true);
				AEP_Utilities.AudioVideoUtils.SetMovieTextureState(gameObject, "Play");
				AEP_Utilities.Delay.DelayFunction(this, playVidLoop, videoLoopWaitTime);
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(rootController, "Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(rootController, "Idle");
				for (int i_316 = 0; i_316 < particles.Count; i_316++)
				{
					AEP_Utilities.AnimationUtils.PlayParticles(particles[i_316], false);
					AEP_Utilities.AudioVideoUtils.SetMovieTextureState(gameObject, "Stop");
					AEP_Utilities.Delay.CancelAllDelays(this);
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
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, true, true);
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
						MenuController.ShowTapDrag(true);
						MenuController.ShowScanImage(false);
						animate(true);
						break;
					case false:
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, true, false);
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
						MenuController.ShowTapDrag(false);
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
			AEP_Utilities.MaterialUtils.SetObjectShader("FUSION71_Cover", false, "Unlit/Texture");
			AEP_Utilities.MaterialUtils.SetObjectShader("FUSION71_NDMF_Calle13", false, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("FUSION71_NDMF_Logo", false, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("FUSION71_Splat_Sm", false, "Particles/Additive");
			AEP_Utilities.MaterialUtils.SetObjectShader("FUSION71_Splat_Med", false, "Particles/Additive");
			AEP_Utilities.MaterialUtils.SetObjectShader("FUSION71_Splat_Large", false, "Particles/Additive");
			AEP_Utilities.MaterialUtils.SetObjectTexture("FUSION71_NDMF_Calle13", fusionTexture);
			AEP_Utilities.MaterialUtils.SetObjectTexture("FUSION71_NDMF_Logo", fusionTexture);
		}

		rootController = UnityEngine.GameObject.Find("AEP_Fusion");
		particles.Add(UnityEngine.GameObject.Find("FUSION71_Splat_Sm"));
		particles.Add(UnityEngine.GameObject.Find("FUSION71_Splat_Med"));
		particles.Add(UnityEngine.GameObject.Find("FUSION71_Splat_Large"));
		AEP_Utilities.ObjectUtils.AddRemoveComponent("FUSION71_NDMF_Calle13", "ObjectDrag", "add");
		AEP_Utilities.ObjectUtils.AddRemoveComponent("FUSION71_NDMF_Logo", "ObjectDrag", "add");
		UnityEngine.GameObject.Find("FUSION71_NDMF_Calle13").GetComponent<ObjectDrag>().speed = 3f;
		UnityEngine.GameObject.Find("FUSION71_NDMF_Calle13").GetComponent<ObjectDrag>().easeType = LeanTweenType.easeOutElastic;
		UnityEngine.GameObject.Find("FUSION71_NDMF_Logo").GetComponent<ObjectDrag>().speed = 3f;
		UnityEngine.GameObject.Find("FUSION71_NDMF_Logo").GetComponent<ObjectDrag>().easeType = LeanTweenType.easeOutElastic;
		AEP_Utilities.AudioVideoUtils.SetMoviePlayerMesh(gameObject, UnityEngine.GameObject.Find("FUSION71_Cover"));
		allowTracking = true;
		MenuController.ShowScanImage(true);
		onScan(false);
	}
	public void playVidLoop()
	{
		AEP_Utilities.AudioVideoUtils.SetMovieTextureProperties(gameObject, "Loop", true);
		AEP_Utilities.AudioVideoUtils.openVideoFromFile(gameObject, RenderHeads.Media.AVProVideo.MediaPlayer.FileLocation.AbsolutePathOrURL, "", false);
		AEP_Utilities.AudioVideoUtils.openVideoFromFile(gameObject, RenderHeads.Media.AVProVideo.MediaPlayer.FileLocation.AbsolutePathOrURL, "http://therobear.com/VideoTextures/Fusion/Fusion71Loop.mp4", true);
		AEP_Utilities.AudioVideoUtils.SetMovieTextureState(gameObject, "Play");
	}
}

