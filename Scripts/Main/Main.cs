using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class Main : MonoBehaviour
{
	public List<Material> tempMats = new List<Material>();
    public List<GameObject> loaders = new List<GameObject>();
    public string cachedSceneName;

    private static GameObject loaderRoot;
	private GameObject go_Reporter;
    private GameObject aepMenu;
    private GameObject arCamera;

    public static bool internetActive;
    public static string s_FirstRun;
	public static string s_BigMachineDownloaded;
	public static string s_BurlesqueDownloaded;
	public static string s_DiaDeLosMuertosDownloaded;
	public static string s_GuardianLithsDownloaded;
	public static string s_HarmonyDownloaded;
	public static string s_GirlScouts01Downloaded;
	public static string s_GirlScouts02Downloaded;
	public static string s_GirlScouts03Downloaded;
    public static string s_OctogirlDownloaded;
    public static string s_TacoDownloaded;
	public static string s_LowRiderDownloaded;
    public static string s_LaCalacaDownloaded;
	public static string s_HerBodyDownloaded;
	public static string s_LoversDownloaded;
    public static string s_GimpToofDownloaded;
	public static string s_OneBillionDownloaded;
	public static string s_MadreAguaDownloaded;
    public static string s_FusionDownloaded;
	public static string s_Dash7Downloaded;
	public static string s_RocketBusterDownloaded;
    public static string s_ElCorazonDownloaded;
	public static string s_FullSteamDownloaded;
    public static string s_ChuladaDownloaded;
    public static string s_NomadLoveDownloaded;
    public static string s_ReceiveDownload;
    public static string s_AdInLearnDownloaded;
	public static string s_DoomGloomDownloaded;
    public static string s_TT_MRIDownloaded;
    public static string s_TT_HeartDownloaded;
    public static string s_TT_NeruoDownloaded;
    public static string s_RioBravoDownloaded;
    public static string s_EvoLogoDownloaded;
    public static string s_AugaEsVidaDownloaded;
    public static string s_OmecoatlDownloaded;
    public static string s_ElPasoPortalDownloaded;
    public static string s_SisterCitiesDownloaded;
    public static string s_GrayFeelsDownloaded;
    public static string s_LaTeleDownloaded;
    public static string s_SacredHeartDownloaded;
    public static string s_GhostMeatDownloaded;
    public static string s_LightSaberDownloaded;
    public static string s_KioskDownloaded;
    public static string s_BarrioSoulDownloaded;
    public static string s_LaCeremoniaDownloaded;
    public static string s_AYSEPosterDownloaded;

    public static Main main;

#region Global Functions ------------------------------------------------------------------------------------
	void Awake()
	{
		DontDestroyOnLoad(this);

		if (GameObject.Find("Loaders"))
		{
			loaderRoot = GameObject.Find("Loaders");

			DontDestroyOnLoad(loaderRoot);
		}
		else if (!GameObject.Find("Loaders"))
		{
			Debug.LogError("Main: Loaders prefab is not in the scene!");
		}

        aepMenu = GameObject.Find("AEP_Menu");
		
		main  = GetComponent<Main>();

        DontDestroyOnLoad(aepMenu);

        arCamera = GameObject.Find("ARCamera");

        DontDestroyOnLoad(arCamera);

#if DEVELOPMENT_BUILD || UNITY_EDIITOR
        Hdg.RemoteDebugServer.AddDontDestroyOnLoadObject(this.gameObject);
        Hdg.RemoteDebugServer.AddDontDestroyOnLoadObject(loaderRoot);
        Hdg.RemoteDebugServer.AddDontDestroyOnLoadObject(aepMenu);
#endif

        InitPlayerPrefs();
	}

//------------------------------------------------------------------------------------
	void Start()
	{
		go_Reporter = GameObject.Find("Main/Reporter");

		if (!Debug.isDebugBuild || Application.isEditor)
		{
            //go_Reporter.SetActive(false);

            //Debug.Log("Disabling Reporter because it's running in the editor or the build is not a Development Build.");
            //TestFairy.begin("");
		}
		else if (Debug.isDebugBuild)
		{
			Debug.Log("Reporter Enabled because it's running a Development Build");

			return;
		}

        internetActive = true;
	}

//------------------------------------------------------------------------------------
    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelChanged;
    }

