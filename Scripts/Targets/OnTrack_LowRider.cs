//MD5Hash:5830ac95507492f246af11f28416ab46;
using UnityEngine;
using Vuforia;
using System;
using System.Text;


public class OnTrack_LowRider : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject lowRiderObject = null;


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
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(lowRiderObject, "Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(lowRiderObject, "Start_Hop");
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(lowRiderObject, "Start_Hop");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(lowRiderObject, "Start");
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
		if (testing)
		{
			///True
			lowRiderObject = UnityEngine.GameObject.Find("Root_LowRider/LEL_01");
		}
		else
		{
			///False
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), true, "Shader Forge/Reg_Color+Spec+Gloss");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_29", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_29", false, "Legacy Shaders/Transparent/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_31", false, "Legacy Shaders/Transparent/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_33", false, "Legacy Shaders/Transparent/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_35", false, "Legacy Shaders/Transparent/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_37", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShaderMultiMat("LEL_38", "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_50", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_53", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_54", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_55", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_57", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_58", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_59", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_60", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_61", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_62", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShaderMultiMat("LEL_65", "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_66", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_68", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_71", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_72", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_73", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_74", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_75", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_76", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_78", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_79", false, "Shader Forge/Fresnel");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_82", false, "Shader Forge/Fresnel");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_76", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_104", false, "Legacy Shaders/Transparent/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_106", false, "Legacy Shaders/Transparent/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_108", false, "Legacy Shaders/Transparent/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_111", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_112", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_115", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShaderMultiMat("LEL_113", "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShaderMultiMat("LEL_114", "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_117", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_118", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_120", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_121", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_123", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_124", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_126", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_127", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_128", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_138", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_139", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_141", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_142", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_144", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_145", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_149", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_150", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_152", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_153", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_155", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_156", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_164", false, "Legacy Shaders/Transparent/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_165", false, "Legacy Shaders/Transparent/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_167", false, "Legacy Shaders/Transparent/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_208", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_210", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_212", false, "Shader Forge/Fresnel");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_216", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_228", false, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("LEL_233", false, "Legacy Shaders/Diffuse");
			///False
			lowRiderObject = UnityEngine.GameObject.Find("Root_LowRider(Clone)/LEL_01");
		}

		///Finished
		allowTracking = true;
		///Finished
		MenuController.ShowScanImage(true);
		///Finished
		onScan(false);
	}
}
