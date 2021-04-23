using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControladorJogo : MonoBehaviour
{
    public GameObject obstaculo;

    void Start()
    {
        StartCoroutine(ObstacleRoutine());
    }

    IEnumerator ObstacleRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            Vector3 posCriar = new Vector3(Random.Range(-6, 6),
                                   0.5f,
                                   Random.Range(25, 35)
                                   );
            Instantiate(obstaculo, posCriar, Quaternion.identity);
        }
    }

    public void JogarOutraVez()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
