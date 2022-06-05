using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChanceFixed : HitChance
{
    public float Value = 70;

    public override bool CalculateHitChance(Unit attacker, Unit defender)
    {
        int roll = Random.Range(0, 101);
        Debug.LogFormat("Roll:{0}", roll);

        if (roll > Value)
        {
            Debug.Log("Miss");
            return false;
        }
        else
        {
            Debug.Log("Hit");
            return true;
        }

    }
}
