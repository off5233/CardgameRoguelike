using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class Giftcick : MonoBehaviour, IPointerDownHandler
{
    public GameObject CardGift;

    public Text[] card;

    public string Textinfo;
    public int power;
    public string nameshow;
    public string typecardinfo;

    public float atks, mags, defmon, defmagmon, defplay, defmagplay, costtocardinput;
    public int lvm;
    public double hpmon, hpplayers;

    public void Start()
    {
        card[0].text = Textinfo;

        string json = File.ReadAllText(Application.dataPath + "/code" + "/PlayerStatus.json");
        PlayerData LoadPlayDATA = JsonUtility.FromJson<PlayerData>(json);

        atks = LoadPlayDATA.ATK;
        defplay = LoadPlayDATA.DEF;
        mags = LoadPlayDATA.MAG;
        defmagplay = LoadPlayDATA.MAGDEF;
        costtocardinput = LoadPlayDATA.COST;
        hpplayers = LoadPlayDATA.HP;
        lvm = LoadPlayDATA.LevelMonster;

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (typecardinfo == "gift")
        {

            PlayerData playdtatastatus = new PlayerData();

            if (nameshow == "Atk") { atks += power; }
            if (nameshow == "Def") { defplay += power; }
            if (nameshow == "MAG") { mags += power; }
            if (nameshow == "MAGDEF") { defmagplay += power; }
            if (nameshow == "HP") { hpplayers += power; }
            if (nameshow == "COST") { costtocardinput += power; }
            lvm += 1;

            playdtatastatus.ATK = atks;
            playdtatastatus.DEF = defplay;
            playdtatastatus.MAG = mags;
            playdtatastatus.MAGDEF = defmagplay;
            playdtatastatus.HP = hpplayers;
            playdtatastatus.COST = costtocardinput;
            playdtatastatus.LevelMonster = lvm;

            string json = JsonUtility.ToJson(playdtatastatus);
            File.WriteAllText(Application.dataPath + "/code" + "/PlayerStatus.json", json);
            SceneManager.LoadScene("FightonlyS");

        }


        if (typecardinfo == "highgift")
        {

            PlayerData playdtatastatus = new PlayerData();

            if (nameshow == "Atk") { atks += power; }
            if (nameshow == "Def") { defplay += power; }
            if (nameshow == "MAG") { mags += power; }
            if (nameshow == "MAGDEF") { defmagplay += power; }
            if (nameshow == "HP") { hpplayers += power; }
            if (nameshow == "COST") { costtocardinput += power; }
            lvm += 1;

            playdtatastatus.ATK = atks;
            playdtatastatus.DEF = defplay;
            playdtatastatus.MAG = mags;
            playdtatastatus.MAGDEF = defmagplay;
            playdtatastatus.HP = hpplayers;
            playdtatastatus.COST = costtocardinput;
            playdtatastatus.LevelMonster = lvm;

            string json = JsonUtility.ToJson(playdtatastatus);
            File.WriteAllText(Application.dataPath + "/code" + "/PlayerStatus.json", json);
            SceneManager.LoadScene("FightonlyS");

        }

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        CardGift.transform.position = new Vector3(transform.position.x, transform.position.y + 50); ;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CardGift.transform.position = new Vector3(transform.position.x, transform.position.y - 50); ;
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
