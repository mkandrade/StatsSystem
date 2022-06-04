using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSim : MonoBehaviour
{

    public Unit Attacker;
    public Unit Defender;

    public StatEnum Stat;

    [ContextMenu("PrintStat")]
    void PrintStat()
    {
        Debug.LogFormat("Value: {0}, Score: {1}",
            Attacker.GetStat(Stat).Value,
            Attacker.GetAbilityScore(Stat));
    }

    [ContextMenu("StartFight")]
    void StartFight()
    {
        StartCoroutine(Fight());
    }


    IEnumerator Fight()
    {
        Unit lastAttacked;
        do
        {
            Debug.LogFormat("{0}'s turn", Attacker.name);
            // CHama efeitos de começo do turno da unidade
            Attacker.OnturnBegin();

            Skill skill = GetSkills();

            // Faz o target conforme necessidade de cada skill
            skill.UseSkill(skill.GetComponent<Targeting>().GetTarget());

            lastAttacked = Defender;
            Defender = Attacker;
            Attacker = lastAttacked;

            yield return new WaitForSecondsRealtime(1);

        } while (lastAttacked.GetStat(StatEnum.HP).Value > 0);
        Debug.LogFormat("{0} was killed", lastAttacked.name);
    }

    [ContextMenu("AddModifier")]
    void AddModifier()
    {
        //Important
        AddValueModifier mod = Attacker.transform.Find("Modifiers").gameObject.AddComponent<AddValueModifier>();
        mod.Value = 10;
        mod.Type = Stat;
    }

    [ContextMenu("MultiModifier")]
    void MultiModifier()
    {
        //Important
        MultiValueModifier mod = Attacker.transform.Find("Modifiers").gameObject.AddComponent<MultiValueModifier>();
        mod.Value = 10;
        mod.Type = Stat;
    }

    Skill GetSkills()
    {
        Skill[] skills = Attacker.GetComponentsInChildren<Skill>();
        int roll = Random.Range(0, skills.Length);

        Debug.LogFormat("{0} USED {1}", Attacker.name, skills[roll].name);
        return skills[roll];
    }

}
