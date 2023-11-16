//MD5Hash:a5a0da937dc1a7e229f12ceccd0c75ad;
using UnityEngine;
using System;
using Vuforia;
using System.Text;


public class OnTrack_LightSaber : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject lightsaberBladeObject = null;
	public UnityEngine.AudioClip[] lightSaberAudio = null;
	public bool isActive = false;


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
	public override void animate(bool animate)
	{
		switch (animate)
		{
			case true:
				AEP_Utilities.TransformUtils.ScaleTweenOnAxis(lightsaberBladeObject, "Z", 2.53781f, 0.25f);
				AEP_Utilities.AudioVideoUtils.SetAudioSourceClip(gameObject, lightSaberAudio[0]);
				gameObject.GetComponent<UnityEngine.AudioSource>().loop = false;
				AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, true);
				AEP_Utilities.Delay.DelayFunction(this, lightSaberIdle, 1.3f);
				break;
			case false:
				AEP_Utilities.TransformUtils.ScaleTweenOnAxis(lightsaberBladeObject, "Z", 0f, 0.25f);
				AEP_Utilities.AudioVideoUtils.SetAudioSourceClip(gameObject, lightSaberAudio[2]);
				gameObject.GetComponent<UnityEngine.AudioSource>().loop = false;
				AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, true);
				break;
			default:
				break;
		}
		
	}
	public override void onScan(bool track)
	{
		switch (allowTracking)
		{
			case true:
				switch (track)
				{
					case true:
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
						MenuController.ShowScanImage(false);
						break;
					case false:
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, gameObject, false);
						MenuController.ShowScanImage(true);
						AEP_Utilities.TransformUtils.SetObjectScale(lightsaberBladeObject, new UnityEngine.Vector3(0.7209806f, 0.7209806f, 0f));
						gameObject.GetComponent<UnityEngine.AudioSource>().loop = false;
						AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, false);
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
	public void OnDestroy()
	{
		Vuforia.TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
		Main.EnableLoader(loaderName);
	}
	public void init()
	{
		if (testing)
		{
		}
		else
		{
			///False
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LS", true, "Unlit/Texture");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LS_Light", false, "Shader Forge/Fresnel");
		}

		///Finished
		lightsaberBladeObject = UnityEngine.GameObject.Find("LS_Light");
		///Finished
		allowTracking = true;
		MenuController.ShowScanImage(true);
		///Finished
		onScan(false);
	}
	public void lightSaberIdle()
	{
		AEP_Utilities.AudioVideoUtils.SetAudioSourceClip(gameObject, lightSaberAudio[1]);
		gameObject.GetComponent<UnityEngine.AudioSource>().loop = true;
		AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, true);
	}
	public void activateLightSaber()
	{
		if (isActive)
		{
			isActive = false;
		}
		else
		{
			isActive = true;
		}

		animate(isActive);
	}
}
