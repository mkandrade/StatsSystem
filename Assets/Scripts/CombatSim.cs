using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSim : MonoBehaviour
{

    public Transform Graveyard;
    TurnOrderController turnOrderController;

    void Awake()
    {
        turnOrderController = GetComponent<TurnOrderController>();
    }

    [ContextMenu("StartFight")]
    void StartFight()
    {
        StartCoroutine(Fight());
    }


    IEnumerator Fight()
    {
        do
        {
            Unit attacker = GetAttacker();
            Unit target = null;

            Debug.LogFormat("{0}'s turn", attacker.name);
            // CHama efeitos de começo do turno da unidade
            attacker.OnturnBegin();

            Skill skill = GetSkills(attacker);

            // Faz o target conforme necessidade de cada skill
            target = skill.GetComponent<Targeting>().GetTarget();

            // Posibila que Tenha Targets diferentes, que não necessariamente consigam encontrar algum alvo adequado, dependendo da situação.
            if (target != null)
            {
                skill.UseSkill(target);
            }
            else
            {
                Debug.Log("No valid target");
            }

            // Depois de atacar, retorna ao final da fila
            turnOrderController.Units.Enqueue(attacker);

            yield return new WaitForSecondsRealtime(1);

        } while (!CheckForGameOver());
        Debug.Log("END FIGHT");
    }

    Skill GetSkills(Unit attacker)
    {
        Skill[] skills = attacker.GetComponentsInChildren<Skill>();
        int roll = Random.Range(0, skills.Length);
        return skills[roll];
    }

    Unit GetAttacker()
    {
        while (turnOrderController.Units.Count != 0)
        {
            Unit attacker = turnOrderController.Units.Dequeue();
            if (attacker != null && attacker.GetStat(StatEnum.HP).Value > 0)
            {
                return attacker;
            }
        }
        return null;
    }

    bool CheckForGameOver()
    {
        if (!IsTeamAlive(turnOrderController.Team1Units))
        {
            Debug.Log("Team 1 is Dead!");
            return true;
        }
        if (!IsTeamAlive(turnOrderController.Team2Units))
        {
            Debug.Log("Team 2 is Dead!");
            return true;
        }

        return false;
    }

    bool IsTeamAlive(List<Unit> units)
    {
        bool anyUnitAlive = false;
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].GetStat(StatEnum.HP).Value > 0)
            {
                anyUnitAlive = true;
            }
            else
            {
                units[i].transform.SetParent(Graveyard);
                units.RemoveAt(i);
                i--;
            }
        }
        return anyUnitAlive;
    }

}
