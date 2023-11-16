//MD5Hash:2923d323ec1a8764225448dd259b157b;
using Vuforia;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;


namespace Vuforia
{
	public class OnTrack_Omecoatl : UnityEngine.MonoBehaviour, Vuforia.ITrackableEventHandler
	{
		public bool testing = false;
		public string loaderName = "";
		public string playerPrefsValue = "";
		public string assetBundle = "";
		public string asset = "";
		public string rootObject = "";
		public UnityEngine.Vector3 startPos;
		public UnityEngine.Vector3 destPos;
		public UnityEngine.GameObject[] backgroundObjs = null;
		private bool allowTracking = false;
		private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
		public System.Collections.Generic.List<UnityEngine.GameObject> omecoatlObjects = null;
		public System.Collections.Generic.List<UnityEngine.GameObject> omecoatlParticles = null;
		public UnityEngine.GameObject backgroundObject = null;
		public UnityEngine.RuntimeAnimatorController backgroundController = null;
		public int currentIndex = 0;


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
			string gsgEarth = "";
			string gsgMoltenPlanet = "";
			string gsgAsteroidBelt = "";
			string gsgPurplePlanet = "";
			string gsgGasGiant = "";
			string gsgGreenTones = "";
			string gsgSpaceBackground = "";

			if (testing)
			{
				///True
				rootObject = "Root_Omecoatl";
				backgroundObject = UnityEngine.GameObject.Find("GSG_SpaceBackgrounds");
			}
			else
			{
				///False
				rootObject = new System.Text.StringBuilder(asset).Append("(Clone)").ToString();
				///False
				AEP_Utilities.TransformUtils.SetObjectParent(rootObject, name);
				///False
				AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Shader Forge/GSG_OME_Pulse");
				///False
				AEP_Utilities.MaterialUtils.SetObjectShader("GSG_OME_Particles_Red", false, "Mobile/Particles/Additive");
				///False
				AEP_Utilities.MaterialUtils.SetObjectShader("GSG_OME_Particles_Blue", false, "Mobile/Particles/Additive");
				///False
				AEP_Utilities.AssetBundleUtils.getNestedAsset(this, assetBundle, "GSG_SpaceBackgrounds");
				backgroundObject = UnityEngine.GameObject.Find("GSG_SpaceBackgrounds(Clone)");
				AEP_Utilities.AnimationUtils.addAnimatorController(backgroundObject, backgroundController);
				AEP_Utilities.TransformUtils.SetObjectRotation(backgroundObject, false, new UnityEngine.Vector3(-90f, 0f, 180f));
				AEP_Utilities.TransformUtils.SetObjectPosition(backgroundObject, false, new UnityEngine.Vector3(-1.304f, 0f, -3.631f));
			}

