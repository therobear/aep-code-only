//MD5Hash:f243069e3261e87498beaece65db5870;
using Vuforia;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;


namespace Vuforia
{
	public class OnTrack_Chulada : UnityEngine.MonoBehaviour, Vuforia.ITrackableEventHandler
	{
		public bool testing = false;
		public string loaderName = "";
		public string playerPrefsValue = "";
		public string assetBundle = "";
		public string asset = "";
		public System.Collections.Generic.List<UnityEngine.GameObject> chuladaLines = null;
		public int previouslyPlayedLines = 0;
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
		public void OnDestoy()
		{
			Vuforia.TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
			Main.EnableLoader(loaderName);
		}
		public void init()
		{
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines1"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines2"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines3"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines5"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines6"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines7"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines7"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines8"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines9"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines11"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines12"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines13"));
			chuladaLines.Add(UnityEngine.GameObject.Find("MNTK_Lines2"));
			if (testing)
			{
			}
			else
			{
				AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
				AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Shader Forge/Unlit");
				AEP_Utilities.MaterialUtils.SetObjectShader("MTNK_Clouds", false, "Shader Forge/Unlit_Txtr+Alpha");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTK_BackgroundPlane", false, "Shaders/Unlit_Gradient");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTK_Girl/MNTK_Girl", false, "Mobile/Unlit (Supports Lightmap)");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTK_Girl_Arm_R", false, "Mobile/Unlit (Supports Lightmap)");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTK_Girl_ArmL", false, "Mobile/Unlit (Supports Lightmap)");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTK_Girl_ArmL_Fingers001", false, "Mobile/Unlit (Supports Lightmap)");
				AEP_Utilities.MaterialUtils.SetObjectShader("MNTK_Antenna", false, "Mobile/Unlit (Supports Lightmap)");
			}

			AEP_Utilities.TransformUtils.SetObjectPosition("MNTK_Lines6", true, new UnityEngine.Vector3(-3.06f, 18.4f, 14.82f));
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
							MenuController.ShowTapActivateImage(false);
							previouslyPlayedLines = 0;
							animate(false);
							AEP_Utilities.Delay.CancelAllDelays(this);
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
					AEP_Utilities.AnimationUtils.PlayAnimation("MNTK_RenderPlane", "MNTK_RenderPlane_Ani", false, "Default");
					AEP_Utilities.TransformUtils.SetObjectPosition("MNTK_Lines10", true, new UnityEngine.Vector3(11.27f, -6.5f, 3.38f));
					AEP_Utilities.TransformUtils.SetObjectPosition("MNTK_Lines6", true, new UnityEngine.Vector3(-3.06f, 18.4f, 14.82f));
					AEP_Utilities.Delay.DelayFunction(this, playRenderCamera, 2f);
					break;
				case false:
					AEP_Utilities.AnimationUtils.RewindAnimation("MNTK_Girl_Whole/MNTK_Girl", "MNTK_Girl_Idle", "Default");
					AEP_Utilities.AnimationUtils.RewindAnimation("MNTK_RenderPlane", "MNTK_RenderPlane_Ani", "Default");
					AEP_Utilities.AnimationUtils.RewindAnimation("MNTK_Girl_RendCam", "MNTK_Cam_Ani", "Default");
					for (int i_234 = 0; i_234 < chuladaLines.Count; i_234++)
					{
						AEP_Utilities.AnimationUtils.RewindAnimation(chuladaLines[i_234], chuladaLines[i_234].name, "Default");
						AEP_Utilities.TransformUtils.SetObjectPosition("MNTK_Lines10", true, new UnityEngine.Vector3(11.27f, -6.5f, 3.38f));
						AEP_Utilities.TransformUtils.SetObjectPosition("MNTK_Lines6", true, new UnityEngine.Vector3(-3.06f, 18.4f, 14.82f));
					}
					break;
				default:
					break;
			}
			
		}
		public void randomizeAnimation()
		{
			AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, true);
			if ((chuladaLines[previouslyPlayedLines].name == "MNTK_Lines6"))
			{
				AEP_Utilities.TransformUtils.SetObjectPosition("MNTK_Lines6", true, new UnityEngine.Vector3(-10.99f, 7.98f, -2.02f));
			}

			AEP_Utilities.AnimationUtils.PlayAnimation(chuladaLines[previouslyPlayedLines].name, chuladaLines[previouslyPlayedLines].name, 1.5f, false, "Default");
			previouslyPlayedLines ++;
			if ((chuladaLines[previouslyPlayedLines].name == "MNTK_Lines14"))
			{
				previouslyPlayedLines = 0;
				AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
				MenuController.ShowTapActivateImage(false);
			}

		}
		public void playGirlIdle()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("MNTK_Girl_Whole/MNTK_Girl", "MNTK_Girl_Idle", false, "PingPong");
			AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
			MenuController.ShowTapActivateImage(true);
		}
		public void playRenderCamera()
		{
			AEP_Utilities.AnimationUtils.PlayAnimation("MNTK_Girl_RendCam", "MNTK_Cam_Ani", false, "Default");
			AEP_Utilities.Delay.DelayFunction(this, playGirlIdle, 4.5f);
		}
	}


}
