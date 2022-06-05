using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentageEffect : Effect
{
    // Se não for negativo, acaba recuperando vida
    [Header("Use Negative For Damage")]
    public float Power;
    public override void ApllyEffect(Unit attacker, Unit defender)
    {

        float maxHP = defender.GetAbilityScore(StatEnum.MaxHP);
        float score = maxHP * Power;

        defender.ChangeHP(Mathf.CeilToInt(score));
        Debug.LogFormat("{0} {1} stat changed by {2}",
            defender.name, maxHP, score);
    }

}