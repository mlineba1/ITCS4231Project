using System.Collections;
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
       //if player health drops to zero they're dead
		if (healthbar.currentHealth <= 0){
			playerDeath();
		}
    }

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "EnemyAttack"){

            Debug.Log("Hit by enemy!");

			//set animator trigger for getting hit
			anim.SetTrigger ("playerHit");
			
			Debug.Log("enemy's damage " + enem.attackDamage);
			healthbar.OnTakeDamage(enem.attackDamage);

			
		}
		if (col.gameObject.tag == "Checkpoint"){
            //save a Vector3 value as a place to respawn at
            respawnPoint = new Vector3(84, 1, 3);
            string temp = respawnPoint.ToString();
            Debug.Log("Respawn point is: " + temp );

			//Heal player
			healthbar.restoreHealth(healthbar.maxHealth-healthbar.currentHealth);

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
        string temp2 = player.transform.ToString();
        Debug.Log("Respawned at: " + temp2);
		isDead = false;
        healthbar.restoreHealth(healthbar.maxHealth);
        anim.SetBool("isDead", false);
	}
}
