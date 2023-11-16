//MD5Hash:ca15ee6547f23e8577667cb1e0cc2d22;
using System;
using UnityEngine;
using Vuforia;
using System.Text;


public class OnTrack_MadreAgua : Vuforia.AEPImageTrackerBase
{
	public float cemelliFadeInWaitTime = 0f;
	public float cemelliFadeInTime = 0f;
	public float sandraFadeInWaitTime = 0f;
	public float sandraFadeInTime = 0f;
	public float hawkFlapLoopWaitTime = 0f;
	public UnityEngine.GameObject zpMaPattern = null;
	public UnityEngine.GameObject zpMaWater = null;
	public UnityEngine.Texture[] textureList = null;
	public bool animateUV = false;
	public float bgUVOffset = 0f;
	public float waterUVOfset = 0f;


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
	public void LateUpdate()
	{
		UnityEngine.Vector2 bgVector2;
		UnityEngine.Vector2 waterVector2;

		if (animateUV)
		{
			bgVector2 = zpMaPattern.GetComponent<UnityEngine.Renderer>().material.GetTextureOffset("_MainTex");
			zpMaPattern.GetComponent<UnityEngine.Renderer>().material.SetTextureOffset("_MainTex", new UnityEngine.Vector2(bgVector2.x, (bgVector2.y + bgUVOffset)));
			waterVector2 = zpMaWater.GetComponent<UnityEngine.Renderer>().material.GetTextureOffset("_MainTex");
			zpMaWater.GetComponent<UnityEngine.Renderer>().material.SetTextureOffset("_MainTex", new UnityEngine.Vector2((waterVector2.x + waterUVOfset), waterVector2.y));
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
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, true, true);
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, true);
						MenuController.ShowScanImage(false);
						MenuController.ShowTapActivateImage(true);
						break;
					case false:
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, true, false);
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
						MenuController.ShowScanImage(true);
						animate(false);
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
				onScan(false);
				break;
		}
		
	}
	public override void animate(bool animate)
	{
		switch (animate)
		{
			case true:
				///True
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("ZP_MA_03", "Start");
				///True
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("ZP_MA_Hawk_02", "Show");
				///True
				animateUV = true;
				///True
				AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, true);
				///True
				startEyeBlink();
				///True
				AEP_Utilities.Delay.DelayFunction(this, animateHawk, hawkFlapLoopWaitTime);
				AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
				MenuController.ShowTapActivateImage(false);
				break;
			case false:
				///False
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("ZP_MA_03", "Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("ZP_MA_03", "Idle");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("ZP_MA_Hawk_02", "Idle");
				///False
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("ZP_MA_Hawk_02", "Show");
				///False
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState("ZP_MA_Hawk_02", "Flap");
				///False
				AEP_Utilities.MaterialUtils.SetObjectShader("ZP_MA_Cemelli", false, "Mobile/Unlit (Supports Lightmap)");
				///False
				AEP_Utilities.MaterialUtils.SetObjectShader("ZP_MA_Cemelli_Braid", false, "Mobile/Unlit (Supports Lightmap)");
				///False
				AEP_Utilities.MaterialUtils.SetObjectShader("ZP_MA_Sandra", false, "Mobile/Unlit (Supports Lightmap)");
				///False
				AEP_Utilities.MaterialUtils.SetObjectShader("ZP_MA_HandMoon", false, "Mobile/Unlit (Supports Lightmap)");
				///False
				AEP_Utilities.MaterialUtils.SetObjectShader("ZP_MA_Hawk", false, "Mobile/Unlit (Supports Lightmap)");
				///False
				AEP_Utilities.MaterialUtils.SetObjectShader(zpMaPattern, false, "Mobile/Unlit (Supports Lightmap)");
				///False
				AEP_Utilities.MaterialUtils.SetObjectShader(zpMaWater, false, "Mobile/Unlit (Supports Lightmap)");
				///False
				AEP_Utilities.MaterialUtils.SetObjectTexture("ZP_MA_Cemelli", "_Texture", textureList[2]);
				///False
				AEP_Utilities.MaterialUtils.SetObjectTexture("ZP_MA_Sandra", "_Texture", textureList[5]);
				///False
				AEP_Utilities.MaterialUtils.SetObjectTexture("ZP_MA_Cemelli_Braid", "_Texture", textureList[0]);
				///False
				resetUV();
				///False
				AEP_Utilities.AudioVideoUtils.PlayAudioSource(gameObject, false);
				///False
				animateUV = false;
				AEP_Utilities.Delay.CancelAllDelays(this);
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
			AEP_Utilities.MaterialUtils.SetObjectShader("ZP_MA_Cemelli", false, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("ZP_MA_Cemelli_Braid", false, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("ZP_MA_Sandra", false, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("ZP_MA_HandMoon", false, "Mobile/Unlit (Supports Lightmap)");
			AEP_Utilities.MaterialUtils.SetObjectShader("ZP_MA_Hawk", false, "Mobile/Unlit (Supports Lightmap)");
		}

		zpMaPattern = UnityEngine.GameObject.Find("ZP_MA_Pattern");
		zpMaWater = UnityEngine.GameObject.Find("ZP_MA_Water");
		AEP_Utilities.MaterialUtils.SetObjectShader(zpMaPattern, false, "Mobile/Unlit (Supports Lightmap)");
		AEP_Utilities.MaterialUtils.SetObjectShader(zpMaWater, false, "Mobile/Unlit (Supports Lightmap)");
		allowTracking = true;
		MenuController.ShowScanImage(true);
		onScan(false);
	}
	public void startEyeBlink()
	{
		eyeBlink01();
		AEP_Utilities.Delay.DelayFunction(this, eyeBlink02, 0.2f);
		AEP_Utilities.Delay.DelayFunction(this, eyeBlink03, 0.4f);
		AEP_Utilities.Delay.DelayFunction(this, eyeBlink04, 0.7f);
		AEP_Utilities.Delay.DelayFunction(this, eyeBlink05, 0.9f);
		AEP_Utilities.Delay.DelayFunction(this, eyeBlink06, 1.1f);
		AEP_Utilities.Delay.DelayFunction(this, startEyeBlink, 3.3f);
	}
	public void animateHawk()
	{
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState("ZP_MA_Hawk_02", "Flap");
		AEP_Utilities.Delay.DelayFunction(this, animateHawk, hawkFlapLoopWaitTime);
	}
	public void fadeInCemelli()
	{
	}
	public void fadeInSandra()
	{
	}
	public void resetUV()
	{
		zpMaPattern.GetComponent<UnityEngine.Renderer>().material.SetTextureOffset("_MainTex", UnityEngine.Vector2.zero);
		zpMaWater.GetComponent<UnityEngine.Renderer>().material.SetTextureOffset("_MainTex", UnityEngine.Vector2.zero);
	}
	public void eyeBlink01()
	{
		AEP_Utilities.MaterialUtils.SetObjectTexture("ZP_MA_Sandra", textureList[5]);
	}
	public void eyeBlink02()
	{
		AEP_Utilities.MaterialUtils.SetObjectTexture("ZP_MA_Sandra", textureList[4]);
	}
	public void eyeBlink03()
	{
		AEP_Utilities.MaterialUtils.SetObjectTexture("ZP_MA_Sandra", textureList[3]);
	}
	public void eyeBlink04()
	{
		AEP_Utilities.MaterialUtils.SetObjectTexture("ZP_MA_Cemelli", textureList[2]);
	}
	public void eyeBlink05()
	{
		AEP_Utilities.MaterialUtils.SetObjectTexture("ZP_MA_Cemelli", textureList[1]);
	}
	public void eyeBlink06()
	{
		AEP_Utilities.MaterialUtils.SetObjectTexture("ZP_MA_Cemelli", textureList[0]);
	}
}
