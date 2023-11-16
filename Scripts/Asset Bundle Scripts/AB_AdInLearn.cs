using UnityEngine;
using System.Collections;

public class AB_AdInLearn : MonoBehaviour
{
    OnTrack_AdInLearn otAdinLearn;
    OnTrack_AdInLearn otAdinLearn02;
    OnTrack_AdInLearn otAdinLearn03;
    OnTrack_AdInLearn otAdinLearn04;

    public string assetBundle;
    public string[] asset;

#region Global Functions ------------------------------------------------------------------------------------
    IEnumerator Start()
    {
        otAdinLearn = GameObject.Find("Target_AIL01").GetComponent<OnTrack_AdInLearn>();
        otAdinLearn02 = GameObject.Find("Target_AIL02").GetComponent<OnTrack_AdInLearn>();
        otAdinLearn03 = GameObject.Find("Target_AIL03").GetComponent<OnTrack_AdInLearn>();
        otAdinLearn04 = GameObject.Find("Target_AIL04").GetComponent<OnTrack_AdInLearn>();

        if (Main.s_AdInLearnDownloaded == string.Empty || Main.s_AdInLearnDownloaded == "")
        {
            if (Main.internetActive)
            {
                MenuController.ShowScanImage(false);
                MenuController.ShowTapActivateImage(false);
                MenuController.ShowTapColor(false);
                MenuController.ShowTapColorMagic(false);
                MenuController.ShowTapDrag(false);

                MenuController.EnableSVGImage("Img_Download", true);

                yield return StartCoroutine(DownloadManager.Instance.WaitDownload(assetBundle + ".assetBundle"));

                Debug.Log("Downloading Learning");

                for (int i = 0; i < asset.Length; i++)
                {
                    GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset[i]);
                    
                    Instantiate(obj);

                    Utilities.SetObjectParent(obj.name + "(Clone)", "Target_AIL0" + (i + 1).ToString());
                }

                otAdinLearn.InitAugmentedPiece();
                otAdinLearn02.InitAugmentedPiece();
                otAdinLearn03.InitAugmentedPiece();
                otAdinLearn04.InitAugmentedPiece();

                PlayerPrefs.SetString("Learning Downloaded", "Yes");

                otAdinLearn.AllowTracking = true;
                otAdinLearn02.AllowTracking = true;
                otAdinLearn03.AllowTracking = true;
                otAdinLearn04.AllowTracking = true;

                MenuController.EnableSVGImage("Img_Download", false);
            }
            else if (!Main.internetActive)
            {
                MenuController.EnableSVGImage("Img_Unable", true);

                Debug.LogError("No Internet!");
            }
        }
        else if (Main.s_AdInLearnDownloaded == "Yes")
        {
            MenuController.ShowScanImage(false);
            MenuController.ShowTapActivateImage(false);
            MenuController.ShowTapColor(false);
            MenuController.ShowTapColorMagic(false);
            MenuController.ShowTapDrag(false);

            yield return StartCoroutine(DownloadManager.Instance.WaitDownload(assetBundle + ".assetBundle"));

            for (int i = 0; i < asset.Length; i++)
            {
                GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset[i]);
                
                Instantiate(obj);

                Utilities.SetObjectParent(obj.name + "(Clone)", "Target_AIL0" + (i + 1).ToString());
            }

            otAdinLearn.InitAugmentedPiece();
            otAdinLearn02.InitAugmentedPiece();
            otAdinLearn03.InitAugmentedPiece();
            otAdinLearn04.InitAugmentedPiece();

            otAdinLearn.AllowTracking = true;
            otAdinLearn02.AllowTracking = true;
            otAdinLearn03.AllowTracking = true;
            otAdinLearn04.AllowTracking = true;

            Debug.Log("Learning on device, resuming...");
        }

        yield return null;
    }
#endregion
}