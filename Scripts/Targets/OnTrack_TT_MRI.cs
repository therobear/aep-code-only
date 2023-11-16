//MD5Hash:3f603708bdbb7042c940b6985476e0ec;
using Vuforia;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;


namespace Vuforia
{
	public class OnTrack_TT_MRI : UnityEngine.MonoBehaviour, ITrackableEventHandler
	{
		public bool TestInEditor = false;
		public string PlayerPrefsValue = "";
		public string AssetBundle = "";
		public string Asset = "";
		public bool bAllowTracking = false;
		private System.Collections.Generic.List<UnityEngine.GameObject> goMRIPieces = new System.Collections.Generic.List<UnityEngine.GameObject>();
		private int iStage = 1;
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
		private bool bExplodedViewReverse = false;
		private Vuforia.StateManager smStateManager = null;


		private void Awake()
		{
			MenuController.HideInfoGraphics();
			if (TestInEditor)
			{
				Init();
			}

		}
		void Start()
		{
			AEP_Utilities.UnityGUIUtils.EnablePanel("MRI_Panel", false);
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
			Main.EnableLoader("Loader_TT_MRI");
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
							AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_Brain_Whole", true, true);
							MenuController.ShowScanImage(false);
							MenuController.ShowTapActivateImage(true);
							break;
						case false:
							Animate(false);
							AEP_Utilities.ObjectUtils.ShowObject(gameObject.transform.GetChild(0).name, true, false);
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
			if (TestInEditor)
			{
			}
			else
			{
				AEP_Utilities.TransformUtils.SetObjectParent("Root_TT_MRI(Clone)", "Target_TT_MRI");
				AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_ExplodedView", true, false);
				AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_MRIView", true, false);
				AEP_Utilities.MaterialUtils.SetObjectShader("TT_MRI_ExplodedView", true, "Mobile/Bumped Specular");
				AEP_Utilities.MaterialUtils.SetObjectShader("TT_MRI_Brain_Whole", true, "Shader Forge/Unlit_Op_Slider");
				AEP_Utilities.MaterialUtils.SetObjectShader("TT_MRI_Int", true, "Mobile/Unlit (Supports Lightmap)");
			}

			goMRIPieces.Add(UnityEngine.GameObject.Find("TT_MRI_Int01"));
			goMRIPieces.Add(UnityEngine.GameObject.Find("TT_MRI_Int02"));
			goMRIPieces.Add(UnityEngine.GameObject.Find("TT_MRI_Int03"));
			goMRIPieces.Add(UnityEngine.GameObject.Find("TT_MRI_Int04"));
			goMRIPieces.Add(UnityEngine.GameObject.Find("TT_MRI_Int05"));
			goMRIPieces.Add(UnityEngine.GameObject.Find("TT_MRI_Int06"));
			goMRIPieces.Add(UnityEngine.GameObject.Find("TT_MRI_Int07"));
			bAllowTracking = true;
			OnScan(false);
		}
		public void Animate(bool animate)
		{
			switch (animate)
			{
				case true:
					AEP_Utilities.UnityGUIUtils.EnablePanel("MRI_Panel", true);
					AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
					MRIView();
					break;
				case false:
					AEP_Utilities.UnityGUIUtils.EnablePanel("MRI_Panel", false);
					AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_ExplodedView", true, false);
					AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_MRIView", true, false);
					AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
					iStage = 1;
					break;
				default:
					break;
			}
			
		}
		public void MRIView()
		{
			AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_Brain_Whole", true, true);
			AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_Int", true, false);
			AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_ExplodedView", true, false);
			AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
		}
		public void ExplodedView()
		{
			AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_Brain_Whole", true, false);
			AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_Int", true, false);
			AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_ExplodedView", true, true);
			AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
			switch (bExplodedViewReverse)
			{
				case true:
					AEP_Utilities.AnimationUtils.PlayAnimation("TT_MRI_ExplodedView", "TT_MRI_ExpView", true, "Default");
					bExplodedViewReverse = false;
					break;
				case false:
					AEP_Utilities.AnimationUtils.PlayAnimation("TT_MRI_ExplodedView", "TT_MRI_ExpView", false, "Default");
					bExplodedViewReverse = true;
					break;
				default:
					break;
			}
			
		}
		public void ShowMRIPieces()
		{
			AEP_Utilities.ObjectUtils.ShowObject("TT_MRI_Int", true, false);
			switch (iStage)
			{
				case 1:
					AEP_Utilities.ObjectUtils.ShowObject(goMRIPieces[0], false, true);
					break;
				case 2:
					AEP_Utilities.ObjectUtils.ShowObject(goMRIPieces[1], false, true);
					break;
				case 3:
					AEP_Utilities.ObjectUtils.ShowObject(goMRIPieces[2], false, true);
					break;
				case 4:
					AEP_Utilities.ObjectUtils.ShowObject(goMRIPieces[3], false, true);
					break;
				case 5:
					AEP_Utilities.ObjectUtils.ShowObject(goMRIPieces[4], false, true);
					break;
				case 6:
					AEP_Utilities.ObjectUtils.ShowObject(goMRIPieces[5], false, true);
					break;
				case 0:
					AEP_Utilities.ObjectUtils.ShowObject(goMRIPieces[6], false, true);
					break;
				default:
					break;
			}
			
			if ((iStage > 7))
			{
				iStage = 1;
				ShowMRIPieces();
			}

			if ((iStage < 8))
			{
				iStage ++;
			}

		}
	}


}
