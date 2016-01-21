using UnityEngine;
using System.Collections;

public class SimpleAINavMesh : MonoBehaviour {

    private GameObject player;
    private NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Irá achar a referencia do player na cena e adicionar nessa variável;
        agent = GetComponent<NavMeshAgent>(); //Adiciona a referencia para o componente NavMeshAgent.
    }

    void Update()
    {
        if (agent.enabled)
        {
            agent.destination = player.transform.position; //Aqui é para que o agente fique seguindo o Player mesmo que ele mude de posição.
        }
        
    }

}
