using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using AEP_Utilities;

public class IntroLoadScene : MonoBehaviour
{
	public float startWaitTime;
	public float loadingWaitTime;
	public string sceneToLoad;
    public GameObject vuforiaCamera;

	Animation anim1 = new Animation();
	Animation anim2 = new Animation();
#region Global Functions ------------------------------------------------------------------------------------
	void Awake()
	{
		anim1 = GameObject.Find("AEP_Logo_02").GetComponent<Animation>();
		anim2 = GameObject.Find("AEP_Logo_FullText").GetComponent<Animation>();
        //vuforiaCamera = GameObject.Find("ARCamera");
        //vuforiaCamera.enabled = false;
        //DontDestroyOnLoad(vuforiaCamera);
	}

//------------------------------------------------------------------------------------
	void Start()
	{
		//Invoke("PlayIntroAnimation", startWaitTime);
        Delay.DelayFunction(this, PlayIntroAnimation, startWaitTime);
	}

//------------------------------------------------------------------------------------
    public void OnDestroy()
    {
        //vuforiaCamera.enabled = true;
    }
#endregion

#region Custom Functions ------------------------------------------------------------------------------------
	void PlayIntroAnimation()
	{
		anim1.Play("Start");
		anim2.Play("Take 001");

		//Invoke("LoadScene", loadingWaitTime);
        Delay.DelayFunction(this, LoadScene, loadingWaitTime);
	}

//------------------------------------------------------------------------------------
	void LoadScene()
	{
        SceneManager.LoadScene(sceneToLoad);
	}
#endregion
}
