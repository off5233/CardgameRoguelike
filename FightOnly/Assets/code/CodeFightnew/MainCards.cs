using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class MainCards : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler
{
    public GameObject CardtoStatus, monsterobj, Texthpmon, cost;
    Text hpmontext;

    public GameObject Fade;
    Animator fadewhite;

    GameObject[] CardDestory;
    GameObject[] DeckCard;

    public Animator[] AnimatorMonster;

    public GameObject CardUse;
    public int Costs;
    public string Textinfo;
    public int power;
    public string nameshow;

    public Image CardMove;
    public Text infocard;
    public Text CostShow;
    public Text CostShow1;

    public string typecardinfo;
    public int typecardint;


    public float atks, mags, defmon, defmagmon, defplay, defmagplay;
    public int lvm;
    public float costtocardinput;
    public double hpmon, hpplayers;

    public void Atkplayer(float atk){  atks = atk;  }
    public void Magplayer(float mag) { mags = mag;  }
    public void defplayerinput(float atk)  { defplay = atk;  }
    public void demagfplayerinput(float mag) { defmagplay = mag; }
    public void lvmonstertoinput(int mag) {  lvm = mag; }
    public void monsterdef(float def) { defmon = def;  }
    public void monsterdefmag(float defmag) { defmagmon = defmag;}
    public void COSTPLAYER(float cost) {  costtocardinput = cost; }
    public void hpPLAYER(double hp)  {  hpplayers = hp; }



    public void hpmonster(double hp)
    {
        hpmon = hp;
        //Debug.Log("hpmon maninCard :" + hpmon);
    }

    boolEvent Animationmon = new boolEvent();
    public void animationmonlis(UnityAction<bool> lis)
    {
        Animationmon.AddListener(lis);
    }



    public void Start()
    {
       

        CardtoStatus = GameObject.Find("EventSystem");
        PlayerinputJson Statusplayer = CardtoStatus.GetComponent<PlayerinputJson>();

        monsterobj = GameObject.FindGameObjectWithTag("Monster");
        MainMonster Statusmon = monsterobj.GetComponent<MainMonster>();

        Statusplayer.atkeventlis(Atkplayer);
        Statusplayer.Mageventlis(Magplayer);
        Statusplayer.hpmax(hpPLAYER);
        //Statusplayer.COSTLIS(COSTPLAYER);

        Statusmon.DEFmonlis(monsterdef);
        Statusmon.MAGDEFkmonlis(monsterdefmag);
        Statusmon.hpmonlis(hpmonster);

        cost = GameObject.Find("COST");
        if(cost == null) { return; }

        Texthpmon = GameObject.Find("HPMON");
        if (Texthpmon == null) { return; }

        if (typecardinfo == "ATK") { typecardint = 1;  }
        if (typecardinfo == "MAG") { typecardint = 2; }
        if (typecardinfo == "HEAL") { typecardint = 3; }
        if (typecardinfo == "MAGHIGH") { typecardint = 4; }
        if (typecardinfo == "ATKHIGH") { typecardint = 5; }


    }

    public void OnPointerDown(PointerEventData eventData)
    {

     

        if (PlayerinputJson.costtocard - Costs >= 0)
        {
            PlayerinputJson.costtocard -= Costs;
            Debug.Log("PlayerinputJson.costtocard : " + PlayerinputJson.costtocard);

            cost.GetComponent<UnityEngine.UI.Text>().text = "COST : " + (PlayerinputJson.costtocard);
            int Random = UnityEngine.Random.Range(0, 10);



            if (typecardinfo == "ATK")
            {

                MUSIC1.PlaySoundEff("SwordDamage");
                MUSIC1.PlaySoundEff("monhunt");
                MainMonster.hpmmaxmon -= Math.Round((((atks * power) + Random)) / (defmon * 2));
                AnimationMonster.checkdamage = true;
                Texthpmon.GetComponent<UnityEngine.UI.Text>().text = "HP : " + MainMonster.hpmmaxmon;

            }

            if (typecardinfo == "MAG")
            {

                MUSIC1.PlaySoundEff("MagDamage");
                MUSIC1.PlaySoundEff("monhunt");
                MainMonster.hpmmaxmon -= Math.Round((((mags * power) + Random)) / (defmagmon * 2));
                AnimationMonster.checkdamage = true;
                Texthpmon.GetComponent<UnityEngine.UI.Text>().text = "HP : " + MainMonster.hpmmaxmon;

            }

            if (typecardinfo == "HEAL")
            {
                MUSIC1.PlaySoundEff("heal");
                MUSIC1.PlaySoundEff("ineedheal");
                AnimationALL.heal = true;
                PlayerinputJson.HPMAX += Math.Round((mags*power)/2);
                if(PlayerinputJson.HPMAX > hpplayers) { PlayerinputJson.HPMAX = hpplayers; }

            }

            if (typecardinfo == "MAGHIGH")
            {

                MUSIC1.PlaySoundEff("MagDamage");
                MUSIC1.PlaySoundEff("monhunt");
                MainMonster.hpmmaxmon -= Math.Round((((mags * power) + Random)));
                AnimationMonster.checkdamage = true;
                Texthpmon.GetComponent<UnityEngine.UI.Text>().text = "HP : " + MainMonster.hpmmaxmon;

            }


            if (typecardinfo == "ATKHIGH")
            {

                MUSIC1.PlaySoundEff("SwordDamage");
                MUSIC1.PlaySoundEff("monhunt");
                MainMonster.hpmmaxmon -= Math.Round((((atks * power) + Random)));
                AnimationMonster.checkdamage = true;
                Texthpmon.GetComponent<UnityEngine.UI.Text>().text = "HP : " + MainMonster.hpmmaxmon;

            }


            if (MainMonster.hpmmaxmon < 1)
            {
                MainMonster.hpmmaxmon = 0; 

            }
                    

            Destroy(CardUse);
            return;


        }


    }

    public void Update()
    {
        if (infocard == null) { return; };infocard.text = Textinfo;
        if (CostShow == null) { return; }; CostShow.text = Costs.ToString();
        if (CostShow1 == null) { return; }; CostShow1.text = Costs.ToString();

    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        CardMove.transform.position = new Vector3(transform.position.x, transform.position.y + 150); ;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CardMove.transform.position = new Vector3(transform.position.x, transform.position.y - 150); ;
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
