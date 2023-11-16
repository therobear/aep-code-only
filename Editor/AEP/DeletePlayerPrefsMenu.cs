using UnityEngine;
using System.Collections;
using UnityEditor;

public class DeletePlayerPrefsMenu : MonoBehaviour
{
	[MenuItem("Window/AEP/Delete Player Prefs")]
	static void DeletePlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
		Caching.CleanCache();
	}
}
