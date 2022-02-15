using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class CardtoCard : MonoBehaviour, IPointerDownHandler
{
    public GameObject[] Cardy , spawnerCard , Gamecard;
    public int cardsnum = 0;
    OrderObject arrayadd;

    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData eventData)
    {
        arrayadd = new OrderObject();
        Cardy = GameObject.FindGameObjectsWithTag("Card");
        spawnerCard = GameObject.FindGameObjectsWithTag("SpawnerCard");

        foreach (GameObject Cardsss in Cardy)
        {
            arrayadd.Add(Cardsss);
            cardsnum++;
        }

        for (int i = 0; i < cardsnum;i++)
        {
            Gamecard = new GameObject[cardsnum];
            Gamecard[i] = arrayadd.indexObj(i);
            Gamecard[i].transform.position = spawnerCard[i].transform.position;
        }
        cardsnum = 0;
    }

}
