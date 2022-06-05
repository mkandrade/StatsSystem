using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictEffect : Effect
{
    public Status StatusToInflict;
    public bool Stackable;

    public override void ApllyEffect(Unit attacker, Unit defender)
    {
        Transform statusHolder = defender.transform.Find("Status");

        // Caso não possa realizar o stack, reseta a duração.
        if (!CanAplly(statusHolder))
        {
            ResetDuration(statusHolder);
            return;
        }

        Status status = Instantiate(StatusToInflict, Vector3.zero, Quaternion.identity, statusHolder);
        status.name = status.name.Replace("(Clone)", "");
        status.SetActors(attacker, defender);
    }

    private bool CanAplly(Transform statusHolder)
    {
        if (Stackable)
        {
            return true;
        }
        for (int i = 0; i < statusHolder.childCount; i++)
        {
            if (statusHolder.GetChild(i).name == StatusToInflict.name)
            {
                return false;
                //TODO reset duration when we have duration 
            }
        }
        return true;
    }

    void ResetDuration(Transform statusHolder)
    {
        TemporaryStatus[] status = statusHolder.GetComponentsInChildren<TemporaryStatus>();

        foreach (TemporaryStatus temp in status)
        {
            if (temp.name == StatusToInflict.name)
            {
                temp.CurrentCuration = temp.InitialDuration;
            }
        }
    }
}