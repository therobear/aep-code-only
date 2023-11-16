//MD5Hash:96303f3de742e92be259a75b2acf68e6;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


namespace Vuforia
{
	public class OnTrack_Receive : UnityEngine.MonoBehaviour, Vuforia.ITrackableEventHandler
	{
		public bool testing = false;
		public string loaderName = "";
		public string playerPrefsValue = "";
		public string assetBundle = "";
		public string asset = "";
		private bool allowTracking = false;
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
		public UnityEngine.ParticleSystem[] particles = null;


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
				OnScan(true);
			}
			else
			{
				OnScan(false);
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
				AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTTR_Woman", true, "Shaders/Twitchy_MNTTR");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTTR_Woman+Bckgrnd", false, "Shaders/Twitchy_MNTTR");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTTR_Particles", true, "Mobile/Particles/Alpha Blended");
			}

			particles = UnityEngine.GameObject.Find("MNTTR_Particles").GetComponentsInChildren<UnityEngine.ParticleSystem>(false);
			allowTracking = true;
			OnScan(false);
		}
		public void OnScan(bool track)
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
					OnScan(false);
					break;
			}
			
		}
		public void OnDestroy()
		{
			Vuforia.TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
			Main.EnableLoader(loaderName);
		}
		public void animate(bool animate)
		{
			switch (animate)
			{
				case true:
					AEP_Utilities.AnimationUtils.PlayAnimation("MNTTR_Woman+Bckgrnd", "MNTTR_Woman_Blink", false, "Loop");
					playParticles(true);
					break;
				case false:
					AEP_Utilities.AnimationUtils.RewindAnimation("MNTTR_Woman+Bckgrnd", "MNTTR_Woman_Blink", "Default");
					playParticles(false);
					break;
				default:
					break;
			}
			
		}
		public void playParticles(bool play)
		{
			for (int i_374 = 0; i_374 < particles.Length; i_374++)
			{
				AEP_Utilities.AnimationUtils.PlayParticles(particles[i_374].gameObject, play);
			}
		}
	}


}
