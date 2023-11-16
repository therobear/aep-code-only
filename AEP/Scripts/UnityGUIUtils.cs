using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using SVGImporter;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AEP_Utilities
{
    public static class UnityGUIUtils
    {
        public static void EnablePanel(string panelName, bool enable)
        {
            try 
            {
                CanvasGroup cgPanel = GameObject.Find(panelName).GetComponent<CanvasGroup>();

                switch (enable)
                {
                    case true:
                        cgPanel.alpha = 1;
                        cgPanel.interactable = true;
                        break;

                    case false:
                        cgPanel.alpha = 0;
                        cgPanel.interactable = false;
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnablePanel: " + panelName + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnablePanel(GameObject panelName, bool enable)
        {
            try
            {
                CanvasGroup cgPanel = panelName.GetComponent<CanvasGroup>();

                switch (enable)
                {
                    case true:
                        cgPanel.alpha = 1;
                        cgPanel.interactable = true;
                        break;

                    case false:
                        cgPanel.alpha = 0;
                        cgPanel.interactable = false;
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnablePanel: " + panelName.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetPanelAlpha(string panelName, float alpha)
        {
            try
            {
                CanvasGroup cgPanel = GameObject.Find(panelName).GetComponent<CanvasGroup>();

                cgPanel.alpha = alpha;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - SetPanelAlpha: " + panelName + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetPanelAlpha(GameObject panelName, float alpha)
        {
            try
            {
                CanvasGroup cgPanel = panelName.GetComponent<CanvasGroup>();

                cgPanel.alpha = alpha;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - SetPanelAlpha: " + panelName.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnablePanelInteractivity(string panelName, bool enable)
        {
            try
            {
                CanvasGroup cgPanel = GameObject.Find(panelName).GetComponent<CanvasGroup>();

                cgPanel.interactable = enable;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnablePanelInteractivity: " + panelName + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnablePanelInteractivity(GameObject panelName, bool enable)
        {
            try
            {
                CanvasGroup cgPanel = panelName.GetComponent<CanvasGroup>();

                cgPanel.interactable = enable;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnablePanelInteractivity: " + panelName.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnablePanelBlockRaytrace(string panelName, bool enable)
        {
            try
            {
                CanvasGroup cgPanel = GameObject.Find(panelName).GetComponent<CanvasGroup>();

                cgPanel.blocksRaycasts = enable;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnablePanelBlockRaytrace: " + panelName + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnablePanelBlockRaytrace(GameObject panelName, bool enable)
        {
            try
            {
                CanvasGroup cgPanel = panelName.GetComponent<CanvasGroup>();

                cgPanel.blocksRaycasts = enable;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnablePanelBlockRaytrace: " + panelName.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableImage(string obj, bool enable)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Image image = gObject.GetComponent<Image>();

                image.enabled = enable;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnableImage: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableImage(GameObject obj, bool enable)
        {
            try
            {
                Image image = obj.GetComponent<Image>();

                image.enabled = enable;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnableImage: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableSVGImage(string obj, bool enable)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                SVGImage svgImage = gObject.GetComponent<SVGImage>();

                svgImage.enabled = enable;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnableSVGImage: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableSVGImage(GameObject obj, bool enable)
        {
            try
            {
                SVGImage svgImage = obj.GetComponent<SVGImage>();

                svgImage.enabled = enable;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnableSVGImage: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableButton (string obj, bool enable)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Button button = gObject.GetComponent<Button>();

                button.interactable = enable;

                if (gObject.GetComponentInChildren<TextMeshProUGUI>())
                {
                    AEPButtonTextColor(obj);
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnableButton: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableButton(GameObject obj, bool enable)
        {
            try
            {
                Button button = obj.GetComponent<Button>();

                button.interactable = enable;

                if (obj.GetComponentInChildren<TextMeshProUGUI>())
                {
                    AEPButtonTextColor(obj);
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnableButton: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableImageButton(string button, bool enable)
        {
            GameObject gObject = GameObject.Find(button);

            try
            {
                if (gObject.GetComponent<Image>())
                {
                    EnableImage(gObject, enable);
                }
                else if (gObject.GetComponent<SVGImage>())
                {
                    EnableSVGImage(gObject, enable);
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnableImageButton: " + button + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void EnableImageButton(GameObject obj, bool enable)
        {
            try
            {
                if (obj.GetComponent<Image>())
                {
                    EnableImage(obj, enable);
                }
                else if (obj.GetComponent<SVGImage>())
                {
                    EnableSVGImage(obj, enable);
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnableImageButton: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static bool GetButtonState(string button)
        {
            GameObject gObject = GameObject.Find(button);

            try
            {
                Button btn = gObject.GetComponent<Button>();

                return btn.interactable;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnableImageButton: " + button + " cannot be found!!! Check your spelling or if the object is in the scene.");

                return false;
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static bool GetButtonState(GameObject button)
        {
            try
            {
                Button btn = button.GetComponent<Button>();

                return btn.interactable;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - EnableImageButton: " + button.name + " cannot be found!!! Check your spelling or if the object is in the scene.");

                return false;
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AEPButtonTextColor(string button)
        {
            try
            {
                TextMeshProUGUI tmpText = GameObject.Find(button).GetComponent<TextMeshProUGUI>();

                if (GetButtonState(button))
                {
                    tmpText.color = Color.white;
                }
                else if (@GetButtonState(button))
                {
                    tmpText.color = new Color(0.69f, 0.9f, 0.84f);
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - AEPButtonTextColor: " + button + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AEPButtonTextColor(GameObject button)
        {
            try
            {
                TextMeshProUGUI tmpText = button.GetComponent<TextMeshProUGUI>();

                if (GetButtonState(button))
                {
                    tmpText.color = Color.white;
                }
                else if (@GetButtonState(button))
                {
                    tmpText.color = new Color(0.69f, 0.9f, 0.84f);
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - AEPButtonTextColor: " + button.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetImageColor(string obj, Color color)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                Image image = gObject.GetComponent<Image>();

                image.color = color;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - SetImageColor: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetImageColor(GameObject obj, Color color)
        {
            try
            {
                Image image = obj.GetComponent<Image>();

                image.color = color;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - SetImageColor: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetSVGColor(string obj, Color color)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                SVGImage svgImage = gObject.GetComponent<SVGImage>();

                svgImage.color = color;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - SetSVGColor: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetSVGColor(GameObject obj, Color color)
        {
            try
            {
                SVGImage svgImage = obj.GetComponent<SVGImage>();

                svgImage.color = color;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - SetSVGColor: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void TweenScaleImage(string obj, float value, float time, LeanTweenType easeType, int repeat, float waitTime)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                RectTransform rtTransform = gObject.GetComponent<RectTransform>();

                LeanTween.scale(rtTransform, rtTransform.localScale * value, time).setEase(easeType).setRepeat(repeat).setDelay(waitTime);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - TweenScaleImage: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void TweenScaleImage(GameObject obj, float value, float time, LeanTweenType easeType, int repeat, float waitTime)
        {
            try
            {
                RectTransform rtTransform = obj.GetComponent<RectTransform>();

                LeanTween.scale(rtTransform, rtTransform.localScale * value, time).setEase(easeType).setRepeat(repeat).setDelay(waitTime);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("UnityGUIUtils - TweenScaleImage: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }
    }
}
