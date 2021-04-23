using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoJogador : MonoBehaviour
{
    public float velocidade;
    public float intensidadeSalto;

    private Rigidbody rb;
    private bool tocarSolo;

    private bool saltar;

    // Ao principio vamos buscar o componente onde vamos aplicar for�as fisicas posteriormente
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    //Verificar quando � que o jogador pressiona no espa�o
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            saltar = true;
        }
    }

    void FixedUpdate()
    {

        //Se o jogador tiver pressionado na tecla de salto e estiver no ch�o, aplicamos a for�a do salto.
        if (saltar && tocarSolo)
        {
            tocarSolo = false;
            rb.AddForce(Vector3.up * intensidadeSalto);
            transform.Find("Jump Sound").GetComponent<AudioSource>().Play();
        }


        //Dado um input do jogador, mexemos para a direita ou para a esquerda
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * h * velocidade);

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Quando o jogador colide com o ch�o, mudamos a variavel tocarSolo para verdadeiro.
        if (collision.gameObject.tag == "Solo")
        {
            tocarSolo = true;
        }

        //Quando o jogador colide com um obst�culo, mostramo o ecr� de Fim de Jogo e destruimos o jogador
        if (collision.gameObject.tag == "Obstacle")
        {
            GameObject gameOverScreenParent = GameObject.Find("GameOverScreenParent");
            GameObject gameOverScreen = gameOverScreenParent.transform.GetChild(0).gameObject;
            gameOverScreen.SetActive(true);

            Destroy(gameObject);
        }
    }
}
