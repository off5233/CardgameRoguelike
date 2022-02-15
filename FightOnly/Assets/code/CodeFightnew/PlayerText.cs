using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerText : MonoBehaviour
{
    public GameObject A;
    public Text[] Playerui;
    float atks,defs,mags,magdefs, costs;
    int monlv;
    double hps;
    // Start is called before the first frame update
    void Start()
    {
        A = GameObject.Find("EventSystem");
        PlayerinputJson Text = A.GetComponent<PlayerinputJson>();
        Text.atkeventlis(atkshow);
        Text.hpmax(hpshow);
        Text.defeventlis(defshow);
        Text.Mageventlis(MAGSHOW);
        Text.MagDefEvent(MAGDEFSHOW);
        Text.COSTLIS(costshow);
        Text.LVMONSTER(LVMONSTERSHOW);

    }

    public void Update()  {  Playerui[5].text = "COST : "+PlayerinputJson.costtocard;  Playerui[1].text = "HP : " + PlayerinputJson.HPMAX;  }
    public void costshow(float cost) { costs = cost; Playerui[5].text = "COST : " + costs; }
    public void atkshow(float atk) { atks = atk; Playerui[0].text = "ATK : " + atks; }
    public void hpshow(double hp) { hps = hp; }
    public void defshow(float def)  { defs = def; Playerui[2].text = "DEF : " + defs; }
    public void MAGSHOW(float mag){  mags = mag;  Playerui[3].text = "MAG : " + mags; }
    public void MAGDEFSHOW(float magdef) { magdefs = magdef;  Playerui[4].text = "MAGDEF : " + magdefs; }
    public void LVMONSTERSHOW(int lv) {  monlv = lv ; Playerui[6].text = "LevelMonster : " + monlv; }



}
