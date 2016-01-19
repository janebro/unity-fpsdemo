using UnityEngine;
using System.Collections;

public class SpiderAnimationsTest : MonoBehaviour {

    public Animator _anim;

    void Start()
    {
        if (_anim == null)
        {
            _anim = GetComponent<Animator>();
        }

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            _anim.SetBool("Moving", true);
        }
        else
        {
            _anim.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _anim.SetTrigger("Attacking");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            _anim.SetTrigger("Dead");
        }
        
    }
}
