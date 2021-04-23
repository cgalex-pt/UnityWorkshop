using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoObstaculo : MonoBehaviour
{
    public float velocidadeObstaculo;

    //Quando renderiza uma frame, verifica se obstaculo passou pelo jogador
    void Update()
    {
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }

    //A uma taxa constante, move o obstaculo em direção ao jogador
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, -1) * velocidadeObstaculo);
    }

}
