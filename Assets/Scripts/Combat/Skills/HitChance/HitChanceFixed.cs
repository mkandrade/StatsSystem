using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChanceFixed : HitChance
{
    public float Value;

    public override bool CalculateHitChance(StatSystem attacker, StatSystem defender)
    {
        int roll = Random.Range(0, 101);
        Debug.LogFormat("ROLL {0}", roll);

        if(roll > Value)
        {
            Debug.Log("MISS");
            return false;
        }
        else
        {
            Debug.Log("HIT");
            return true;
        }

    }
}
