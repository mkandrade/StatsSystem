using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictEffect : Effect
{
    public Status StatusToInflict;
    public bool stackable;

    public override void ApllyEffect(StatSystem attacker, StatSystem defender)
    {
        Transform statusHolder = defender.transform.Find("Status");

        if (!CanAplly(statusHolder))
        {
            Debug.Log("Couldn't apply");
            return;
        }

        Status status =  Instantiate(StatusToInflict, Vector3.zero, Quaternion.identity, statusHolder);
        status.name = status.name.Replace(("(Clone)"), "");
    }

    private bool CanAplly(Transform statusHolder)
    {
        if (stackable)
        {
            return true;
        }

        // Caso encontre algum status com o mesmo status, return false
        for(int i = 0; i < statusHolder.childCount; i++)
        {
            if (statusHolder.GetChild(i).name == StatusToInflict.name)
            {
                return false;
            }
        }

        return true;
    }
}