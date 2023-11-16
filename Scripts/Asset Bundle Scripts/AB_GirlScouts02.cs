using UnityEngine;
using System.Collections;

public class AB_GirlScouts02 : MonoBehaviour
{
	/*
	OnTrack_GirlScouts02 otGirlScouts02;
	
	public string assetBundle;
	public string asset;
	
	#region Global Functions ------------------------------------------------------------------------------------
	IEnumerator Start()
	{
		otGirlScouts02 = GetComponent<OnTrack_GirlScouts02>();
		
		if (Main.s_GirlScouts02Downloaded == string.Empty || Main.s_GirlScouts02Downloaded == "")
		{
            if (Main.internetActive)
            {
                MenuController.EnableSVGImage("Img_Download", true);

                yield return StartCoroutine(DownloadManager.Instance.WaitDownload(assetBundle + ".assetBundle"));

                Debug.Log("Downloading Girl Scouts 02");

                GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset);

                Instantiate(obj);

                Utilities.SetObjectParent(obj.name + "(Clone)", this.gameObject.name);

                otGirlScouts02.InitAugmentedPiece();

                PlayerPrefs.SetString("Girl Scouts 02 Downloaded", "Yes");

                otGirlScouts02.AllowTracking = true;

                MenuController.EnableSVGImage("Img_Download", false);
            }
            else if (!Main.internetActive)
            {
                MenuController.EnableSVGImage("Img_Unable", true);

                Debug.LogError("No Internet!");
            }
		}
		else if (Main.s_GirlScouts02Downloaded == "Yes")
		{
			yield return StartCoroutine(DownloadManager.Instance.WaitDownload(assetBundle + ".assetBundle"));
			
			GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset);
			
			Instantiate(obj);
			
			Utilities.SetObjectParent(obj.name + "(Clone)", this.gameObject.name);
			
			otGirlScouts02.InitAugmentedPiece();
			
			otGirlScouts02.AllowTracking = true;
			
			Debug.Log("Girl Scouts 02 on device, resuming...");
		}
		
		yield return null;
	}
	#endregion
	*/
}