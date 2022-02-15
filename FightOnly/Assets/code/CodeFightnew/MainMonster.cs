using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMonster : MonoBehaviour
{

    public float atkmonster = 1 , defmonster = 1, magmonster = 1 ,magdefmonster = 1, hpmonster = 1;
    public static double hpmmaxmon = 1;

    public void Start()
    {  hpmmaxmon = hpmonster;   }

    public void Update()
    {
        atkmonstertocard.Invoke(atkmonster);
        defmonstertocard.Invoke(defmonster);
        magmonstertocard.Invoke(magmonster);
        magdefmonstertocard.Invoke(magdefmonster);
        hpmonmax.Invoke(hpmonster);
    }

    FloatEventall atkmonstertocard = new FloatEventall();
    public void Atkmonlis (UnityAction<float> listener) {  atkmonstertocard.AddListener(listener); }

    FloatEventall defmonstertocard = new FloatEventall();
    public void DEFmonlis(UnityAction<float> listener) {   defmonstertocard.AddListener(listener); }

    FloatEventall magdefmonstertocard = new FloatEventall();
    public void MAGDEFkmonlis(UnityAction<float> listener) {  magdefmonstertocard.AddListener(listener); }

    FloatEventall magmonstertocard = new FloatEventall();
    public void MAGMONLIS (UnityAction<float> lis) { magmonstertocard.AddListener(lis); }
    DoubleEventall hpmonmax = new DoubleEventall();
    public void hpmonlis(UnityAction<double> lis) { hpmonmax.AddListener(lis);  }
}
