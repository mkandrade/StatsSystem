using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryStatus : Status
{
    public int InitialDuration = 1;
    public int CurrentCuration = 1;

    // Quando Prefab for invocado
    void OnEnable()
    {
        CurrentCuration = InitialDuration;
        Unit host = GetComponentInParent<Unit>();
        host.OnturnBegin += OnturnBeginDo;
    }

    // Quando for destruido ou acabar o efeito
    void OnDisable()
    {
        Unit host = GetComponentInParent<Unit>();
        // Previne erros da unity ao tentar Disabe em objetos já excluidos ao encerrar o play.
        // Não Importaria tanto, pq o erro acontece ao quitar do jogo.
        // Porém, todavia e entretando, irrita o erro no console.
        if (host != null)
        {
            host.OnturnBegin -= OnturnBeginDo;
        }
    }

    void OnturnBeginDo()
    {
        CurrentCuration--;
        if (CurrentCuration <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
