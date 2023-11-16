//MD5Hash:f25ee225ffb27f35424efbc3b52b2c90;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


namespace Vuforia
{
	public class OnTrack_RioBravo : UnityEngine.MonoBehaviour, ITrackableEventHandler
	{
		public bool TestInEditor = false;
		public string PlayerPrefsValue = "";
		public string AssetBundle = "";
		public string Asset = "";
		public string MoviePlayerMesh = "";
		public UnityEngine.GameObject goMoviePlayer = null;
		public string loaderName = "";
		public bool bAllowTracking = false;
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
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
			Main.EnableLoader(loaderName);
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
		public void Init()
		{
			if (TestInEditor)
			{
			}
			else
			{
				AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(Asset).Append("(Clone)").ToString(), name);
				AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Mobile/Unlit (Supports Lightmap)");
			}

			goMoviePlayer = gameObject;
			AEP_Utilities.AudioVideoUtils.SetMoviePlayerMesh(name, MoviePlayerMesh);
			MenuController.ShowScanImage(true);
			AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
			bAllowTracking = true;
			OnScan(false);
		}
		public void OnScan(bool track)
		{
			switch (bAllowTracking)
			{
				case true:
					switch (track)
					{
						case true:
							AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
							MenuController.ShowScanImage(false);
							AEP_Utilities.AudioVideoUtils.SetMovieTextureProperties(goMoviePlayer, "Loop", true);
							Utilities.SetMovieTextureState(goMoviePlayer, "Play");
							break;
						case false:
							AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
							MenuController.ShowScanImage(true);
							AEP_Utilities.AudioVideoUtils.SetMovieTextureProperties(goMoviePlayer, "Loop", false);
							Utilities.SetMovieTextureState(goMoviePlayer, "Stop");
							Utilities.SetMovieTextureState(goMoviePlayer, "Rewind");
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
	}
}
