//MD5Hash:4bfe57c7a785e80341425a5dffc882ec;
using UnityEngine;
using Vuforia;
using System;
using System.Text;


public class OnTrack_GhostMeat : Vuforia.AEPImageTrackerBase
{
	public UnityEngine.GameObject ghostMeatPivot = null;
	public MegaMorph heartMorphObject = null;
	public UnityEngine.GameObject rootObject = null;
	public UnityEngine.GameObject ghostMeatParticles = null;


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
				ghostHoverUp();
				AEP_Utilities.AnimationUtils.PlayParticles(ghostMeatParticles, true);
				heartMorphObject.animate = true;
				break;
			case false:
				AEP_Utilities.Delay.CancelAllDelays(this);
				AEP_Utilities.Delay.CancelAllLeanTween();
				resetGhostPosition();
				AEP_Utilities.AnimationUtils.PlayParticles(ghostMeatParticles, false);
				heartMorphObject.animate = false;
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
			rootObject = UnityEngine.GameObject.Find(asset);
		}
		else
		{
			///False
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("GM_Ghost", false, "Shader Forge/Fresnel");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("GM_Heart_01", false, "Shader Forge/Fresnel");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("GM_Eye_L", false, "Unlit/Transparent");
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader("GM_Eye_R", false, "Unlit/Transparent");
			rootObject = UnityEngine.GameObject.Find(new System.Text.StringBuilder(asset).Append("(Clone)").ToString());
		}

		///Finished
		ghostMeatPivot = UnityEngine.GameObject.Find("GhostMeat_Pivot");
		///Finished
		heartMorphObject = UnityEngine.GameObject.Find("Heart_00").GetComponent<MegaMorph>();
		///Finished
		ghostMeatParticles = UnityEngine.GameObject.Find("GhostMeat_Particles");
		///Finished
		allowTracking = true;
		///Finished
		MenuController.ShowScanImage(true);
		///Finished
		onScan(false);
	}
	public void ghostHoverUp()
	{
		AEP_Utilities.TransformUtils.MoveObject(ghostMeatPivot, true, new UnityEngine.Vector3(-42.9f, -40f, 0f), 2f, LeanTweenType.easeInOutCubic);
		AEP_Utilities.Delay.DelayFunction(this, ghostHoverDown, 2f);
	}
	public void ghostHoverDown()
	{
		AEP_Utilities.TransformUtils.MoveObject(ghostMeatPivot, true, new UnityEngine.Vector3(-42.9f, -2.520168f, 0f), 2f, LeanTweenType.easeInOutCubic);
		AEP_Utilities.Delay.DelayFunction(this, ghostHoverUp, 2f);
	}
	public void resetGhostPosition()
	{
		AEP_Utilities.TransformUtils.SetObjectPosition(ghostMeatPivot, true, new UnityEngine.Vector3(-42.9f, -2.520168f, 0f));
	}
}
