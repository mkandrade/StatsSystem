using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : Effect
{
    const float Variance = 0.2f;
    public List<StatsEffectiveness> AttackerStats;
    public StatEnum DefenderStat;

    public override void ApllyEffect(StatSystem attacker, StatSystem defender)
    {
        float attackerScore = StatSCalculateScore(attacker, AttackerStats);
        float defenderScore = defender.GetAbilityScore(DefenderStat);

        float score = attackerScore - (defenderScore / 2);
        float roll = 1 + Random.Range(-Variance, Variance);

        float finalScore = roll * score;

        // Para Apenas Retirar Vida -finalScore
        defender.ChangeHP(Mathf.CeilToInt(-finalScore));

        Debug.LogFormat("{0} Suffered {1} of Damage",
            defender.name, finalScore);
    }

    float StatSCalculateScore(StatSystem unit, List<StatsEffectiveness> statsToCalculate)
    {
        float sum = 0;
        foreach (StatsEffectiveness statType in statsToCalculate)
        {
            float score = unit.GetAbilityScore(statType.Stat);
            sum += score * statType.Multiplier;
        }
        return sum;
    }
}
