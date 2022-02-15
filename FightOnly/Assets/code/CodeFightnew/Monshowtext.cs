using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Monshowtext : MonoBehaviour
{


    public GameObject monsterobj;
    public Text[] Textshowmon;

    public float atks, defs, mags, defmags, hps;
    // Start is called before the first frame update
    void Start()
    {
        monsterobj = GameObject.FindGameObjectWithTag("Monster");
        MainMonster Statusmon2 = monsterobj.GetComponent<MainMonster>();
        Statusmon2.Atkmonlis(atkmoninput);
        Statusmon2.DEFmonlis(monsterdef);
        Statusmon2.MAGMONLIS(monstermag);
        Statusmon2.MAGDEFkmonlis(monsterdefmag);
        Textshowmon[4].text = "HP : " + MainMonster.hpmmaxmon;
    }

    public void atkmoninput(float atk) { atks = atk;  Textshowmon[0].text = "ATK : " + atks; }
    public void monsterdef(float def){  defs = def;  Textshowmon[1].text = "DEF : " + defs; }
    public void monstermag(float mag){  mags = mag; Textshowmon[2].text = "MAG : " + mags; }
    public void monsterdefmag(float def) { defmags = def; Textshowmon[3].text = "MAGDEF : " + defmags; }

}
