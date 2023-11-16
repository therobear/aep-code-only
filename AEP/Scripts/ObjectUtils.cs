using UnityEngine;
using System;
using System.IO;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AEP_Utilities
{
    public static class ObjectUtils
    {
        public static void ShowObject(string obj, bool children, bool show)
        {
            GameObject gGameObject = GameObject.Find(obj);

            try
            {
                switch (children)
                {
                    case true:
                        Renderer[] rRenderer = gGameObject.GetComponentsInChildren<Renderer>();

                        for (int i = 0; i < rRenderer.Length; i++)
                        {
                            rRenderer[i].enabled = show;
                        }

                        Debug.Log("ObjectUtils - ShowObject: Children are being shown/hidden from object " + obj + ".");
                        break;

                    case false:
                        Renderer rComponent = gGameObject.GetComponent<Renderer>();

                        rComponent.enabled = show;

                        Debug.Log("ObjectUtils - ShowObject: " + obj + " is being shown/hidden.");
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("ObjectUtils - ShowObject: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ShowObject(GameObject obj, bool children, bool show)
        {
            try
            {
                switch (children)
                {
                    case true:
                        Renderer[] rRenderer = obj.GetComponentsInChildren<Renderer>();

                        for (int i = 0; i < rRenderer.Length; i++)
                        {
                            rRenderer[i].enabled = show;
                        }

                        Debug.Log("ObjectUtils - ShowObject: Children are being shown/hidden from object " + obj.name + ".");
                        break;

                    case false:
                        Renderer rComponent = obj.GetComponent<Renderer>();

                        rComponent.enabled = show;

                        Debug.Log("ObjectUtils - ShowObject: " + obj.name + " is being shown/hidden.");
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("ObjectUtils - ShowObject: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableCollider(string obj, bool children, bool enable)
        {
            GameObject gGameObject = GameObject.Find(obj);

            try
            {
                switch (children)
                {
                    case true:
                        Collider[] cCollider = gGameObject.GetComponentsInChildren<Collider>();

                        for (int i = 0; i < cCollider.Length; i++)
                        {
                            cCollider[i].enabled = enable;
                        }

                        Debug.Log("ObjectUtils - EnableCollider: Children colliders are being enabled/disabled from object " + obj + ".");
                        break;

                    case false:
                        Collider cComponent = gGameObject.GetComponent<Collider>();

                        cComponent.enabled = enable;

                        Debug.Log("ObjectUtils - EnableCollider: Collider on " + obj + " is now enabled/disabled.");
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("ObjectUtils - EnableCollider: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableCollider(GameObject obj, bool children, bool enable)
        {
            try
            {
                switch (children)
                {
                    case true:
                        Collider[] cCollider = obj.GetComponentsInChildren<Collider>();

                        for (int i = 0; i < cCollider.Length; i++)
                        {
                            cCollider[i].enabled = enable;
                        }

                        Debug.Log("ObjectUtils - EnableCollider: Children colliders are being enabled/disabled from object " + obj.name + ".");
                        break;

                    case false:
                        Collider cComponent = obj.GetComponent<Collider>();

                        cComponent.enabled = enable;

                        Debug.Log("ObjectUtils - EnableCollider: Collider on " + obj.name + " is now enabled/disabled.");
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("ObjectUtils - EnableCollider: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableObject(string obj, bool children, bool enable)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                ShowObject(obj, children, enable);
                EnableCollider(obj, children, enable);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("ObjectUtils - EnableObject: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableObject(GameObject obj, bool children, bool enable)
        {
            try
            {
                ShowObject(obj, children, enable);
                EnableCollider(obj, children, enable);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("ObjectUtils - EnableObject: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void showSprite(string obj, bool children, bool enable)
        {
            GameObject gObj = GameObject.Find(obj);

            try
            {
                switch (children)
                {
                    case true:
                        SpriteRenderer[] sSpriteRender = gObj.GetComponentsInChildren<SpriteRenderer>();

                        for (int i = 0; i < sSpriteRender.Length; i++)
                        {
                            sSpriteRender[i].enabled = enable;
                        }
                        break;

                    case false:
                        SpriteRenderer cComponent = gObj.GetComponent<SpriteRenderer>();

                        cComponent.enabled = enable;
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("ObjectUtils - showSprite: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void showSprite(GameObject obj, bool children, bool enable)
        {
            try
            {
                switch (children)
                {
                    case true:
                        SpriteRenderer[] sSpriteRender = obj.GetComponentsInChildren<SpriteRenderer>();

                        for (int i = 0; i < sSpriteRender.Length; i++)
                        {
                            sSpriteRender[i].enabled = enable;
                        }
                        break;

                    case false:
                        SpriteRenderer cComponent = obj.GetComponent<SpriteRenderer>();

                        cComponent.enabled = enable;
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("ObjectUtils - showSprite: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AddRemoveComponent(string obj, string script, string addRemove)
        {
            GameObject go = GameObject.Find(obj);

            addRemove = addRemove.ToLower();

            switch (addRemove)
            {
                case "add":
                    go.AddComponent(System.Type.GetType(script));
                    break;

                case "remove":
                    GameObject.Destroy(go.GetComponent(script));
                    break;
            }
        }
    }
}
