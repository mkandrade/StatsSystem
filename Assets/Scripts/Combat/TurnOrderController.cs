using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderController : MonoBehaviour
{

    public Team Team1;

    [HideInInspector]
    public List<Unit> Team1Units;

    public Team Team2;

    [HideInInspector]
    public List<Unit> Team2Units;

    public Queue<Unit> Units;

    void Awake()
    {
        Units = new Queue<Unit>();
        AddUnits();
    }

    void AddUnits()
    {
        Team1Units = new List<Unit>(Team1.transform.GetComponentsInChildren<Unit>());
        Team2Units = new List<Unit>(Team2.transform.GetComponentsInChildren<Unit>());

        // Identifica o time com maior numero de units
        int maxUnits = Mathf.Max(Team1Units.Count, Team2Units.Count);


        for (int i = 0; i < maxUnits; i++)
        {
            AddUnit(i, Team1Units);
            AddUnit(i, Team2Units);
        }
    }

    void AddUnit(int i, List<Unit> teamUnits)
    {
        if (i < teamUnits.Count)
        {
            // .Enqueue() Insere em primeiro
            Units.Enqueue(teamUnits[i]);
        }
    }
    [ContextMenu("Print Queue")]
    void PrintQueue()
    {
        while (Units.Count > 0)
        {
            // .Dequeue() Tira por Primeiro
            Unit unit = Units.Dequeue();
            Debug.Log(unit.name);
        }
    }
}
