using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPScript : MonoBehaviour {

    private float alfaCut; //Variável de controle do fill da imagem.
    private float HPmax, HPnow; //HPmax = HP máximo do personagem. HPnow = HP atual do personagem.
    private Image imageCol; //Referência à imagem da HUD.
    private GameObject player; //Referência ao Player.
    private PlayerStats plStats; //Referência ao script PlayerStats.
    //public Color col;

    // Use this for initialization
    void Start()
    {
        alfaCut = 1.0f;
        imageCol = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        plStats = player.GetComponent<PlayerStats>();
        HPmax = plStats.health;
        HPnow = HPmax;
    }

    // Update is called once per frame
    void Update()
    {
        HPnow = plStats.health; //Deixando sempre atualizado o valor da variável HPnow.
        alfaCut = HPnow / HPmax; //Calculo de porcentagem do HP.

        imageCol.fillAmount = alfaCut; //Seta o quanto de fill será dado na imagem. 1 = cheio, 0 = vazio.

        //imageCol.color = Color.Lerp(Color.white, col, 1 - alfaCut);

    }
}
