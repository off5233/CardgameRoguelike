using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassstatusMon : MonoBehaviour
{
    float ATKshow;
    float DEFshow;
    float MAGshow;
    float MAGDEFshow;
    float HPshow;

    public ClassstatusMon(float aTK, float dEF, float mAG, float mAGDEF, float hP)
    {
        ATK = aTK;
        DEF = dEF;
        MAG = mAG;
        MAGDEF = mAGDEF;
        HP = hP;
    }

    public float ATK { get => ATKshow; set => ATKshow = value; }
    public float DEF { get => DEFshow; set => DEFshow = value; }
    public float MAG { get => MAGshow; set => MAGshow = value; }
    public float MAGDEF { get => MAGDEFshow; set => MAGDEFshow = value; }
    public float HP { get => HPshow; set => HPshow = value; }
}

