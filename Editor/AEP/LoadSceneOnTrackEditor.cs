using UnityEngine;
using UnityEditor;
using Vuforia;

[CustomEditor(typeof(LoadSceneOnTrack))]
public class LoadSceneOnTrackEditor : Editor
{
	private LoadSceneOnTrack loadScene;

	void Awake()
	{
		loadScene = (LoadSceneOnTrack)target;
	}

	public override void OnInspectorGUI()
	{
		EditorGUILayout.HelpBox("Click on the button to set \nScene Name to the current open scene.", MessageType.Info);

		GUI.backgroundColor = Color.green;

		if (GUILayout.Button ("Enter Scene Name.", GUILayout.Width(400), GUILayout.Height(50)))
		{
			loadScene.GetSceneName();
		}

		GUI.backgroundColor = Color.gray;

		EditorGUILayout.LabelField("Scene Name", loadScene.sceneName);

		EditorGUILayout.HelpBox("If you want to clear the Scene Name, \nClick on the red button below", MessageType.Error);

		GUI.backgroundColor = Color.red;

		if (GUILayout.Button("Clear Scene name.", GUILayout.Width(400), GUILayout.Height(50)))
		{
			loadScene.sceneName = string.Empty;
		}
	}
}
