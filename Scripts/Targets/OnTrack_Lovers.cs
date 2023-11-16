//MD5Hash:6414db6336c20045e4a2ad140a2d1ad2;
using Vuforia;
using UnityEngine;
using System;


namespace Vuforia
{
	public class OnTrack_Lovers : UnityEngine.MonoBehaviour, Vuforia.ITrackableEventHandler
	{
		public string loadername = "";
		public string playerPrefsValue = "";
		public bool bAllowTracking = false;
		public Vuforia.TrackableBehaviour mtrackableBehaviour = null;


		void Start()
		{
			mtrackableBehaviour = gameObject.GetComponent<Vuforia.TrackableBehaviour>();
			if (mtrackableBehaviour)
			{
				mtrackableBehaviour.RegisterTrackableEventHandler(this);
			}

			init();
		}
		void OnDestroy()
		{
			Vuforia.TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mtrackableBehaviour.Trackable);
			Main.EnableLoader(loadername);
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
		public void init()
		{
			bAllowTracking = true;
			onScan(false);
		}
		public void onScan(bool track)
		{
			switch (track)
			{
				case true:
					AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
					MenuController.ShowScanImage(false);
					MenuController.ShowTapActivateImage(true);
					AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
					break;
				case false:
					AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
					MenuController.ShowScanImage(true);
					MenuController.ShowTapActivateImage(false);
					animate(false);
					AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
					break;
				default:
					break;
			}
			
		}
		public void animate(bool animate)
		{
			switch (animate)
			{
				case true:
					startLovers();
					MenuController.ShowTapActivateImage(false);
					AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
					break;
				case false:
					resetLovers();
					break;
				default:
					break;
			}
			
		}
		public void startLovers()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("LVS_Lovers", "Start", false, "Default");
			AEP_Utilities.Delay.DelayFunction(this, playHeart, 2.2f);
			AEP_Utilities.Delay.DelayFunction(this, playHeartGlow, 2.2f);
			AEP_Utilities.Delay.DelayFunction(this, fadeInEnergy, 2.6f);
			AEP_Utilities.Delay.DelayFunction(this, playHeadHeart, 3f);
			AEP_Utilities.Delay.DelayFunction(this, playBackground, 4f);
		}
		public void playHeart()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("Root_Lovers/LVS_Heart", "Expand", false, "Default");
			AEP_Utilities.Delay.DelayFunction(this, loopHeart, 1f);
		}
		public void loopHeart()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("Root_Lovers/LVS_Heart", "Loop", false, "Loop");
		}
		public void playHeartGlow()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("LVS_HeartBeams", "Expand", false, "Default");
			AEP_Utilities.Delay.DelayFunction(this, loopHeartGlow, 1f);
		}
		public void loopHeartGlow()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("LVS_HeartBeams", "Loop", false, "Loop");
		}
		public void playBackground()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("LVS_Glow", "Expand", false, "Default");
			AEP_Utilities.MaterialUtils.SetObjectAlpha("LVS_Glow", false, 1f);
			AEP_Utilities.Delay.DelayFunction(this, fadeBackground, 3f);
			AEP_Utilities.Delay.DelayFunction(this, playBackground, 5f);
		}
		public void playHeadHeart()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("LVS_Lovers", "ShowHeart", false, "Default");
		}
		public void fadeInEnergy()
		{
			UnityEngine.Renderer[] hisEnergy = null;
			UnityEngine.Renderer[] herEnergy = null;

			hisEnergy = UnityEngine.GameObject.Find("His_Energy").GetComponentsInChildren<UnityEngine.Renderer>(false);
			herEnergy = UnityEngine.GameObject.Find("Her_Energy").GetComponentsInChildren<UnityEngine.Renderer>(false);
			for (int i_187 = 0; i_187 < hisEnergy.Length; i_187++)
			{
				hisEnergy[i_187].gameObject.GetComponent<MegaWave>().animate = true;
			}
			for (int i_194 = 0; i_194 < herEnergy.Length; i_194++)
			{
				herEnergy[0].gameObject.GetComponent<MegaWave>().animate = true;
			}
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("His_Energy", true, true, 1f);
			AEP_Utilities.MaterialUtils.SetObjectShader("His_Energy", true, "Shader Forge/Unlit_DS_Color");
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("Her_Energy", true, true, 1f);
			AEP_Utilities.MaterialUtils.SetObjectShader("Her_Energy", true, "Shader Forge/Unlit_DS_Color");
		}
		public void fadeBackground()
		{
			AEP_Utilities.MaterialUtils.AnimateObjectAlpha("LVS_Glow", false, true, 1f);
			AEP_Utilities.MaterialUtils.SetObjectShader("LVS_Glow", false, "Unlit/Transparent Unlit Color");
		}
		public void resetLovers()
		{
			UnityEngine.Renderer[] hisWaves = null;
			UnityEngine.Renderer[] herWaves = null;

			AEP_Utilities.Delay.CancelAllDelays(this);
			AEP_Utilities.AnimationUtils.RewindAnimation("LVS_Lovers", "ShowHeart", "Default");
			AEP_Utilities.AnimationUtils.RewindAnimation("LVS_Lovers", "Start", "Default");
			AEP_Utilities.AnimationUtils.RewindAnimation("Root_Lovers/LVS_Heart", "Loop", "Default");
			AEP_Utilities.AnimationUtils.RewindAnimation("LVS_HeartBeams", "Loop", "Default");
			AEP_Utilities.AnimationUtils.RewindAnimation("LVS_Glow", "Expand", "Default");
			AEP_Utilities.AnimationUtils.RewindAnimation("Root_Lovers/LVS_Heart", "Expand", "Default");
			AEP_Utilities.AnimationUtils.RewindAnimation("LVS_HeartBeams", "Expand", "Default");
			AEP_Utilities.MaterialUtils.SetObjectAlpha("His_Energy", true, 0f);
			AEP_Utilities.MaterialUtils.SetObjectAlpha("Her_Energy", true, 0f);
			hisWaves = UnityEngine.GameObject.Find("His_Energy").GetComponentsInChildren<UnityEngine.Renderer>(false);
			herWaves = UnityEngine.GameObject.Find("Her_Energy").GetComponentsInChildren<UnityEngine.Renderer>(false);
			for (int i_239 = 0; i_239 < hisWaves.Length; i_239++)
			{
				hisWaves[i_239].gameObject.GetComponent<MegaWave>().animate = true;
			}
			for (int i_245 = 0; i_245 < herWaves.Length; i_245++)
			{
				herWaves[i_245].gameObject.GetComponent<MegaWave>().animate = true;
			}
		}
	}

}
