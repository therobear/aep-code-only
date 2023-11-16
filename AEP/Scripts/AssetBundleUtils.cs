using UnityEngine;
using System;
using System.Collections;

namespace AEP_Utilities
{
    public static class AssetBundleUtils
    {
        public static IEnumerator eGetAssetBundle(this MonoBehaviour monoBehaviour, string augPiecePref, string assetBundle, string asset, Action action)
        {
            if (PlayerPrefs.GetString(augPiecePref) == string.Empty || PlayerPrefs.GetString(augPiecePref) == "")
            {
                if (Main.internetActive)
                {
                    MenuController.EnableSVGImage("Img_Download", true);

                    yield return monoBehaviour.StartCoroutine(DownloadManager.Instance.WaitDownload(assetBundle + ".assetBundle"));

                    GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset);
                    
                    GameObject.Instantiate(obj);

                    PlayerPrefs.SetString(augPiecePref, "Yes");

                    MenuController.EnableSVGImage("Img_Download", false);

                    MenuController.setMediaButtonState(augPiecePref);

                    action();
                }
                else if (!Main.internetActive)
                {
                    UnityGUIUtils.EnableSVGImage("Img_Unable", true);

                    Debug.LogError("No connection to the internet detected!!!");
                }
            }
            else if (PlayerPrefs.GetString(augPiecePref) == "Yes")
            {
                yield return monoBehaviour.StartCoroutine(DownloadManager.Instance.WaitDownload(assetBundle + ".assetBundle"));

                GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset);

                GameObject.Instantiate(obj);

                action();
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static Coroutine GetAssetBundle(this MonoBehaviour monoBehaviour, string augPiecePref, string assetBundle, string asset, Action action)
        {
            return monoBehaviour.StartCoroutine(eGetAssetBundle(monoBehaviour, augPiecePref, assetBundle, asset, action));
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static IEnumerator eGetNestedAssets(string assetBundle, string asset)
        {
            GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset);

            GameObject.Instantiate(obj);

            yield return null;
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static Coroutine getNestedAsset(this MonoBehaviour monoBehaviour, string assetBundle, string asset)
        {
            return monoBehaviour.StartCoroutine(eGetNestedAssets(assetBundle, asset));
        }
    }
}
