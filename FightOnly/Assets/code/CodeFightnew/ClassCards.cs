using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassCards : MonoBehaviour
{
    string infocardshow, namecardshow, typeshow;
    int costshow, powershow;
    // Start is called before the first frame update
    public ClassCards(string infocard, string namecard, int cost, string typecard, int power)
    {
        Infocard = infocard;
        Namecard = namecard;
        Cost = cost;
        Typecard = typecard;
        Power = power;

    }

    public string Infocard { get => infocardshow; set => infocardshow = value; }
    public string Namecard { get => namecardshow; set => namecardshow = value; }
    public int Cost { get => costshow; set => costshow = value; }
    public string Typecard { get => typeshow; set => typeshow = value; }
    public int Power { get => powershow; set => powershow = value; }

}
