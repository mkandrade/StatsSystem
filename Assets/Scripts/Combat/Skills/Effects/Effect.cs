using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public abstract void ApllyEffect(Unit attacker, Unit defender);
}
