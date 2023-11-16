//MD5Hash:ae37bfcc70baad0ba04aa90c42967527;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using AEP_Utilities;

namespace Vuforia
{
	public class OnTrack_Neuromuscular : AEPImageTrackerBase
	{
		public List<GameObject> VestList;
		public List<AudioClip> soundList;
		public int iStage = 0;
		private TrackableBehaviour mTrackabgleBehaviour;

		void Awake()
		{
			MenuController.HideInfoGraphics();
			if (testing)
			{
				init();
			}

		}
		void Start()
		{
			mTrackabgleBehaviour = gameObject.GetComponent<Vuforia.TrackableBehaviour>();

			if (mTrackabgleBehaviour)
			{
				mTrackabgleBehaviour.RegisterTrackableEventHandler(this);

                if (!testing)
                {
                    AssetBundleUtils.GetAssetBundle(this, playerPrefsValue, assetBundle, asset, init);
                }

                MenuController.HideInfoGraphics();
            }

		}
		
		public void OnDestroy()
		{
            TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackabgleBehaviour.Trackable);
			Main.EnableLoader(loaderName);
		}
		public override void onScan(bool track)
		{
			switch (allowTracking)
			{
				case true:
					switch (track)
					{
						case true:
							animate(true);
							ObjectUtils.ShowObject(gameObject, true, true);
							MenuController.ShowScanImage(false);
							break;
						case false:
							animate(false);
							ObjectUtils.ShowObject(gameObject, true, false);
							MenuController.ShowScanImage(true);
							MenuController.ShowTapActivateImage(false);
							break;
						default:
							break;
					}
					
					break;
				case false:
					Debug.Log("Asset not ready yet!");
					break;
			}
			
		}
		public void init()
		{
			GameObject[] goNJRoot = null;

			if (testing)
			{
				MaterialUtils.SetObjectShader("Root_Neuromuscular", true, "Shader Forge/Unlit");
				goNJRoot = FindObjectsOfType<GameObject>();
				for (int i_196 = 0; i_196 < goNJRoot.Length; i_196++)
				{
					if (goNJRoot[i_196].name.Contains("TT_NJ_Ves0"))
					{
						VestList.Add(goNJRoot[i_196]);
					}

					if (goNJRoot[i_196].name.Contains("TT_NJ_Txt"))
					{
						MaterialUtils.SetObjectShader(goNJRoot[i_196].name, true, "Shader Forge/Unlit_DS+Op");
					}

				}
			}
			else
			{
				TransformUtils.SetObjectParent("Root_Neuromuscular(Clone)", "Target_Neuromuscular");
				MaterialUtils.SetObjectShader("Root_Neuromuscular(Clone)", true, "Shader Forge/Unlit");
				goNJRoot = FindObjectsOfType<GameObject>();
				for (int i_196 = 0; i_196 < goNJRoot.Length; i_196++)
				{
					if (goNJRoot[i_196].name.Contains("TT_NJ_Ves0"))
					{
						VestList.Add(goNJRoot[i_196]);
					}

					if (goNJRoot[i_196].name.Contains("TT_NJ_Txt"))
					{
						MaterialUtils.SetObjectShader(goNJRoot[i_196].name, true, "Shader Forge/Unlit_DS+Op");
					}
                }

                soundList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("NMJ1"));
                soundList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("NMJ2"));
                soundList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("NMJ3"));
                soundList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("NMJ4"));
                soundList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("NMJ5"));
                soundList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("NMJ6"));
                soundList.Add(DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<AudioClip>("NMJ7"));
            }

			allowTracking = true;

			onScan(false);
		}
		public override void animate(bool animate)
		{
			switch (animate)
			{
				case true:
					ObjectUtils.EnableCollider(gameObject, false, true);
					AnimationUtils.PlayAnimation("TT_NJ_Acetylcholine", "TT_NJ_Acetylcholine_Loop", false, "Loop");
					MenuController.ShowTapActivateImage(true);
					for (int i_177 = 0; i_177 < VestList.Count; i_177++)
					{
						ObjectUtils.ShowObject(VestList[i_177], false, true);
					}
					break;
				case false:
					ObjectUtils.EnableCollider(gameObject, false, false);
					AnimationUtils.RewindAnimation("TT_NJ_Whole", "Stage01", "Default");
					AnimationUtils.RewindAnimation("TT_NJ_Acetylcholine", "TT_NJ_Acetylcholine_Loop", "Default");
					iStage = 0;
					AudioVideoUtils.PlayAudioSource(gameObject, false);
					break;
				default:
					break;
			}
			
		}
		public void Flow01()
		{
			AnimationUtils.PlayAnimation("TT_NJ_Acetylcholine", "TT_NJ_Acetylcholine_Flow1", false, "Default");
			for (int i_206 = 0; i_206 < VestList.Count; i_206++)
			{
				ObjectUtils.ShowObject(VestList[i_206], false, false);
			}
		}
		public void Flow02()
		{
			AnimationUtils.PlayAnimation("TT_NJ_Acetylcholine", "TT_NJ_Acetylcholine_Flow2", false, "Default");
		}
		public void SetStage()
		{
			switch (iStage)
			{
				case 1:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage01", false, "Default");
					break;
				case 2:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage02", false, "Default");
					break;
				case 3:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage03", false, "Default");
					break;
				case 4:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage04", false, "Default");
					break;
				case 5:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage05", false, "Default");
					break;
				case 6:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage06", false, "Default");
					break;
				case 7:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage07", false, "Default");
					break;
				case 8:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage08", false, "Default");
					break;
				case 9:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage09", false, "Default");
					break;
				case 10:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage10", false, "Default");
					break;
				case 11:
					AnimationUtils.PlayAnimation("TT_NJ_Acetylcholine", "TT_NJ_Acetylcholine_Flow1", false, "Default");
					for (int i_227 = 0; i_227 < VestList.Count; i_227++)
					{
						ObjectUtils.ShowObject(VestList[i_227], false, false);
					}
					break;
				case 12:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage12", false, "Default");
					break;
				case 13:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage13", false, "Default");
					break;
				case 14:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage14", false, "Default");
					break;
				case 15:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage15", false, "Default");
					break;
				case 16:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage16", false, "Default");
					break;
				case 17:
					AnimationUtils.PlayAnimation("TT_NJ_Acetylcholine", "TT_NJ_Acetylcholine_Flow2", false, "Default");
					break;
				case 18:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage18", false, "Default");
					break;
				case 19:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage19", false, "Default");
					break;
				case 20:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage20", false, "Default");
					break;
				case 21:
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage21", false, "Default");
					break;
				default:
					break;
			}
			
			if ((iStage < 21))
			{
				iStage ++;
			}
			else
			{
				return;
			}

		}
		public IEnumerator eSetStageNew()
		{
			MenuController.ShowTapActivateImage(false);
			var _TempVar_274_1 = gameObject;
			ObjectUtils.EnableCollider(_TempVar_274_1, false, false);
			switch (iStage)
			{
				case 0:
					AudioVideoUtils.SetAudioSourceClip(_TempVar_274_1, soundList[0]);
					AudioVideoUtils.PlayAudioSource(_TempVar_274_1, true);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage01", false, "Default");
					yield return new WaitForSeconds(3f);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage02", false, "Default");
					yield return new WaitForSeconds(3f);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage03", false, "Default");
					yield return new WaitForSeconds(3f);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage04", false, "Default");
					yield return new WaitForSeconds(3f);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage05", false, "Default");
					yield return new WaitForSeconds(36f);
					ObjectUtils.EnableCollider(_TempVar_274_1, false, true);
					MenuController.ShowTapActivateImage(true);
					break;
				case 1:
					AudioVideoUtils.SetAudioSourceClip(_TempVar_274_1, soundList[1]);
					AudioVideoUtils.PlayAudioSource(_TempVar_274_1, _TempVar_274_1);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage06", false, "Default");
					yield return new WaitForSeconds(5.5f);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage08", false, "Default");
					yield return new WaitForSeconds(2.5f);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage09", false, "Default");
					yield return new WaitForSeconds(6f);
					ObjectUtils.EnableCollider(_TempVar_274_1, false, true);
					MenuController.ShowTapActivateImage(true);
					break;
				case 2:
					AudioVideoUtils.SetAudioSourceClip(_TempVar_274_1, soundList[2]);
					AudioVideoUtils.PlayAudioSource(_TempVar_274_1, true);
					yield return new WaitForSeconds(6f);
					AnimationUtils.PlayAnimation("TT_NJ_Acetylcholine", "TT_NJ_Acetylcholine_Flow1", false, "Default");
					for (int i_316 = 0; i_316 < VestList.Count; i_316++)
					{
						ObjectUtils.ShowObject(VestList[i_316], false, false);
					}
					yield return new WaitForSeconds(7.5f);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage14", false, "Default");
					yield return new WaitForSeconds(18.5f);
					ObjectUtils.EnableCollider(_TempVar_274_1, false, true);
					MenuController.ShowTapActivateImage(true);
					break;
				case 3:
					AudioVideoUtils.SetAudioSourceClip(_TempVar_274_1, soundList[3]);
					AudioVideoUtils.PlayAudioSource(_TempVar_274_1, true);
					AnimationUtils.PlayAnimation("TT_NJ_Acetylcholine", "TT_NJ_Acetylcholine_Flow2", false, "Default");
					yield return new WaitForSeconds(15f);
					ObjectUtils.EnableCollider(_TempVar_274_1, false, true);
					MenuController.ShowTapActivateImage(true);
					break;
				case 4:
					AudioVideoUtils.SetAudioSourceClip(_TempVar_274_1, soundList[4]);
					AudioVideoUtils.PlayAudioSource(_TempVar_274_1, true);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage19", false, "Default");
					yield return new WaitForSeconds(9f);
					AEP_Utilities.AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage20", false, "Default");
					yield return new WaitForSeconds(9f);
					ObjectUtils.EnableCollider(_TempVar_274_1, false, true);
					MenuController.ShowTapActivateImage(true);
					break;
				case 5:
					AudioVideoUtils.SetAudioSourceClip(_TempVar_274_1, soundList[5]);
					AudioVideoUtils.PlayAudioSource(_TempVar_274_1, true);
					yield return new WaitForSeconds(4f);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage21", false, "Default");
					yield return new WaitForSeconds(7f);
					AnimationUtils.PlayAnimation("TT_NJ_Whole", "Stage22", false, "Default");
					yield return new WaitForSeconds(34f);
					ObjectUtils.EnableCollider(_TempVar_274_1, false, true);
					MenuController.ShowTapActivateImage(true);
					break;
				case 6:
					AudioVideoUtils.SetAudioSourceClip(_TempVar_274_1, soundList[6]);
					AudioVideoUtils.PlayAudioSource(_TempVar_274_1, true);
					for (int i_395 = 0; i_395 < VestList.Count; i_395++)
					{
						ObjectUtils.ShowObject(VestList[i_395], false, true);
						AnimationUtils.PlayAnimation("TT_NJ_Acetylcholine", "TT_NJ_Acetylcholine_Loop", false, "Loop");
						yield return new WaitForSeconds(30f);
						ObjectUtils.EnableCollider(_TempVar_274_1, false, true);
						MenuController.ShowTapActivateImage(true);
					}
					break;
				default:
					break;
			}
			
			if ((iStage < 7))
			{
				iStage ++;
			}
			else
			{
				yield return null;
			}

		}
		public void setStageNew()
		{
			this.StartCoroutine(eSetStageNew());
		}
	}
}
