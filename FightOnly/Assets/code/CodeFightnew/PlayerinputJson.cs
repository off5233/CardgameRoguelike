using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.IO;

public class PlayerinputJson : MonoBehaviour
{

    public static float costtocard;
    public static double HPMAX;
    public void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/code" + "/PlayerStatus.json");
        PlayerData LoadPlayDATA = JsonUtility.FromJson<PlayerData>(json);
       
        
        
        costtocard = LoadPlayDATA.COST;
        HPMAX = LoadPlayDATA.HP;
        costevent.Invoke(LoadPlayDATA.COST);
        Debug.Log("Cost : " + LoadPlayDATA.COST);

    }

    public void Update()
    {
        string json = File.ReadAllText(Application.dataPath + "/code" + "/PlayerStatus.json");
        PlayerData LoadPlayDATA = JsonUtility.FromJson<PlayerData>(json);

        hpmaxall.Invoke(LoadPlayDATA.HP);
        atkevent.Invoke(LoadPlayDATA.ATK);
        Defkevent.Invoke(LoadPlayDATA.DEF);
        MagEvent.Invoke(LoadPlayDATA.MAG);
        MagdefEvent.Invoke(LoadPlayDATA.MAGDEF);
        LV.Invoke(LoadPlayDATA.LevelMonster); 
    }

    DoubleEventall hpmaxall = new DoubleEventall();
    public void hpmax(UnityAction<double> listener) { hpmaxall.AddListener(listener); }

    FloatEventall atkevent = new FloatEventall();
    public void atkeventlis(UnityAction<float> listener) {  atkevent.AddListener(listener);  }

    FloatEventall Defkevent = new FloatEventall();
    public void defeventlis(UnityAction<float> listener) { Defkevent.AddListener(listener); }

    FloatEventall MagEvent = new FloatEventall();
    public void Mageventlis(UnityAction<float> listener) { MagEvent.AddListener(listener);}

    FloatEventall MagdefEvent = new FloatEventall();
    public void MagDefEvent(UnityAction<float> listener) {  MagdefEvent.AddListener(listener); }

    FloatEventall costevent = new FloatEventall();
    public void COSTLIS(UnityAction<float> lis) { costevent.AddListener(lis);}
    
    IntEventall LV = new IntEventall();
    public void LVMONSTER(UnityAction<int> lis) { LV.AddListener(lis); }


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


