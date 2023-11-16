using UnityEngine;
using System;
using System.IO;
using System.Collections;
using RenderHeads.Media.AVProVideo;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Utilities : MonoBehaviour
{
#region Animation Functions ------------------------------------------------------------------------------------
	public static void PlayAnimation(string obj, string anim, bool reverse, string wrapMode)
	{
		GameObject go = GameObject.Find(obj);

		if (go)
		{
			Animation animate = go.GetComponent<Animation>();

			if (reverse)
			{
				SetAnimationWrapMode(obj, wrapMode);
				animate[anim].time = animate[anim].length;
				animate[anim].speed = -1.0f;
				animate.Play(anim);
			}
			else if (!reverse)
			{
				SetAnimationWrapMode(obj, wrapMode);
				animate[anim].time = 0.0f;
				animate[anim].speed = 1.0f;
				animate.Play(anim);
			}

			Debug.Log("PlayAnimation: " + anim + " from " + go.name + " is playing.");
		}
		else if (!go)
		{
			Debug.LogError("PlayAnimation: Game Object field is empty!!!");
		}
	}

//------------------------------------------------------------------------------------
    public static void PlayAnimation(string obj, string anim, float speed, bool reverse, string wrapMode)
    {
        GameObject go = GameObject.Find(obj);

        if (go)
        {
            Animation animate = go.GetComponent<Animation>();

            if (reverse)
            {
                SetAnimationWrapMode(obj, wrapMode);
                animate[anim].time = animate[anim].length;
                animate[anim].speed = speed * -1.0f;
                animate.Play(anim);
            }
            else if (!reverse)
            {
                SetAnimationWrapMode(obj, wrapMode);
                animate[anim].time = 0.0f;
                animate[anim].speed = speed;
                animate.Play(anim);
            }

            Debug.Log("PlayAnimation: " + anim + " from " + go.name + " is playing.");
        }
        else if (!go)
        {
            Debug.LogError("PlayAnimation: Game Object field is empty!!!");
        }
    }

//------------------------------------------------------------------------------------
	public static void StopAnimation(string obj, string anim, string wrapMode)
	{
		GameObject go = GameObject.Find(obj);

		if (go)
		{
			Animation animate = go.GetComponent<Animation>();

			animate.Stop(anim);
			SetAnimationWrapMode(obj, wrapMode);

			Debug.Log("StopAnimation: " + anim + " from " + go.name + " has been stopped.");
		}
		else if (!go)
		{
			Debug.LogError("StopAnimation: Game Object field is empty!!!");
		}
	}

//------------------------------------------------------------------------------------
	public static void RewindAnimation(string obj, string anim, string wrapMode)
	{
		GameObject go = GameObject.Find(obj);
        /*
		if (go)
		{
			Animation animate = go.GetComponent<Animation>();

			SetAnimationWrapMode(obj, wrapMode);
			animate.Stop(anim);
			animate.Rewind(anim);
            animate[anim].speed = -1.0f;
            animate.Play(anim);

			Debug.Log("RewindAnimation: " + anim + " from " + go.name + " has been reset.");
		}
		else if (!go)
		{
			Debug.LogError("RewindAnimation; Game Object field is empty!!!");
		}
        */

        try
        {
            Animation animate = go.GetComponent<Animation>();

            SetAnimationWrapMode(obj, wrapMode);
            animate.Stop(anim);
            animate.Rewind(anim);
            animate[anim].speed = -1.0f;
            animate.Play(anim);

            Debug.Log("RewindAnimation: " + anim + " from " + go.name + " has been reset.");
        }
        catch(NullReferenceException)
        {
            Debug.LogError("RewindAnimation: Game Object field is empty!!!");
        }
	}

//------------------------------------------------------------------------------------
	public static void SetAnimationWrapMode(string obj, string wrapMode)
	{
		GameObject go = GameObject.Find(obj);

		if (go)
		{
			Animation anim = go.GetComponent<Animation>();

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
	}

//------------------------------------------------------------------------------------
    public static void SetAnimatorBoolState(string objectName, string stateName, bool state)
    {
        Animator anim = GameObject.Find(objectName).GetComponent<Animator>();

        anim.SetBool(stateName, state);
    }

//------------------------------------------------------------------------------------
    public static void SetAnimatorBoolState(GameObject gObject, string stateName, bool state)
    {
        Animator anim = gObject.GetComponent<Animator>();

        anim.SetBool(stateName, state);
    }

//------------------------------------------------------------------------------------
    public static void SetAnimatorBoolState(Animator anim, string stateName, bool state)
    {
        anim.SetBool(stateName, state);
    }

//------------------------------------------------------------------------------------
    public static void SetAnimatorTriggerState(string objectName, string triggerName)
    {
        Animator anim = GameObject.Find(objectName).GetComponent<Animator>();

        anim.SetTrigger(triggerName);
    }

//------------------------------------------------------------------------------------
    public static void SetAnimatorTriggerState(GameObject gObject, string triggerName)
    {
        Animator anim = gObject.GetComponent<Animator>();

        anim.SetTrigger(triggerName);
    }

//------------------------------------------------------------------------------------
    public static void SetAnimatorTriggerState(Animator anim, string triggerName)
    {
        anim.SetTrigger(triggerName);
    }

//------------------------------------------------------------------------------------
    public static void ResetAnimatorTriggerState(string objectName, string triggerName)
    {
        Animator anim = GameObject.Find(objectName).GetComponent<Animator>();

        anim.ResetTrigger(triggerName);
    }

//------------------------------------------------------------------------------------
    public static void ResetAnimatorTriggerState(GameObject gObject, string triggerName)
    {
        Animator anim = gObject.GetComponent<Animator>();

        anim.ResetTrigger(triggerName);
    }

//------------------------------------------------------------------------------------
    public static void ResetAnimatorTriggerState(Animator anim, string triggerName)
    {
        anim.ResetTrigger(triggerName);
    }
#endregion
    
#region Render and Collider Functions ------------------------------------------------------------------------------------
	public static void ShowObject(string obj, bool children, bool show)
	{
		GameObject go = GameObject.Find(obj);

		if (go)
		{
			switch (children)
			{
				case true:
					Renderer[] render = go.GetComponentsInChildren<Renderer>();

					foreach (Renderer ren in render)
					{
                        ren.enabled = show;
					}

					Debug.Log("ShowObject: Child are being shown/hidden from object " + go.name + ".");
					break;

				case false:
					Renderer component = go.GetComponent<Renderer>();

					component.enabled = show;

					Debug.Log("ShowObject: " + go.name + " is being shown/hidden.");
					break;
			}
		}
		else if (!go)
		{
			Debug.LogError("ShowObject: Game Object field is empty!!!");
		}
	}

//------------------------------------------------------------------------------------
	public static void EnableCollider(string obj, bool children, bool enable)
	{
		GameObject go = GameObject.Find(obj);

		if (go)
		{
			switch (children)
			{
				case true:
                    Collider[] collide = go.GetComponentsInChildren<Collider>();

					foreach (Collider col in collide)
					{
                        col.enabled = enable;
					}
					Debug.Log("EnableCollider: Child colliders are being enabled/disabled from object " + go.name + ".");
					break;

				case false:
					Collider component = go.GetComponent<Collider>();

					component.enabled = enable;

					Debug.Log("EnableCollider: " + go.name + "'s collider is being enabled/disabled.");
					break;
			}
		}
		else if (!go)
		{
			Debug.LogError("EnableCollider: Game Object field is empty!!!");
		}
	}

//------------------------------------------------------------------------------------
	public static void EnableObject(string obj, bool children, bool enable)
	{
		ShowObject(obj, children, enable);
		EnableCollider(obj, children, enable);
	}
#endregion

#region Position, Rotation, and Scale ------------------------------------------------------------------------------------
	public static void SetObjectPosition(string obj, bool isLocal, Vector3 position)
	{
		GameObject go = GameObject.Find(obj);

		switch (isLocal)
		{
			case true:
				go.transform.localPosition = position;
				break;

			case false:
				go.transform.position = position;
				break; 
		}
	}

//------------------------------------------------------------------------------------
	public static void SetObjectRotation(string obj, bool isLocal, Vector3 rotation)
	{
		GameObject go = GameObject.Find(obj);

		switch (isLocal)
		{
		case true:
			go.transform.localRotation = Quaternion.Euler(rotation);
			break;

		case false:
			go.transform.rotation = Quaternion.Euler(rotation);
			break;
		}
	}

//------------------------------------------------------------------------------------
	public static void SetObjectScale(string obj, Vector3 scale)
	{
		GameObject go = GameObject.Find(obj);

		go.transform.localScale = scale;
	}

//------------------------------------------------------------------------------------
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
            Debug.LogError("Utilities - Rotate Around Axis: Cannot find " + go + "! Make sure " + go + " is in the scene or the spelling is correct.");
        }
    }
