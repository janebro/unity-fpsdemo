using UnityEngine;
using System.Collections;

public class WeaponAnimationsScript : MonoBehaviour {

    public string drawAnim, fireLeftAnim, reloadAnim;
    public float drawCD, reloadCD, shootCD;
    public GameObject animationGO;
    public AudioClip drawClip, reloadClip;

    public bool drawWeapon, reloading, shooting;

	// Use this for initialization
	void Start () {
        drawWeapon = reloading = false;
        DrawWeapon();
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetButtonDown("Fire1") && reloading == false && drawWeapon == false)
        //{
        //    Fire();
        //}

        //if (Input.GetKeyDown("r") && reloading == false && drawWeapon == false)
        //{
        //    StartCoroutine(Reloading());
        //}

        //if (Input.GetKeyDown("1") && reloading == false)
        //{
        //    StartCoroutine("DrawWeapon");
        //}      
	}


    public IEnumerator Fire()
    {
        if (!shooting)
        {
            animationGO.GetComponent<Animation>().CrossFadeQueued(fireLeftAnim, 0.08f, QueueMode.PlayNow); //Faz um 'crossfade' da última animação com a atual que queremos tocar.
            shooting = true;
            yield return new WaitForSeconds(shootCD);
            shooting = false;
        }
        
        
    }

    public IEnumerator Reloading()
    {
        if (!reloading)
        {
            GetComponent<AudioSource>().clip = reloadClip;
            GetComponent<AudioSource>().Play();
            animationGO.GetComponent<Animation>().Play(reloadAnim);
            reloading = true;
            yield return new WaitForSeconds(reloadCD);
            reloading = false;
        }
        
    }

    public IEnumerator DrawWeapon()
    {
    	GetComponent<AudioSource>().clip = drawClip;
       	GetComponent<AudioSource>().Play();
        animationGO.GetComponent<Animation>().Play(drawAnim);
        drawWeapon = true;
        yield return new WaitForSeconds(drawCD);
        drawWeapon = false;
    }
}


/*
 * var drawAnim : String = "Draw";
var fireLeftAnim : String = "Fire";
var reloadAnim : String = "Reload";
var animationGO : GameObject;
var drawClip : AudioClip;
var reloadClip : AudioClip;
  
private var drawWeapon : boolean = false;
private var reloading : boolean = false;

function Start (){
    DrawWeapon();
}
 
function Update (){
 
    if(Input.GetButtonDown ("Fire1") && reloading == false && drawWeapon == false){
        Fire();
        }
       
        if (Input.GetKeyDown ("r") && reloading == false && drawWeapon == false){
    Reloading();
        }
       
        if (Input.GetKeyDown ("1") && reloading == false){
        DrawWeapon();
        }      
}
 
function Fire(){
    animationGO.GetComponent.<Animation>().CrossFadeQueued(fireLeftAnim, 0.08, QueueMode.PlayNow);
}
 
function DrawWeapon() {
  if(drawWeapon)
    return;
        GetComponent.<AudioSource>().clip = drawClip;
        GetComponent.<AudioSource>().Play();
        animationGO.GetComponent.<Animation>().Play(drawAnim);
        drawWeapon = true;
        yield WaitForSeconds(0.6);
        drawWeapon = false;
       
}
 
function Reloading(){
     if(reloading) 
     return;
        GetComponent.<AudioSource>().clip = reloadClip;
        GetComponent.<AudioSource>().Play();
        animationGO.GetComponent.<Animation>().Play(reloadAnim);
        reloading = true;
        yield WaitForSeconds(2.0);
        reloading = false;
}
 * 
 * 
*/