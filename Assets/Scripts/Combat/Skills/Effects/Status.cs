using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public StatusType Type;

    [HideInInspector]
    public Unit Caster;

    [HideInInspector]
    public Unit Host;

    public void SetActors(Unit paramCaster, Unit paramHost)
    {
        Caster = paramCaster;
        Host = paramHost;
    }

}
