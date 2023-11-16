using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AEP_Utilities;

namespace Vuforia
{
    public class OnTrack_AYSEPoster : AEPImageTrackerBase
    {
        public float delayTime;

        private GameObject logo01;
        private GameObject logo02;
        private GameObject logo03;
        private GameObject logo04;
        private GameObject text;
        private GameObject pattern;
        private GameObject patternSeq;

//------------------------------------------------------------------------------------
        public void Awake()
        {
            if (testing)
            {
                Init();
            }
        }

//------------------------------------------------------------------------------------
        public void Start()
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
        public void OnDestroy()
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

                            animate(true);
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
                    MaterialUtils.setObjectMaterialFloatProperty(patternSeq, "_TextureSeqOnOff", 0);
                    MaterialUtils.setObjectMaterialFloatProperty(patternSeq, "_AlphaSeqOnOff", 0);
                    ObjectUtils.ShowObject(patternSeq, false, false);

                    PlayPoster();
                    break;

                case false:
                    AnimationUtils.ResetAnimatorTriggerState(logo01, "Play");
                    AnimationUtils.SetAnimatorTriggerState(logo01, "Idle");
                    AnimationUtils.ResetAnimatorTriggerState(logo02, "Play");
                    AnimationUtils.SetAnimatorTriggerState(logo02, "Idle");
                    AnimationUtils.ResetAnimatorTriggerState(logo03, "Play");
                    AnimationUtils.SetAnimatorTriggerState(logo03, "Idle");
                    AnimationUtils.ResetAnimatorTriggerState(logo04, "Play");
                    AnimationUtils.SetAnimatorTriggerState(logo04, "Idle");
                    AnimationUtils.ResetAnimatorTriggerState(text, "Play");
                    AnimationUtils.SetAnimatorTriggerState(text, "Idle");

                    MaterialUtils.setObjectMaterialFloatProperty(patternSeq, "_TextureSeqOnOff", 0);
                    MaterialUtils.setObjectMaterialFloatProperty(patternSeq, "_AlphaSeqOnOff", 0);
                    break;
            }
        }

//------------------------------------------------------------------------------------
        public void Init()
        {
            if (testing)
            {
            }
            else if (!testing)
            {
                TransformUtils.SetObjectParent(asset + "(Clone)", gameObject.name);

                MaterialUtils.SetObjectShader("CIAP_Pattern", false, "Shaders/Unlit_Rotate");
                MaterialUtils.SetObjectShader("CIAP_Pattern_Seq", false, "Shaders/Unlit_AniSeq");
                MaterialUtils.SetObjectShader("CIAP_Planes", true, "Shader Forge/Unlit_DS");
                MaterialUtils.SetObjectShader("CIAP_Logos", true, "Shader Forge/Unlit_DS");
                MaterialUtils.SetObjectShader("CIAP_Logos2", true, "Shader Forge/Unlit_DS");
                MaterialUtils.SetObjectShader("CIAP_Logos3", true, "Shader Forge/Unlit_DS");
                MaterialUtils.SetObjectShader("CIAP_Logos4", true, "Shader Forge/Unlit_DS");
                MaterialUtils.SetObjectShader("CIAP_Text", true, "Shader Forge/Unlit_DS_Color");
            }

            logo01 = GameObject.Find("CIAP_Logos");
            logo02 = GameObject.Find("CIAP_Logos2");
            logo03 = GameObject.Find("CIAP_Logos3");
            logo04 = GameObject.Find("CIAP_Logos4");
            text = GameObject.Find("CIAP_Text");
            pattern = GameObject.Find("CIAP_Pattern");
            patternSeq = GameObject.Find("CIAP_Pattern_Seq");

            allowTracking = true;

            onScan(false);
        }

//------------------------------------------------------------------------------------
        void PlayPoster()
        {
            AnimationUtils.ResetAnimatorTriggerState(logo01, "Idle");
            AnimationUtils.SetAnimatorTriggerState(logo01, "Play");
            AnimationUtils.ResetAnimatorTriggerState(logo02, "Idle");
            AnimationUtils.SetAnimatorTriggerState(logo02, "Play");
            AnimationUtils.ResetAnimatorTriggerState(logo03, "Idle");
            AnimationUtils.SetAnimatorTriggerState(logo03, "Play");
            AnimationUtils.ResetAnimatorTriggerState(logo04, "Idle");
            AnimationUtils.SetAnimatorTriggerState(logo04, "Play");
            AnimationUtils.ResetAnimatorTriggerState(text, "Idle");
            AnimationUtils.SetAnimatorTriggerState(text, "Play");

            ObjectUtils.ShowObject(pattern, false, true);
        }

//------------------------------------------------------------------------------------
        public void PlaySequence()
        {
            ObjectUtils.EnableCollider(gameObject, false, false);

            ObjectUtils.ShowObject(pattern, false, false);

            ObjectUtils.ShowObject(patternSeq, false, true);
            MaterialUtils.setObjectMaterialFloatProperty(patternSeq, "_TextureSeqOnOff", 1);
            MaterialUtils.setObjectMaterialFloatProperty(patternSeq, "_AlphaSeqOnOff", 1);

            Delay.DelayFunction(this, ResetSequence, delayTime);
        }

//------------------------------------------------------------------------------------
        void ResetSequence()
        {
            ObjectUtils.EnableCollider(gameObject, false, true);

            ObjectUtils.ShowObject(pattern, false, true);

            ObjectUtils.ShowObject(patternSeq, false, false);
            MaterialUtils.setObjectMaterialFloatProperty(patternSeq, "_TextureSeqOnOff", 0);
            MaterialUtils.setObjectMaterialFloatProperty(patternSeq, "_AlphaSeqOnOff", 0);
        }
    }
}