using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStatusAfflicted : Targeting
{
    public StatusType Type;
    public override Unit GetTarget()
    {
        Team targetTeam = GetTeam();
        Unit[] units = targetTeam.GetComponentsInChildren<Unit>();

        foreach (Unit u in units)
        {
            Status[] status = u.transform.Find("Status").GetComponentsInChildren<Status>();
            if (SearchRemoveable(status))
            {
                return u;
            }
        }
        return null;

    }

    Team GetTeam()
    {
        Team thisTeam = GetComponentInParent<Team>();
        // Remover Efeitos Negativos de Aliados
        if (Type == StatusType.Debuff)
        {
            return thisTeam;
        }
        //Remover Efeitos Positivos de Inimigos
        else
        {
            return thisTeam.EnemyTeam;
        }
    }

    bool SearchRemoveable(Status[] status)
    {
        foreach (Status stat in status)
        {
            if (stat.Type == Type)
            {
                return true;
            }
        }
        return false;
    }
}
