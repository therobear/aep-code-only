//MD5Hash:f8a021ef891aa0194eda0ae6bb12811e;
using UnityEngine;
using Vuforia;
using System;
using System.Text;


public class OnTrack_HerBody : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject geoRoot = null;


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
		UnityEngine.Renderer[] renderArray = null;

		renderArray = UnityEngine.GameObject.Find("HBSD_Whole").GetComponentsInChildren<UnityEngine.Renderer>(false);
		switch (animate)
		{
			case true:
				for (int i_298 = 0; i_298 < renderArray.Length; i_298++)
				{
					if (renderArray[i_298].material.HasProperty("_CanAnimate"))
					{
						renderArray[i_298].material.SetInt("_CanAnimate", 1);
					}

				}
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(geoRoot, "Idle");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(geoRoot, "Start");
				break;
			case false:
				for (int i_304 = 0; i_304 < renderArray.Length; i_304++)
				{
					if (renderArray[i_304].material.HasProperty("_CanAnimate"))
					{
						renderArray[i_304].material.SetInt("_CanAnimate", 0);
					}

				}
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(geoRoot, "Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(geoRoot, "Idle");
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
	public void OnDestroy()
	{
		Vuforia.TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
		Main.EnableLoader(loaderName);
	}
	public void init()
	{
		UnityEngine.Renderer[] render = null;

		if (testing)
		{
		}
		else
		{
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			render = UnityEngine.GameObject.Find("HBSD_Whole").GetComponentsInChildren<UnityEngine.Renderer>(false);
			for (int i_253 = 0; i_253 < render.Length; i_253++)
			{
				if (render[i_253].name.Contains("HSBD_"))
				{
					AEP_Utilities.MaterialUtils.SetObjectShader(render[i_253].name, false, "Shaders/HBSD_StarField");
				}

				if (render[i_253].name.Contains("HSBD_SnakeTat"))
				{
					AEP_Utilities.MaterialUtils.SetObjectShader(render[i_253].name, false, "Shader Forge/Unlit_DS+UVOS");
					AEP_Utilities.MaterialUtils.SetObjectShader("HBSD_Frame", false, "Legacy Shaders/Diffuse");
					AEP_Utilities.MaterialUtils.SetObjectShader("HBSD_Frame001", false, "Mask/DepthMask");
					AEP_Utilities.MaterialUtils.SetObjectShader("HSBD_SnakeTat_Hand_L", false, "Shaders/HBSD_SnakePattern");
					AEP_Utilities.MaterialUtils.SetObjectShader("HSBD_SnakeTat_Hand_R", false, "Shaders/HBSD_SnakePattern");
					AEP_Utilities.MaterialUtils.SetObjectShader("HBSD_Hair", false, "Mobile/Unlit (Supports Lightmap)");
				}

			}
		}

		geoRoot = UnityEngine.GameObject.Find("HBSD_Whole");
		allowTracking = true;
		MenuController.ShowScanImage(true);
		onScan(false);
	}
}

