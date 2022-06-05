using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChanceStatBased : HitChance
{
    public float HitChanceObjective = 70;

    public StatEnum AttackerStat;
    public StatEnum DefenderStat;

    public override bool CalculateHitChance(Unit attacker, Unit defender)
    {
        float attackerScore = attacker.GetAbilityScore(AttackerStat);
        float defenderScore = defender.GetAbilityScore(DefenderStat);

        float score = (attackerScore - defenderScore) * 2;
        float finalScore = score + HitChanceObjective;
        float roll = Random.Range(0, 101);

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
