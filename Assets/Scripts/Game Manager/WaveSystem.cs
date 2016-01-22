using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSystem : MonoBehaviour {

    public int enemiesTotal; //Quantidade total de inimigos nessa wave.
    public float timeBetweenWaves; //Tempo entre uma wave e outra. (Só começa a contar quando todos os inimigos da wave atual morrerem). 
    private float timeBetweenWavesCount; //Count é o contador.

    public int[] EnemiesPerSpawner; //O tamanho vetor será a quantidade de waves e em cada posição será a quantidade de inimigos para spawnar em cada spawner.
    public int waveIndex; //Um índice para sabermos em que waves estamos.

    public bool endGame;
	// Use this for initialization
	void Start () {
        timeBetweenWavesCount = timeBetweenWaves;
        waveIndex = -1; //Começa em -1, pois temos um incremento logo no começo. Sem isso, iriamos começar da wave numero 2.
        endGame = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (enemiesTotal <= 0 && endGame == false)//Se todos os inimigos da Wave já morreram e o jogo não tiver terminado, começa a contagem regressiva pra próxima wave.
        {
            timeBetweenWavesCount -= Time.deltaTime;

            if (timeBetweenWavesCount < 0) //Hora de spawnar a próxima wave.
            {
                if (waveIndex + 1 <= EnemiesPerSpawner.Length) //Se não estivermos na última wave, chama a próxima wave, se não, termina o jogo.
                {
                    waveIndex++;
                    StartTheSpawners();
                }
                else
                {
                    endGame = true;
                }

                timeBetweenWavesCount = timeBetweenWaves;
            }
        }

	}

    private void StartTheSpawners()//Faz um loop em todos os spawners que são "filhos" desse GameObject e seta o startSpawner deles pra true.
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpawnEnemies>().SetNextWave(EnemiesPerSpawner[waveIndex]); //Seta a quantidade de inimigos da próxima wave de acordo com nosso vetor de Waves.
            child.GetComponent<SpawnEnemies>().startSpawner = true;
        }
    }

    public void AddEnemy()
    {
        enemiesTotal++;
    }

    public void RemoveEnemy()
    {
        enemiesTotal--;
    }

}
