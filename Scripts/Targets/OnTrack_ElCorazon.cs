//MD5Hash:9629f597fb4a07b55651f2de29c044af;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;
using System.Text;


public class OnTrack_ElCorazon : Vuforia.AEPImageTrackerBase
{
	public System.Collections.Generic.List<UnityEngine.Color> colorList = null;
	public UnityEngine.GameObject corazonObject = null;
	public float currentNumber = 0f;
	public float newNumber = 0f;
	public UnityEngine.GameObject corazonRoot = null;


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
				AEP_Utilities.MaterialUtils.SetObjectColor(corazonObject, false, colorList[4]);
				corazonStart();
				break;
			case false:
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(corazonRoot, "Start");
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(corazonRoot, "Loop");
				AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(corazonRoot, "Shrink");
				AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(corazonRoot, "Idle");
				DelayMethods.CancelAllDelays(this);
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
			AEP_Utilities.MaterialUtils.SetObjectShader(gameObject, true, "Shader Forge/Reg_Color+Spec+Gloss");
		}

		///Finished
		colorList.Add(UnityEngine.Color.cyan);
		///Finished
		colorList.Add(UnityEngine.Color.magenta);
		///Finished
		colorList.Add(UnityEngine.Color.yellow);
		///Finished
		colorList.Add(UnityEngine.Color.black);
		///Finished
		colorList.Add(new UnityEngine.Color(0.6f, 0f, 0f, 1f));
		///Finished
		corazonObject = UnityEngine.GameObject.Find("LT_EC_corazon");
		corazonRoot = UnityEngine.GameObject.Find("Loteria_ElCorazon");
		///Finished
		allowTracking = true;
		///Finished
		MenuController.ShowScanImage(true);
		///Finished
		onScan(false);
	}
	public void checkRandom()
	{
		if ((currentNumber == newNumber))
		{
			setCorazonColor();
		}

	}
	public void setCorazonColor()
	{
		newNumber = UnityEngine.Random.Range(0f, (colorList.Count - 1));
		checkRandom();
		AEP_Utilities.MaterialUtils.TweenObjectColor(corazonObject, colorList[(int)newNumber], 2f);
		currentNumber = newNumber;
	}
	public void corazonStart()
	{
		AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(corazonRoot, "Idle");
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(corazonRoot, "Start");
		AEP_Utilities.Delay.DelayFunction(this, corazonLoop, 3.5f);
	}
	public void corazonLoop()
	{
		AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(corazonRoot, "Start");
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(corazonRoot, "Loop");
		AEP_Utilities.Delay.DelayFunction(this, corazonShrink, 30f);
	}
	public void corazonShrink()
	{
		AEP_Utilities.AnimationUtils.ResetAnimatorTriggerState(corazonRoot, "Loop");
		AEP_Utilities.AnimationUtils.SetAnimatorTriggerState(corazonRoot, "Shrink");
		AEP_Utilities.Delay.DelayFunction(this, corazonStart, 5f);
	}
}
