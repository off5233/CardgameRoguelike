using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class SpawnerCard : MonoBehaviour ,IPointerDownHandler
{
    public GameObject Fade,FadeLose;
    Animator fadewhite;


    public Animator[] monster1;
    public GameObject CardtoStatus, monsterobj,hpplayershow,showtextmons;
    public float Atkmon,MAGMON,DEFPLAYER,DEFMAGPLAYER,costss,atkplayers ,magplayers ;
    public double hpplayers,damage;


    public void Start()
    {

        CardtoStatus = GameObject.Find("EventSystem");
        PlayerinputJson Statusplayer = CardtoStatus.GetComponent<PlayerinputJson>();

        monsterobj = GameObject.FindGameObjectWithTag("Monster");
        MainMonster Statusmon = monsterobj.GetComponent<MainMonster>();

        Statusplayer.atkeventlis(atkplayer);
        Statusplayer.Mageventlis(magplayer);
        Statusplayer.defeventlis(defplayer);
        Statusplayer.COSTLIS(cost);
        Statusplayer.MagDefEvent(defmagplayer);
        Statusplayer.hpmax(HPplayer);

        Statusmon.Atkmonlis(atkmon);
        Statusmon.MAGMONLIS(magkmon);
    }

    public void atkplayer(float costs) { atkplayers = costs;}
    public void magplayer(float costs) { magplayers = costs; }
    public void cost(float costs){ costss = costs; }
    public void atkmon(float atkinput) {  Atkmon = atkinput; } 
    public void magkmon(float maginput) { MAGMON = maginput;}
    public void defplayer(float def) { DEFPLAYER = def; }
    public void defmagplayer(float defmag) {  DEFMAGPLAYER = defmag; }
    public void HPplayer(double hp){ hpplayers = hp;  }



    GameObject[] CardDestory;
    public Canvas canvas;

    GameObject potest;
    MainCards Po;
    public GameObject[] spawnObject;
    public MainCards[] Card;

    public string ConfFileName = "INFO.csv";
    Dictionary<string, ClassCards> Cards = new Dictionary<string, ClassCards>();

    private void ReadData()
    {
        StreamReader input = null;
        string path = "Assets/Item/CSV";
        try
        {
            input = File.OpenText(Path.Combine(path, ConfFileName));
            string name = input.ReadLine();
            string values = input.ReadLine();
            while (values != null)
            {
                AssignData(values);
                values = input.ReadLine();
            }
        }
        catch (Exception ex) { Debug.Log(ex.Message); }
        finally { if (input != null) input.Close(); }
    }


    void AssignData(string values)
    {
        string[] data = values.Split(',');
        string no = data[0];
        string namecard = data[1];
        string infocard = data[2];
        int cost = int.Parse(data[3]);
        string typecard = data[4];
        int power = int.Parse(data[5]);
        ClassCards infocards = new ClassCards(infocard, namecard, cost, typecard, power);
        Cards.Add(no, infocards);
    }

    private void Awake()
    {
        ReadData();
        RecardAll();
    }

    void RecardAll()
    {
        if (Card == null) return;
        if (spawnObject == null) return;

        OrderObject arrayobjectspawncard = new OrderObject();

        foreach (GameObject spawn in spawnObject)
        {
            string infocardshow = "None";
            string namecardshow = "None";
            int costshow = 0;
            string typeshow = "None";
            int powershow = 0;

            int Random = UnityEngine.Random.Range(1, 11);
            Debug.Log("RandomCardNum 1 :" + Random);

            for (int i = 0; i < 1; i-- )
            {


                if (Random == 9 && magplayers > 10 && i == 0) { i = 1; break; }
                else if (Random == 10 && atkplayers > 10 && i == 0) { i = 1; break; }
                else if (Random != 9 && Random != 10) { i = 1; break; }
                else { Random = UnityEngine.Random.Range(1, 11); }

            }

            Debug.Log("RandomCardNum 2 :" + Random);

            //string className = Card[Random].GetType().Name;
            ClassCards CardData = new ClassCards(infocardshow, namecardshow, costshow, typeshow, powershow);
            switch (Random)
            {
                case 1:
                    CardData = Cards["1"];
                    break;
                case 2:
                    CardData = Cards["2"];
                    break;
                case 3:
                    CardData = Cards["3"];
                    break;
                case 4:
                    CardData = Cards["4"];
                    break;
                case 5:
                    CardData = Cards["5"];
                    break;
                case 6:
                    CardData = Cards["6"];
                    break;
                case 7:
                    CardData = Cards["7"];
                    break;
                case 8:
                    CardData = Cards["8"];
                    break; 
                case 9:
                    CardData = Cards["9"];
                    break;
                case 10:
                    CardData = Cards["10"];
                    break;
                default:
                    break;
            }

            if (CardData.Typecard == "ATK")
            {
                Card[0].nameshow = CardData.Namecard;
                Card[0].Textinfo = CardData.Infocard;
                Card[0].Costs = CardData.Cost;
                Card[0].typecardinfo = CardData.Typecard;
                Card[0].power = CardData.Power;
                Po = Instantiate(Card[0], canvas.transform);
                Po.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y);
            }

            if (CardData.Typecard == "MAG")
            {
                Card[1].nameshow = CardData.Namecard;
                Card[1].Textinfo = CardData.Infocard;
                Card[1].Costs = CardData.Cost;
                Card[1].typecardinfo = CardData.Typecard;
                Card[1].power = CardData.Power;
                Po = Instantiate(Card[1], canvas.transform);
                Po.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y);
            }


            if (CardData.Typecard == "HEAL")
            {
                Card[2].nameshow = CardData.Namecard;
                Card[2].Textinfo = CardData.Infocard;
                Card[2].Costs = CardData.Cost;
                Card[2].typecardinfo = CardData.Typecard;
                Card[2].power = CardData.Power;
                Po = Instantiate(Card[2], canvas.transform);
                Po.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y);
            }


            if (CardData.Typecard == "MAGHIGH")
            {
                Card[3].nameshow = CardData.Namecard;
                Card[3].Textinfo = CardData.Infocard;
                Card[3].Costs = CardData.Cost;
                Card[3].typecardinfo = CardData.Typecard;
                Card[3].power = CardData.Power;
                Po = Instantiate(Card[3], canvas.transform);
                Po.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y);
            }

            if (CardData.Typecard == "ATKHIGH")
            {
                Card[4].nameshow = CardData.Namecard;
                Card[4].Textinfo = CardData.Infocard;
                Card[4].Costs = CardData.Cost;
                Card[4].typecardinfo = CardData.Typecard;
                Card[4].power = CardData.Power;
                Po = Instantiate(Card[4], canvas.transform);
                Po.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y);
            }

        }

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        CardDestory = GameObject.FindGameObjectsWithTag("Card");

        int Randommonster = UnityEngine.Random.Range(1, 3);
        int RandomDamage = UnityEngine.Random.Range(0, 5);

        hpplayershow = GameObject.Find("HPPLAYER");
        showtextmons = GameObject.Find("textshow");

        if (Randommonster == 1)
        {
            damage = Math.Round((Atkmon + RandomDamage) / (DEFPLAYER * 2),2);
            PlayerinputJson.HPMAX -= damage;
            showtextmons.GetComponent<UnityEngine.UI.Text>().text = "ปิศาจโจมตีคุณด้วย ท่ากายภาพ!! : " + damage;

        }

        if (Randommonster == 2)
        {
            damage = Math.Round((MAGMON + RandomDamage) / (DEFMAGPLAYER * 2), 2);
            PlayerinputJson.HPMAX -= damage;
            showtextmons.GetComponent<UnityEngine.UI.Text>().text = "ปิศาจโจมตีคุณด้วย เวทย์มนต์!! : " + damage;

        }


        MUSIC1.PlaySoundEff("PlayerDamage");
        monster1[0].SetBool("DamageTake", true);



        if (PlayerinputJson.HPMAX < 1)
        {
            PlayerinputJson.HPMAX = 0;


            FadeLose.SetActive(true);
            fadewhite = FadeLose.GetComponent<Animator>();

        }


        foreach (GameObject Cardsss in CardDestory)
        {
            Destroy(Cardsss);
        }





        PlayerinputJson.costtocard = costss;


        Debug.Log("has been destroyed.");
        //costshow = Costmemory;
        RecardAll();
    }

    public void Update()
    {
        if (MainMonster.hpmmaxmon < 1) 
        {
            Fade.SetActive(true);
            fadewhite = Fade.GetComponent<Animator>();
        }
    }

}