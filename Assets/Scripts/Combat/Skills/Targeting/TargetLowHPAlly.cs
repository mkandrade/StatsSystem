using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLowHPAlly : Targeting
{
    public float LowHPTreshold = 0.75f;
    public override Unit GetTarget()
    {
        Team team = GetComponentInParent<Team>();
        Unit[] Units = team.GetComponentsInChildren<Unit>();

        foreach (Unit u in Units)
        {
            float HP = u.GetAbilityScore(StatEnum.HP);
            float MaxHP = u.GetAbilityScore(StatEnum.MaxHP);

            if (HP < (MaxHP * LowHPTreshold))
            {
                Debug.Log("Condition Matched, Now i'm Allowed to Heal");
                return u;
            }
        }
        return null;
    }
}
