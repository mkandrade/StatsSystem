using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddValueModifier : StatModifier
{
    public override void ChangeValue(ModifiedValue modifiedValue)
    {
        modifiedValue.ModdedValue += Value;
    }
}
