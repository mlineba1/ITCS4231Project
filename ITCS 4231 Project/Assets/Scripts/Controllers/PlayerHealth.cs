using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private Animator anim;
	private bool isDead;
	public int maxHealth;
	public int currentHealth;
	private EnemyManager enem;
	private int enemyDamage;

    // Start is called before the first frame update
    void Start()
    {
        enem = GetComponent<EnemyManager>();
		enemyDamage = enem.attackDamage;
		isDead = false;
		currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Enemy"){
			//set animator trigger for getting hit
			anim.SetTrigger ("playerHit");
			
			TakeDamage(enemyDamage);
		}
	}

	public void TakeDamage(int amount){
		//nothing happens if enemy is dead
		if(isDead)
			return;

		currentHealth -= amount;

		//if enemy health drops to zero they're dead
		if (currentHealth <= 0){
			playerDeath();
		}
	}

	void playerDeath(){
		isDead = true;

		//set animator for dying
		anim.SetBool("isDead", true);
	}
}
