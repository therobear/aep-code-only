//MD5Hash:f4477949565e318c414ced828f10ca15;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


namespace Vuforia
{
	public class OnTrack_GimpToof : UnityEngine.MonoBehaviour, Vuforia.ITrackableEventHandler
	{
		public bool testing = false;
		public string loaderName = "";
		public string playerPrefsValue = "";
		public string assetBundle = "";
		public string asset = "";
		private bool bAllowTracking = false;
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
		private MegaMorph megaMorph = null;
		private UnityEngine.ParticleSystem particleSystemGF = null;
		public UnityEngine.RuntimeAnimatorController animatorController = null;


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
					megaMorph.SetAnimTime(0f);
					megaMorph.animate = true;
					particleSystemGF.Play();
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("GT3D_05", "Start");
					break;
				case false:
					megaMorph.animate = false;
					megaMorph.SetAnimTime(0f);
					particleSystemGF.Stop();
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("GT3D_05", "Idle");
					break;
				default:
					break;
			}
			
		}
		public void init()
		{
			UnityEngine.Renderer[] gimpToofRenderer = null;

			if (testing)
			{
			}
			else
			{
				AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
				gimpToofRenderer = UnityEngine.GameObject.Find("GT3D_05").GetComponentsInChildren<UnityEngine.Renderer>(false);
				for (int i_134 = 0; i_134 < UnityEngine.GameObject.Find("GT3D_05").GetComponentsInChildren<UnityEngine.Renderer>(false).Length; i_134++)
				{
					if (gimpToofRenderer[i_134].material.shader.name.Contains("Shader Forge/Blinn_Spec+DS+OP"))
					{
						AEP_Utilities.MaterialUtils.SetObjectShader(gimpToofRenderer[i_134].gameObject, false, "Shader Forge/Blinn_Spec+DS+OP");
					}

					if ((gimpToofRenderer[i_134].gameObject.name == "GT"))
					{
						AEP_Utilities.MaterialUtils.SetObjectShaderMultiMat("GT", "Shader Forge/Blinn_Spec+DS+OP");
					}

					AEP_Utilities.MaterialUtils.SetObjectShader("GimpToof_Particles", false, "Particles/Alpha Blended Premultiply");
				}
			}

			megaMorph = UnityEngine.GameObject.Find("GT3D_05").GetComponent<MegaMorph>();
			particleSystemGF = UnityEngine.GameObject.Find("GimpToof_Particles").GetComponent<UnityEngine.ParticleSystem>();
			UnityEngine.GameObject.Find("GT3D_05").GetComponent<UnityEngine.Animator>().runtimeAnimatorController = animatorController;
			bAllowTracking = true;
			onScan(false);
		}
	}


}
