using UnityEngine;
using System.Collections;

public class AB_GirlScouts03 : MonoBehaviour
{
	/*
	OnTrack_GirlScouts03 otGirlScouts03;
	
	public string assetBundle;
	public string asset;
	
	#region Global Functions ------------------------------------------------------------------------------------
	IEnumerator Start()
	{
		otGirlScouts03 = GetComponent<OnTrack_GirlScouts03>();
		
		if (Main.s_GirlScouts03Downloaded == string.Empty || Main.s_GirlScouts03Downloaded == "")
		{
            if (Main.internetActive)
            {
                MenuController.EnableSVGImage("Img_Download", true);

                yield return StartCoroutine(DownloadManager.Instance.WaitDownload(assetBundle + ".assetBundle"));

                Debug.Log("Downloading Girl Scouts 03");

                GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset);

                Instantiate(obj);

                Utilities.SetObjectParent(obj.name + "(Clone)", this.gameObject.name);

                otGirlScouts03.InitAugmentedPiece();

                PlayerPrefs.SetString("Girl Scouts 03 Downloaded", "Yes");

                otGirlScouts03.AllowTracking = true;

                MenuController.EnableSVGImage("Img_Download", false);
            }
            else if (!Main.internetActive)
            {
                MenuController.EnableSVGImage("Img_Unable", true);

                Debug.LogError("No Internet!");
            }
		}
		else if (Main.s_GirlScouts03Downloaded == "Yes")
		{
			yield return StartCoroutine(DownloadManager.Instance.WaitDownload(assetBundle + ".assetBundle"));
			
			GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset);
			
			Instantiate(obj);
			
			Utilities.SetObjectParent(obj.name + "(Clone)", this.gameObject.name);
			
			otGirlScouts03.InitAugmentedPiece();
			
			otGirlScouts03.AllowTracking = true;
			
			Debug.Log("Girl Scouts 03 on device, resuming...");
		}
		
		yield return null;
	}
	#endregion
	*/
}