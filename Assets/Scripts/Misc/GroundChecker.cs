using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

    private bool onGround;

	// Use this for initialization
	void Start () {
        onGround = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool isGrounded()//Apenas retorna o estado do objeto.
    {
        return onGround;
    }

    void OnTriggerEnter(Collider other) //Método herdado de MonoBehaviour. Esse método irá dizer se colidimos com alguma coisa (Na entrada).
    {
        //Debug.Log(other.gameObject.tag + " - Trigger");
        if (other.gameObject.tag == "Ground") //Se o objeto colidido tem a tag "Ground", põe onGround em true.
        {
            onGround = true;
        }
    }

    void OnTriggerExit(Collider other) //(Na saída).
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
