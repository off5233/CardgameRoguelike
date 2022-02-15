using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class Lose : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadFight()
    {
        SceneManager.LoadScene("FightonlyS");
    }

    public void Mainload()
    {
        SceneManager.LoadScene("Main");
    }
}
