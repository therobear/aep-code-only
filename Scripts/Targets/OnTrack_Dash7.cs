//MD5Hash:0e6b2e359433f5dc683cff6567aae2ab;
using UnityEngine;
using System;
using System.Collections.Generic;
using Vuforia;
using System.Text;


public class OnTrack_Dash7 : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject dash7Env01Object = null;
	public UnityEngine.GameObject dash7Env02Object = null;
	public int passCount = 0;
	public System.Collections.Generic.List<UnityEngine.GameObject> roadsideObjects = null;
	public UnityEngine.GameObject rootObject = null;
	public System.Collections.Generic.List<UnityEngine.GameObject> crankObjects = null;


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
				AEP_Utilities.TransformUtils.MoveObject(dash7Env01Object, true, new UnityEngine.Vector3(-66.1f, 0f, 27f), 10f);
				AEP_Utilities.TransformUtils.MoveObject(dash7Env02Object, true, new UnityEngine.Vector3(-66.1f, 0f, 27f), 20f);
				AEP_Utilities.Delay.DelayFunction(this, moveEnv01, 10f);
				AEP_Utilities.Delay.DelayFunction(this, moveEnv02, 20f);
				for (int i_404 = 0; i_404 < crankObjects.Count; i_404++)
				{
					AEP_Utilities.TransformUtils.RotateAroundAxis(crankObjects[i_404].name, new UnityEngine.Vector3(0f, 0f, 1f), 360f, 10f, -1, true);
				}
				break;
			case false:
				AEP_Utilities.Delay.CancelAllDelays(this);
				AEP_Utilities.TransformUtils.SetObjectPosition(dash7Env01Object, true, new UnityEngine.Vector3(0f, 0f, 27f));
				AEP_Utilities.TransformUtils.SetObjectPosition(dash7Env02Object, true, new UnityEngine.Vector3(66.27f, 0f, 27f));
				AEP_Utilities.Delay.CancelAllLeanTween();
				for (int i_387 = 0; i_387 < roadsideObjects.Count; i_387++)
				{
					AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[i_387], rootObject);
					AEP_Utilities.TransformUtils.SetObjectPosition(roadsideObjects[i_387], true, new UnityEngine.Vector3(66.27f, 0f, 19f));
				}
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
	}
	public void init()
	{
		if (testing)
		{
			rootObject = UnityEngine.GameObject.Find("Root_Dash7");
		}
		else
		{
			///False
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			rootObject = UnityEngine.GameObject.Find(new System.Text.StringBuilder(asset).Append("(Clone)").ToString());
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Shader Forge/Reg_Spec+Gloss+Nrml");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("Dash7_Sky", false, "ShtoporGames/Unlit/LinearGradient");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Van_SP", 0, "Legacy Shaders/Transparent/Specular");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Van_SP", 1, "Mobile/Unlit (Supports Lightmap)");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Van_SP", 2, "Mobile/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Van_SP", 3, "Mobile/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Van_SP", 4, "Mobile/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Van_SP", 5, "Mobile/Bumped Specular");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Van_SP", 6, "Legacy Shaders/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Env_SP", 0, "Mobile/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Env_SP", 1, "Mobile/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Env_SP", 2, "Unlit/Texture");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Env_SP", 3, "Mobile/Bumped Specular");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Env_SP_1", 0, "Mobile/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Env_SP_1", 1, "Mobile/Diffuse");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Env_SP_1", 2, "Unlit/Texture");
			///False
			AEP_Utilities.MaterialUtils.setObjectShaderMultiMatIndex("Dash07_Env_SP_1", 3, "Mobile/Bumped Specular");
			AEP_Utilities.MaterialUtils.SetObjectShader("Dash07_Crate", true, "Unlit/Texture");
		}

		///Finished
		dash7Env01Object = UnityEngine.GameObject.Find("Dash07_Env_SP");
		///Finished
		dash7Env02Object = UnityEngine.GameObject.Find("Dash07_Env_SP_1");
		roadsideObjects.Add(UnityEngine.GameObject.Find("Dash07_PH_SP"));
		roadsideObjects.Add(UnityEngine.GameObject.Find("Dash07_GS_SP"));
		roadsideObjects.Add(UnityEngine.GameObject.Find("Dash07_HA_SP"));
		roadsideObjects.Add(UnityEngine.GameObject.Find("Dash07_SF_SP"));
		roadsideObjects.Add(UnityEngine.GameObject.Find("Dash07_Cafe_SP"));
		crankObjects.Add(UnityEngine.GameObject.Find("Dash7_Crank_Left"));
		crankObjects.Add(UnityEngine.GameObject.Find("Dash7_Crank_Right"));
		///Finished
		allowTracking = true;
		///Finished
		MenuController.ShowScanImage(true);
		///Finished
		onScan(false);
	}
	public void moveEnv01()
	{
		AEP_Utilities.TransformUtils.SetObjectPosition(dash7Env01Object, true, new UnityEngine.Vector3(66.27f, 0f, 27f));
		switch (passCount)
		{
			case 0:
				AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[4], rootObject);
				AEP_Utilities.TransformUtils.SetObjectPosition(roadsideObjects[4], true, new UnityEngine.Vector3(66.27f, 0f, 19f));
				AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[0], dash7Env01Object);
				break;
			case 1:
				AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[0], rootObject);
				AEP_Utilities.TransformUtils.SetObjectPosition(roadsideObjects[0], true, new UnityEngine.Vector3(66.27f, 0f, 19f));
				AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[1], dash7Env01Object);
				break;
			case 2:
				AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[1], rootObject);
				AEP_Utilities.TransformUtils.SetObjectPosition(roadsideObjects[1], true, new UnityEngine.Vector3(66.27f, 0f, 19f));
				AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[2], dash7Env01Object);
				break;
			case 3:
				AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[2], rootObject);
				AEP_Utilities.TransformUtils.SetObjectPosition(roadsideObjects[2], true, new UnityEngine.Vector3(66.27f, 0f, 19f));
				AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[3], dash7Env01Object);
				break;
			case 4:
				AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[1], rootObject);
				AEP_Utilities.TransformUtils.SetObjectPosition(roadsideObjects[1], true, new UnityEngine.Vector3(66.27f, 0f, 19f));
				AEP_Utilities.TransformUtils.SetObjectParent(roadsideObjects[2], dash7Env01Object);
				break;
			default:
				break;
		}
		
		AEP_Utilities.TransformUtils.MoveObject(dash7Env01Object, true, new UnityEngine.Vector3(-66.1f, 0f, 27f), 20f);
		AEP_Utilities.Delay.DelayFunction(this, moveEnv01, 20f);
		passCount = (passCount + 1);
		if ((passCount > 4))
		{
			passCount = 0;
		}

	}
	public void moveEnv02()
	{
		AEP_Utilities.TransformUtils.SetObjectPosition(dash7Env02Object, true, new UnityEngine.Vector3(66.27f, 0f, 27f));
		AEP_Utilities.TransformUtils.MoveObject(dash7Env02Object, true, new UnityEngine.Vector3(-66.1f, 0f, 27f), 20f);
		AEP_Utilities.Delay.DelayFunction(this, moveEnv02, 20f);
	}
}
