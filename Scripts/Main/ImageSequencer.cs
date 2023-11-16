using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ImageSequencer : MonoBehaviour
{
    public bool loop = false;
    public bool debug = false;
    public bool play;

    public float waitTime;

    public enum TextureType
    {
        JPG,
        PNG,
        TGA
    };

    public string textureFolder = "";
    public TextureType textureType;
    public List<Texture2D> frames;
    public float framesPerSecond;
    public float startFrame;

    float index;
    Renderer thisRenderer;

#region Global Functions ------------------------------------------------------------------------------------
    void Start()
    {
        index = startFrame;
        thisRenderer = this.gameObject.GetComponent<Renderer>();
    }

//------------------------------------------------------------------------------------
    void Update()
    {
        if (play)
        {
            if (thisRenderer.enabled)
            {
                index += Time.deltaTime * framesPerSecond;
            }

            if (loop)
            {
                if (index > frames.Count)
                {
                    index = startFrame;
                }

                index = index % frames.Count;
            }

            if (index < frames.Count)
            {
                thisRenderer.material.mainTexture = frames[(int)index];

                if (debug)
                {
                    Debug.Log("Frame " + (int)index);
                }
            }

            if (index > frames.Count)
            {
                play = false;
                index = startFrame;
            }
        }
    }
    #endregion

#region Custom Functions ------------------------------------------------------------------------------------
    public void Restart()
    {
        index = 0;

        if (frames.Count != 0 )
        {
            thisRenderer.material.mainTexture = frames[0];
        }
    }

//------------------------------------------------------------------------------------
    public string GetTextureType()
    {
        string _textureType;

        switch (textureType)
        {
            case TextureType.JPG:
                _textureType = "jpg";
                break;

            case TextureType.PNG:
                _textureType = "png";
                break;

            case TextureType.TGA:
                _textureType = "tga";
                break;

            default:
                _textureType = "jpg";
                break;
        }

        Debug.Log(_textureType);

        return _textureType;
    }

    //------------------------------------------------------------------------------------
#if UNITY_EDITOR
    public void LoadImageSequence()
    {
        string _textureFolder = "Assets/" + textureFolder;

        if (UnityEditor.AssetDatabase.IsValidFolder(_textureFolder))
        {
            string[] _textureFiles = Directory.GetFiles(_textureFolder, "*." + GetTextureType(), SearchOption.AllDirectories);

            for (int i = 0; i < _textureFiles.Length; i++)
            {
                frames.Add((Texture2D)UnityEditor.AssetDatabase.LoadAssetAtPath(_textureFiles[i], typeof(Texture2D)));
            }
        }
        else if (!UnityEditor.AssetDatabase.IsValidFolder(_textureFolder))
        {
            Debug.LogError("Image Sequencer: Image sequence folder cannot be found!!!");
        }
    }


    //------------------------------------------------------------------------------------
    [ContextMenu("Load Image Sequence")]
    void Build()
    {
        LoadImageSequence();
    }
#endif
#endregion
}