#endregion

#region Parenting ------------------------------------------------------------------------------------
	public static void SetObjectParent(string target, string parent)
	{
		GameObject go = GameObject.Find(target);

		GameObject pObj = GameObject.Find(parent);

		go.transform.SetParent(pObj.transform);
	}
#endregion

#region Particles ------------------------------------------------------------------------------------
	public static void PlayParticles(string particles, bool play)
	{
		ParticleSystem ps_Particls = GameObject.Find(particles).GetComponent<ParticleSystem>();

		switch (play)
		{
			case true:	
				ps_Particls.Play();

				Debug.Log("Particle System " + particles + " is playing.");
				break;

			case false:
				ps_Particls.Stop();
				Debug.Log("Particle System " + particles + " has stopped.");
				break;
		}
	}
#endregion

#region Color, Materials, Shaders ------------------------------------------------------------------------------------
	public static void SetObjectShader(string obj, bool children, string shader)
	{
		GameObject go = GameObject.Find(obj);

		switch (children)
		{
			case true:
				Renderer[] render = go.GetComponentsInChildren<Renderer>();

				foreach (Renderer component in render)
				{
					component.material.shader = Shader.Find(shader);
				}
				break;

			case false:
				Renderer oRender = go.GetComponent<Renderer>();

                oRender.material.shader = Shader.Find(shader);	
				break;
		}
	}

