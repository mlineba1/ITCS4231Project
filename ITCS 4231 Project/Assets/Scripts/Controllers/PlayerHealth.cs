using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private Animator anim;
	private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Enemy"){
			//set animator trigger for getting hit
			anim.SetTrigger ("playerHit");
			//create script for causing damage to player (!!!)
		}
	}

	void playerDeath(){
		isDead = true;

		//set animator for dying
		anim.SetBool("isDead", true);
	}
}
