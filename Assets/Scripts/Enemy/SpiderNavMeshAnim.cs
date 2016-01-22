using UnityEngine;
using System.Collections;

public class SpiderNavMeshAnim : MonoBehaviour {

    public GameObject attackGameObject;

    private Animator anim; //Referencia ao componente de animação.
    private NavMeshAgent agent; //Referencia ao componente NavMeshAgent.
    private EnemyStats enemyStats; //Referencia ao componente EnemyStats.

    private bool moving;

    private float speedBlend;
    private float speed;

    private float enemyHealth;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemyStats = GetComponent<EnemyStats>();

        speed = enemyStats.speed;
        enemyHealth = enemyStats.health;
	}
	
	// Update is called once per frame
	void Update () {

        if (agent.enabled) //Todo o comportamento só pode ser iniciado se o component NavMeshAgent estiver enable, para evitar erros.
        {

            if (agent.velocity != Vector3.zero) //Se a velocidade dele for diferente de zero.
            {
                moving = true;
                speedBlend = agent.velocity.magnitude / speed; //Pequeno cálculo para setar o blend das animações de correr e andar.
            }
            else
            {
                moving = false;
                speedBlend = 0;
            }
            
            if (agent.remainingDistance - agent.stoppingDistance < 0) //Se a distancia restante menos a distancia de parada for negativa, ataque.
            {
                anim.SetTrigger("Attacking"); //Ativa animação de ataque.
            }

            if (enemyHealth <= 0)//Se a vida do inimigo for menor ou igual a 0, chama a animação de morrer.
            {
                anim.SetTrigger("Dead"); 
            }

            anim.SetBool("Moving", moving); //Seta a variável Moving no Animator desse componente para o valor de moving.
            anim.SetFloat("Speed", speedBlend);//Seta a variável Speed no Animator desse componente para o valor de speedBlend.
        }

	}

    public void AttackTrigger(int value)
    {
        if(value == 1)
            attackGameObject.SetActive(true);
        else
            attackGameObject.SetActive(false);
        
    }
}
