using UnityEngine;
using System.Collections;

public class AB_GirlScounts01 : MonoBehaviour
{
	/*
	OnTrack_GirlScouts01 otGirlScouts01;

	public string assetBundle;
	public string asset;

#region Global Functions ------------------------------------------------------------------------------------
	IEnumerator Start()
	{
		otGirlScouts01 = GetComponent<OnTrack_GirlScouts01>();

		if (Main.s_GirlScouts01Downloaded == string.Empty || Main.s_GirlScouts01Downloaded == "")
		{
            if (Main.internetActive)
            {
                MenuController.EnableSVGImage("Img_Download", true);

                yield return StartCoroutine(DownloadManager.Instance.WaitDownload(assetBundle + ".assetBundle"));

                Debug.Log("Downloading Girl Scouts 01");

                GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset);

                Instantiate(obj);

                Utilities.SetObjectParent(obj.name + "(Clone)", this.gameObject.name);

                otGirlScouts01.InitAugmentedPiece();

                PlayerPrefs.SetString("Girl Scouts 01 Downloaded", "Yes");

                otGirlScouts01.AllowTracking = true;

                MenuController.EnableSVGImage("Img_Download", false);
            }
            else if (!Main.internetActive)
            {
                MenuController.EnableSVGImage("Img_Unable", true);

                Debug.LogError("No Internet!");
            }
		}
		else if (Main.s_GirlScouts01Downloaded == "Yes")
		{
			yield return StartCoroutine(DownloadManager.Instance.WaitDownload(assetBundle + ".assetBundle"));
			
			GameObject obj = DownloadManager.Instance.GetWWW(assetBundle + ".assetBundle").assetBundle.LoadAsset<GameObject>(asset);
			
			Instantiate(obj);
			
			Utilities.SetObjectParent(obj.name + "(Clone)", this.gameObject.name);
			
			otGirlScouts01.InitAugmentedPiece();
			
			otGirlScouts01.AllowTracking = true;
			
			Debug.Log("Girl Scouts 01 on device, resuming...");
		}
		
		yield return null;
	}
#endregion

*/
}