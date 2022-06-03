using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiValueModifier : StatModifier
{
    public override void ChangeValue(ModifiedValue modifiedValue)
    {
        modifiedValue.ModdedValue += (Value / 100) * modifiedValue.InitialValue;
    }
}
