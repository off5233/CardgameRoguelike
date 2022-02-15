using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGiftcard : MonoBehaviour
{


    string infocardshow;
    string namecardshow;
    int powershow;
    string typeshow;

    public MainGiftcard(string infocard, string namecard, int power, string typecard)
    {
        Infocard = infocard;
        Namecard = namecard;
        Power = power;
        Typecard = typecard;
    }

    public string Typecard { get => typeshow; set => typeshow = value; }
    public string Infocard { get => infocardshow; set => infocardshow = value; }
    public string Namecard { get => namecardshow; set => namecardshow = value; }
    public int Power { get => powershow; set => powershow = value; }

}
