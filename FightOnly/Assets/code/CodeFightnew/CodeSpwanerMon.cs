using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using System.IO;


public class CodeSpwanerMon : MonoBehaviour
{
    public Text[] a;

    // Start is called before the first frame update
    public string ConfFileName = "Monster.csv";
    Dictionary<string, ClassstatusMon> Monsters = new Dictionary<string, ClassstatusMon>();

    public Canvas canvas;
    MainMonster Po;

    public GameObject[] spawnObject;
    public MainMonster[] MonsterObject;


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
                Data(values);
                values = input.ReadLine();
            }
        }
        catch (Exception ex) { Debug.Log(ex.Message); }
        finally { if (input != null) input.Close(); }
    }

    void Data(string values)
    {
        string[] data = values.Split(',');
        string Name = data[0];
        float aTK = int.Parse(data[1]);
        float dEF = int.Parse(data[2]);
        float mAG = int.Parse(data[3]);
        float mAGDEF = int.Parse(data[4]);
        float hP = float.Parse(data[5]);

        ClassstatusMon MonsterData = new ClassstatusMon(aTK, dEF, mAG, mAGDEF, hP);
        Monsters.Add(Name, MonsterData);
    }

    private void Awake()
    {

        ReadData();
        spawnMonsterVoid();
    }

    public void spawnMonsterVoid()
    {
        string json = File.ReadAllText(Application.dataPath + "/code" + "/PlayerStatus.json");
        PlayerData LoadPlayDATA = JsonUtility.FromJson<PlayerData>(json);


        if (MonsterObject == null) return;
        if (spawnObject == null) return;

        foreach (GameObject spawn in spawnObject)
        {

            float ATKshow = 0;
            float DEFshow = 0;
            float MAGshow = 0;
            float MAGDEFshow = 0;
            float HPshow = 0;
            ClassstatusMon MonsterData = new ClassstatusMon(ATKshow, DEFshow, MAGshow, MAGDEFshow, HPshow);

            int Random = UnityEngine.Random.Range(0, 2);

            switch (Random)
            {
                case 0:
                    MonsterData = Monsters["Slime"];
                    break;
                case 1:
                    MonsterData = Monsters["Golem"];
                    break;
                default:
                    break;
            }

            int RandomMonsterLevel = UnityEngine.Random.Range(0, 3);
            MonsterObject[Random].atkmonster = MonsterData.ATK + ((LoadPlayDATA.LevelMonster * 1) / 2) + RandomMonsterLevel;
            MonsterObject[Random].defmonster = MonsterData.DEF + ((LoadPlayDATA.LevelMonster * 1) / 2) + RandomMonsterLevel;
            MonsterObject[Random].magmonster = MonsterData.MAG + ((LoadPlayDATA.LevelMonster * 1) / 2) + RandomMonsterLevel;
            MonsterObject[Random].magdefmonster = MonsterData.MAGDEF + ((LoadPlayDATA.LevelMonster * 1) / 2) + RandomMonsterLevel;
            MonsterObject[Random].hpmonster = MonsterData.HP + ((LoadPlayDATA.LevelMonster * 1)) + RandomMonsterLevel;

            a[0].text = "ATK : " + MonsterObject[Random].atkmonster;
            a[1].text = "DEF : " + MonsterObject[Random].defmonster;
            a[2].text = "MAG : " + MonsterObject[Random].magmonster;
            a[3].text = "MAGDEF : " + MonsterObject[Random].magdefmonster;
            a[4].text = "HP : " + MonsterObject[Random].hpmonster;

            Po = Instantiate(MonsterObject[Random], canvas.transform);
            Po.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y);

        }

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