//------------------------------------------------------------------------------------
    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelChanged;
    }

//------------------------------------------------------------------------------------
	void LevelChanged(Scene scene, LoadSceneMode sceneMode)
	{
        TrackerManager.Instance.GetStateManager().ReassociateTrackables();
        MenuController.ShowLoadingPanel(false);
		#if UNITY_IPHONE || UNITY_ANDROID
		StartCoroutine(IsConnected());
		#endif

		#if UNITY_EDITOR
		internetActive = true;
#endif

        Debug.Log("LevelChanged!!!");
	}
#endregion

#region Custom Functions ------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------
    public static void AddToLoader(GameObject loaderObject)
    {
        main.loaders.Add(loaderObject);
        Debug.Log("Added!!!");
    }

//------------------------------------------------------------------------------------
    public static void EnableLoader(string loaderName)
    {
        try
        {
            for (int i = 0; i < main.loaders.Count; i++)
            {
                if (main.loaders[i].name == loaderName)
                {
                    main.loaders[i].SetActive(true);
                }
            }
        }
        catch (MissingReferenceException)
        {

        }
    }

//------------------------------------------------------------------------------------
    public static void DisableLoader(string loaderName)
    {
        for (int i = 0; i < main.loaders.Count; i++)
        {
            if (main.loaders[i].name == loaderName)
            {
                main.loaders[i].GetComponent<LoadSceneOnTrack>().DisableThisTracker();
                main.loaders[i].SetActive(false);
            }
        }
    }

