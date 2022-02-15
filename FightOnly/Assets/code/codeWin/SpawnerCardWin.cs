using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class SpawnerCardWin : MonoBehaviour
{
    GameObject[] CardDestory;
    public Canvas canvas;
    Giftcick Po;

    public GameObject[] spawnObject;
    public Giftcick[] Card;

    public string ConfFileName = "GiftItem.csv";
    Dictionary<string, MainGiftcard> CarDGift = new Dictionary<string, MainGiftcard>();
    public static int card = 0;

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
        int power = int.Parse(data[3]);
        string typecard = data[4];
        MainGiftcard CardsGifts = new MainGiftcard(infocard, namecard, power, typecard);
        CarDGift.Add(no, CardsGifts);
    }


    // Start is called before the first frame update
    private void Awake()
    {
        ReadData();
        RecardAll();
    }



    void RecardAll()
    {
        if (Card == null) return;
        if (spawnObject == null) return;

        foreach (GameObject spawn in spawnObject)
        {
            string infocardshow = "None";
            string namecardshow = "None";
            int powershow = 0;
            string typecard = "None";


            int RandomGacha =  UnityEngine.Random.Range(0, 100);

            Debug.Log("RandomGacha :" + RandomGacha);

            if (RandomGacha <= 95)
            {
                int Random = UnityEngine.Random.Range(1, 7);
                //string className = Card[Random].GetType().Name;
                MainGiftcard CardData = new MainGiftcard(infocardshow, namecardshow, powershow, typecard);
                switch (Random)
                {
                    case 1:
                        CardData = CarDGift["1"];
                        break;
                    case 2:
                        CardData = CarDGift["2"];
                        break;
                    case 3:
                        CardData = CarDGift["3"];
                        break;
                    case 4:
                        CardData = CarDGift["4"];
                        break;
                    case 5:
                        CardData = CarDGift["5"];
                        break;
                    case 6:
                        CardData = CarDGift["6"];
                        break;
                    default:
                        break;
                }

                Card[0].nameshow = CardData.Namecard;
                Card[0].Textinfo = CardData.Infocard;
                Card[0].power = CardData.Power;
                Card[0].typecardinfo = CardData.Typecard;
                Po = Instantiate(Card[0], canvas.transform);
                Po.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y);
            }

            if (RandomGacha > 95)
            {
                int Random = UnityEngine.Random.Range(7, 12);
                //string className = Card[Random].GetType().Name;
                MainGiftcard CardData = new MainGiftcard(infocardshow, namecardshow, powershow, typecard);
                switch (Random)
                {
                    case 7:
                        CardData = CarDGift["7"];
                        break;
                    case 8:
                        CardData = CarDGift["8"];
                        break;
                    case 9:
                        CardData = CarDGift["9"];
                        break;
                    case 10:
                        CardData = CarDGift["10"];
                        break;
                    case 11:
                        CardData = CarDGift["11"];
                        break;
                    case 12:
                        CardData = CarDGift["12"];
                        break;
                    default:
                        break;
                }

                Card[1].nameshow = CardData.Namecard;
                Card[1].Textinfo = CardData.Infocard;
                Card[1].power = CardData.Power;
                Card[1].typecardinfo = CardData.Typecard;
                Po = Instantiate(Card[1], canvas.transform);
                Po.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y);
            }

        }

    }
}
