using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitChance : MonoBehaviour
{
    public abstract bool CalculateHitChance(Unit attacker, Unit defender);
}