//------------------------------------------------------------------------------------
    void InitPlayerPrefs()
	{
        s_FirstRun = PlayerPrefs.GetString("First Run");
		s_BigMachineDownloaded = PlayerPrefs.GetString("Big Machine Downloaded");
		s_BurlesqueDownloaded = PlayerPrefs.GetString("Burlesque Downloaded");
		s_DiaDeLosMuertosDownloaded = PlayerPrefs.GetString("Dia De Los Muertos Downloaded");
		s_GuardianLithsDownloaded = PlayerPrefs.GetString("Guardian Liths Downloaded");
		s_HarmonyDownloaded = PlayerPrefs.GetString("Harmony Downloaded");
		s_GirlScouts01Downloaded = PlayerPrefs.GetString("Girl Scouts 01 Downloaded");
		s_GirlScouts02Downloaded = PlayerPrefs.GetString("Girl Scouts 02 Downloaded");
		s_GirlScouts03Downloaded = PlayerPrefs.GetString("Girl Scouts 03 Downloaded");
        s_OctogirlDownloaded = PlayerPrefs.GetString("Octogirl Downloaded");
        s_TacoDownloaded = PlayerPrefs.GetString("Taco Downloaded");
		s_LowRiderDownloaded = PlayerPrefs.GetString("Low Rider Downloaded");
        s_LaCalacaDownloaded = PlayerPrefs.GetString("La Calaca Downloaded");
		s_HerBodyDownloaded = PlayerPrefs.GetString("Her Body Downloaded");
		s_LoversDownloaded = PlayerPrefs.GetString("Lovers Downloaded");
        s_GimpToofDownloaded = PlayerPrefs.GetString("Gimp Toof Downloaded");
		s_OneBillionDownloaded = PlayerPrefs.GetString("One Billion Downloaded");
		s_MadreAguaDownloaded = PlayerPrefs.GetString("Madre Agua Downloaded");
        s_FusionDownloaded = PlayerPrefs.GetString("Fusion Downloaded");
		s_Dash7Downloaded = PlayerPrefs.GetString("Dash 7 Downloaded");
		s_RocketBusterDownloaded = PlayerPrefs.GetString("Rocketbuster Downloaded");
        s_ElCorazonDownloaded = PlayerPrefs.GetString("El Corazon Downloaded");
		s_FullSteamDownloaded = PlayerPrefs.GetString ("Full Steam Downloaded");
        s_ChuladaDownloaded = PlayerPrefs.GetString("Chulada Downloaded");
        s_NomadLoveDownloaded = PlayerPrefs.GetString("Nomad Love Downloaded");
        s_ReceiveDownload = PlayerPrefs.GetString("Receive Downloaded");
        s_AdInLearnDownloaded = PlayerPrefs.GetString("Learning Downloaded");
		s_DoomGloomDownloaded = PlayerPrefs.GetString("Doom Gloom Downloaded");
        s_TT_MRIDownloaded = PlayerPrefs.GetString("TT MRI Downloaded");
        s_TT_HeartDownloaded = PlayerPrefs.GetString("TT Heart Downloaded");
        s_TT_NeruoDownloaded = PlayerPrefs.GetString("TT Neuro Downloaded");
        s_RioBravoDownloaded = PlayerPrefs.GetString("Rio Bravo Downloaded");
        s_EvoLogoDownloaded = PlayerPrefs.GetString("Evolve Logo Downloaded");
        s_AugaEsVidaDownloaded = PlayerPrefs.GetString("Agua Es Vida Downloaded");
        s_OmecoatlDownloaded = PlayerPrefs.GetString("Omecoatl Downloaded");
        s_ElPasoPortalDownloaded = PlayerPrefs.GetString("El Paso Portal Downloaded");
        s_SisterCitiesDownloaded = PlayerPrefs.GetString("Sister Cities Downloaded");
        s_GrayFeelsDownloaded = PlayerPrefs.GetString("Gray Feels Downloaded");
        s_LaTeleDownloaded = PlayerPrefs.GetString("La Tele Downloaded");
        s_SacredHeartDownloaded = PlayerPrefs.GetString("Sacred Heart Downloaded");
        s_GhostMeatDownloaded = PlayerPrefs.GetString("Ghost Meat Downloaded");
        s_LightSaberDownloaded = PlayerPrefs.GetString("Light Saber Downloaded");
        s_KioskDownloaded = PlayerPrefs.GetString("Kiosk Downloaded");
        s_BarrioSoulDownloaded = PlayerPrefs.GetString("Barrio Soul Downloaded");
        s_LaCeremoniaDownloaded = PlayerPrefs.GetString("La Ceremonia Downloaded");
        s_AYSEPosterDownloaded = PlayerPrefs.GetString("ASYE Poster Downloaded");
    }

//------------------------------------------------------------------------------------
	IEnumerator IsConnected()
	{
		WWW intCheck = new WWW("http://s3.dualstack.us-west-1.amazonaws.com/aepassets/InternetCheck/InternetCheck.txt");
		
		yield return intCheck;
		
		#if UNITY_IPHONE
		System.IO.File.WriteAllBytes("/private" + Application.persistentDataPath + "/" + "InternetCheck.txt", intCheck.bytes);
		#endif
		
		#if UNITY_ANDROID
		System.IO.File.WriteAllBytes(Application.persistentDataPath + "/" + "InternetCheck.txt", intCheck.bytes);
		#endif
		
		if (/*CheckConnection("http://augmentep.com") && */intCheck.isDone)
		{
			#if UNITY_IPHONE
			System.IO.File.Delete("/private" + Application.persistentDataPath + "/" + "InternetCheck.txt");
			#endif
			
			#if UNITY_ANDROID || UNITY_EDITOR
			System.IO.File.Delete(Application.persistentDataPath + "/" + "InternetCheck.txt");
			#endif
			
			internetActive = true;
		}
		else
		{
			internetActive = false;
			
			Debug.Log("No Internet");
		}
	}

//------------------------------------------------------------------------------------
	bool CheckConnection(string URL)
	{
		try
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
			request.Timeout = 5000;
			request.Credentials = CredentialCache.DefaultNetworkCredentials;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			
			if (response.StatusCode == HttpStatusCode.OK)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		catch
		{
			return false;
		}
	}

    public static void DisableSpecificLoader(string loader)
    {

    }
#endregion
}