//MD5Hash:fe855d61fd0911e1508f5d51010b865d;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


namespace Vuforia
{
	public class OnTrack_Octogirl : UnityEngine.MonoBehaviour, Vuforia.ITrackableEventHandler
	{
		public bool testing = false;
		public string loaderName = "";
		public string playerPrefsValue = "";
		public string assetBundle = "";
		public string asset = "";
		public UnityEngine.GameObject octogirlHead = null;
		public UnityEngine.GameObject octogirlShells = null;
		private bool bAllowTracking = false;
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;


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
			if (testing)
			{
				octogirlHead = UnityEngine.GameObject.Find("Root_Octogirl/FS_OG_Head");
				octogirlShells = UnityEngine.GameObject.Find("Root_Octogirl/FS_OG_Shells");
			}
			else
			{
				AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
				AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
				AEP_Utilities.MaterialUtils.SetObjectShader("FS_OG_Background", false, "Unlit/Transparent");
				AEP_Utilities.MaterialUtils.SetObjectShader("Root_Octogirl(Clone)/FS_OG_Head", true, "Mobile/Unlit (Supports Lightmap)");
				AEP_Utilities.MaterialUtils.SetObjectShader("Root_Octogirl(Clone)/FS_OG_Shells", true, "Mobile/Unlit (Supports Lightmap)");
				AEP_Utilities.MaterialUtils.SetObjectShader("FS_OG__Sun", false, "Unlit/Transparent");
				AEP_Utilities.MaterialUtils.SetObjectShader("FS_OG_RedOval", false, "Unlit/Transparent");
				octogirlHead = UnityEngine.GameObject.Find("Root_Octogirl(Clone)/FS_OG_Head");
				octogirlShells = UnityEngine.GameObject.Find("Root_Octogirl(Clone)/FS_OG_Shells");
			}

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
			hideTenticleControls();
			switch (animate)
			{
				case true:
					AEP_Utilities.AnimationUtils.PlayAnimation(octogirlHead, "Head_Start", false, "Loop");
					AEP_Utilities.AnimationUtils.PlayAnimation(octogirlShells, "Shells_Start", false, "Loop");
					break;
				case false:
					AEP_Utilities.AnimationUtils.RewindAnimation(octogirlHead, "Head_Start", "Default");
					AEP_Utilities.AnimationUtils.RewindAnimation(octogirlShells, "Shells_Start", "Default");
					break;
				default:
					break;
			}
			
		}
		public void hideTenticleControls()
		{
			UnityEngine.Renderer[] controls01 = null;
			UnityEngine.Renderer[] controls02 = null;
			UnityEngine.Renderer[] controls03 = null;
			UnityEngine.Renderer[] controls04 = null;

			controls01 = UnityEngine.GameObject.Find("FS_OG_Tent001").GetComponentsInChildren<UnityEngine.Renderer>(false);
			controls02 = UnityEngine.GameObject.Find("FS_OG_Tent006").GetComponentsInChildren<UnityEngine.Renderer>(false);
			controls03 = UnityEngine.GameObject.Find("FS_OG_Tent007").GetComponentsInChildren<UnityEngine.Renderer>(false);
			controls04 = UnityEngine.GameObject.Find("FS_OG_Tent008").GetComponentsInChildren<UnityEngine.Renderer>(false);
			for (int i_193 = 0; i_193 < controls01.Length; i_193++)
			{
				if (controls01[i_193].name.Contains("FS_Octo_BN_CTRL"))
				{
					UnityEngine.Object.Destroy(controls01[i_193], 0f);
				}

			}
			for (int i_201 = 0; i_201 < controls02.Length; i_201++)
			{
				if (controls02[i_201].name.Contains("FS_Octo_BN_CTRL"))
				{
					UnityEngine.Object.Destroy(controls02[i_201], 0f);
				}

			}
			for (int i_209 = 0; i_209 < controls03.Length; i_209++)
			{
				if (controls03[i_209].name.Contains("FS_Octo_BN_CTRL"))
				{
					UnityEngine.Object.Destroy(controls03[i_209], 0f);
				}

			}
			for (int i_217 = 0; i_217 < controls04.Length; i_217++)
			{
				if (controls04[i_217].name.Contains("FS_Octo_BN_CTRL"))
				{
					UnityEngine.Object.Destroy(controls04[i_217], 0f);
				}

			}
		}
	}


}
