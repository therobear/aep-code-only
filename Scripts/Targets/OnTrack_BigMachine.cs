//MD5Hash:d351e7056b3ac69c3ffcca9759b6d221;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


namespace Vuforia
{
	public class OnTrack_BigMachine : UnityEngine.MonoBehaviour, ITrackableEventHandler
	{
		public bool TestInEditor = false;
		public string PlayerPrefsValue = "";
		public string AssetBundle = "";
		public string Asset = "";
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
		private bool bAllowTracking = false;
		private Vuforia.StateManager smStateManager = null;


		void Awake()
		{
			if (TestInEditor)
			{
				Init();
			}

		}
		void Start()
		{
			AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
			mTrackableBehaviour = gameObject.GetComponent<Vuforia.TrackableBehaviour>();
			smStateManager = Vuforia.TrackerManager.Instance.GetStateManager();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
				if (TestInEditor)
				{
				}
				else
				{
					AEP_Utilities.AssetBundleUtils.GetAssetBundle(this, PlayerPrefsValue, AssetBundle, Asset, Init);
				}

				MenuController.HideInfoGraphics();
			}

		}
		public void OnDestroy()
		{
			smStateManager.DestroyTrackableBehavioursForTrackable(gameObject.GetComponent<Vuforia.TrackableBehaviour>().Trackable);
			Main.EnableLoader("Loader_BigMachine");
		}
		public void OnTrackableStateChanged(Vuforia.TrackableBehaviour.Status previousStatus, Vuforia.TrackableBehaviour.Status newStatus)
		{
			if ((((newStatus == Vuforia.TrackableBehaviour.Status.DETECTED) || (newStatus == Vuforia.TrackableBehaviour.Status.TRACKED)) || (newStatus == Vuforia.TrackableBehaviour.Status.EXTENDED_TRACKED)))
			{
				if (bAllowTracking)
				{
					OnScan(true);
				}

			}
			else
			{
				OnScan(false);
			}

		}
		public void OnScan(bool track)
		{
			switch (bAllowTracking)
			{
				case true:
					switch (track)
					{
						case true:
							AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
							AEP_Utilities.ObjectUtils.ShowObject("Root_BigMachine(Clone)", true, true);
							MenuController.ShowScanImage(false);
							MenuController.ShowTapActivateImage(true);
							break;
						case false:
							Animate(false);
							AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
							AEP_Utilities.ObjectUtils.ShowObject("Root_BigMachine(Clone)", true, false);
							MenuController.ShowScanImage(true);
							MenuController.ShowTapActivateImage(false);
							break;
						default:
							break;
					}
					
					break;
				case false:
					UnityEngine.Debug.Log(new System.Text.StringBuilder("Asset not ready yet!"));
					break;
				default:
					OnScan(false);
					break;
			}
			
		}
		public void Init()
		{
			AEP_Utilities.TransformUtils.SetObjectParent("Root_BigMachine(Clone)", "Target_BigMachine");
			AEP_Utilities.MaterialUtils.SetObjectShader("Root_BigMachine(Clone)", true, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("junk_cars", false, "Unlit/Texture");
			AEP_Utilities.MaterialUtils.SetObjectShader("BM_Birds1", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.SetObjectShader("BM_Birds2", true, "Shader Forge/Unlit");
			AEP_Utilities.MaterialUtils.SetObjectShader("BM_Body_Black", false, "Legacy Shaders/Diffuse");
			AEP_Utilities.MaterialUtils.SetObjectShader("BM_Part_Steam1", false, "Particles/Alpha Blended Premultiply");
			AEP_Utilities.MaterialUtils.SetObjectShader("BM_Part_Steam2", false, "Particles/Alpha Blended Premultiply");
			AEP_Utilities.MaterialUtils.SetObjectShader("BM_Part_Steam3", false, "Particles/Alpha Blended Premultiply");
			AEP_Utilities.ObjectUtils.ShowObject("Root_BigMachine(Clone)", true, false);
			bAllowTracking = true;
			AEP_Utilities.AnimationUtils.RewindAnimation("BM_Birds1", "BM_09", "Default");
			AEP_Utilities.AnimationUtils.RewindAnimation("BM_Birds2", "BM_09", "Default");
			AEP_Utilities.AnimationUtils.RewindAnimation("BM_Junk", "BM_09", "Default");
			AEP_Utilities.AnimationUtils.RewindAnimation("BM_Whole", "BM_10", "Default");
			if (UnityEngine.GameObject.Find("BM_Particle_Cans_1"))
			{
				AEP_Utilities.AnimationUtils.PlayParticles(UnityEngine.GameObject.Find("BM_Particle_Cans_1"), false);
				MenuController.ShowScanImage(true);
			}

		}
		public void Animate(bool animate)
		{
			switch (animate)
			{
				case true:
					AEP_Utilities.AnimationUtils.RewindAnimation("BM_Birds1", "BM_09", "Default");
					AEP_Utilities.AnimationUtils.RewindAnimation("BM_Birds2", "BM_09", "Default");
					AEP_Utilities.AnimationUtils.RewindAnimation("BM_Junk", "BM_09", "Default");
					AEP_Utilities.AnimationUtils.RewindAnimation("BM_Whole", "BM_10", "Default");
					AEP_Utilities.AnimationUtils.PlayAnimation("BM_Birds1", "BM_09", false, "Loop");
					AEP_Utilities.AnimationUtils.PlayAnimation("BM_Birds2", "BM_09", false, "Loop");
					AEP_Utilities.AnimationUtils.PlayAnimation("BM_Junk", "BM_09", false, "Loop");
					AEP_Utilities.AnimationUtils.PlayAnimation("BM_Whole", "BM_10", false, "Loop");
					if (UnityEngine.GameObject.Find("BM_Particle_Cans_1"))
					{
						AEP_Utilities.AnimationUtils.PlayParticles(UnityEngine.GameObject.Find("BM_Particle_Cans_1"), true);
					}

					AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
					MenuController.ShowTapActivateImage(false);
					break;
				case false:
					AEP_Utilities.AnimationUtils.RewindAnimation("BM_Birds1", "BM_09", "Default");
					AEP_Utilities.AnimationUtils.RewindAnimation("BM_Birds2", "BM_09", "Default");
					AEP_Utilities.AnimationUtils.RewindAnimation("BM_Junk", "BM_09", "Default");
					AEP_Utilities.AnimationUtils.RewindAnimation("BM_Whole", "BM_10", "Default");
					if (UnityEngine.GameObject.Find("BM_Particle_Cans_1"))
					{
						AEP_Utilities.AnimationUtils.PlayParticles(UnityEngine.GameObject.Find("BM_Particle_Cans_1"), false);
					}

					break;
				default:
					break;
			}
			
		}
	}
}
