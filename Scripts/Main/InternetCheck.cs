using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using UnityEngine.UI;

public class InternetCheck : MonoBehaviour
{
    public float loadingWaitTime;

    private bool b_ConnectionActive;

#region Global Functions ------------------------------------------------------------------------------------
    IEnumerator Start()
    {
        ShowObject("AEP_Intro", true, false);

        EnableImage("Img_Connection", false);

        WWW intCheck = new WWW("http://therobear.com/InternetCheck/IntenetCheck.txt");

        yield return intCheck;

        #if UNITY_IPHONE
        System.IO.File.WriteAllBytes("/private" + Application.persistentDataPath + "/" + "InternetCheck.txt", intCheck.bytes);
        #endif

        #if UNITY_ANDROID || UNITY_EDITOR
        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/" + "InternetCheck.txt", intCheck.bytes);
        #endif

        if (CheckConnection("http://augmentep.com") && intCheck.isDone)
        {
            ShowObject("AEP_Intro", true, true);

            Animation anim1 = GameObject.Find("AEP_Logo_02").GetComponent<Animation>();
            Animation anim2 = GameObject.Find("AEP_Logo_FullText").GetComponent<Animation>();

            anim1.Play("Start");
            anim2.Play("Take 001");

            #if UNITY_IPHONE
            System.IO.File.Delete("/private" + Application.persistentDataPath + "/" + "InternetCheck.txt");
            #endif

            #if UNITY_ANDROID || UNITY_EDITOR
            System.IO.File.Delete(Application.persistentDataPath + "/" + "InternetCheck.txt");
            #endif


            Invoke("LoadLoadingScene", loadingWaitTime);
        }
        else
        {
            EnableImage("Img_Connection", true);

            Debug.Log("No Internet");
        }
    }
#endregion

#region Custom Functions ------------------------------------------------------------------------------------
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

//------------------------------------------------------------------------------------
    public static void ShowObject(string obj, bool children, bool show)
    {
        GameObject go = GameObject.Find(obj);

        if (go)
        {
            switch (children)
            {
                case true:
                    Renderer[] render = go.GetComponentsInChildren<Renderer>();
                    /*
                    foreach (Renderer component in render)
                    {
                        component.enabled = show;
                    }
                    */
                    Debug.Log("ShowObject: Child are being shown/hidden from object " + go.name + ".");
                    break;

                case false:
                    Renderer component = go.GetComponent<Renderer>();

                    component.enabled = show;

                    Debug.Log("ShowObject: " + go.name + " is being shown/hidden.");
                    break;
            }
        }
        else if (!go)
        {
            Debug.LogError("ShowObject: Game Object field is empty!!!");
        }
    }

//------------------------------------------------------------------------------------
    public void EnableImage(string obj, bool enable)
    {
        GameObject go = GameObject.Find(obj);
        Image image = go.GetComponent<Image>();

        image.enabled = enable;
    }

//------------------------------------------------------------------------------------
    void LoadLoadingScene()
    {
        Application.LoadLevel("AEP_Loading_Scene");
    }
#endregion
}
