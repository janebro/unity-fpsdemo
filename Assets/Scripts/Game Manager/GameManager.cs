using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject menuCamera;

    public bool gameOver, gameWin; //gameOver = perdeu o jogo. gameWin = venceu o jogo.

    void Start()
    {
        gameOver = gameWin = false;
    }

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Return)) {
			player.SetActive (true);
			menuCamera.SetActive (false);
		}

        if (gameOver)
        {
            //Chama tela de "perdeu".
        }

        if (gameWin)
        {
            //Chama tela de "ganhou".
        }
	}

    public void YouLose()
    {
        gameOver = true;
        gameWin = false; //Só por uma questão de precaução.
    }

    public void YouWin()
    {
        gameWin = true;
        gameOver = false; //Só por uma questão de precaução.
    }
}
