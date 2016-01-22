using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

    public float health = 100f; //Quantidade de vida do inimigo.
    public float speed = 10f; //Velocidade do inimigo.

    public bool grounded; //Booleana para indicar se o objeto está no chão ou não;
    public GroundChecker groundChk;

    private NavMeshAgent agent; //Referência para o componente NavMeshAgent.
    private Rigidbody rBody;

    //NavMeshParameters
    [Header("NavMesh Parameters")] //No Inspector irá aparecer em negrito escrito isso antes das variáveis abaixo.
    public float radius;
    public float baseOffset;
    public float angularSpeed;
    public float stoppingDistance;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //Adiciona a referencia para o componente NavMeshAgent.
        rBody = GetComponent<Rigidbody>();
        NavMeshAgentReconfig();
        grounded = false;

        stoppingDistance = agent.stoppingDistance * transform.localScale.x; //Um cálculo simples para regular a distancia de parada da aranha dependendo da sua escala.
        agent.stoppingDistance = stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = groundChk.isGrounded();

        agent.enabled = grounded; //Se ele ta no chão, ativa o agente.
        rBody.isKinematic = grounded; //Ativa o isKinematic do componente RigidBody.

        //Debug.DrawLine(transform.localPosition, -Vector3.up, Color.black);        
    }

    private void NavMeshAgentReconfig() //Essa função irá substituir alguns valores no componente NavMeshAgent de acordo com os valores presentes nessa classe.
    {
        agent.speed = speed;
        agent.radius = radius;
        agent.baseOffset = baseOffset;
        agent.angularSpeed = angularSpeed;
    }

}
