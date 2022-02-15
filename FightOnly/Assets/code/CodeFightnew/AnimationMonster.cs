using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMonster : MonoBehaviour
{
    public static bool checkdamage = false;
    public Animator[] AnimatorFade;
    public AudioClip Damage;
    // Start is called before the first frame update
    void Update()
    {
        if (checkdamage == true)
        {
            if (AnimatorFade[0] == null) { return; }
            AnimatorFade[0].SetBool("checkdamage", true);
            MUSIC2.PlaySoundEff2("MonsterDamage");
            checkdamage = false;
        }
    }

}
