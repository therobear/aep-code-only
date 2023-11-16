using UnityEngine;
using System;
using System.IO;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AEP_Utilities
{
    public static class TransformUtils
    {
        public static void SetObjectPosition(string obj, bool isLocal, Vector3 position)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (isLocal)
                {
                    case true:
                        gObject.transform.localPosition = position;
                        break;

                    case false:
                        gObject.transform.position = position;
                        break;
                }
            }
            catch(NullReferenceException)
            {
                Debug.LogError("TransformUtils - SetObjectPosition: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectPosition(GameObject obj, bool isLocal, Vector3 position)
        {
            try
            {
                switch (isLocal)
                {
                    case true:
                        obj.transform.localPosition = position;
                        break;

                    case false:
                        obj.transform.position = position;
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - SetObjectPosition: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectRotation(string obj, bool isLocal, Vector3 rotation)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (isLocal)
                {
                    case true:
                        gObject.transform.localRotation = Quaternion.Euler(rotation);
                        break;

                    case false:
                        gObject.transform.rotation = Quaternion.Euler(rotation);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - SetObjectRotation: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectRotation(GameObject obj, bool isLocal, Vector3 rotation)
        {
            try
            {
                switch (isLocal)
                {
                    case true:
                        obj.transform.localRotation = Quaternion.Euler(rotation);
                        break;

                    case false:
                        obj.transform.rotation = Quaternion.Euler(rotation);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - SetObjectRotation: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectScale(string obj, Vector3 scale)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                gObject.transform.localScale = scale;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - SetObjectScale: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectScale(GameObject obj, Vector3 scale)
        {
            try
            {
                obj.transform.localScale = scale;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - SetObjectScale: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void MoveObject(string obj, bool isLocal, Vector3 position, float time)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch(isLocal)
                {
                    case true:
                        LeanTween.moveLocal(gObject, position, time);
                        break;

                    case false:
                        LeanTween.move(gObject, position, time);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - MoveObject: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void MoveObject(GameObject obj, bool isLocal, Vector3 position, float time)
        {
            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.moveLocal(obj, position, time);
                        break;

                    case false:
                        LeanTween.move(obj, position, time);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - MoveObject: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void MoveObject(string obj, bool isLocal, Vector3 position, float time, LeanTweenType easeType)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.moveLocal(gObject, position, time).setEase(easeType);
                        break;

                    case false:
                        LeanTween.move(gObject, position, time).setEase(easeType);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - MoveObject: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void MoveObject(GameObject obj, bool isLocal, Vector3 position, float time, LeanTweenType easeType)
        {
            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.moveLocal(obj, position, time).setEase(easeType);
                        break;

                    case false:
                        LeanTween.move(obj, position, time).setEase(easeType);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - MoveObject: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void MoveOnSpecificAxis(string obj, bool isLocal, float amount, string axis, float time)
        {
            GameObject gObject = GameObject.Find(obj);

            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - MoveOnSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.moveLocalX(gObject, amount, time);
                                break;

                            case "Y":
                                LeanTween.moveLocalY(gObject, amount, time);
                                break;

                            case "Z":
                                LeanTween.moveLocalZ(gObject, amount, time);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.moveX(gObject, amount, time);
                                break;

                            case "Y":
                                LeanTween.moveY(gObject, amount, time);
                                break;

                            case "Z":
                                LeanTween.moveZ(gObject, amount, time);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - MoveOnSpecificAxis: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void MoveOnSpecificAxis(string obj, bool isLocal, float amount, string axis, float time, LeanTweenType easeType)
        {
            GameObject gObject = GameObject.Find(obj);

            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - MoveOnSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.moveLocalX(gObject, amount, time).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.moveLocalY(gObject, amount, time).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.moveLocalZ(gObject, amount, time).setEase(easeType);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.moveX(gObject, amount, time).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.moveY(gObject, amount, time).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.moveZ(gObject, amount, time).setEase(easeType);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - MoveOnSpecificAxis: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void MoveOnSpecificAxis(GameObject obj, bool isLocal, float amount, string axis, float time)
        {
            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - MoveOnSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.moveLocalX(obj, amount, time);
                                break;

                            case "Y":
                                LeanTween.moveLocalY(obj, amount, time);
                                break;

                            case "Z":
                                LeanTween.moveLocalZ(obj, amount, time);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.moveX(obj, amount, time);
                                break;

                            case "Y":
                                LeanTween.moveY(obj, amount, time);
                                break;

                            case "Z":
                                LeanTween.moveZ(obj, amount, time);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - MoveOnSpecificAxis: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void MoveOnSpecificAxis(GameObject obj, bool isLocal, float amount, string axis, float time, LeanTweenType easeType)
        {
            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - MoveOnSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.moveLocalX(obj, amount, time).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.moveLocalY(obj, amount, time).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.moveLocalZ(obj, amount, time).setEase(easeType);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.moveX(obj, amount, time).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.moveY(obj, amount, time).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.moveZ(obj, amount, time).setEase(easeType);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - MoveOnSpecificAxis: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateObject(string obj, bool isLocal, Vector3 rotation, float time)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.rotateLocal(gObject, rotation, time);
                        break;

                    case false:
                        LeanTween.rotate(gObject, rotation, time);
                        break;
                }
            }

            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateObject: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateObject(string obj, bool isLocal, Vector3 rotation, float time, LeanTweenType easeType)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.rotateLocal(gObject, rotation, time).setEase(easeType);
                        break;

                    case false:
                        LeanTween.rotate(gObject, rotation, time).setEase(easeType);
                        break;
                }
            }

            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateObject: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateObject(string obj, bool isLocal, Vector3 rotation, float time, int repeat)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.rotateLocal(gObject, rotation, time).setRepeat(repeat);
                        break;

                    case false:
                        LeanTween.rotate(gObject, rotation, time).setRepeat(repeat);
                        break;
                }
            }

            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateObject: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateObject(string obj, bool isLocal, Vector3 rotation, float time, int repeat, LeanTweenType easeType)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.rotateLocal(gObject, rotation, time).setRepeat(repeat);
                        break;

                    case false:
                        LeanTween.rotate(gObject, rotation, time).setRepeat(repeat);
                        break;
                }
            }

            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateObject: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateObject(GameObject obj, bool isLocal, Vector3 rotation, float time)
        {
            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.rotateLocal(obj, rotation, time);
                        break;

                    case false:
                        LeanTween.rotate(obj, rotation, time);
                        break;
                }
            }

            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateObject: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateObject(GameObject obj, bool isLocal, Vector3 rotation, float time, LeanTweenType easeType)
        {
            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.rotateLocal(obj, rotation, time).setEase(easeType);
                        break;

                    case false:
                        LeanTween.rotate(obj, rotation, time).setEase(easeType);
                        break;
                }
            }

            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateObject: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateObject(GameObject obj, bool isLocal, Vector3 rotation, float time, int repeat)
        {
            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.rotateLocal(obj, rotation, time).setRepeat(repeat);
                        break;

                    case false:
                        LeanTween.rotate(obj, rotation, time).setRepeat(repeat);
                        break;
                }
            }

            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateObject: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateObject(GameObject obj, bool isLocal, Vector3 rotation, float time, int repeat, LeanTweenType easeType)
        {
            try
            {
                switch (isLocal)
                {
                    case true:
                        LeanTween.rotateLocal(obj, rotation, time).setRepeat(repeat).setEase(easeType);
                        break;

                    case false:
                        LeanTween.rotate(obj, rotation, time).setRepeat(repeat).setEase(easeType);
                        break;
                }
            }

            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateObject: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

        public static void RotateAroundAxis(string obj, Vector3 axis, float amount, float time, int repeat, bool local)
        {
            GameObject go = GameObject.Find(obj);

            if (go)
            {
                switch (local)
                {
                    case true:
                        LeanTween.rotateAroundLocal(go, axis, amount, time).setRepeat(repeat);
                        break;

                    case false:
                        LeanTween.rotateAround(go, axis, amount, time).setRepeat(repeat);
                        break;
                }
            }
            else if (!go)
            {
                Debug.LogError("TransformUtils - Rotate Around Axis: Cannot find " + go + "! Make sure " + go + " is in the scene or the spelling is correct.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateAroundSpecificAxis(string obj, bool isLocal, string axis, float amount, float time)
        {
            GameObject gObject = GameObject.Find(obj);

            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateAroundLocal(gObject, Vector3.right, amount, time);
                                break;

                            case "Y":
                                LeanTween.rotateAroundLocal(gObject, Vector3.up, amount, time);
                                break;

                            case "Z":
                                LeanTween.rotateAroundLocal(gObject, Vector3.forward, amount, time);
                                break;
                        }
                        break;

                    case false:
                        switch(axis)
                        {
                            case "X":
                                LeanTween.rotateX(gObject, amount, time);
                                break;

                            case "Y":
                                LeanTween.rotateY(gObject, amount, time);
                                break;

                            case "Z":
                                LeanTween.rotateZ(gObject, amount, time);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateAroundSpecificAxis(string obj, bool isLocal, string axis, float amount, float time, int repeat)
        {
            GameObject gObject = GameObject.Find(obj);

            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateAroundLocal(gObject, Vector3.right, amount, time).setRepeat(repeat);
                                break;

                            case "Y":
                                LeanTween.rotateAroundLocal(gObject, Vector3.up, amount, time).setRepeat(repeat);
                                break;

                            case "Z":
                                LeanTween.rotateAroundLocal(gObject, Vector3.forward, amount, time).setRepeat(repeat);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateX(gObject, amount, time).setRepeat(repeat);
                                break;

                            case "Y":
                                LeanTween.rotateY(gObject, amount, time).setRepeat(repeat);
                                break;

                            case "Z":
                                LeanTween.rotateZ(gObject, amount, time).setRepeat(repeat);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateAroundSpecificAxis(string obj, bool isLocal, string axis, float amount, float time, LeanTweenType easeType)
        {
            GameObject gObject = GameObject.Find(obj);

            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateAroundLocal(gObject, Vector3.right, amount, time).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.rotateAroundLocal(gObject, Vector3.up, amount, time).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.rotateAroundLocal(gObject, Vector3.forward, amount, time).setEase(easeType);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateX(gObject, amount, time).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.rotateY(gObject, amount, time).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.rotateZ(gObject, amount, time).setEase(easeType);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateAroundSpecificAxis(string obj, bool isLocal, string axis, float amount, float time, int repeat, LeanTweenType easeType)
        {
            GameObject gObject = GameObject.Find(obj);

            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateAroundLocal(gObject, Vector3.right, amount, time).setRepeat(repeat).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.rotateAroundLocal(gObject, Vector3.up, amount, time).setRepeat(repeat).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.rotateAroundLocal(gObject, Vector3.forward, amount, time).setRepeat(repeat).setEase(easeType);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateX(gObject, amount, time).setRepeat(repeat).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.rotateY(gObject, amount, time).setRepeat(repeat).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.rotateZ(gObject, amount, time).setRepeat(repeat).setEase(easeType);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateAroundSpecificAxis(GameObject obj, bool isLocal, string axis, float amount, float time)
        {
            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateAroundLocal(obj, Vector3.right, amount, time);
                                break;

                            case "Y":
                                LeanTween.rotateAroundLocal(obj, Vector3.up, amount, time);
                                break;

                            case "Z":
                                LeanTween.rotateAroundLocal(obj, Vector3.forward, amount, time);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateX(obj, amount, time);
                                break;

                            case "Y":
                                LeanTween.rotateY(obj, amount, time);
                                break;

                            case "Z":
                                LeanTween.rotateZ(obj, amount, time);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateAroundSpecificAxis(GameObject obj, bool isLocal, string axis, float amount, float time, int repeat)
        {
            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateAroundLocal(obj, Vector3.right, amount, time).setRepeat(repeat);
                                break;

                            case "Y":
                                LeanTween.rotateAroundLocal(obj, Vector3.up, amount, time).setRepeat(repeat);
                                break;

                            case "Z":
                                LeanTween.rotateAroundLocal(obj, Vector3.forward, amount, time).setRepeat(repeat);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateX(obj, amount, time).setRepeat(repeat);
                                break;

                            case "Y":
                                LeanTween.rotateY(obj, amount, time).setRepeat(repeat);
                                break;

                            case "Z":
                                LeanTween.rotateZ(obj, amount, time).setRepeat(repeat);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateAroundSpecificAxis(GameObject obj, bool isLocal, string axis, float amount, float time, LeanTweenType easeType)
        {
            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateAroundLocal(obj, Vector3.right, amount, time).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.rotateAroundLocal(obj, Vector3.up, amount, time).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.rotateAroundLocal(obj, Vector3.forward, amount, time).setEase(easeType);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateX(obj, amount, time).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.rotateY(obj, amount, time).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.rotateZ(obj, amount, time).setEase(easeType);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RotateAroundSpecificAxis(GameObject obj, bool isLocal, string axis, float amount, float time, int repeat, LeanTweenType easeType)
        {
            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (isLocal)
                {
                    case true:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateAroundLocal(obj, Vector3.right, amount, time).setRepeat(repeat).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.rotateAroundLocal(obj, Vector3.up, amount, time).setRepeat(repeat).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.rotateAroundLocal(obj, Vector3.forward, amount, time).setRepeat(repeat).setEase(easeType);
                                break;
                        }
                        break;

                    case false:
                        switch (axis)
                        {
                            case "X":
                                LeanTween.rotateX(obj, amount, time).setRepeat(repeat).setEase(easeType);
                                break;

                            case "Y":
                                LeanTween.rotateY(obj, amount, time).setRepeat(repeat).setEase(easeType);
                                break;

                            case "Z":
                                LeanTween.rotateZ(obj, amount, time).setRepeat(repeat).setEase(easeType);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - RotateAroundSpecificAxis: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTween(string obj, Vector3 scale, float time)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                LeanTween.scale(gObject, scale, time);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTween: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTween(string obj, Vector3 scale, float time, LeanTweenType easeType)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                LeanTween.scale(gObject, scale, time).setEase(easeType);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTween: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTween(string obj, Vector3 scale, float time, int repeat)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                LeanTween.scale(gObject, scale, time).setRepeat(repeat);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTween: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTween(string obj, Vector3 scale, float time, int repeat, LeanTweenType easeType)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                LeanTween.scale(gObject, scale, time).setRepeat(repeat).setEase(easeType);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTween: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTween(GameObject obj, Vector3 scale, float time)
        {
            try
            {
                LeanTween.scale(obj, scale, time);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTween: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTween(GameObject obj, Vector3 scale, float time, LeanTweenType easeType)
        {
            try
            {
                LeanTween.scale(obj, scale, time).setEase(easeType);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTween: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTween(GameObject obj, Vector3 scale, float time, int repeat)
        {
            try
            {
                LeanTween.scale(obj, scale, time).setRepeat(repeat);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTween: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTween(GameObject obj, Vector3 scale, float time, int repeat, LeanTweenType easeType)
        {
            try
            {
                LeanTween.scale(obj, scale, time).setRepeat(repeat).setEase(easeType);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTween: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTweenOnAxis(string obj, string axis, float amount, float time)
        {
            GameObject gObject = GameObject.Find(obj);

            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch(axis)
                {
                    case "X":
                        LeanTween.scaleX(gObject, amount, time);
                        break;

                    case "Y":
                        LeanTween.scaleY(gObject, amount, time);
                        break;

                    case "Z":
                        LeanTween.scaleZ(gObject, amount, time);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTweenOnAxis(string obj, string axis, float amount, float time, int repeat)
        {
            GameObject gObject = GameObject.Find(obj);

            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (axis)
                {
                    case "X":
                        LeanTween.scaleX(gObject, amount, time).setRepeat(repeat);
                        break;

                    case "Y":
                        LeanTween.scaleY(gObject, amount, time).setRepeat(repeat);
                        break;

                    case "Z":
                        LeanTween.scaleZ(gObject, amount, time).setRepeat(repeat);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTweenOnAxis(string obj, string axis, float amount, float time, LeanTweenType easeType)
        {
            GameObject gObject = GameObject.Find(obj);

            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (axis)
                {
                    case "X":
                        LeanTween.scaleX(gObject, amount, time).setEase(easeType);
                        break;

                    case "Y":
                        LeanTween.scaleY(gObject, amount, time).setEase(easeType);
                        break;

                    case "Z":
                        LeanTween.scaleZ(gObject, amount, time).setEase(easeType);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTweenOnAxis(string obj, string axis, float amount, float time, int repeat, LeanTweenType easeType)
        {
            GameObject gObject = GameObject.Find(obj);

            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (axis)
                {
                    case "X":
                        LeanTween.scaleX(gObject, amount, time).setRepeat(repeat).setEase(easeType);
                        break;

                    case "Y":
                        LeanTween.scaleY(gObject, amount, time).setRepeat(repeat).setEase(easeType);
                        break;

                    case "Z":
                        LeanTween.scaleZ(gObject, amount, time).setRepeat(repeat).setEase(easeType);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTweenOnAxis(GameObject obj, string axis, float amount, float time)
        {
            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (axis)
                {
                    case "X":
                        LeanTween.scaleX(obj, amount, time);
                        break;

                    case "Y":
                        LeanTween.scaleY(obj, amount, time);
                        break;

                    case "Z":
                        LeanTween.scaleZ(obj, amount, time);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTweenOnAxis(GameObject obj, string axis, float amount, float time, int repeat)
        {
            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (axis)
                {
                    case "X":
                        LeanTween.scaleX(obj, amount, time).setRepeat(repeat);
                        break;

                    case "Y":
                        LeanTween.scaleY(obj, amount, time).setRepeat(repeat);
                        break;

                    case "Z":
                        LeanTween.scaleZ(obj, amount, time).setRepeat(repeat);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTweenOnAxis(GameObject obj, string axis, float amount, float time, LeanTweenType easeType)
        {
            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (axis)
                {
                    case "X":
                        LeanTween.scaleX(obj, amount, time).setEase(easeType);
                        break;

                    case "Y":
                        LeanTween.scaleY(obj, amount, time).setEase(easeType);
                        break;

                    case "Z":
                        LeanTween.scaleZ(obj, amount, time).setEase(easeType);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ScaleTweenOnAxis(GameObject obj, string axis, float amount, float time, int repeat, LeanTweenType easeType)
        {
            if (axis == "x" || axis == "y" || axis == "z")
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: axis must be a capitol letter!!!");
                return;
            }

            try
            {
                switch (axis)
                {
                    case "X":
                        LeanTween.scaleX(obj, amount, time).setRepeat(repeat).setEase(easeType);
                        break;

                    case "Y":
                        LeanTween.scaleY(obj, amount, time).setRepeat(repeat).setEase(easeType);
                        break;

                    case "Z":
                        LeanTween.scaleZ(obj, amount, time).setRepeat(repeat).setEase(easeType);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - ScaleTweenOnAxis: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectParent(string target, string parent)
        {
            GameObject gTarget = GameObject.Find(target);

            GameObject gParent = GameObject.Find(parent);

            try
            {
                gTarget.transform.SetParent(gParent.transform);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - SetObjectParent: " + target + " or " + parent + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectParent(GameObject target, GameObject parent)
        {
            try
            {
                target.transform.SetParent(parent.transform);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("TransformUtils - SetObjectParent: " + target.name + " or " + parent.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }
    }
}