//------------------------------------------------------------------------------------
	public static void SetObjectShader(GameObject obj, bool children, string shader)
	{
		switch (children)
		{
			case true:
				Renderer[] render = obj.GetComponentsInChildren<Renderer>();

				foreach (Renderer component in render)
				{
					component.material.shader = Shader.Find(shader);
				}
				break;

			case false:
				Renderer oRender = obj.GetComponent<Renderer>();

                oRender.material.shader = Shader.Find(shader);
				break;
		}
	}

//------------------------------------------------------------------------------------
    public static void SetObjectShaderMultiMat(string obj, string shader)
    {
        GameObject go = GameObject.Find(obj);

        if (go != null)
        {
            Renderer render = go.GetComponent<Renderer>();
            Material[] material = render.materials;

            foreach (Material mat in material)
            {
                mat.shader = Shader.Find(shader);
            }
        }
    }

//------------------------------------------------------------------------------------
	public static void SetObjectAlpha(string obj, bool children, float alpha)
	{
		GameObject go = GameObject.Find(obj);

		switch (children)
		{
		case true:
			Renderer[] render = go.GetComponentsInChildren<Renderer>();

			foreach (Renderer component in render)
			{
				component.material.SetColor("_Color", new Color(component.material.color.r,
				                                                component.material.color.g,
				                                                component.material.color.b,
				                                                alpha));
			}
			break;

		case false:
			Renderer oRender = go.GetComponent<Renderer>();

			oRender.material.SetColor("_Color", new Color(oRender.material.color.r,
			                                                oRender.material.color.g,
			                                                oRender.material.color.b,
			                                                alpha));
			break;
		}
	}

