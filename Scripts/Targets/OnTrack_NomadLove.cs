//MD5Hash:772e1dc220caf426985b014c2f47257f;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


namespace Vuforia
{
	public class OnTrack_NomadLove : UnityEngine.MonoBehaviour, Vuforia.ITrackableEventHandler
	{
		public bool testing = false;
		public string loaderName = "";
		public string playerPrefsValue = "";
		public string assetBundle = "";
		public string asset = "";
		public UnityEngine.RuntimeAnimatorController birdHoverController = null;
		public UnityEngine.RuntimeAnimatorController birdMovementController = null;
		public UnityEngine.RuntimeAnimatorController birdWingsController = null;
		public UnityEngine.RuntimeAnimatorController cyoteController = null;
		public UnityEngine.RuntimeAnimatorController doodeController = null;
		public UnityEngine.RuntimeAnimatorController linesController = null;
		public UnityEngine.RuntimeAnimatorController rabitController = null;
		private bool bAllowTracking = false;
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
		public int tapCount = 0;


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
		private void onScan(bool track)
		{
			switch (bAllowTracking)
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
		public void animate(bool animate)
		{
			switch (animate)
			{
				case true:
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Rabit", "Start");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Bird_Hover", "Start");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Bird_Hover/MNTZ_HB_Body_Hover_PT/MNTZ_Bird_Wings", "Start");
					AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays", true, false);
					AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays2", true, false);
					AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays3", true, false);
					AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays4", true, false);
					AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
					break;
				case false:
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Rabit", "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Bird_Hover", "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Bird_Hover/MNTZ_HB_Body_Hover_PT/MNTZ_Bird_Wings", "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Cyote", "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Nomad/MNTZ_Doode", "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Bird_Movement", "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_LightRays", "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_LightRays2", "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_LightRays3", "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_LightRays4", "Idle");
					AEP_Utilities.Delay.CancelAllDelays(this);
					hideRays();
					tapCount = 0;
					AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, false);
					AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
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
				AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Unlit/Texture");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_Dialogue_Howl_Bubble_PT", true, "Shader Forge/Unlit_Mask");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_Dialogue_Orale", false, "Shader Forge/Unlit_Mask");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_LightRays", true, "Shaders/Twitchy_MNTZ");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_LightRays2", true, "Shaders/Twitchy_MNTZ");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_LightRays3", true, "Shaders/Twitchy_MNTZ");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_LightRays4", true, "Shaders/Twitchy_MNTZ");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_Background", true, "Shader Forge/Unlit");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_Cyote", true, "Shader Forge/Unlit");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_Cyote_Eye", false, "Unlit/Texture");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_Dialogue_Howl_Bubble_PT", true, "Shader Forge/Unlit_Mask");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_Dialogue_Orale_PT", true, "Shader Forge/Unlit_Mask");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTZ_Flame", false, "Shaders/Twitchy_MNTZ");
			}

			AEP_Utilities.AnimationUtils.addAnimatorController("MNTZ_Bird_Hover/MNTZ_HB_Body_Hover_PT/MNTZ_Bird_Wings", birdWingsController);
			AEP_Utilities.AnimationUtils.addAnimatorController("MNTZ_Nomad/MNTZ_Doode", doodeController);
			AEP_Utilities.AnimationUtils.addAnimatorController("MNTZ_Bird_Movement", birdMovementController);
			AEP_Utilities.AnimationUtils.addAnimatorController("MNTZ_Bird_Hover", birdHoverController);
			AEP_Utilities.AnimationUtils.addAnimatorController("MNTZ_Rabit", rabitController);
			AEP_Utilities.AnimationUtils.addAnimatorController("MNTZ_Cyote", cyoteController);
			AEP_Utilities.AnimationUtils.addAnimatorController("MNTZ_LightRays", linesController);
			AEP_Utilities.AnimationUtils.addAnimatorController("MNTZ_LightRays2", linesController);
			AEP_Utilities.AnimationUtils.addAnimatorController("MNTZ_LightRays3", linesController);
			AEP_Utilities.AnimationUtils.addAnimatorController("MNTZ_LightRays4", linesController);
			bAllowTracking = true;
			onScan(false);
		}
		public void playSequence()
		{
			switch (tapCount)
			{
				case 0:
					AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Cyote", "Anim01");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Nomad/MNTZ_Doode", "Anim01");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Bird_Movement", "Anim01");
					hideRays();
					tapCount = 1;
					AEP_Utilities.Delay.DelayFunction(this, enableThisCollider, 12f);
					AEP_Utilities.Delay.DelayFunction(this, playHowl, 4f);
					break;
				case 1:
					AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Cyote", "Anim02");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Nomad/MNTZ_Doode", "Anim02");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_Bird_Movement", "Anim02");
					hideRays();
					tapCount = 0;
					AEP_Utilities.Delay.DelayFunction(this, enableThisCollider, 12f);
					AEP_Utilities.Delay.DelayFunction(this, playRays01, 4f);
					AEP_Utilities.Delay.DelayFunction(this, playRays02, 4.8f);
					AEP_Utilities.Delay.DelayFunction(this, playRays03, 5.6f);
					AEP_Utilities.Delay.DelayFunction(this, playRays04, 6.4f);
					break;
				default:
					break;
			}
			
		}
		public void enableThisCollider()
		{
			MenuController.ShowTapActivateImage(true);
			AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
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
		public void hideRays()
		{
			AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays", true, false);
			AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays2", true, false);
			AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays3", true, false);
			AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays4", true, false);
		}
		public void playRays01()
		{
			AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays", true, true);
			AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_LightRays", "Start");
		}
		public void playRays02()
		{
			AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays2", true, true);
			AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_LightRays2", "Start");
		}
		public void playRays03()
		{
			AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays3", true, true);
			AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_LightRays3", "Start");
		}
		public void playRays04()
		{
			AEP_Utilities.ObjectUtils.ShowObject("MNTZ_LightRays4", true, false);
			AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("MNTZ_LightRays4", "Start");
			AEP_Utilities.Delay.DelayFunction(this, hideRays, 1.5f);
		}
		public void playHowl()
		{
			AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, true);
		}
	}


}
