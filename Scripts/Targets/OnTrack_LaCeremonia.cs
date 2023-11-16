using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AEP_Utilities;

namespace Vuforia
{
    public class OnTrack_LaCeremonia : AEPImageTrackerBase
    {
        private GameObject background;
        private GameObject blueMan;
        private GameObject carpet;
        private GameObject curandera;
        private GameObject fox;
        private GameObject rabbit;
        private GameObject raccoon;
        private GameObject rat;
        private GameObject skull;
        private GameObject space;
        private GameObject logo;
        private GameObject outlines;
        private GameObject smoke;
        private GameObject cleanse;

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
                            AssignShaders();

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
                    PlayIntroAnims();

                    Delay.DelayFunction(this, HideLogo, 3.0f);
                    Delay.DelayFunction(this, HideAnimals, 14.0f);
                    Delay.DelayFunction(this, StartLoopBlueManCarpet, 14.0f);
                    Delay.DelayFunction(this, StopCleanse, 15.0f);
                    Delay.DelayFunction(this, StartLoopCurandera, 15.0f);
                    Delay.DelayFunction(this, StartLoopSkull, 23.0f);
                    Delay.DelayFunction(this, StartLoopOutlines, 25.0f);
                    Delay.DelayFunction(this, StartLoopSpace, 25.0f);
                    break;

                case false:
                    SetAllToIdle();

                    Delay.CancelAllDelays(this);
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

                MaterialUtils.SetObjectShader(gameObject, true, "Shaders/Temp Sprite");

                MaterialUtils.SetObjectShader("LC_Skull_Clouds", false, "Shaders/LC_Smoke");
                MaterialUtils.SetObjectShader("LC_Skull_Fill", false, "Shaders/Unlit_Multi");

                MaterialUtils.SetObjectShader("LC_Space", true, "Shaders/2D_Opacity");

                MaterialUtils.SetObjectShader("LC_MA_Logo", false, "Shaders/2D_Opacity");

                MaterialUtils.SetObjectShader("LC_PART_SmokeStem", false, "Mobile/Particles/Alpha Blended");
                MaterialUtils.SetObjectShader("LC_CUR_Smoke_Cleanse_Part", false, "Mobile/Particles/Alpha Blended");

                MaterialUtils.SetObjectShader("LC_Outlines", true, "Shaders/Unlit_AniSeq");
            }

            background = GameObject.Find("LC_Background1");
            blueMan = GameObject.Find("LC_BlueMan");
            carpet = GameObject.Find("LC_Whole/LC_Carpet");
            cleanse = GameObject.Find("LC_CUR_Smoke_Cleanse_Part");
            curandera = GameObject.Find("LC_Curandera");
            fox = GameObject.Find("LC_Whole/LC_Fox");
            rabbit = GameObject.Find("LC_Whole/LC_Rabbit");
            raccoon = GameObject.Find("LC_Whole/LC_Raccoon");
            rat = GameObject.Find("LC_Whole/LC_Rat");
            skull = GameObject.Find("LC_Whole/LC_Skull");
            space = GameObject.Find("LC_Whole/LC_Space");
            logo = GameObject.Find("LC_LaCeremonia/LC_MA_Logo");
            smoke = GameObject.Find("LC_PART_SmokeStem");
            outlines = GameObject.Find("LC_Outlines");

            allowTracking = true;

            onScan(false);
        }

        void AssignShaders()
        {
            TransformUtils.SetObjectParent(asset + "(Clone)", gameObject.name);

            MaterialUtils.SetObjectShader(gameObject, true, "Sprites/Default");

            MaterialUtils.SetObjectShader("LC_Skull_Clouds", false, "Shaders/LC_Smoke");
            MaterialUtils.SetObjectShader("LC_Skull_Fill", false, "Shaders/Unlit_Multi");

            MaterialUtils.SetObjectShader("LC_Space", true, "Shaders/2D_Opacity");

            MaterialUtils.SetObjectShader("LC_MA_Logo", false, "Shaders/2D_Opacity");

            MaterialUtils.SetObjectShader("LC_PART_SmokeStem", false, "Mobile/Particles/Alpha Blended");
            MaterialUtils.SetObjectShader("LC_CUR_Smoke_Cleanse_Part", false, "Mobile/Particles/Alpha Blended");

            MaterialUtils.SetObjectShader("LC_Outlines", true, "Shaders/Unlit_AniSeq");
        }

