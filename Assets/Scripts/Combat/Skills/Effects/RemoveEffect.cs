using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEffect : Effect
{
    public StatusType type;
    public override void ApllyEffect(Unit attacker, Unit defender)
    {
        Transform statusHolder = defender.transform.Find("Status");
        Status[] removeables = statusHolder.GetComponentsInChildren<Status>();

        foreach (Status s in removeables)
        {
            if (s.Type == type)
            {
                Destroy(s.gameObject);

            }
        }
    }
}