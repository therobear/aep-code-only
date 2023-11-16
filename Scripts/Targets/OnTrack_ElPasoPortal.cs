//MD5Hash:820d8e539d9c08529bf15189ec48efee;
using UnityEngine;
using System;
using Vuforia;
using System.Text;


public class OnTrack_ElPasoPortal : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject[] wercAnimControllers = null;
	public UnityEngine.GameObject[] starObjects = null;
	public UnityEngine.GameObject[] freewayParts = null;
	public float freewayTimeOut = 0f;
	public float shinySpeed = 0f;


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
	public override void onScan(bool track)
	{
		switch (allowTracking)
		{
			case true:
				switch (track)
				{
					case true:
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
						for (int i_335 = 0; i_335 < freewayParts.Length; i_335++)
						{
							AEP_Utilities.ObjectUtils.showSprite(freewayParts[i_335], false, true);
						}
						MenuController.ShowScanImage(false);
						animate(true);
						break;
					case false:
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
						for (int i_340 = 0; i_340 < freewayParts.Length; i_340++)
						{
							AEP_Utilities.ObjectUtils.showSprite(freewayParts[i_340], false, false);
						}
						MenuController.ShowScanImage(true);
						animate(false);
						break;
					default:
						break;
				}
				
				break;
			case false:
			default:
				break;
		}
		
	}
	public override void animate(bool animate)
	{
		switch (animate)
		{
			case true:
				///True
				for (int i_317 = 0; i_317 < wercAnimControllers.Length; i_317++)
				{
					///True
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(wercAnimControllers[i_317], "Start");
				}
				///True
				for (int i_323 = 0; i_323 < starObjects.Length; i_323++)
				{
					///True
					AEP_Utilities.MaterialUtils.setObjectMaterialFloatProperty(starObjects[i_323], "_EnableEmit", 1f);
				}
				///True
				freewayParts[0].GetComponent<_2dxFX_Shiny_Reflect>().enabled = true;
				///True
				AEP_Utilities.Delay.DelayFunction(this, enableFreeway2, freewayTimeOut);
				break;
			case false:
				///False
				for (int i_368 = 0; i_368 < wercAnimControllers.Length; i_368++)
				{
					///False
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(wercAnimControllers[i_368], "Start");
					///False
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(wercAnimControllers[i_368], "Idle");
				}
				///False
				for (int i_374 = 0; i_374 < starObjects.Length; i_374++)
				{
					///False
					AEP_Utilities.MaterialUtils.setObjectMaterialFloatProperty(starObjects[i_374], "_EnableEmit", 0f);
				}
				///False
				for (int i_377 = 0; i_377 < freewayParts.Length; i_377++)
				{
					///False
					freewayParts[i_377].GetComponent<_2dxFX_Shiny_Reflect>().enabled = false;
				}
				///False
				DelayMethods.CancelAllDelays(this);
				break;
			default:
				break;
		}
		
	}
	public void init()
	{
		if (testing)
		{
		}
		else
		{
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), true, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_Geo_Root", true, "Shader Forge/Unlit_DS");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_Floor", false, "Shader Forge/Unlit_DS");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_Sky", false, "Shader Forge/Unlit_DS");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_Mts_Root", true, "Shader Forge/Unlit_DS");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_Star", false, "Shader Forge/WER_EPP_Pulse");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_StarLights2", false, "Shader Forge/WER_EPP_Pulse");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_StarLights3", false, "Shader Forge/WER_EPP_Pulse");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_StarLights4", false, "Shader Forge/WER_EPP_Pulse");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_StarLights5", false, "Shader Forge/WER_EPP_Pulse");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_PART_Circ1", false, "Mobile/Particles/Alpha Blended");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_PART_Circ2", false, "Mobile/Particles/VertexLit Blended");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_PART_Circ3", false, "Mobile/Particles/VertexLit Blended");
			AEP_Utilities.MaterialUtils.SetObjectShader("WER_EPP_Part_Lights", true, "Mobile/Particles/Alpha Blended");
		}

		wercAnimControllers[0] = UnityEngine.GameObject.Find("WER_EPP_Aligators_ROOT_OBJ");
		wercAnimControllers[1] = UnityEngine.GameObject.Find("WER_EPP_Mts_Root_Obj");
		wercAnimControllers[2] = UnityEngine.GameObject.Find("WER_EPP_Boy_Root");
		wercAnimControllers[3] = UnityEngine.GameObject.Find("WER_EPP_Geo_Root");
		starObjects[0] = UnityEngine.GameObject.Find("WER_EPP_Star");
		starObjects[1] = UnityEngine.GameObject.Find("WER_EPP_StarLights2");
		starObjects[2] = UnityEngine.GameObject.Find("WER_EPP_StarLights3");
		starObjects[3] = UnityEngine.GameObject.Find("WER_EPP_StarLights4");
		starObjects[4] = UnityEngine.GameObject.Find("WER_EPP_StarLights5");
		freewayParts[0] = UnityEngine.GameObject.Find("WER_EPP_Freeway1");
		freewayParts[1] = UnityEngine.GameObject.Find("WER_EPP_Freeway2");
		for (int i_346 = 0; i_346 < freewayParts.Length; i_346++)
		{
			freewayParts[i_346].GetComponent<_2dxFX_Shiny_Reflect>().AnimationSpeedReduction = shinySpeed;
		}
		allowTracking = true;
		onScan(false);
	}
	public void enableFreeway2()
	{
		freewayParts[1].GetComponent<_2dxFX_Shiny_Reflect>().enabled = true;
	}
}

