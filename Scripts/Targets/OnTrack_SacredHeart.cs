//MD5Hash:8d99adfe670df63d2034756834ead90d;
using Vuforia;
using UnityEngine;
using System;
using System.Text;


public class OnTrack_SacredHeart : Vuforia.AEPImageTrackerBase
{
	public MegaMorph heartObject = null;


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
				heartObject.animate = true;
				break;
			case false:
				heartObject.animate = false;
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
		}
		else
		{
			///False
			AEP_Utilities.TransformUtils.SetObjectParent(new System.Text.StringBuilder(asset).Append("(Clone)").ToString(), name);
			///False
			AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Standard");
		}

		///Finished
		heartObject = UnityEngine.GameObject.Find("Heart_00").GetComponent<MegaMorph>();
		///Finished
		allowTracking = true;
		///Finished
		onScan(false);
	}
}