//------------------------------------------------------------------------------------
    /*
	public static IEnumerator eAnimateObjectAlpha(string obj, float time, bool children, bool reverse, string shader)
	{
		GameObject go = GameObject.Find(obj);

		if (go)
		{
			if (!reverse)
			{
				if (!children)
				{
					Renderer render = go.GetComponent<Renderer>();

					SetObjectShader(obj, children, shader);

					while (render.material.color.a > 0)
					{
						render.material.SetColor("Color", new Color(render.material.color.r,
						                                             render.material.color.g,
						                                             render.material.color.b,
						                                             render.material.color.a - (Time.deltaTime * time)));

						yield return null;
					}
				}
				else if (children)
				{
					Renderer[] render = go.GetComponentsInChildren<Renderer>();

					SetObjectShader(obj, children, shader);

					foreach(Renderer component in render)
					{
						while (component.material.color.a > 0)
						{
							component.material.SetColor("Color", new Color(component.material.color.r,
							                                                component.material.color.g,
							                                                component.material.color.b,
							                                             	component.material.color.a - (Time.deltaTime * time)));
							
							yield return null;
						}
					}
				}
			}
			else if (reverse)
			{
				if (!children)
				{
					Renderer render = go.GetComponent<Renderer>();

					while (render.material.color.a < 1)
					{
						render.material.SetColor("Color", new Color(render.material.color.r,
						                                             render.material.color.g,
						                                             render.material.color.b,
						                                             render.material.color.a + (Time.deltaTime * time)));

						yield return null;
					}

					SetObjectShader(obj, children, shader);
				}
				else if (children)
				{
					Renderer[] render = go.GetComponentsInChildren<Renderer>();

					foreach(Renderer component in render)
					{
						while (component.material.color.a < 1)
						{
							component.material.SetColor("Color", new Color(component.material.color.r,
							                                                component.material.color.g,
							                                                component.material.color.b,
							                                                component.material.color.a + (Time.deltaTime * time)));
							
							yield return null;
						}
					}

					SetObjectShader(obj, children, shader);
				}
			}
		}
	}
    */
//------------------------------------------------------------------------------------
	public void AnimateObjectAlpha(string obj, float time, bool children, bool reverse, string shader)
	{
		StartCoroutine(eAnimateObjectAlpha(obj, time, children, reverse, shader));
	}

//------------------------------------------------------------------------------------\
    public static IEnumerator eAnimateObjectAlpha(string obj, float time, bool children, bool reverse, string shader)
    {
        GameObject go = GameObject.Find(obj);

        if (go)
        {
            if (!reverse)
            {
                if (children)
                {
                    Renderer[] render = go.GetComponentsInChildren<Renderer>();

                    SetObjectShader(obj, children, shader);

                    foreach (Renderer component in render)
                    {
                        LeanTween.alpha(component.gameObject, 0.0f, time);
                    }
                }
                else if (!children)
                {
                    SetObjectShader(obj, children, shader);

                    LeanTween.alpha(go, 0.0f, time);

                    yield return new WaitForSeconds(time);
                }
            }
            else if (reverse)
            {
                if (children)
                {
                    Renderer[] render = go.GetComponentsInChildren<Renderer>();

                    foreach (Renderer component in render)
                    {
                        LeanTween.alpha(component.gameObject, 1.0f, time);
                    }

                    yield return new WaitForSeconds(time);

                    SetObjectShader(obj, children, shader);
                }
                else if (!children)
                {
                    LeanTween.alpha(go, 1.0f, time);

                    yield return new WaitForSeconds(time);

                    SetObjectShader(obj, children, shader);
                }
            }
        }
        else if (!go)
        {
            Debug.LogWarning("Utilities - AnimateObjectAlpha: Cannot find " + go + "!");
        }
    }

//------------------------------------------------------------------------------------
    public static void SetObjectColor(string obj, bool children, Color color)
    {
        GameObject go = GameObject.Find(obj);

        if (children)
        {
            Renderer[] render = go.GetComponentsInChildren<Renderer>();

            foreach (Renderer component in render)
            {
                component.material.SetColor("_Color", color);
            }
        }
        else if (!children)
        {
            Renderer oRender = go.GetComponent<Renderer>();

            oRender.material.SetColor("_Color", color);
        }
    }

//------------------------------------------------------------------------------------
    public static void SetObjectColorRGB(string obj, string property, float red, float green, float blue)
    {
        GameObject go = GameObject.Find(obj);

        float r = (float)Math.Round((Decimal)red / 256, 2);
        float g = (float)Math.Round((Decimal)green / 256, 2);
        float b = (float)Math.Round((Decimal)blue / 256, 2);

        go.GetComponent<Renderer>().material.SetColor(property, new Color(r, g, b));
    }

