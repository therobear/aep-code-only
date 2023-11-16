using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class ReferenceTargetImage : ScriptableWizard
{
#region Variables ------------------------------------------------------------------------------------
	public Texture2D targetImage;
#endregion

#region Wizard Functions ------------------------------------------------------------------------------------
	void OnWizardUpdate()
	{
		helpString = "Drag the target image into the Target Image section.";

		if (targetImage)
		{
			isValid = true;
		}
		else if (!targetImage)
		{
			isValid = false;
		}
	}

//------------------------------------------------------------------------------------
	void OnWizardCreate()
	{
		var bytes = targetImage.EncodeToJPG();

		string path = "Assets/2D Assets/" + targetImage.name + ".jpg";

		File.WriteAllBytes(path, bytes);

		AssetDatabase.Refresh();
		AssetDatabase.ImportAsset(path);

		TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

		GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
		go.name = "_TargetReferece";
		go.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
		go.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));
		go.transform.localScale = new Vector3(
			targetImage.width,
			targetImage.height,
			1.0f);

		importer.spriteImportMode = SpriteImportMode.None;

		AssetDatabase.WriteImportSettingsIfDirty(path);
		Renderer render = go.GetComponent<Renderer>();

		render.sharedMaterial = (Material)Resources.Load ("Materials/TargetImage");
		render.material.SetTexture("_MainTex", targetImage);
		render.material.shader = Shader.Find("Unlit/Texture");

		AssetDatabase.Refresh();
	}

//------------------------------------------------------------------------------------
	[MenuItem("Window/AEP/Create Reference Image Object")]
	static void CreateReferenceImageObject()
	{
		ScriptableWizard.DisplayWizard("Create Reference Image Object",
		                               typeof(ReferenceTargetImage), "GO!");
	}
#endregion
}
