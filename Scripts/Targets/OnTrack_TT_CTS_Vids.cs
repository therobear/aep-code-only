//MD5Hash:b98936e391f42985c02c45b6337d05c3;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


namespace Vuforia
{
	public class OnTrack_TT_CTS_Vids : UnityEngine.MonoBehaviour, ITrackableEventHandler
	{
		public UnityEngine.GameObject goMoviePlayer = null;
		public string loaderName = "";
		public bool bAllowTracking = false;
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
		private Vuforia.StateManager smStateManager = null;


		void Awake()
		{
			MenuController.HideInfoGraphics();
		}
		void Start()
		{
			goMoviePlayer = gameObject;
			mTrackableBehaviour = gameObject.GetComponent<Vuforia.TrackableBehaviour>();
			smStateManager = Vuforia.TrackerManager.Instance.GetStateManager();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
				Init();
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
							Animate(true);
							AEP_Utilities.ObjectUtils.ShowObject(transform.GetChild(0).name, false, true);
							MenuController.ShowScanImage(false);
							break;
						case false:
							Animate(false);
							AEP_Utilities.ObjectUtils.ShowObject(transform.GetChild(0).name, false, false);
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
					OnScan(false);
					break;
			}
			
		}
		public void Init()
		{
			bAllowTracking = true;
			OnScan(false);
		}
		public void Animate(bool animate)
		{
			switch (animate)
			{
				case true:
					AEP_Utilities.AudioVideoUtils.SetMovieTextureProperties(goMoviePlayer, "Loop", true);
					AEP_Utilities.AudioVideoUtils.SetMovieTextureState(goMoviePlayer, "Play");
					break;
				case false:
					AEP_Utilities.AudioVideoUtils.SetMovieTextureProperties(goMoviePlayer, "Loop", true);
					AEP_Utilities.AudioVideoUtils.SetMovieTextureState(goMoviePlayer, "Stop");
					AEP_Utilities.AudioVideoUtils.SetMovieTextureState(goMoviePlayer, "Rewind");
					break;
				default:
					break;
			}
			
		}
	}


}
