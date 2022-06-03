using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    [SerializeField]
    Stat[] Stats = new Stat[(int)StatEnum.Wisdom + 1];

    [ContextMenu("SetStats")]
    void SetStats()
    {
        Stats = new Stat[(int)StatEnum.Wisdom + 1];

        for (int i = 0; i < Stats.Length; i++)
        {
            Stats[i] = new Stat();
            Stats[i].Type = (StatEnum)i;
        }
    }


    [ContextMenu("RandomizeStats")]
    void RandomizeStats()
    {
        for (int i = 0; i < Stats.Length; i++)
        {
            Stats[i].Value = Random.Range(0, 20);
        }


        GetStat(StatEnum.HP).Value = GetStat(StatEnum.MaxHP).Value;
        GetStat(StatEnum.MP).Value = GetStat(StatEnum.MaxMP).Value;
    }

    public Stat GetStat(StatEnum type)
    {
        return Stats[(int)type];
    }

    public int GetAbilityScore(StatEnum type)
    {
        Stat stat = GetStat(type);
        ModifiedValue modifiedValue = new ModifiedValue(stat.Value);

        foreach (StatModifier mod in GetComponentsInChildren<StatModifier>())
        {
            if (mod.Type == type)
            {
                mod.ChangeValue(modifiedValue);
            }

        }
        Debug.LogFormat("Initial: {0}, Modded: {1}", modifiedValue.InitialValue, modifiedValue.ModdedValue);
        return Mathf.FloorToInt(modifiedValue.ModdedValue);
    }

    public void ChangeHP(int value)
    {
        Stat hp = GetStat(StatEnum.HP);
        float tempValue = hp.Value + value;

        float clampedValue = Mathf.Clamp(tempValue, 0, GetStat(StatEnum.MaxHP).Value);

        hp.Value = clampedValue;
    }
}