using UnityEngine;
using System.Collections;

public class SpiderNavMeshAnim : MonoBehaviour {

    public GameObject attackGameObject;

    private Animator anim; //Referencia ao componente de animação.
    private UnityEngine.AI.NavMeshAgent agent; //Referencia ao componente NavMeshAgent.
    private EnemyStats enemyStats; //Referencia ao componente EnemyStats.
    private GroundChecker groundChk; //Referencia para o GroundChecker (O uso é explicado mais em baixo).

    private bool moving;
    private bool attacking;
    private bool dead;

    private float speedBlend;
    private float speed;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyStats = GetComponent<EnemyStats>();
        groundChk = GetComponentInChildren<GroundChecker>();

        dead = false;    
        speed = enemyStats.speed;
	}
	
	// Update is called once per frame
	void Update () {

        if (agent.enabled && dead == false) //Todo o comportamento só pode ser iniciado se o component NavMeshAgent estiver enable, para evitar erros.
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
                attacking = true;
                moving = false;
                anim.SetTrigger("Attacking"); //Ativa animação de ataque.
            }

            if (attacking == true) //Se tiver atacando, seta moving para falso. (Aqui é só relativo à animação, o objeto irá se locomover ainda).
            {
                anim.SetBool("Moving", false); //Seta a variável Moving no Animator desse componente para o valor de moving.
                anim.SetFloat("Speed", speedBlend);//Seta a variável Speed no Animator desse componente para o valor de speedBlend.
            }
            else
            {
                anim.SetBool("Moving", moving); //Seta a variável Moving no Animator desse componente para o valor de moving.
                anim.SetFloat("Speed", speedBlend);//Seta a variável Speed no Animator desse componente para o valor de speedBlend
            }

            if (enemyStats.health <= 0)//Se a vida do inimigo for menor ou igual a 0, chama a animação de morrer.
            {
                SpiderDeath();
            }

        }

	}

    public void AttackTrigger(int value)//Essa função será chamada no evento da animação. Se for 1, ativa o componente para fazer a colisão com o jogador, se for 0 desativa.
    {
        if(value == 1)
        {
            attackGameObject.SetActive(true);
        }
        else
        {
            attacking = false;
            attackGameObject.SetActive(false);
        }   
    }

    private void SpiderDeath()
    {
        anim.SetTrigger("Dead");
        anim.SetBool("Moving", false);
        dead = true;
        agent.speed = 0; //Seta a velocidade do agent pra zero, assim ele não fica nos seguindo depois de morrer.
        NotifyWaveSystem(); //Notifica ao sistema de waves que essa unidade morreu.
        Destroy(gameObject, 2f); //Destroy o objeto depois de 2 segundos;
    }

    private void NotifyWaveSystem()
    {
        GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>().enemiesTotal--;
    }
}
