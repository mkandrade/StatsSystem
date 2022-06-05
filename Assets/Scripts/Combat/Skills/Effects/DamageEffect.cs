using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : Effect
{
    const float Variance = 0.2f;
    public List<StatsEffectiveness> AttackerStats;
    public StatEnum DefenderStat;

    public override void ApllyEffect(Unit attacker, Unit defender)
    {
        float attackerScore = StatSCalculateScore(attacker, AttackerStats);
        float defenderScore = defender.GetAbilityScore(DefenderStat);

        float score = attackerScore - (defenderScore / 2);
        float roll = 1 + Random.Range(-Variance, Variance);
        float finalScore = score * roll;

        Debug.LogFormat("AttackerScore:{0}, DefenderScore:{1}, score:{2}, roll:{3}, finalScore:{4}",
        attackerScore, defenderScore, score, roll, finalScore);

        //

        defender.ChangeHP(Mathf.Min(0, Mathf.CeilToInt(-finalScore)));
        Debug.LogFormat("{0} suffered {1} damage", defender.name, -finalScore);
    }

    float StatSCalculateScore(Unit unit, List<StatsEffectiveness> stats)
    {
        float sum = 0;
        foreach (StatsEffectiveness stat in stats)
        {
            float score = unit.GetAbilityScore(stat.Stat);
            sum += score * stat.Multiplier;
        }
        return sum;
    }
}
