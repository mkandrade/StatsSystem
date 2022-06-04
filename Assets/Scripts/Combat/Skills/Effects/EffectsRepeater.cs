using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsRepeater : MonoBehaviour
{
    Status status;

    void Start()
    {
        status = GetComponent<Status>();
        status.Host.OnturnBegin += OnturnBeginDo;

    }

    void OnDisable()
    {
        if (status != null)
        {
            status.Host.OnturnBegin -= OnturnBeginDo;
        }
    }

    void OnturnBeginDo()
    {
        foreach (Effect effect in GetComponents<Effect>())
        {
            effect.ApllyEffect(status.Caster, status.Host);
        }
    }
}
