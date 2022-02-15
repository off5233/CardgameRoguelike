using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class CodeOption : MonoBehaviour, IPointerDownHandler
{
    public GameObject OPTIONFIGHT;

    public void OnPointerDown(PointerEventData eventData)
    {
        OPTIONFIGHT.SetActive(true);

    }

    public void CLOSE()
    {
        OPTIONFIGHT.SetActive(false);
    }

    public void main()
    {
        SceneManager.LoadScene("Main");
    }
}
