using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;


public class Mainbuttun : MonoBehaviour
{
    public GameObject Fade;
    public Animator Fadeint;

    public Slider[] MUSIC;
    public GameObject optton1;

    public void PLAY()
    {

        PlayerData playdtatastatus = new PlayerData();
        playdtatastatus.ATK = 5;
        playdtatastatus.DEF = 5;
        playdtatastatus.HP = 10;
        playdtatastatus.MAG = 5;
        playdtatastatus.MAGDEF = 5;
        playdtatastatus.COST = 4;
        playdtatastatus.LevelMonster = 1;

        string json = JsonUtility.ToJson(playdtatastatus);
        File.WriteAllText(Application.dataPath + "/code" + "/PlayerStatus.json", json);

        Fade.SetActive(true);
        Fadeint = Fade.GetComponent<Animator>();
        Fadeint.SetBool("Fade", true);


    }

    public void Load()
    {
        Fade.SetActive(true);
        Fadeint = Fade.GetComponent<Animator>();
        Fadeint.SetBool("Fade", true);
    }

    public void Optionopen()
    {
        optton1.SetActive(true);
    }


    public void Optionclose()
    {
        optton1.SetActive(false);
        
    }

    public void Reset()
    {
        MUSIC[0].value = 1;
        MUSIC[1].value = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Update()
    {

    }

    private class PlayerData
    {
        public float ATK = 1;
        public float DEF = 1;
        public float MAG = 1;
        public float MAGDEF = 1;
        public double HP = 1;
        public float COST = 1;
        public int LevelMonster = 1;

    }
}


