using UnityEngine;
using System;
using System.IO;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AEP_Utilities
{
    public static class AnimationUtils
    {
        public static void SetAnimationWrapMode(string obj, string wrapMode)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Animation anim = gObject.GetComponent<Animation>();

                switch (wrapMode)
                {
                    case "Default":
                        anim.wrapMode = WrapMode.Default;
                        break;

                    case "Loop":
                        anim.wrapMode = WrapMode.Loop;
                        break;

                    case "Once":
                        anim.wrapMode = WrapMode.Once;
                        break;

                    case "PingPong":
                        anim.wrapMode = WrapMode.PingPong;
                        break;

                    case "Clamp":
                        anim.wrapMode = WrapMode.Clamp;
                        break;

                    case "ClampForever":
                        anim.wrapMode = WrapMode.ClampForever;
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - SetAnimationWrapMode: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetAnimationWrapMode(GameObject obj, string wrapMode)
        {
            try
            {
                Animation anim = obj.GetComponent<Animation>();

                switch (wrapMode)
                {
                    case "Default":
                        anim.wrapMode = WrapMode.Default;
                        break;

                    case "Loop":
                        anim.wrapMode = WrapMode.Loop;
                        break;

                    case "Once":
                        anim.wrapMode = WrapMode.Once;
                        break;

                    case "PingPong":
                        anim.wrapMode = WrapMode.PingPong;
                        break;

                    case "Clamp":
                        anim.wrapMode = WrapMode.Clamp;
                        break;

                    case "ClampForever":
                        anim.wrapMode = WrapMode.ClampForever;
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - SetAnimationWrapMode: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void PlayAnimation(string obj, string animation, bool reverse, string wrapMode)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Animation aAnimation = gObject.GetComponent<Animation>();

                switch (reverse)
                {
                    case true:
                        SetAnimationWrapMode(obj, wrapMode);
                        aAnimation[animation].time = aAnimation[animation].length;
                        aAnimation[animation].speed = -1.0f;
                        aAnimation.Play(animation);
                        break;

                    case false:
                        SetAnimationWrapMode(obj, wrapMode);
                        aAnimation[animation].time = 0.0f;
                        aAnimation[animation].speed = 1.0f;
                        aAnimation.Play(animation);
                        break;
                }
                Debug.Log("AnimationUtils - PlayAnimation: " + animation + " from " + obj + " is playing.");
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - PlayAnimation: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void PlayAnimation(GameObject obj, string animation, bool reverse, string wrapMode)
        {
            try
            {
                Animation aAnimation = obj.GetComponent<Animation>();

                switch (reverse)
                {
                    case true:
                        SetAnimationWrapMode(obj, wrapMode);
                        aAnimation[animation].time = aAnimation[animation].length;
                        aAnimation[animation].speed = -1.0f;
                        aAnimation.Play(animation);
                        break;

                    case false:
                        SetAnimationWrapMode(obj, wrapMode);
                        aAnimation[animation].time = 0.0f;
                        aAnimation[animation].speed = 1.0f;
                        aAnimation.Play(animation);
                        break;
                }
                Debug.Log("AnimationUtils - PlayAnimation: " + animation + " from " + obj.name + " is playing.");
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - PlayAnimation: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void PlayAnimation(string obj, string animation, float speed, bool reverse, string wrapMode)
        {
            GameObject gObject = GameObject.Find(obj);
            
            try
            {
                Animation aAnimation = gObject.GetComponent<Animation>();

                switch (reverse)
                {
                    case true:
                        SetAnimationWrapMode(obj, wrapMode);
                        aAnimation[animation].time = aAnimation[animation].length;
                        aAnimation[animation].speed = speed * -1.0f;
                        aAnimation.Play(animation);
                        break;

                    case false:
                        SetAnimationWrapMode(obj, wrapMode);
                        aAnimation[animation].time = aAnimation[animation].length;
                        aAnimation[animation].speed = speed;
                        aAnimation.Play(animation);
                        break;
                }
                Debug.Log("AnimationUtils - PlayAnimation: " + animation + " from " + obj + " is playing.");
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - PlayAnimation: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void PlayAnimation(GameObject obj, string animation, float speed, bool reverse, string wrapMode)
        {
            try
            {
                Animation aAnimation = obj.GetComponent<Animation>();

                switch (reverse)
                {
                    case true:
                        SetAnimationWrapMode(obj, wrapMode);
                        aAnimation[animation].time = aAnimation[animation].length;
                        aAnimation[animation].speed = speed * -1.0f;
                        aAnimation.Play(animation);
                        break;

                    case false:
                        SetAnimationWrapMode(obj, wrapMode);
                        aAnimation[animation].time = aAnimation[animation].length;
                        aAnimation[animation].speed = speed;
                        aAnimation.Play(animation);
                        break;
                }
                Debug.Log("AnimationUtils - PlayAnimation: " + animation + " from " + obj.name + " is playing.");
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - PlayAnimation: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void StopAnimation(string obj, string animation, string wrapMode)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Animation aAnimation = gObject.GetComponent<Animation>();

                aAnimation.Stop(animation);
                SetAnimationWrapMode(obj, wrapMode);

                Debug.Log("AnimationUtils - StopAnimation: " + animation + " from " + obj + " has been stopped.");
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - StopAnimation: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void StopAnimation(GameObject obj, string animation, string wrapMode)
        {
            try
            {
                Animation aAnimation = obj.GetComponent<Animation>();

                aAnimation.Stop(animation);
                SetAnimationWrapMode(obj, wrapMode);

                Debug.Log("AnimationUtils - StopAnimation: " + animation + " from " + obj.name + " has been stopped.");
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - StopAnimation: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RewindAnimation(string obj, string animation, string wrapMode)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Animation aAnimation = gObject.GetComponent<Animation>();

                SetAnimationWrapMode(obj, wrapMode);
                aAnimation.Stop(animation);
                aAnimation.Rewind(animation);
                aAnimation[animation].speed = -1.0f;
                aAnimation.Play(animation);

                Debug.Log("AnimationUtils - RewindAnimation: " + animation + " from " + obj + " has been reset.");
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - RewindAnimation: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RewindAnimation(GameObject obj, string animation, string wrapMode)
        {
            try
            {
                Animation aAnimation = obj.GetComponent<Animation>();

                SetAnimationWrapMode(obj, wrapMode);
                aAnimation.Stop(animation);
                aAnimation.Rewind(animation);
                aAnimation[animation].speed = -1.0f;
                aAnimation.Play(animation);

                Debug.Log("AnimationUtils - RewindAnimation: " + animation + " from " + obj.name + " has been reset.");
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - RewindAnimation: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetAnimatorBoolState(string obj, string stateName, bool state)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Animator aAnimator = gObject.GetComponent<Animator>();

                aAnimator.SetBool(stateName, state);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - SetAnimatorBoolState: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetAnimatorBoolState(GameObject obj, string stateName, bool state)
        {
            try
            {
                Animator aAnimator = obj.GetComponent<Animator>();

                aAnimator.SetBool(stateName, state);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - SetAnimatorBoolState: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetAnimatorTriggerState(string obj, string triggerName)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Animator aAnimator = gObject.GetComponent<Animator>();

                aAnimator.SetTrigger(triggerName);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - SetAnimatorTriggerState: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetAnimatorTriggerState(GameObject obj, string triggerName)
        {
            try
            {
                Animator aAnimator = obj.GetComponent<Animator>();

                aAnimator.SetTrigger(triggerName);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - SetAnimatorTriggerState: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ResetAnimatorTriggerState(string obj, string triggerName)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Animator aAnimator = gObject.GetComponent<Animator>();

                aAnimator.ResetTrigger(triggerName);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - ResetAnimatorTriggerState: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ResetAnimatorTriggerState(GameObject obj, string triggerName)
        {
            try
            {
                Animator aAnimator = obj.GetComponent<Animator>();

                aAnimator.ResetTrigger(triggerName);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - ResetAnimatorTriggerState: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void addAnimatorController(string obj, RuntimeAnimatorController controller)
        {
            GameObject go = GameObject.Find(obj);

            try
            {
                go.GetComponent<Animator>().runtimeAnimatorController = controller;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - addAnimatorController: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void addAnimatorController(GameObject obj, RuntimeAnimatorController controller)
        {
            try
            {
                obj.GetComponent<Animator>().runtimeAnimatorController = controller;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - addAnimatorController: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void PlayParticles(string obj, bool play)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                ParticleSystem psParticles = gObject.GetComponent<ParticleSystem>();

                switch (play)
                {
                    case true:
                        psParticles.Play();
                        break;

                    case false:
                        psParticles.Stop();
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - PlayParticles: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void PlayParticles(GameObject obj, bool play)
        {
            try
            {
                ParticleSystem psParticles = obj.GetComponent<ParticleSystem>();

                switch (play)
                {
                    case true:
                        psParticles.Play();
                        break;

                    case false:
                        psParticles.Stop();
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AnimationUtils - PlayParticles: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }
    }
}
