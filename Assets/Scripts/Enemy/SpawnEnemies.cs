using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

    public GameObject[] enemies; //Vetor de prefab de inimigos.

    public float spawnTimer, spawnCD;//SpawnTimer = contador de tempo do spawn; spawnCD = intervalo entre um novo inimigo e outro.
    public bool startSpawner; //Para fazer o controle se devemos começar a instanciar os inimigos ou não.

    public int enemiesAmount, enemiesWave; //enemiesAmount = Contador de inimigos que já foram instanciados nessa 'wave'. enemiesWave = Quantidade de inimigos que serão instanciados nessa 'wave'. 


    private GameObject newEnemy;

	// Use this for initialization
	void Start () {
        spawnTimer = spawnCD;
        enemiesAmount = enemiesWave;
	}
	
	// Update is called once per frame
	void Update () {

        if (startSpawner)
        {
            spawnTimer -= Time.deltaTime; //Decremento do nosso contador.

            if (spawnTimer < 0) //Quando o contador for menor do que zero é hora de instanciar um novo inimigo.
            {
                SpawnEnemy(); //Chama o método de instanciar inimigo;
                spawnTimer = spawnCD; //Reseta o nosso contador para o valor padrão dele.
            }

        }

        if (enemiesAmount == 0)
        {
            startSpawner = false;
            enemiesAmount = enemiesWave;
        }

	}

    private void SpawnEnemy()
    {
        newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)]); //Instancia um novo objeto e guarda a referencia dele na variável newEnemy;
        newEnemy.transform.position = transform.position; //Atribui a posição do novo inimigo para a posição do objeto que esse script está adicionado.
        enemiesAmount--; //Decrementa em uma unidade a quantidade de inimigos que devemos instanciar;
    }
}
