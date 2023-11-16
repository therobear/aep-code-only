//MD5Hash:1208144b58d51f0ad9a36975408b181d;
using Vuforia;
using UnityEngine;
using System;
using System.Text;
using System.Collections;


public class OnTrack_TT_HRT : UnityEngine.MonoBehaviour, ITrackableEventHandler
{
	public bool TestInEditor = false;
	public string PlayerPrefsValue = "";
	public string AssetBundle = "";
	public string Asset = "";
	public int heartIndex = 0;
	public bool bAllowTracking = false;
	private Vuforia.TrackableBehaviour mTrackableBehaviour = null;
	private Vuforia.StateManager smStateManager = null;
	public UnityEngine.GameObject rootObject = null;
	public bool doRotate = false;


	void Awake()
	{
		MenuController.HideInfoGraphics();
		if (TestInEditor)
		{
			Init();
		}

	}
	void Start()
	{
		mTrackableBehaviour = gameObject.GetComponent<Vuforia.TrackableBehaviour>();
		smStateManager = Vuforia.TrackerManager.Instance.GetStateManager();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
			if (TestInEditor)
			{
			}
			else
			{
				AEP_Utilities.AssetBundleUtils.GetAssetBundle(this, PlayerPrefsValue, AssetBundle, Asset, Init);
			}

		}

	}
	public void Update()
	{
		float rotateSpeed = 40f;

		if (doRotate)
		{
			rootObject.transform.Rotate((rotateSpeed * (UnityEngine.Vector3.down * UnityEngine.Time.deltaTime)));
		}

	}
	public void OnDestroy()
	{
		smStateManager.DestroyTrackableBehavioursForTrackable(gameObject.GetComponent<Vuforia.TrackableBehaviour>().Trackable);
		Main.EnableLoader("Loader_TT_Heart");
	}
	public void OnTrackableStateChanged(Vuforia.TrackableBehaviour.Status previousStatus, Vuforia.TrackableBehaviour.Status newStatus)
	{
		if ((((newStatus == Vuforia.TrackableBehaviour.Status.DETECTED) || (newStatus == Vuforia.TrackableBehaviour.Status.TRACKED)) || (newStatus == Vuforia.TrackableBehaviour.Status.EXTENDED_TRACKED)))
		{
			if (bAllowTracking)
			{
				OnScan(true);
			}

		}
		else
		{
			OnScan(false);
		}

	}
	public void OnScan(bool track)
	{
		switch (bAllowTracking)
		{
			case true:
				switch (track)
				{
					case true:
						Animate(true);
						AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Heart", true, true);
						MenuController.ShowScanImage(false);
						MenuController.ShowTapActivateImage(true);
						break;
					case false:
						Animate(false);
						AEP_Utilities.ObjectUtils.ShowObject(gameObject, true, false);
						MenuController.ShowScanImage(true);
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
				OnScan(false);
				break;
		}
		
	}
	public void Init()
	{
		if (TestInEditor)
		{
			rootObject = UnityEngine.GameObject.Find("Root_TT_HRT");
		}
		else
		{
			AEP_Utilities.TransformUtils.SetObjectParent("Root_TT_HRT(Clone)", "Target_TT_Heart");
			rootObject = UnityEngine.GameObject.Find("Root_TT_HRT(Clone)");
		}

		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Heart", false, "Mobile/Unlit (Supports Lightmap)");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Labels", true, "Shader Forge/Unlit_DS+Op");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label00", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label001", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label002", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label003", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label004", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label005", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label006", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label007", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label008", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label009", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label010", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label011", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label012", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label013", false, "Resources/Shaders/Unlit_Color");
		AEP_Utilities.MaterialUtils.SetObjectShader("TT_HRT_Label014", false, "Resources/Shaders/Unlit_Color");
		bAllowTracking = true;
		OnScan(false);
	}
	public void Animate(bool animate)
	{
		switch (animate)
		{
			case true:
				AEP_Utilities.AnimationUtils.PlayAnimation("TT_HRT_Heart", "TT_HRT_Heart", false, "Loop");
				AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, true);
				AEP_Utilities.UnityGUIUtils.EnablePanel("Pnl_Button", true);
				break;
			case false:
				AEP_Utilities.ObjectUtils.EnableCollider(gameObject, false, false);
				AEP_Utilities.AnimationUtils.RewindAnimation("TT_HRT_Heart", "TT_HRT_Heart", "Default");
				AEP_Utilities.AnimationUtils.RewindAnimation("TT_HRT_Labels", "TT_HRT_Labels1", "Default");
				AEP_Utilities.AnimationUtils.RewindAnimation("TT_HRT_Labels", "TT_HRT_Labels2", "Default");
				AEP_Utilities.AnimationUtils.RewindAnimation("TT_HRT_Labels", "TT_HRT_Labels3", "Default");
				heartIndex = 0;
				AEP_Utilities.UnityGUIUtils.EnablePanel("Pnl_Button", false);
				AEP_Utilities.TransformUtils.SetObjectRotation(rootObject, true, new UnityEngine.Vector3(0f, 180f, 0f));
				break;
			default:
				break;
		}
		
	}
	public void ShowHeartIndex()
	{
		switch (heartIndex)
		{
			case 0:
				AEP_Utilities.AnimationUtils.PlayAnimation("TT_HRT_Labels", "TT_HRT_Labels1", false, "Default");
				break;
			case 1:
				AEP_Utilities.AnimationUtils.PlayAnimation("TT_HRT_Labels", "TT_HRT_Labels2", false, "Default");
				break;
			case 2:
				AEP_Utilities.AnimationUtils.PlayAnimation("TT_HRT_Labels", "TT_HRT_Labels3", false, "Default");
				break;
			default:
				break;
		}
		
		PlayLabels(heartIndex);
		heartIndex ++;
		if ((heartIndex >= 3))
		{
			heartIndex = 0;
		}

	}
	public System.Collections.IEnumerator PlayLabels01()
	{
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label00_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT002", true, true);
		yield return new UnityEngine.WaitForSeconds(0.2f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label015_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT004", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label016_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT008", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label017_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT006", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label018_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT011", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label019_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT014", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label020_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT010", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label021_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT031", true, true);
	}
	public System.Collections.IEnumerator PlayLabels02()
	{
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label022_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT026", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label023_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT033", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label024_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT037", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label025_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT036", true, true);
	}
	public System.Collections.IEnumerator PlayLabels03()
	{
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label026_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT038", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label027_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT040", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT046", true, true);
		yield return new UnityEngine.WaitForSeconds(0.16f);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Label028_ROOT", true, true);
		AEP_Utilities.ObjectUtils.ShowObject("TT_HRT_Stem00_PT043", true, true);
	}
	public void PlayLabels(int labelIndex)
	{
		switch (heartIndex)
		{
			case 0:
				this.StartCoroutine(PlayLabels01());
				break;
			case 1:
				this.StartCoroutine(PlayLabels02());
				break;
			case 2:
				this.StartCoroutine(PlayLabels03());
				break;
			default:
				break;
		}
		
	}
	public void setRotate(bool enable)
	{
		doRotate = enable;
	}
}
