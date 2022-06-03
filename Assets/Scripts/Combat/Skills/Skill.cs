using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    StatSystem attacker;

    void Awake()
    {
        // Saber quem está invocando
        attacker = GetComponentInParent<StatSystem>(); 
    }

    public void UseSkill(StatSystem defender)
    {
        if(GetComponentInParent<HitChance>().CalculateHitChance(attacker, defender))
        {
            GetComponentInParent<Effect>().ApllyEffect(attacker, defender);
        }
    }

}
