using UnityEngine;
using System;
using System.IO;
using System.Collections;
using RenderHeads.Media.AVProVideo;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AEP_Utilities
{
    public static class AudioVideoUtils
    {
        public static void PlayAudioSource(string obj, bool play)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                AudioSource asSource = gObject.GetComponent<AudioSource>();

                switch (play)
                {
                    case true:
                        asSource.Play();
                        break;

                    case false:
                        asSource.Stop();
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - PlayAudioSource: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void PlayAudioSource(GameObject obj, bool play)
        {
            try
            {
                AudioSource asSource = obj.GetComponent<AudioSource>();

                switch (play)
                {
                    case true:
                        asSource.Play();
                        break;

                    case false:
                        asSource.Stop();
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - PlayAudioSource: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetAudioSourceClip(string obj, AudioClip clip)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                AudioSource asSource = gObject.GetComponent<AudioSource>();

                asSource.clip = clip;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetAudioSourceClip: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetAudioSourceClip(GameObject obj, AudioClip clip)
        {
            try
            {
                AudioSource asSource = obj.GetComponent<AudioSource>();

                asSource.clip = clip;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetAudioSourceClip: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMovieTextureProperties(string obj, string prop, bool propSet)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                MediaPlayer mPlayer = gObject.GetComponent<MediaPlayer>();

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
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMovieTextureProperties: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMovieTextureProperties(GameObject obj, string prop, bool propSet)
        {
            try
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
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMovieTextureProperties: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMovieTextureState(string obj, string state)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                MediaPlayer mPlayer = gObject.GetComponent<MediaPlayer>();

                switch (state)
                {
                    case "Play":
                        mPlayer.Play();
                        break;

                    case "Stop":
                        mPlayer.Stop();
                        Debug.Log("Movie has stopped playing");
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
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMovieTextureState: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMovieTextureState(GameObject obj, string state)
        {
            try
            {
                MediaPlayer mPlayer = obj.GetComponent<MediaPlayer>();

                switch (state)
                {
                    case "Play":
                        mPlayer.Play();
                        break;

                    case "Stop":
                        mPlayer.Stop();
                        Debug.Log("Movie has stopped playing");
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
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMovieTextureState: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static MediaPlayer.FileLocation GetMoviePlayerLocation(string obj)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                MediaPlayer mPlayer = gObject.GetComponent<MediaPlayer>();

                return mPlayer.m_VideoLocation;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMovieTextureState: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");

                return MediaPlayer.FileLocation.AbsolutePathOrURL;
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static MediaPlayer.FileLocation GetMoviePlayerLocation(GameObject obj)
        {
            try
            {
                MediaPlayer mPlayer = obj.GetComponent<MediaPlayer>();

                return mPlayer.m_VideoLocation;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - GetMoviePlayerLocation: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");

                return MediaPlayer.FileLocation.AbsolutePathOrURL;
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMovieTexture(string obj, string movieFile, bool autoPlay)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                MediaPlayer mPlayer = gObject.GetComponent<MediaPlayer>();

                mPlayer.m_VideoPath = movieFile;

                mPlayer.OpenVideoFromFile(GetMoviePlayerLocation(obj), mPlayer.m_VideoPath, autoPlay);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMovietexture: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMovieTexture(GameObject obj, string movieFile, bool autoPlay)
        {
            try
            {
                MediaPlayer mPlayer = obj.GetComponent<MediaPlayer>();

                mPlayer.m_VideoPath = movieFile;

                mPlayer.OpenVideoFromFile(GetMoviePlayerLocation(obj), mPlayer.m_VideoPath, autoPlay);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMovietexture: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMoviePath(string obj, string path)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                MediaPlayer mPlayer = gObject.GetComponent<MediaPlayer>();

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
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMoviePath: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMoviePath(GameObject obj, string path)
        {
            try
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
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMoviePath: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMoviePlayerMesh(string obj, string mesh)
        {
            GameObject gObject = GameObject.Find(obj);

            try
            {
                ApplyToMesh  atmMesh= gObject.GetComponent<ApplyToMesh>();

                atmMesh._mesh = GameObject.Find(mesh).GetComponent<Renderer>();
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMoviePath: " + obj + " or " + mesh + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMoviePlayerMesh(GameObject obj, GameObject mesh)
        {
            try
            {
                ApplyToMesh atmMesh = obj.GetComponent<ApplyToMesh>();

                atmMesh._mesh = mesh.GetComponent<Renderer>();
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMoviePath: " + obj.name + " or " + mesh.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMovieFilePath(string obj, string path)
        {
            GameObject gObj = GameObject.Find(obj);

            try
            {
                MediaPlayer mediaPlayer = gObj.GetComponent<MediaPlayer>();

                mediaPlayer.m_VideoPath = path;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMovieFilePath: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void SetMovieFilePath(GameObject obj, string path)
        {
            try
            {
                MediaPlayer mediaPlayer = obj.GetComponent<MediaPlayer>();

                mediaPlayer.m_VideoPath = path;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - SetMovieFilePath: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void openVideoFromFile(string obj, MediaPlayer.FileLocation location, string path, bool open)
        {
            GameObject gObj = GameObject.Find(obj);

            try
            {
                MediaPlayer mediaPlayer = gObj.GetComponent<MediaPlayer>();

                switch (open)
                {
                    case true:
                        mediaPlayer.OpenVideoFromFile(location, path);
                        break;

                    case false:
                        mediaPlayer.CloseVideo();
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - openVideoFromFile: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void openVideoFromFile(GameObject obj, MediaPlayer.FileLocation location, string path, bool open)
        {
            try
            {
                MediaPlayer mediaPlayer = obj.GetComponent<MediaPlayer>();

                switch (open)
                {
                    case true:
                        mediaPlayer.OpenVideoFromFile(location, path);
                        break;

                    case false:
                        mediaPlayer.CloseVideo();
                        break;
                }
            }
            catch (NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - openVideoFromFile: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void startVideoDownload(string obj, string fileName)
        {
            GameObject gObj = GameObject.Find(obj);

            try
            {
                FastDownloader fastDownloader = gObj.GetComponent<FastDownloader>();

                if (!File.Exists(Application.persistentDataPath + "/" + fileName))
                {
                    fastDownloader.DownloadFile();
                }
                else if (File.Exists(Application.persistentDataPath + "/" + fileName))
                {
                    return;
                }
            }
            catch(NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - startVideoDownload: " + obj + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void startVideoDownload(GameObject obj, string fileName)
        {
            try
            {
                FastDownloader fastDownloader = obj.GetComponent<FastDownloader>();

                if (!File.Exists(Application.persistentDataPath + "/" + fileName))
                {
                    fastDownloader.DownloadFile();
                }
                else if (File.Exists(Application.persistentDataPath + "/" + fileName))
                {
                    return;
                }
                
            }
            catch(NullReferenceException)
            {
                Debug.LogError("AudioVideoUtils - startVideoDownload: " + obj.name + " cannot be found!!! Check your spelling or if the object is in the scene.");
            }
        }
    }
}
