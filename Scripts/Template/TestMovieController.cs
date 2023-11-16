using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class TestMovieController : MonoBehaviour
{
    GameObject mTop;
    GameObject mBottom;

    void Start()
    {
        mTop = GameObject.Find("Top");
        mBottom = GameObject.Find("Bottom");

        Invoke("SetTexture", 2.0f);
    }
    
    void SetTexture()
    {
        Utilities.SetMovieTexture(mTop, "Fusion71_End.mp4");
        Utilities.SetMovieTexture(mBottom, "Fusion71_Beginning.mp4");

        Invoke("PlayMovies", 3.0f);
    }

    void PlayMovies()
    {
        Utilities.SetMovieTextureState(mTop, "Play");
        Utilities.SetMovieTextureState(mBottom, "Play");
        Debug.Log("Play!!!");
    }
}