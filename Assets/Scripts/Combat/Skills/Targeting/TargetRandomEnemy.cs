using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomEnemy : Targeting
{
    public override Unit GetTarget()
    {
        Team team = GetComponentInParent<Team>();
        Unit[] enemyUnits = team.EnemyTeam.GetComponentsInChildren<Unit>();
        int roll = Random.Range(0, enemyUnits.Length);

        return enemyUnits[roll];
    }
}
