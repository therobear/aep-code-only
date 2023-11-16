//MD5Hash:a1747dba8bd4f161fe304060450d1e51;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using Vuforia;


public class OnTrack_FullSteam : Vuforia.AEPImageTrackerBase
{
	public System.Collections.Generic.List<UnityEngine.GameObject> jellyObjects = null;
	public UnityEngine.GameObject jellyObject = null;


	void Awake()
	{
		if (testing)
		{
			init();
		}

	}
	public override void animate(bool animate)
	{
		switch (animate)
		{
			case true:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(jellyObject, "Idle");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(jellyObject, "Start");
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(jellyObject, "Start");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(jellyObject, "Idle");
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
	public void init()
	{
		if (testing)
		{
		}
		else
		{
			///False
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Frame", true, "PBR_Double_Sided_Emmisive");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Cloth", false, "Standard");
			AEP_Utilities.MaterialUtils.setStandardShaderProperties("FSA_Cloth", "ALPHABLEND_ON");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Gear_Lrg001", true, "Shaders/Unlit_DS+Op+NRM");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Gear_Lrg001", false, "Shader Forge/Unlit_DS_Color");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Gear_Med", false, "Standard");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Propller", false, "Shader Forge/Unlit_DS_Color");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Frame001", true, "PBR_Double_Sided_Emmisive");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Cloth001", false, "Standard");
			AEP_Utilities.MaterialUtils.setStandardShaderProperties("FSA_Cloth001", "ALPHABLEND_ON");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Gear_Lrg002", true, "Shaders/Unlit_DS+Op+NRM");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Gear_Lrg002", false, "Shader Forge/Unlit_DS_Color");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Gear_Med001", false, "Standard");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Propller001", false, "Shader Forge/Unlit_DS_Color");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Frame002", true, "PBR_Double_Sided_Emmisive");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Cloth002", false, "Standard");
			AEP_Utilities.MaterialUtils.setStandardShaderProperties("FSA_Cloth002", "ALPHABLEND_ON");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Gear_Lrg003", true, "Shaders/Unlit_DS+Op+NRM");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Gear_Lrg003", false, "Shader Forge/Unlit_DS_Color");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Gear_Med002", false, "Standard");
			AEP_Utilities.MaterialUtils.SetObjectShader("FSA_Propller002", false, "Shader Forge/Unlit_DS_Color");
		}

		///Finished
		jellyObject = UnityEngine.GameObject.Find("FSA_Jelly_LP");
		///Finished
		allowTracking = true;
		///Finished
		MenuController.ShowScanImage(true);
		///Finished
		onScan(false);
	}
	public void setJellyShaders(string jelly)
	{
		string partentObj = "";

		partentObj = new System.Text.StringBuilder(jelly).Append("/FSA_Jelly_LP").ToString();
		AEP_Utilities.MaterialUtils.SetObjectShader(partentObj, false, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Cloth").ToString(), false, "Standard");
		AEP_Utilities.MaterialUtils.setStandardShaderProperties(new System.Text.StringBuilder(partentObj).Append("/FSA_Cloth").ToString(), "ALPHABLEND_ON");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Stem").ToString(), false, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Stem/FSA_Gear_Lrg001").ToString(), false, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Stem/FSA_Gear_Lrg001/FSA_Link48").ToString(), true, "Shaders/Unlit_DS+Op+NRM");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Stem/FSA_Gear_Lrg001/FSA_Link096").ToString(), true, "Shaders/Unlit_DS+Op+NRM");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Stem/FSA_Gear_Lrg001/FSA_Link144").ToString(), true, "Shaders/Unlit_DS+Op+NRM");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Stem/FSA_Gear_Lrg001/FSA_Link192").ToString(), true, "Shaders/Unlit_DS+Op+NRM");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Stem/FSA_Gear_Lrg001/FSA_Link240").ToString(), true, "Shaders/Unlit_DS+Op+NRM");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Stem/FSA_Gear_Lrg001/FSA_Link288").ToString(), true, "Shaders/Unlit_DS+Op+NRM");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Stem/FSA_Gear_Med").ToString(), true, "Standard");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/FSA_Stem/FSA_Propller").ToString(), true, "Standard");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/Object011").ToString(), true, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/Object012").ToString(), true, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/Object013").ToString(), true, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/Object014").ToString(), true, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/Object015").ToString(), true, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/Object016").ToString(), true, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/Object017").ToString(), true, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/Object018").ToString(), true, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/Object019").ToString(), true, "PBR_Double_Sided_Emmisive");
		AEP_Utilities.MaterialUtils.SetObjectShader(new System.Text.StringBuilder(partentObj).Append("/Object020").ToString(), true, "PBR_Double_Sided_Emmisive");
	}
	public void startJelly(int jellyIndex)
	{
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(jellyObjects[jellyIndex], "Start");
	}
}
