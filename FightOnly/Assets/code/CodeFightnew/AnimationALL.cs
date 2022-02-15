using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationALL : MonoBehaviour
{
    public static bool checkdamage = false , heal = false;
    public Animator[] AnimatorFade;
    public AudioClip Damage;


    public void Update()
    {

        if(heal == true)
        {
            if (AnimatorFade[0] == null) { return; }
            AnimatorFade[0].SetBool("DamageTake", true);
        }
    }
    public void RedBG()
    {
        AnimatorFade[0].SetBool("DamageTake", false);
        heal = false;
    }

    public void RedMonsterstop()
    {
        AnimatorFade[1].SetBool("checkdamage", false);
    }
}
