using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AEP_Utilities
{
    public static class MaterialUtils
    {
        public static void SetObjectShader(string obj, bool children, string shader)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (children)
                {
                    case true:
                        Renderer[] rRenderer = gObject.GetComponentsInChildren<Renderer>();

                        for (int i = 0; i < rRenderer.Length; i++)
                        {
                            rRenderer[i].material.shader = Shader.Find(shader);
                        }
                        break;

                    case false:
                        Renderer render = gObject.GetComponent<Renderer>();

                        render.material.shader = Shader.Find(shader);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectShader: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void setObjectMaterialFloatProperty(string obj, string property,  float value)
        {
            GameObject gObj = GameObject.Find(obj);

            try
            {
                Renderer render = gObj.GetComponent<Renderer>();

                render.material.SetFloat(property, value);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - setObjectMaterialFloatProperty: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void setObjectMaterialFloatProperty(GameObject obj, string property, float value)
        {
            try
            {
                Renderer render = obj.GetComponent<Renderer>();

                render.material.SetFloat(property, value);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - setObjectMaterialFloatProperty: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectShader(GameObject obj, bool children, string shader)
        {
            try
            {
                switch (children)
                {
                    case true:
                        Renderer[] rRenderer = obj.GetComponentsInChildren<Renderer>();

                        for (int i = 0; i < rRenderer.Length; i++)
                        {
                            rRenderer[i].material.shader = Shader.Find(shader);
                        }
                        break;

                    case false:
                        Renderer render = obj.GetComponent<Renderer>();

                        render.material.shader = Shader.Find(shader);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectShader: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectShaderMultiMat(string obj, string shader)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Renderer rRenderer = gObject.GetComponent<Renderer>();

                Material[] mMaterials = rRenderer.materials;

                for (int i = 0; i < mMaterials.Length; i++)
                {
                    mMaterials[i].shader = Shader.Find(shader);
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectShaderMultiMat: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectShaderMultiMat(GameObject obj, string shader)
        {
            try
            {
                Renderer rRenderer = obj.GetComponent<Renderer>();

                Material[] mMaterials = rRenderer.materials;

                for (int i = 0; i < mMaterials.Length; i++)
                {
                    mMaterials[i].shader = Shader.Find(shader);
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectShaderMultiMat: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void setObjectShaderMultiMatIndex(string obj, int index, string shader)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Renderer render = gObject.GetComponent<Renderer>();

                Material[] materials = render.materials;

                materials[index].shader = Shader.Find(shader);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - setObjectShaderMultiMatIndex: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void setObjectShaderMultiMatIndex(GameObject obj, int index, string shader)
        {
            try
            {
                Renderer render = obj.GetComponent<Renderer>();

                Material[] materials = render.materials;

                materials[index].shader = Shader.Find(shader);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - setObjectShaderMultiMatIndex: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void setStandardShaderProperties(string obj, string keyword)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Material material = gObject.GetComponent<Renderer>().material;

                StringBuilder stringBuilder = new StringBuilder();
                
                string modKeyword = stringBuilder.Append("_").Append(keyword.ToUpper()).ToString();

                material.EnableKeyword(modKeyword);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - setStandardShaderProperties: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void setStandardShaderProperties(GameObject obj, string keyword)
        {
            try
            {
                Material material = obj.GetComponent<Renderer>().material;

                StringBuilder stringBuilder = new StringBuilder();

                string modKeyword = stringBuilder.Append("_").Append(keyword.ToUpper()).ToString();

                material.EnableKeyword(modKeyword);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - setStandardShaderProperties: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectAlpha(string obj, bool children, float alpha)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (children)
                {
                    case true:
                        Renderer[] renderer = gObject.GetComponentsInChildren<Renderer>();

                        for (int i = 0; i < renderer.Length; i++)
                        {
                            renderer[i].material.SetColor("_Color", new Color(renderer[i].material.color.r,
                                                                              renderer[i].material.color.g,
                                                                              renderer[i].material.color.b,
                                                                              alpha));
                        }
                        break;

                    case false:
                        Renderer rRenderer = gObject.GetComponent<Renderer>();

                        rRenderer.material.SetColor("_Color", new Color(rRenderer.material.color.r,
                                                                        rRenderer.material.color.g,
                                                                        rRenderer.material.color.b,
                                                                        alpha));
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectAlpha: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectAlpha(GameObject obj, bool children, float alpha)
        {
            try
            {
                switch (children)
                {
                    case true:
                        Renderer[] renderer = obj.GetComponentsInChildren<Renderer>();

                        for (int i = 0; i < renderer.Length; i++)
                        {
                            renderer[i].material.SetColor("_Color", new Color(renderer[i].material.color.r,
                                                                              renderer[i].material.color.g,
                                                                              renderer[i].material.color.b,
                                                                              alpha));
                        }
                        break;

                    case false:
                        Renderer rRenderer = obj.GetComponent<Renderer>();

                        rRenderer.material.SetColor("_Color", new Color(rRenderer.material.color.r,
                                                                        rRenderer.material.color.g,
                                                                        rRenderer.material.color.b,
                                                                        alpha));
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectAlpha: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AnimateObjectAlpha(string obj, bool children, bool reverse, float time)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (reverse)
                {
                    case true:
                        switch (children)
                        {
                            case true:
                                Renderer[] renderer = gObject.GetComponentsInChildren<Renderer>();

                                for (int i = 0; i < renderer.Length; i++)
                                {
                                    LeanTween.alpha(renderer[i].gameObject, 1.0f, time);
                                }
                                break;

                            case false:
                                LeanTween.alpha(gObject, 0.0f, time);
                                break;
                        }
                        break;
                        
                    case false:
                         switch (children)
                        {
                            case true:
                                Renderer[] renderer = gObject.GetComponentsInChildren<Renderer>();

                                for (int i = 0; i < renderer.Length; i++)
                                {
                                    LeanTween.alpha(renderer[i].gameObject, 0.0f, time);
                                }
                                break;

                            case false:
                                LeanTween.alpha(gObject, 1.0f, time);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - AnimateObjectAlpha: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AnimateObjectAlpha(GameObject obj, bool children, bool reverse, float time)
        {
            try
            {
                switch (reverse)
                {
                    case true:
                        switch (children)
                        {
                            case true:
                                Renderer[] renderer = obj.GetComponentsInChildren<Renderer>();

                                for (int i = 0; i < renderer.Length; i++)
                                {
                                    LeanTween.alpha(renderer[i].gameObject, 1.0f, time);
                                }
                                break;

                            case false:
                                LeanTween.alpha(obj, 0.0f, time);
                                break;
                        }
                        break;

                    case false:
                        switch (children)
                        {
                            case true:
                                Renderer[] renderer = obj.GetComponentsInChildren<Renderer>();

                                for (int i = 0; i < renderer.Length; i++)
                                {
                                    LeanTween.alpha(renderer[i].gameObject, 0.0f, time);
                                }
                                break;

                            case false:
                                LeanTween.alpha(obj, 1.0f, time);
                                break;
                        }
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - AnimateObjectAlpha: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectColor(string obj, bool children, Color color)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                switch (children)
                {
                    case true:
                        Renderer[] renderer = gObject.GetComponentsInChildren<Renderer>();

                        for (int i = 0; i < renderer.Length; i++)
                        {
                            renderer[i].material.SetColor("_Color", color);
                        }
                        break;

                    case false:
                        Renderer rRenderer = gObject.GetComponent<Renderer>();

                        rRenderer.material.SetColor("_Color", color);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectColor: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectColor(GameObject obj, bool children, Color color)
        {
            try
            {
                switch (children)
                {
                    case true:
                        Renderer[] renderer = obj.GetComponentsInChildren<Renderer>();

                        foreach (Renderer component in renderer)
                        {
                            component.material.SetColor("_Color", color);
                        }
                        break;

                    case false:
                        Renderer rRenderer = obj.GetComponent<Renderer>();

                        rRenderer.material.SetColor("_Color", color);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectColor: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectColorRGB(string obj, string property, float red, float green, float blue)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                float r = (float)Math.Round((Decimal)red / 256, 2);
                float g = (float)Math.Round((Decimal)green / 256, 2);
                float b = (float)Math.Round((Decimal)blue / 256, 2);

                gObject.GetComponent<Renderer>().material.SetColor(property, new Color(r, g, b));
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectColorRGB: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectColorRGB(GameObject obj, string property, float red, float green, float blue)
        {
            try
            {
                float r = (float)Math.Round((Decimal)red / 256, 2);
                float g = (float)Math.Round((Decimal)green / 256, 2);
                float b = (float)Math.Round((Decimal)blue / 256, 2);

                obj.GetComponent<Renderer>().material.SetColor(property, new Color(r, g, b));
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectColorRGB: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectColorRGB(string obj, int materialElement, string property, float red, float green, float blue)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                float r = (float)Math.Round((Decimal)red / 256, 2);
                float g = (float)Math.Round((Decimal)green / 256, 2);
                float b = (float)Math.Round((Decimal)blue / 256, 2);

                gObject.GetComponent<Renderer>().materials[materialElement].SetColor(property, new Color(r, g, b));
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectColorRGB: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectColorRGB(GameObject obj, int materialElement, string property, float red, float green, float blue)
        {
            try
            {
                float r = (float)Math.Round((Decimal)red / 256, 2);
                float g = (float)Math.Round((Decimal)green / 256, 2);
                float b = (float)Math.Round((Decimal)blue / 256, 2);

                obj.GetComponent<Renderer>().materials[materialElement].SetColor(property, new Color(r, g, b));
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectColorRGB: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectColorHEX(string obj, string property, string hexValue)
        {
            try
            {
                GameObject gObject = GameObject.Find(obj);

                hexValue = hexValue.Replace("0x", "");
                hexValue = hexValue.Replace("#", "");

                byte red = byte.Parse(hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                byte green = byte.Parse(hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                byte blue = byte.Parse(hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

                float r = (float)Math.Round((float)red / 256, 2);
                float g = (float)Math.Round((float)green / 256, 2);
                float b = (float)Math.Round((float)blue / 256, 2);

                gObject.GetComponent<Renderer>().material.SetColor(property, new Color(r, g, b));
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectColorHEX: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectColorHEX(GameObject obj, string property, string hexValue)
        {
            try
            {
                hexValue = hexValue.Replace("0x", "");
                hexValue = hexValue.Replace("#", "");

                byte red = byte.Parse(hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                byte green = byte.Parse(hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                byte blue = byte.Parse(hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

                float r = (float)Math.Round((float)red / 256, 2);
                float g = (float)Math.Round((float)green / 256, 2);
                float b = (float)Math.Round((float)blue / 256, 2);

                obj.GetComponent<Renderer>().material.SetColor(property, new Color(r, g, b));
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectColorHEX: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectColorHEX(string obj, int materialElement, string property, string hexValue)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                hexValue = hexValue.Replace("0x", "");
                hexValue = hexValue.Replace("#", "");

                byte red = byte.Parse(hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                byte green = byte.Parse(hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                byte blue = byte.Parse(hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

                float r = (float)Math.Round((float)red / 256, 2);
                float g = (float)Math.Round((float)green / 256, 2);
                float b = (float)Math.Round((float)blue / 256, 2);

                gObject.GetComponent<Renderer>().materials[materialElement].SetColor(property, new Color(r, g, b));
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectColorHEX: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectColorHEX(GameObject obj, int materialElement, string property, string hexValue)
        {
            try
            {
                hexValue = hexValue.Replace("0x", "");
                hexValue = hexValue.Replace("#", "");

                byte red = byte.Parse(hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                byte green = byte.Parse(hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                byte blue = byte.Parse(hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

                float r = (float)Math.Round((float)red / 256, 2);
                float g = (float)Math.Round((float)green / 256, 2);
                float b = (float)Math.Round((float)blue / 256, 2);

                obj.GetComponent<Renderer>().materials[materialElement].SetColor(property, new Color(r, g, b));
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectColorHEX: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void TweenObjectColor(string obj, Color color, float time)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                LeanTween.color(gObject, color, time);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - TweenObjectColor: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void TweenObjectColor(GameObject obj, Color color, float time)
        {
            try
            {
                LeanTween.color(obj, color, time);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - TweenObjectColor: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectTexture(string obj, Texture texture)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Renderer rRenderer = gObject.GetComponent<Renderer>();

                rRenderer.material.SetTexture("_MainTex", texture);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectTexture: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectTexture(string obj, string property, Texture texture)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Renderer rRenderer = gObject.GetComponent<Renderer>();

                rRenderer.material.SetTexture(property, texture);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectTexture: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetObjectTexture(GameObject obj, string property, Texture texture)
        {
            try
            {
                Renderer rRenderer = obj.GetComponent<Renderer>();

                rRenderer.material.SetTexture(property, texture);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("MaterialUtils - SetObjectTexture: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }
    }
}
