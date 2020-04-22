﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private Animator anim;
	[SerializeField] private Transform player;
	private Vector3 respawnPoint;
	private bool isDead;
	private EnemyManager enem;
	public HealthbarController healthbar;
	public bool potionRestore;

    // Start is called before the first frame update
    void Start()
    {
        enem = GetComponent<EnemyManager>();
		isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        
        
        /* if(enem.isAttacking == true)
        {
            Debug.Log("Player is being attacked");
            healthbar.OnTakeDamage(enem.attackDamage);

            if(healthbar.currentHealth <= 0)
            {
                playerDeath();
            }

            enem.isAttacking = false;
        }*/
    }

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "EnemyAttack"){

            Debug.Log("Hit by enemy!");

			//set animator trigger for getting hit
			anim.SetTrigger ("playerHit");
			
			Debug.Log("enemy's damage " + enem.attackDamage);
			healthbar.OnTakeDamage(enem.attackDamage);

			//if enemy health drops to zero they're dead
			if (healthbar.currentHealth <= 0){
				playerDeath();
			}
		}
		if (col.gameObject.tag == "Checkpoint"){
			//save a Vector3 value as a place to respawn at
			respawnPoint = col.transform.position;

			//Heal player
			healthbar.currentHealth = healthbar.maxHealth;

			//restore potions
			potionRestore = true;
		}
	}

	void playerDeath(){
		isDead = true;

		//set animator for dying
		anim.SetBool("isDead", true);

		//respawn
		respawn();
	}

	void respawn(){
		player.transform.position = respawnPoint;
		isDead = false;
		healthbar.currentHealth = healthbar.maxHealth;
		anim.SetBool("isDead", false);
	}
}
