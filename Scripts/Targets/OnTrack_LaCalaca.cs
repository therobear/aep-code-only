//MD5Hash:d036772e2563fd3568979c92579ecc4e;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


namespace Vuforia
{
	public class OnTrack_LaCalaca : UnityEngine.MonoBehaviour, ITrackableEventHandler
	{
		public bool TestInEditor = false;
		public string PlayerPrefsValue = "";
		public string AssetBundle = "";
		public string Asset = "";
		public string LoaderName = "";
		public UnityEngine.Color[] colorList = new UnityEngine.Color[4];
		private bool bAllowTracking = false;
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
		private Vuforia.StateManager smStateManager = null;
		private int iNewRandomNumber = 0;
		private int iCurrentRandomNumber = 0;
		private UnityEngine.GameObject gSkull = null;


		void Awake()
		{
			if (TestInEditor)
			{
				Init();
			}

		}
		public void Start()
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
		public void OnDestroy()
		{
			smStateManager.DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
			Main.EnableLoader(LoaderName);
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
							Animate(true);
							break;
						case false:
							AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
							MenuController.ShowScanImage(true);
							Animate(false);
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
				AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(Asset).Append("(Clone)").ToString(), name);
				AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Shader Forge/Reg_Color+Spec+Gloss");
			}

			gSkull = UnityEngine.GameObject.Find("Skull");
			colorList[0] = UnityEngine.Color.cyan;
			colorList[1] = UnityEngine.Color.magenta;
			colorList[2] = UnityEngine.Color.yellow;
			colorList[0] = UnityEngine.Color.black;
			bAllowTracking = true;
			OnScan(false);
		}
		public void Animate(bool animate)
		{
			switch (animate)
			{
				case true:
					AEP_Utilities.AnimationUtils.PlayAnimation("Loteria_LaCalaca_01", "LT_LC_01", false, "Loop");
					SetCalacaColor();
					break;
				case false:
					AEP_Utilities.AnimationUtils.RewindAnimation("Loteria_LaCalaca_01", "LT_LC_01", "Default");
					AEP_Utilities.Delay.CancelLeanTweenOnObject(gSkull);
					AEP_Utilities.MaterialUtils.SetObjectColor(gSkull, false, colorList[3]);
					AEP_Utilities.Delay.CancelAllDelays(this);
					break;
				default:
					break;
			}
			
		}
		public void SetCalacaColor()
		{
			iNewRandomNumber = UnityEngine.Random.Range(0, (colorList.Length - 1));
			if ((iCurrentRandomNumber == iNewRandomNumber))
			{
				SetCalacaColor();
			}

			AEP_Utilities.MaterialUtils.TweenObjectColor(gSkull, colorList[iNewRandomNumber], 2f);
			AEP_Utilities.Delay.DelayFunction(this, SetCalacaColor, 3f);
		}
	}


}
