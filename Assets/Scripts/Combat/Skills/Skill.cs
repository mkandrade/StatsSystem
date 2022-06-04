using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    Unit attacker;

    void Awake()
    {
        // Saber quem est� invocando
        attacker = GetComponentInParent<Unit>();
    }

    public void UseSkill(Unit defender)
    {
        if (GetComponentInParent<HitChance>().CalculateHitChance(attacker, defender))
        {
            foreach (Effect effect in GetComponents<Effect>())
            {
                effect.ApllyEffect(attacker, defender);

            }
        }
    }

}
