using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using AEP_Utilities;
using Vuforia;

public class LoadingScene : MonoBehaviour
{
    public string sceneToLoad;
    private StateManager sm_StateManager;

    void Start()
    {
        sm_StateManager = TrackerManager.Instance.GetStateManager();
        MenuController.ShowLoadingPanel(true);

        Delay.DelayFunction(this, EnableDatasetScript, 2.0f);
        Delay.DelayFunction(this, LoadScene, 5.0f);
    }

    void EnableDatasetScript()
    {
        //GameObject.Find("ARCamera").GetComponent<DatabaseLoadBehaviour>().enabled = true;
    }

	void LoadScene()
	{
        //sm_StateManager.DestroyTrackableBehavioursForTrackable(GameObject.Find("Loader_AEP").GetComponent<TrackableBehaviour>().Trackable, false);
        Main.DisableLoader("Loader_AEP");
        SceneManager.LoadSceneAsync(sceneToLoad);
    }
}