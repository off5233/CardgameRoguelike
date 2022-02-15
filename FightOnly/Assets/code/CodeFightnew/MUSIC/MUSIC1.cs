using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUSIC1 : MonoBehaviour
{

    public static AudioClip PlayerDamageSuond, SwordDamage, MagDamage, Healmepls,ineedhealme,mondamage;
    static AudioSource AudioEff;
    public AudioSource BGMMAIN;


    public void Update()
    {

    }

    public void Start()
    {

        PlayerDamageSuond = Resources.Load<AudioClip>("PlayerDamage");
        SwordDamage = Resources.Load<AudioClip>("Sword");
        MagDamage = Resources.Load<AudioClip>("fireball");
        Healmepls = Resources.Load<AudioClip>("Heal");
        ineedhealme = Resources.Load<AudioClip>("ineedheal");
        mondamage = Resources.Load<AudioClip>("Squish");

        
        AudioEff = GetComponent<AudioSource>();
    }

    public static void PlaySoundEff(string clip)
    {
        switch (clip)
        {
            case "PlayerDamage":
                AudioEff.PlayOneShot(PlayerDamageSuond);
                break;
            case "SwordDamage":
                AudioEff.PlayOneShot(SwordDamage);
                break;
            case "MagDamage":
                AudioEff.PlayOneShot(MagDamage);
                break;
            case "heal":
                AudioEff.PlayOneShot(Healmepls);
                break;
            case "ineedheal":
                AudioEff.PlayOneShot(ineedhealme);
                break;
            case "monhunt":
                AudioEff.PlayOneShot(mondamage);
                break;

            default:
                break;

        }
    }
}
