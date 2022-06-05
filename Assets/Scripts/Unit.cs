using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate, "Variável que você poe métodos dentro, então você chama ela e vai rodar todos os métodos ali dentro"
public delegate void OnturnBegin();
public class Unit : MonoBehaviour
{
    public OnturnBegin OnturnBegin = delegate { };

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
            Stats[i].Value = Random.Range(1, 21);
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
            if (type == mod.Type)
                mod.ChangeValue(modifiedValue);
        }
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
