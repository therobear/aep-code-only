//MD5Hash:29e7d020b69a29c019de793b71f960d8;
using UnityEngine;
using System.Collections.Generic;
using System;
using Vuforia;
using System.Text;


public class OnTrack_Kiosk : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject kioskCloudsObject = null;
	public UnityEngine.GameObject kioskObject = null;
	public UnityEngine.GameObject kioskProfilesObject = null;
	public System.Collections.Generic.List<UnityEngine.GameObject> particlesList = null;
	public int pageIndex = 0;
	public System.Collections.Generic.List<UnityEngine.GameObject> page01Objects = null;
	public System.Collections.Generic.List<UnityEngine.GameObject> page02Objects = null;
	public System.Collections.Generic.List<UnityEngine.GameObject> page03Objects = null;


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
				for (int i_316 = 0; i_316 < particlesList.Count; i_316++)
				{
					AEP_Utilities.AnimationUtils.PlayParticles(particlesList[i_316], true);
				}
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(kioskCloudsObject, "Idle");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(kioskCloudsObject, "Start");
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(kioskObject, "Idle");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(kioskObject, "Start");
				for (int i_413 = 0; i_413 < page01Objects.Count; i_413++)
				{
					AEP_Utilities.ObjectUtils.ShowObject(page01Objects[i_413], true, false);
				}
				for (int i_418 = 0; i_418 < page02Objects.Count; i_418++)
				{
					AEP_Utilities.ObjectUtils.ShowObject(page02Objects[i_418], true, false);
				}
				for (int i_423 = 0; i_423 < page03Objects.Count; i_423++)
				{
					AEP_Utilities.ObjectUtils.ShowObject(page03Objects[i_423], true, false);
				}
				kioskOnTap();
				break;
			case false:
				for (int i_319 = 0; i_319 < particlesList.Count; i_319++)
				{
					AEP_Utilities.AnimationUtils.PlayParticles(particlesList[i_319], false);
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(kioskCloudsObject, "Start");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(kioskCloudsObject, "Idle");
					AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(kioskObject, "Start");
					AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(kioskObject, "Idle");
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
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
						MenuController.ShowScanImage(false);
						animate(true);
						break;
					case false:
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
						AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
						pageIndex = 0;
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
		}
		else
		{
			///False
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("DSK_CloudBox1", false, "Particles/Additive (Soft)");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("DSK_CloudBox002", false, "Mobile/Unlit (Supports Lightmap)");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("DSK_Kiosk", true, "Mobile/Bumped Specular");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("DSK_Glass", false, "Shader Forge/Fresnel");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("DSK_Profiles", true, "Mobile/Unlit (Supports Lightmap)");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("PS_1", false, "Mobile/Particles/Additive");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("PS_2", false, "Mobile/Particles/Additive");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("PS_3", false, "Mobile/Particles/Additive");
		}

		///Finished
		kioskCloudsObject = UnityEngine.GameObject.Find("DSK_CloudPillar1");
		///Finished
		kioskObject = UnityEngine.GameObject.Find("DSK_Kiosk");
		///Finished
		kioskProfilesObject = UnityEngine.GameObject.Find("DSK_Profiles");
		///Finished
		particlesList.Add(UnityEngine.GameObject.Find("PS_1"));
		///Finished
		particlesList.Add(UnityEngine.GameObject.Find("PS_2"));
		///Finished
		particlesList.Add(UnityEngine.GameObject.Find("PS_3"));
		page01Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT026"));
		page01Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT025"));
		page01Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT024"));
		page01Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT023"));
		page01Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT022"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT1"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT002"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT003"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT004"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT005"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT006"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT007"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT008"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT009"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT010"));
		page02Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT027"));
		page03Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT011"));
		page03Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT012"));
		page03Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT013"));
		page03Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT014"));
		page03Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT016"));
		page03Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT017"));
		page03Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT018"));
		page03Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT019"));
		page03Objects.Add(UnityEngine.GameObject.Find("DSK_Text_PT028"));
		///Finished
		allowTracking = true;
		///Finished
		MenuController.ShowScanImage(true);
		///Finished
		onScan(false);
	}
	public void kioskOnTap()
	{
		pageIndex = (pageIndex + 1);
		switch (pageIndex)
		{
			case 1:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(kioskProfilesObject, "Idle");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(kioskProfilesObject, "First");
				for (int i_459 = 0; i_459 < page03Objects.Count; i_459++)
				{
					AEP_Utilities.ObjectUtils.ShowObject(page03Objects[i_459], true, false);
				}
				for (int i_432 = 0; i_432 < page01Objects.Count; i_432++)
				{
					AEP_Utilities.ObjectUtils.ShowObject(page01Objects[i_432], true, true);
				}
				break;
			case 2:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(kioskProfilesObject, "First");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(kioskProfilesObject, "Second");
				for (int i_449 = 0; i_449 < page01Objects.Count; i_449++)
				{
					AEP_Utilities.ObjectUtils.ShowObject(page01Objects[i_449], true, false);
				}
				for (int i_437 = 0; i_437 < page02Objects.Count; i_437++)
				{
					AEP_Utilities.ObjectUtils.ShowObject(page02Objects[i_437], true, true);
				}
				break;
			case 3:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(kioskProfilesObject, "Second");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(kioskProfilesObject, "Third");
				for (int i_452 = 0; i_452 < page02Objects.Count; i_452++)
				{
					AEP_Utilities.ObjectUtils.ShowObject(page02Objects[i_452], true, false);
				}
				for (int i_440 = 0; i_440 < page03Objects.Count; i_440++)
				{
					AEP_Utilities.ObjectUtils.ShowObject(page03Objects[i_440], true, true);
				}
				pageIndex = 0;
				break;
			default:
				break;
		}
		
	}
}
