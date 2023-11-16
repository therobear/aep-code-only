using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using AEP_Utilities;

namespace Vuforia
{
    public class LoadSceneOnTrack : MonoBehaviour, ITrackableEventHandler
    {
        public string sceneName;
        private bool b_EnableLoading;
        private GameObject go_ThisObject;
        private TrackableBehaviour mTrackableBehaviour;
        private StateManager sm_StateManager;

        public bool EnableLoading
        {
            get { return b_EnableLoading; }
            set { b_EnableLoading = value; }
        }

#region Global Functions ------------------------------------------------------------------------------------
        void Awake()
        {
            go_ThisObject = this.gameObject;
            sm_StateManager = TrackerManager.Instance.GetStateManager();
            Main.AddToLoader(go_ThisObject);
        }

//------------------------------------------------------------------------------------
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();

            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }

            //Main.AddToLoader(go_ThisObject);
        }
        #endregion

#region Tracking Functions ------------------------------------------------------------------------------------
        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, 
                                            TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnScan(true);
            }
            else
            {
                OnScan(false);
            }
        }

//------------------------------------------------------------------------------------
        void OnScan(bool track)
        {
            switch (track)
            {
                case true:
                        LoadSceneByName();
                    break;

                case false:
                    return;
            }
        }
        #endregion

#region Custom Functions ------------------------------------------------------------------------------------
        void LoadSceneByName()
        {
            if (sceneName == string.Empty)
            {
                Debug.LogWarning("Scene Name is empty! Please enter a scene name in the inspector for " + this.name + ".");
            }
            else if (sceneName != string.Empty)
            {
                MenuController.ShowLoadingPanel(true);
                DelayMethods.DelayCall(this, LoadScene, 5.0f);
                Debug.Log(sceneName);

                if (GameObject.Find("Pnl_EXP"))
                {
                    MenuController.EnablePanel("Pnl_EXP", false);
                }
            }
        }

//------------------------------------------------------------------------------------
        void LoadScene()
        {
            DisableThisTracker();
            go_ThisObject.SetActive(false);
            SceneManager.LoadSceneAsync(sceneName);
        }

//------------------------------------------------------------------------------------
        public void DisableThisTracker()
        {
            //sm_StateManager.DestroyTrackableBehavioursForTrackable(this.gameObject.GetComponent<TrackableBehaviour>().Trackable, false);
            TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(this.gameObject.GetComponent<TrackableBehaviour>().Trackable, false);
        }

//------------------------------------------------------------------------------------
        public void GetSceneName()
        {
#if UNITY_EDITOR
                sceneName = SceneManager.GetActiveScene().name;
#endif
        }
#endregion
    }
}