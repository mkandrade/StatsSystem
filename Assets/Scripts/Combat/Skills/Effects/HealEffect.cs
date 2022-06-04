using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : Effect
{
    const float Variance = 0.2f;
    public float power = 1;

    public StatEnum AttackerStat;

    public override void ApllyEffect(Unit attacker, Unit defender)
    {
        float attackerScore = attacker.GetAbilityScore(AttackerStat);

        float roll = 1 + Random.Range(-Variance, Variance);

        float finalScore = (attackerScore * roll) * power;

        // Debug.LogFormat("Attacker {0}, Roll {1}, FinalScore {2}",
        //   attackerScore, roll, finalScore);

        defender.ChangeHP(Mathf.Max(0, Mathf.CeilToInt(finalScore)));

        Debug.LogFormat("{0} Healed {1} of HP",
            defender.name, finalScore);
    }
}
