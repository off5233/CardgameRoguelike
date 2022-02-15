using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class Optionsound : MonoBehaviour
{
    public Slider[] MUSIC;
    public float nusic,music2;
    // Update is called once per frame
    
    void Update()
    {
        MusicOnly.Bm = MUSIC[0].value;
        MusicOnly.Em = MUSIC[1].value;

    }
}
