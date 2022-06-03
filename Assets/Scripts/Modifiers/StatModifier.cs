using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatModifier : MonoBehaviour
{
    public float Value;
    public StatEnum Type;
    public abstract void ChangeValue(ModifiedValue modifiedValue);
}
