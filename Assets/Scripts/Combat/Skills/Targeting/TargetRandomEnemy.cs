using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomEnemy : Targeting
{
    public override StatSystem GetTarget()
    {
        Team team = GetComponentInParent<Team>();
        StatSystem[] enemyUnits = team.EnemyTeam.GetComponentsInChildren<StatSystem>();
        int roll = Random.Range(0, enemyUnits.Length);

        return enemyUnits[roll];
    }
}
