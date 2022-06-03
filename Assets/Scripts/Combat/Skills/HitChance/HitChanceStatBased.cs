using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChanceStatBased : HitChance
{
    //Chance media de acertar
    public float HitChanceObjective = 70;

    public StatEnum AttackerStat;
    public StatEnum DefenderStat;

    public override bool CalculateHitChance(StatSystem attacker, StatSystem defender)
    {
        float attackerScore = attacker.GetAbilityScore(AttackerStat);
        float defenderScore = defender.GetAbilityScore(DefenderStat);

        float score = (attackerScore - defenderScore) * 2;
        float finalScore = score + HitChanceObjective;
        int roll = Random.Range(0, 101);

        if (roll > finalScore)
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
