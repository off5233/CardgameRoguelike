using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnly : MonoBehaviour
{
    public static float Bm = 1, Em = 1 ;
    public AudioSource B, E, E2;
    // Start is called before the first frame update
    public void Update()
    {
        if (B != null)
        {
            B.volume = Bm;
        }
        if (E != null)
        {
            E.volume = Em;
        }
        if (E2 != null)

        {
            E2.volume = Em;
        }
    }
}
