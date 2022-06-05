using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : Effect
{
    const float Variance = 0.2f;
    public float Power = 1;

    public StatEnum AttackerStat;

    public override void ApllyEffect(Unit attacker, Unit defender)
    {
        float attackerScore = attacker.GetAbilityScore(AttackerStat);

        float roll = 1 + Random.Range(-Variance, Variance);
        float finalScore = (attackerScore * roll) * Power;

        Debug.LogFormat("AttackerScore:{0}, roll:{1}, finalScore:{2}",
            attackerScore, roll, finalScore);

        defender.ChangeHP(Mathf.Max(0, Mathf.CeilToInt(finalScore)));
        Debug.LogFormat("{0} heals {1} damage", defender.name, finalScore);
    }
}
