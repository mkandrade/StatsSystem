using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelf : Targeting
{
    public override Unit GetTarget()
    {
        return GetComponentInParent<Unit>();
    }
}
