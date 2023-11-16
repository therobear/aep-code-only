//MD5Hash:6b9c15420b55a3e94336215e0fce26d5;
using UnityEngine;
using System.Collections.Generic;
using Vuforia;
using System;
using System.Text;


public class OnTrack_SisterCities : Vuforia.AEPImageTrackerBase
{
	private UnityEngine.GameObject objSisters = null;
	public UnityEngine.GameObject objMask = null;
	public UnityEngine.GameObject objTownOld = null;
	public System.Collections.Generic.List<UnityEngine.GameObject> objParticles = null;
	public UnityEngine.GameObject objSistersPopin = null;
	public UnityEngine.GameObject objTownNew = null;
	public System.Collections.Generic.List<UnityEngine.GameObject> hairPulseObjs = null;
	public UnityEngine.Texture2D sistersOldTexture = null;
	public UnityEngine.Texture2D sisterPreLoopTexture = null;


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
						AEP_Utilities.ObjectUtils.ShowObject(objTownNew, true, false);
						MenuController.EnablePanel("New_City_Canvas", false);
						MenuController.ShowScanImage(false);
						animate(true);
						break;
					case false:
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
						MenuController.EnablePanel("New_City_Canvas", false);
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
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(objMask, "Mask_Intro");
				///True
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(objSistersPopin, "PopIn");
				///True
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(objTownOld, "Build_Intro");
				///True
				for (int i_368 = 0; i_368 < hairPulseObjs.Count; i_368++)
				{
					///True
					AEP_Utilities.MaterialUtils.setObjectMaterialFloatProperty(hairPulseObjs[i_368], "_EnableEmit", 0f);
				}
				gameObject.GetComponent<RenderHeads.Media.AVProVideo.ApplyToMesh>()._defaultTexture = sistersOldTexture;
				///True
				AEP_Utilities.Delay.DelayFunction(this, loopAnimations, 1.25f);
				break;
			case false:
				AEP_Utilities.AudioVideoUtils.openVideoFromFile(gameObject, RenderHeads.Media.AVProVideo.MediaPlayer.FileLocation.RelativeToPeristentDataFolder, "", false);
				///False
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(objSisters, "Idle");
				///False
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(objMask, "Idle");
				///False
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(objTownOld, "Idle");
				///False
				AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
				///False
				for (int i_393 = 0; i_393 < objParticles.Count; i_393++)
				{
					///False
					AEP_Utilities.AnimationUtils.PlayParticles(objParticles[i_393], false);
				}
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
			///False
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), true, "Mobile/Unlit (Supports Lightmap)");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LOS_SC_Particles", true, "Mobile/Particles/Alpha Blended");
			AEP_Utilities.MaterialUtils.SetObjectShader("LOS_SC_Part_Whisps", false, "Mobile/Particles/Additive");
			AEP_Utilities.MaterialUtils.SetObjectShader("LOS_SC_Part_Mask", false, "Mobile/Particles/Alpha Blended");
			AEP_Utilities.MaterialUtils.SetObjectShaderMultiMat("LOS_SC_TownOld", "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShaderMultiMat("LOS_SC_TownNew", "Mobile/Unlit (Supports Lightmap)");
		}

		///Finished
		objSisters = UnityEngine.GameObject.Find("LOS_SC_Sisters");
		///Finished
		objMask = UnityEngine.GameObject.Find("LOS_SC_Mask_Root");
		///Finished
		objTownOld = UnityEngine.GameObject.Find("LOS_SC_Town_Old");
		///Finished
		objSistersPopin = UnityEngine.GameObject.Find("LOS_SC_Sisters_PopIn");
		///Finished
		objTownNew = UnityEngine.GameObject.Find("LOS_SC_Town_New");
		///Finished
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Body_Outline"));
		///Finished
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair0_1"));
		///Finished
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair1-4"));
		///Finished
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair2-4"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Eyes_L"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Head_L001"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Eyes_R"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Head_R001"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair1-1"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair2-1"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair1-6"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair1-5"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair1-007"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair1-3"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair1-2"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair0-2"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair0-003"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair2-3"));
		hairPulseObjs.Add(UnityEngine.GameObject.Find("LOS_SC_Hair2-2"));
		///Finished
		objParticles.Add(UnityEngine.GameObject.Find("LOS_SC_Part_Whisps"));
		///Finished
		objParticles.Add(UnityEngine.GameObject.Find("LOS_SC_Part_Glow_1"));
		///Finished
		objParticles.Add(UnityEngine.GameObject.Find("LOS_SC_Part_Glow_2"));
		AEP_Utilities.AudioVideoUtils.SetMoviePlayerMesh(gameObject, UnityEngine.GameObject.Find("LOS_SC_Body001"));
		for (int i_490 = 0; i_490 < hairPulseObjs.Count; i_490++)
		{
			AEP_Utilities.MaterialUtils.SetObjectShader(hairPulseObjs[i_490], false, "Shader Forge/LOS_Hair_Pulse");
		}
		AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
		MenuController.EnablePanel("New_City_Canvas", false);
		downloadIntroVideo();
	}
	public void loopAnimations()
	{
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(objSisters, "Sisters_Loop");
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(objMask, "Mask_Loop");
		AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
		MenuController.ShowTapActivateImage(true);
	}
	public void maskZoomIn()
	{
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(objMask, "Mask_ZoomIn");
		AEP_Utilities.Delay.DelayFunction(this, swapCities, 1.25f);
	}
	public void sisterMagic()
	{
		MenuController.ShowTapActivateImage(false);
		AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
		AEP_Utilities.AudioVideoUtils.openVideoFromFile(gameObject, RenderHeads.Media.AVProVideo.MediaPlayer.FileLocation.RelativeToPeristentDataFolder, "Los_Sc_Bodyani_Whole.mp4", true);
		AEP_Utilities.AudioVideoUtils.SetMovieTextureState(gameObject, "Play");
		for (int i_409 = 0; i_409 < hairPulseObjs.Count; i_409++)
		{
			AEP_Utilities.MaterialUtils.setObjectMaterialFloatProperty(hairPulseObjs[i_409], "_EnableEmit", 1f);
		}
		for (int i_415 = 0; i_415 < objParticles.Count; i_415++)
		{
			AEP_Utilities.AnimationUtils.PlayParticles(objParticles[i_415], true);
		}
	}
	public void playSisterLoop()
	{
	}
	public void swapCities()
	{
		AEP_Utilities.ObjectUtils.ShowObject(objTownOld, true, false);
		AEP_Utilities.ObjectUtils.ShowObject(objTownNew, true, true);
		MenuController.EnablePanel("New_City_Canvas", true);
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(objMask, "Mask_Loop");
		sisterMagic();
	}
	public void downloadIntroVideo()
	{
		AEP_Utilities.AudioVideoUtils.startVideoDownload("DownloadIntroVideo", "Los_Sc_Bodyani_Whole.mp4");
		AEP_Utilities.Delay.DelayFunction(this, setAllowTracking, 2f);
	}
	public void setAllowTracking()
	{
		allowTracking = true;
		onScan(false);
	}
}
