using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomAlly : Targeting
{
    public override StatSystem GetTarget()
    {
        Team team = GetComponentInParent<Team>();
        StatSystem[] allyUnits = team.GetComponentsInChildren<StatSystem>();
        int roll = Random.Range(0, allyUnits.Length);

        return allyUnits[roll];
    }
}
