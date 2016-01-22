using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public float health = 100; //Vida do jogador;
    private bool isColliding;

	// Use this for initialization
	void Start () {
        isColliding = false;
	}
	
	// Update is called once per frame
	void Update () {
        isColliding = false;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyAttack")
        {

            health -= 10;
            other.gameObject.SetActive(false); //Desativa o collisor que atingiu o jogador para evitar que aconteça uma nova colisão inesperada.

        }
    }
}