//------------------------------------------------------------------------------------
    public static void SetObjectColorRGB(string obj, int materialElement, string property, float red, float green, float blue)
    {
        GameObject go = GameObject.Find(obj);

        float r = (float)Math.Round((Decimal)red / 256, 2);
        float g = (float)Math.Round((Decimal)green / 256, 2);
        float b = (float)Math.Round((Decimal)blue / 256, 2);

        go.GetComponent<Renderer>().materials[materialElement].SetColor(property, new Color(r, g, b));
    }

//------------------------------------------------------------------------------------
    public static void SetObjectColorHEX(string obj, string property, string hexValue)
    {
        GameObject go = GameObject.Find(obj);

        hexValue = hexValue.Replace("0x", "");
        hexValue = hexValue.Replace("#", "");

        byte red = byte.Parse(hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte green = byte.Parse(hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte blue = byte.Parse(hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        float r = (float)Math.Round((float)red / 256, 2);
        float g = (float)Math.Round((float)green / 256, 2);
        float b = (float)Math.Round((float)blue / 256, 2);

        go.GetComponent<Renderer>().material.SetColor(property, new Color(r, g, b));
    }

//------------------------------------------------------------------------------------
    public static void SetObjectColorHEX(string obj, int materialElement, string property, string hexValue)
    {
        GameObject go = GameObject.Find(obj);

        hexValue = hexValue.Replace("0x", "");
        hexValue = hexValue.Replace("#", "");

        byte red = byte.Parse(hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte green = byte.Parse(hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte blue = byte.Parse(hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        float r = (float)Math.Round((float)red / 256, 2);
        float g = (float)Math.Round((float)green / 256, 2);
        float b = (float)Math.Round((float)blue / 256, 2);

        go.GetComponent<Renderer>().materials[materialElement].SetColor(property, new Color(r, g, b));
    }
#endregion

#region Textures ------------------------------------------------------------------------------------
	public static void SetObjectTexture(string obj, Texture texture)
	{
		GameObject go = GameObject.Find(obj);

		Renderer render = go.GetComponent<Renderer>();

		render.material.SetTexture("_MainTex", texture);
	}

//------------------------------------------------------------------------------------
    public static void SetObjectTexture(string obj, string property, Texture texture)
    {
        GameObject go = GameObject.Find(obj);

        Renderer render = go.GetComponent<Renderer>();

        render.material.SetTexture(property, texture);
    }
#endregion

#region Sound ------------------------------------------------------------------------------------
	public static void PlayAudioSource(string obj, bool play)
	{
		GameObject go = GameObject.Find(obj);
        /*
		if (go.GetComponent<AudioSource>())
		{
			AudioSource audio = go.GetComponent<AudioSource>();

			switch (play)
			{
			case true:
				audio.Play();
				break;

			case false:
				audio.Stop();
				break;
			}
		}
		else if (!go.GetComponent<AudioSource>())
		{
			Debug.LogWarning("Utilities - PlayAudioSource: " + obj + " does not have an Audio Source component!!!");
		}
        */
        try
        {
            AudioSource audio = go.GetComponent<AudioSource>();

            switch (play)
            {
                case true:
                    audio.Play();
                    break;

                case false:
                    audio.Stop();
                    break;
            }
        }
        catch(NullReferenceException)
        {
            Debug.LogWarning("Utilities - PlayAudioSource: " + obj + " does not have an Audio Source component!!!");
        }
	}

//------------------------------------------------------------------------------------
    public static void SetAudioSourceClip(string obj, AudioClip clip)
    {
        GameObject go = GameObject.Find(obj);
        /*
        if (go.GetComponent<AudioSource>())
        {
            AudioSource audio = go.GetComponent<AudioSource>();

            audio.clip = clip;
        }
        else if (!go.GetComponent<AudioSource>())
        {
            Debug.LogWarning("Utilities - SetAudioSourceClip: " + obj + " does not have an Audio Source component!!!");
        }
        */
        try
        {
            AudioSource audio = go.GetComponent<AudioSource>();

            audio.clip = clip;
        }
        catch(NullReferenceException)
        {
            Debug.LogWarning("Utilities - SetAudioSourceClip: " + obj + " does not have an Audio Source component!!!");
        }
    }
#endregion

#region Video ------------------------------------------------------------------------------------
    public static void SetMovieTextureProperties(GameObject obj, string prop, bool propSet)
    {
        MediaPlayer mPlayer = obj.GetComponent<MediaPlayer>();

        switch (prop)
        {
            case "Loop":
                mPlayer.m_Loop = propSet;
				Debug.Log("Loop = " + mPlayer.m_Loop.ToString());
                break;

            case "Auto-Start":
                mPlayer.m_AutoStart = propSet;
				Debug.Log("Auto-Start = " + mPlayer.m_AutoStart.ToString());
                break;

            case "Auto-Open":
                mPlayer.m_AutoOpen = propSet;
                break;

            case "Mute":
                mPlayer.m_Muted = propSet;
                break;
        }
    }

//------------------------------------------------------------------------------------
    public static void SetMovieTextureState(GameObject obj, string state)
    {
        MediaPlayer mPlayer = obj.GetComponent<MediaPlayer>();

        switch (state)
        {
            case "Play":
                mPlayer.Play();
                break;

            case "Stop":
                mPlayer.Stop();
				Debug.Log ("Movie has stopped playing");
                break;

            case "Rewind":
                mPlayer.Rewind(true);
                break;

            case "Rewind-Play":
                mPlayer.Rewind(false);
                break;

            case "Close":
                mPlayer.CloseVideo();
                break;
        }
    }

//------------------------------------------------------------------------------------
    public static void SetMovieTexture(GameObject obj, string movieFile)
    {
        MediaPlayer mPlayer = obj.GetComponent<MediaPlayer>();

        mPlayer.m_VideoPath = movieFile;

        mPlayer.OpenVideoFromFile(GetMovieFileLocation(obj), mPlayer.m_VideoPath, false);
    }

//------------------------------------------------------------------------------------
    public static void SetMoviePath(GameObject obj, string path)
    {
        MediaPlayer mPlayer = obj.GetComponent<MediaPlayer>();

        switch (path)
        {
            case "Stream":
                mPlayer.m_VideoLocation = MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder;
                break;

            case "Path-URL":
                mPlayer.m_VideoLocation = MediaPlayer.FileLocation.AbsolutePathOrURL;
                break;

            case "Project":
                mPlayer.m_VideoLocation = MediaPlayer.FileLocation.RelativeToProjectFolder;
                break;

            case "Data":
                mPlayer.m_VideoLocation = MediaPlayer.FileLocation.RelativeToDataFolder;
                break;

            case "Persistent":
                mPlayer.m_VideoLocation = MediaPlayer.FileLocation.RelativeToPeristentDataFolder;
                break;
        }
    }

//------------------------------------------------------------------------------------
    public static MediaPlayer.FileLocation GetMovieFileLocation(GameObject obj)
    {
        MediaPlayer mPlayer = obj.GetComponent<MediaPlayer>();

        return mPlayer.m_VideoLocation;
    }
#endregion

#region Prefab ------------------------------------------------------------------------------------
    public static void ApplyPrefab(string prefab)
    {
#if UNITY_EDITOR
        PrefabUtility.ReplacePrefab(GameObject.Find(prefab),
            PrefabUtility.GetPrefabParent(GameObject.Find(prefab)),
            ReplacePrefabOptions.ConnectToPrefab);
#endif
    }
    #endregion

#region File Moving ------------------------------------------------------------------------------------
    public static void MoveFile(string fileName)
    {
        FileInfo file = new FileInfo(Application.persistentDataPath);
    }
#endregion
}

public static class DelayMethods
{
    public static Coroutine DelayCall(this MonoBehaviour monoBehavior, Action action, float time)
    {
        return monoBehavior.StartCoroutine(WaitImpl(action, time));
    }

//------------------------------------------------------------------------------------
    public static IEnumerator WaitImpl(Action action, float time)
    {
        yield return new WaitForSeconds(time);

        action();
    }

//------------------------------------------------------------------------------------
    public static void CancelDelay(this MonoBehaviour monoBehavior, Coroutine coroutine)
    {
        monoBehavior.StopCoroutine(coroutine);
    }

//------------------------------------------------------------------------------------
    public static void CancelAllDelays(this MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StopAllCoroutines();
    }
}