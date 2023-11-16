using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AEP_Utilities;

namespace Vuforia
{
    public class OnTrack_AYSETiles : AEPImageTrackerBase
    {
        public GameObject tileObject;

//------------------------------------------------------------------------------------
        private void Awake()
        {
            if (testing)
            {
                Init();
            }
        }

//------------------------------------------------------------------------------------
        private void Start()
        {
            mTrackableBehaviour = gameObject.GetComponent<TrackableBehaviour>();

            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);

                if (!testing)
                {
                    AssetBundleUtils.GetAssetBundle(this, playerPrefsValue, assetBundle, asset, Init);
                }

                MenuController.HideInfoGraphics();
            }
        }

//------------------------------------------------------------------------------------
        private void OnDestroy()
        {
            TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);

            Main.EnableLoader(loaderName);
        }

//------------------------------------------------------------------------------------
        public override void onScan(bool track)
        {
            switch (allowTracking)
            {
                case true:
                    switch (track)
                    {
                        case true:
                            ObjectUtils.ShowObject(gameObject, true, true);

                            MenuController.ShowScanImage(false);
                            break;

                        case false:
                            ObjectUtils.ShowObject(gameObject, true, false);

                            MenuController.ShowScanImage(true);

                            animate(false);
                            break;
                    }
                    break;

                case false:
                    break;
            }
        }

//------------------------------------------------------------------------------------
        public override void animate(bool animate)
        {
            switch (animate)
            {
                case true:
                    AnimationUtils.ResetAnimatorTriggerState(tileObject, "Idle");
                    AnimationUtils.SetAnimatorTriggerState(tileObject, "ColorChange");
                    ObjectUtils.EnableCollider(gameObject, false, false);
                    Delay.DelayFunction(this, EnableTileCollider, 8.5f);
                    break;

                case false:
                    AnimationUtils.SetAnimatorTriggerState(tileObject, "Idle");
                    AnimationUtils.ResetAnimatorTriggerState(tileObject, "ColorChange");
                    break;
            }
        }

//------------------------------------------------------------------------------------
        void Init()
        {
            if (testing)
            {
            }
            else if (!testing)
            {
            }

            allowTracking = true;

            onScan(false);
        }

//------------------------------------------------------------------------------------
        void EnableTileCollider()
        {
            ObjectUtils.EnableCollider(gameObject, false, true);
        }
    }
}