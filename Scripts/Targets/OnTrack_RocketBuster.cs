//MD5Hash:78ecdb9ce41e17a33497ccddbe64e06d;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


namespace Vuforia
{
	public class OnTrack_RocketBuster : UnityEngine.MonoBehaviour, Vuforia.ITrackableEventHandler
	{
		public bool testing = false;
		public string loaderName = "";
		public string playerPrefsValue = "";
		public string assetBundle = "";
		public string asset = "";
		public UnityEngine.RuntimeAnimatorController rbbAdvController = null;
		public UnityEngine.RuntimeAnimatorController rbbBootsController = null;
		private UnityEngine.GameObject rootBoots = null;
		public MegaWave megaWaveRocketSign = null;
		private bool isBootsActive = false;
		private bool bAllowTracking = false;
		public Vuforia.TrackableBehaviour mTrackableBehaviour = null;


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
		public void OnDestroy()
		{
			Vuforia.TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
			Main.EnableLoader(loaderName);
		}
		public void init()
		{
			UnityEngine.Renderer[] eyeList01 = null;
			UnityEngine.Renderer[] eyeList02 = null;
			SetRenderQueue[] renQUe = null;

			if (testing)
			{
			}
			else
			{
				AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_ADV", true, "Mobile/Unlit (Supports Lightmap)");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Boot1", false, "Shader Forge/Unlit_DS");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Boot2", false, "Shader Forge/Unlit_DS");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Mask", false, "Mask/DepthMask");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_3D-Boots_PT_LBoot", true, "Unlit/Texture");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_3D-Boots_PT_RBoot", true, "Unlit/Texture");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Eye_PT_ROOT", true, "Shader Forge/Unlit_DS");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Eye_PT_ROOT001", true, "Shader Forge/Unlit_DS");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Text_3D", false, "Shader Forge/Unlit_DS");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Particle_Coins", true, "Mobile/Particles/Alpha Blended");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Particle_Clover", true, "Mobile/Particles/Alpha Blended");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Particle_Horseshoe", true, "Mobile/Particles/Alpha Blended");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Particle_Dust", true, "Particles/Alpha Blended Premultiply");
				AEP_Utilities.MaterialUtils.SetObjectShader("RBB_Particle_Dust2", true, "Mobile/Particles/Alpha Blended");
			}

			rootBoots = UnityEngine.GameObject.Find("Root_RBB_Boots");
			megaWaveRocketSign = UnityEngine.GameObject.Find("RBB_Banner").GetComponent<MegaWave>();
			AEP_Utilities.AnimationUtils.addAnimatorController("RBB_ADV", rbbAdvController);
			AEP_Utilities.AnimationUtils.addAnimatorController("RBB_Boots", rbbBootsController);
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Text_Rocket", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Text_Handmade", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Bird_Cherry1", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Bird_WingB1", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Bird1", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Bird_WingF1", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Text_CmngAt", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Banner", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Text_Phone", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Text_Website", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Text_EyePop", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Bird_WingB2", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Bird2", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Bird_WingF2", "SetRenderQueue", "add");
			AEP_Utilities.ObjectUtils.AddRemoveComponent("RBB_Bird_Cherry2", "SetRenderQueue", "add");
			renQUe = UnityEngine.Object.FindObjectsOfType<SetRenderQueue>();
			for (int i_158 = 0; i_158 < renQUe.Length; i_158++)
			{
				renQUe[i_158].Queues[0] = 3020;
			}
			AEP_Utilities.MaterialUtils.SetObjectShader("Root_RBB_Boots", true, "Shader Forge/Unlit_Spec+Gloss");
			bAllowTracking = true;
			onScan(false);
		}
		public void onScan(bool track)
		{
			switch (bAllowTracking)
			{
				case true:
					switch (track)
					{
						case true:
							AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
							animate(true);
							AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, true);
							MenuController.ShowScanImage(false);
							break;
						case false:
							AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
							animate(false);
							AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, false);
							MenuController.ShowScanImage(true);
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
					AEP_Utilities.ObjectUtils.ShowObject("RBB_Mask", false, true);
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("RBB_ADV", "Reveal");
					AEP_Utilities.Delay.DelayFunction(this, hideMask, 0.2f);
					AEP_Utilities.Delay.DelayFunction(this, loopRocketAnimation, 1.15f);
					rootBoots.SetActive(false);
					megaWaveRocketSign.animate = true;
					AEP_Utilities.Delay.DelayFunction(this, animateBoots, 5f);
					break;
				case false:
					AEP_Utilities.Delay.CancelAllDelays(this);
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("RBB_ADV", "Reveal");
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("RBB_ADV", "Loop");
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Dust2", false);
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Coins", false);
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Clover", false);
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Horseshoe", false);
					isBootsActive = false;
					megaWaveRocketSign.animate = false;
					break;
				default:
					break;
			}
			
		}
		public void hideMask()
		{
			AEP_Utilities.ObjectUtils.ShowObject("RBB_Mask", false, false);
		}
		public void loopRocketAnimation()
		{
			AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("RBB_ADV", "Loop");
		}
		public void animateBoots()
		{
			switch (isBootsActive)
			{
				case true:
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("RBB_Boots", "LoopBoots");
					rootBoots.SetActive(false);
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Dust2", false);
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Coins", false);
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Clover", false);
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Horseshoe", false);
					AEP_Utilities.ObjectUtils.ShowObject("RBB_ADV", true, true);
					animate(true);
					isBootsActive = false;
					break;
				case false:
					AEP_Utilities.ObjectUtils.ShowObject("RBB_ADV", true, false);
					animate(false);
					rootBoots.SetActive(true);
					AEP_Utilities.ObjectUtils.ShowObject(rootBoots, true, true);
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("RBB_Boots", "LoopBoots");
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Dust2", true);
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Coins", true);
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Clover", true);
					AEP_Utilities.AnimationUtils.PlayParticles("RBB_Particle_Horseshoe", true);
					isBootsActive = true;
					callBoots();
					break;
				default:
					break;
			}
			
		}
		public void callBoots()
		{
			AEP_Utilities.TransformUtils.SetObjectRotation(rootBoots, true, UnityEngine.Vector3.zero);
			AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("RBB_Boots", "Loop_Boots");
			AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("RBB_Boots", "Loop_Boots");
		}
		public void animateDelay()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("RBB_Boots", "Loop_Boots", false, "Default");
		}
	}


}
