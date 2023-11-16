using UnityEngine;
using System;
using System.Collections;

namespace AEP_Utilities
{
    public static class Delay
    {
        public static Coroutine DelayFunction(this MonoBehaviour monoBehaviour, Action action, float time)
        {
            return monoBehaviour.StartCoroutine(WaitImpl(action, time));
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static Coroutine DelayFunction(this MonoBehaviour monoBehaviour, Action<int> action, int actionParam, float time)
        {
            return monoBehaviour.StartCoroutine(WaitImpl(action, actionParam, time));
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static IEnumerator WaitImpl(Action action, float time)
        {
            yield return new WaitForSeconds(time);

            action();
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static IEnumerator WaitImpl(Action<int> action, int actionParam, float time)
        {
            yield return new WaitForSeconds(time);

            action(actionParam);
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void CancelDelay(this MonoBehaviour monoBehaviour, Coroutine coroutine)
        {
            monoBehaviour.StopCoroutine(coroutine);
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void CancelAllDelays(this MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StopAllCoroutines();
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void CancelAllLeanTween()
        {
            LeanTween.cancelAll();
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void CancelLeanTweenOnObject(string obj)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                LeanTween.cancel(gObject);
            }
            catch (NullReferenceException)
            {
                Debug.LogWarning("Delay - CancelLeanTweeenOnObject: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void CancelLeanTweenOnObject(GameObject obj)
        {
            try
            {
                LeanTween.cancel(obj);
            }
            catch (NullReferenceException)
            {
                Debug.LogWarning("Delay - CancelLeanTweeenOnObject: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }
    }
}
