using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class FadeOnly : MonoBehaviour
{
    public static bool Fadestart = false;
    public GameObject Fadeobj;

    public void LoadFightFADE()
    {
        Fadestart = false;
        SceneManager.LoadScene("FightonlyS");
    }

    public void Closeobj()
    {
        Fadeobj.SetActive(false);
    }

    public void NexWin()
    {
        SceneManager.LoadScene("WIN");
    }

    public void Alose()
    {
        SceneManager.LoadScene("Lose");
    }

}
