using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUSIC2 : MonoBehaviour
{
    public static AudioClip MonsterDamageSuond;
    static AudioSource AudioEff2;


    public void Update()
    {


    }

    public void Start()
    {
        MonsterDamageSuond = Resources.Load<AudioClip>("MonsterDamage");
        AudioEff2 = GetComponent<AudioSource>();
    }

    public static void PlaySoundEff2(string clip)
    {
        switch (clip)
        {
            case "MonsterDamage":
                AudioEff2.PlayOneShot(MonsterDamageSuond);
                break;

            default:
                break;

        }
    }
}