			///Finished
			startPos = UnityEngine.GameObject.Find(rootObject).transform.localPosition;
			///Finished
			omecoatlObjects.Add(UnityEngine.GameObject.Find("GSG_OME_Body"));
			///Finished
			omecoatlObjects.Add(UnityEngine.GameObject.Find("GSG_OME_Body-B"));
			///Finished
			omecoatlObjects.Add(UnityEngine.GameObject.Find("GSG_OME_Head"));
			///Finished
			omecoatlObjects.Add(UnityEngine.GameObject.Find("GSG_OME_Head001"));
			///Finished
			omecoatlObjects.Add(UnityEngine.GameObject.Find("GSG_OME_Tongue-R"));
			///Finished
			omecoatlObjects.Add(UnityEngine.GameObject.Find("GSG_OME_Tongue-R001"));
			///Finished
			omecoatlParticles.Add(UnityEngine.GameObject.Find("GSG_OME_Particles_Red"));
			///Finished
			omecoatlParticles.Add(UnityEngine.GameObject.Find("GSG_OME_Particles_Blue"));
			///Finished
			AEP_Utilities.Delay.DelayFunction(this, hideBackgrounds, 1f);
			///Finished
			AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, true);
			backgroundObjs[0] = UnityEngine.GameObject.Find("GSG_OME_Ear_Space_ROOT");
			backgroundObjs[1] = UnityEngine.GameObject.Find("GSG_OME_GG_Space_ROOT");
			backgroundObjs[2] = UnityEngine.GameObject.Find("GSG_OME_Gt_Space_ROOT");
			backgroundObjs[3] = UnityEngine.GameObject.Find("GSG_OME_MP_Space_ROOT");
			backgroundObjs[4] = UnityEngine.GameObject.Find("GSG_OME_PP_Space_ROOT");
			///Finished
			allowTracking = true;
			///Finished
			onScan(false);
		}
		public void onScan(bool track)
		{
			switch (allowTracking)
			{
				case true:
					switch (track)
					{
						case true:
							///True
							AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
							///True
							for (int i_281 = 0; i_281 < omecoatlObjects.Count; i_281++)
							{
								///True
								AEP_Utilities.MaterialUtils.setObjectMaterialFloatProperty(omecoatlObjects[i_281], "_EnableEmit", 1f);
							}
							///True
							for (int i_300 = 0; i_300 < omecoatlParticles.Count; i_300++)
							{
								///True
								AEP_Utilities.AnimationUtils.PlayParticles(omecoatlParticles[i_300], true);
							}
							setBackground();
							///True
							MenuController.ShowScanImage(false);
							///True
							animate(true);
							break;
						case false:
							///False
							AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
							AEP_Utilities.ObjectUtils.ShowObject(backgroundObject, true, false);
							///False
							for (int i_288 = 0; i_288 < omecoatlObjects.Count; i_288++)
							{
								///False
								AEP_Utilities.MaterialUtils.setObjectMaterialFloatProperty(omecoatlObjects[i_288], "_EnableEmit", 0f);
							}
							///False
							for (int i_306 = 0; i_306 < omecoatlParticles.Count; i_306++)
							{
								///False
								AEP_Utilities.AnimationUtils.PlayParticles(omecoatlParticles[i_306], false);
							}
							///False
							MenuController.ShowScanImage(true);
							///False
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
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("GSG_Omecoatl", "Breathe");
					MenuController.ShowTapActivateImage(true);
					AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, true);
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(backgroundObject, "Idle");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(backgroundObject, "Start");
					break;
				case false:
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("GSG_Omecoatl", "Breathe");
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("GSG_Omecoatl", "Roar");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("GSG_Omecoatl", "Idle");
					AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, false);
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(backgroundObject, "Start");
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(backgroundObject, "Idle");
					break;
				default:
					break;
			}
			
		}
		public void startRoar()
		{
			AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
			AEP_Utilities.TransformUtils.MoveObject(rootObject, true, destPos, 3f);
			AEP_Utilities.Delay.DelayFunction(this, playRoar, 3f);
		}
		public void enableCollider()
		{
			AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
			MenuController.ShowTapActivateImage(true);
		}
		public void playRoar()
		{
			MenuController.ShowTapActivateImage(false);
			AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("GSG_Omecoatl", "Roar");
			AEP_Utilities.Delay.DelayFunction(this, enableCollider, 7.5f);
		}
		public void resetPosition()
		{
			AEP_Utilities.TransformUtils.MoveObject(rootObject, true, startPos, 3f);
			AEP_Utilities.Delay.DelayFunction(this, enableCollider, 3f);
		}
		public void setBackground()
		{
			int randomNumber = 0;

			randomNumber = UnityEngine.Random.Range(0, (backgroundObjs.Length - 1));
			if ((randomNumber == currentIndex))
			{
				setBackground();
			}
			else
			{
				AEP_Utilities.ObjectUtils.ShowObject(backgroundObjs[randomNumber], true, true);
				currentIndex = randomNumber;
			}

		}
		public void hideBackgrounds()
		{
			AEP_Utilities.ObjectUtils.ShowObject(backgroundObject, true, false);
			AEP_Utilities.MaterialUtils.SetObjectShader(backgroundObject, true, "Unlit/Texture");
		}
		public void setAsteroidBeltShaders()
		{
			UnityEngine.Renderer[] render = null;

			AEP_Utilities.MaterialUtils.SetObjectShader(backgroundObjs[2], true, "Sprites/Default");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[2].name).Append("/Big Stars").ToString(), false, "Unlit/ScreenBlend (Looping)");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[2].name).Append("/Stars").ToString(), false, "Unlit/ScreenBlend (Looping + Flickering)");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[2].name).Append("/Asteroid Field01").ToString(), false, "Unlit/Looping");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[2].name).Append("/Asteroid Field02").ToString(), false, "Unlit/Looping");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[2].name).Append("/Asteroid Field03").ToString(), false, "Unlit/Looping");
		}
		public void setEarthShaders()
		{
			AEP_Utilities.MaterialUtils.SetObjectShader(backgroundObjs[0], true, "Sprites/Default");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[0].name).Append("/Big Stars").ToString(), false, "Unlit/ScreenBlend (Looping + Flickering)");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[0].name).Append("/Stars").ToString(), false, "Unlit/ScreenBlend (Looping + Flickering)");
		}
		public void setGasGiantShaders()
		{
			AEP_Utilities.MaterialUtils.SetObjectShader(backgroundObjs[4], true, "Sprites/Default");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[4].name).Append("/Big Stars").ToString(), false, "Unlit/ScreenBlend (Looping)");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[4].name).Append("/Stars").ToString(), false, "Unlit/ScreenBlend (Looping + Flickering)");
		}
		public void setGreenTonesShaders()
		{
			AEP_Utilities.MaterialUtils.SetObjectShader(backgroundObjs[5], true, "Sprites/Default");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[5].name).Append("/Bright Stars").ToString(), false, "Unlit/ScreenBlend (Looping)");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[5].name).Append("/Big Stars").ToString(), false, "Unlit/ScreenBlend (Looping)");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[5].name).Append("/Stars").ToString(), false, "Unlit/ScreenBlend (Looping + Flickering)");
		}
		public void setMoltenPlanetShaders()
		{
			AEP_Utilities.MaterialUtils.SetObjectShader(backgroundObjs[1], true, "Sprites/Default");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[1].name).Append("/Big Stars").ToString(), false, "Unlit/ScreenBlend (Looping)");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[1].name).Append("/Stars").ToString(), false, "Unlit/ScreenBlend (Looping + Flickering)");
		}
		public void setPurplePlanetShaders()
		{
			AEP_Utilities.MaterialUtils.SetObjectShader(backgroundObjs[3], true, "Sprites/Default");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[3].name).Append("/Big Stars").ToString(), false, "Unlit/ScreenBlend (Looping + Flickering)");
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(backgroundObjs[3].name).Append("/Stars").ToString(), false, "Unlit/ScreenBlend (Looping + Flickering)");
		}
	}
}
