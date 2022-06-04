using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomAlly : Targeting
{
    public override Unit GetTarget()
    {
        Team team = GetComponentInParent<Team>();
        Unit[] allyUnits = team.GetComponentsInChildren<Unit>();
        int roll = Random.Range(0, allyUnits.Length);

        return allyUnits[roll];
    }
}