//------------------------------------------------------------------------------------
        void SetAllToIdle()
        {
            AnimationUtils.SetAnimatorTriggerState(blueMan, "Idle");
            AnimationUtils.SetAnimatorTriggerState(carpet, "Idle");
            AnimationUtils.SetAnimatorTriggerState(curandera, "Idle");
            AnimationUtils.SetAnimatorTriggerState(fox, "Idle");
            AnimationUtils.SetAnimatorTriggerState(rabbit, "Idle");
            AnimationUtils.SetAnimatorTriggerState(raccoon, "Idle");
            AnimationUtils.SetAnimatorTriggerState(rat, "Idle");
            AnimationUtils.SetAnimatorTriggerState(skull, "Idle");
            AnimationUtils.SetAnimatorTriggerState(space, "Idle");
            AnimationUtils.SetAnimatorTriggerState(logo, "Idle");
            AnimationUtils.SetAnimatorTriggerState(outlines, "Idle");

            AnimationUtils.PlayParticles(smoke, false);
            AnimationUtils.PlayParticles(cleanse, false);
        }

//------------------------------------------------------------------------------------
        void PlayIntroAnims()
        {
            AnimationUtils.SetAnimatorTriggerState(logo, "FadeIn");
            AnimationUtils.SetAnimatorTriggerState(blueMan, "Intro");
            AnimationUtils.SetAnimatorTriggerState(carpet, "Intro");
            AnimationUtils.SetAnimatorTriggerState(curandera, "Intro");
            AnimationUtils.SetAnimatorTriggerState(fox, "Intro");
            AnimationUtils.SetAnimatorTriggerState(rabbit, "Intro");
            AnimationUtils.SetAnimatorTriggerState(raccoon, "Intro");
            AnimationUtils.SetAnimatorTriggerState(rat, "Intro");
            AnimationUtils.SetAnimatorTriggerState(skull, "Fade");
            AnimationUtils.SetAnimatorTriggerState(space, "Intro");
            AnimationUtils.SetAnimatorTriggerState(outlines, "FadeIn");

            AnimationUtils.PlayParticles(smoke, true);
            AnimationUtils.PlayParticles(cleanse, true);
        }

//------------------------------------------------------------------------------------
        void HideLogo()
        {
            AnimationUtils.SetAnimatorTriggerState(logo, "Idle");
            ObjectUtils.ShowObject(logo, true, false);
        }

//------------------------------------------------------------------------------------
        void HideAnimals()
        {
            AnimationUtils.SetAnimatorTriggerState(fox, "Idle");
            ObjectUtils.ShowObject(fox, true, false);

            AnimationUtils.SetAnimatorTriggerState(rabbit, "Idle");
            ObjectUtils.ShowObject(rabbit, true, false);

            AnimationUtils.SetAnimatorTriggerState(raccoon, "Idle");
            ObjectUtils.ShowObject(raccoon, true, false);

            AnimationUtils.SetAnimatorTriggerState(rat, "Idle");
            ObjectUtils.ShowObject(rat, true, false);
        }

//------------------------------------------------------------------------------------
        void StopCleanse()
        {
            AnimationUtils.PlayParticles(cleanse, false);
        }

//------------------------------------------------------------------------------------
        void StartLoopBlueManCarpet()
        {
            AnimationUtils.SetAnimatorTriggerState(blueMan, "Loop");
            AnimationUtils.SetAnimatorTriggerState(carpet, "Loop");
        }

//------------------------------------------------------------------------------------
        void StartLoopCurandera()
        {
            AnimationUtils.SetAnimatorTriggerState(curandera, "Loop");
        }

//------------------------------------------------------------------------------------
        void StartLoopSkull()
        {
            AnimationUtils.SetAnimatorTriggerState(skull, "Loop");
        }

//------------------------------------------------------------------------------------
        void StartLoopOutlines()
        {
            AnimationUtils.SetAnimatorTriggerState(outlines, "Loop");
        }

//------------------------------------------------------------------------------------
        void StartLoopSpace()
        {
            AnimationUtils.SetAnimatorTriggerState(space, "Loop");
        }
    }
}