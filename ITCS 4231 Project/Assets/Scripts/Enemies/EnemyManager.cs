using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private Animator enemyAnim;
	[SerializeField] private Transform trans;
	[SerializeField] private float attackRange;
	[SerializeField] private float aggroRadius;
    [SerializeField] private Transform playerTrans;
	private int maxHealth;
	private int currentHealth;
	private bool isAggro;
	private bool isMoving;
	private bool isAttacking;
	private Vector3 spawnPoint;
	private int attackType;
	private bool isDead;

	//private static CharacterManager character; (connect character script to this script !!!)

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
		isDead = false;
		isAggro = false;
		isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator CheckForAggro(){
		while (isAggro == false){
			yield return new WaitForSeconds(1f);

			// Check distance to aggro (!!!)
			float d = Vector3.Distance (trans.position, playerTrans.position); 

			if (d < aggroRadius) {
				isAggro = true;
			}
		}
	
	}

	//following player
	private void followPlayer(){
		
		Vector3 towardsPlayer =playerTrans.position - trans.position;
		Vector3 towardsSpawnPoint = trans.position - spawnPoint;

		// Are we close enough to attack -> Attack state
		if (isAggro==true && towardsPlayer.magnitude < attackRange) {
			//set animator to not move
			isMoving = false;
			enemyAnim.SetBool("enemyMoving", false);

			//insert some attacking code here (!!!)

			//set the animator to attacking 
			isAttacking = true;
			enemyAnim.SetBool("enemyAttacking", true);

			//set up script for different attack types (!!!)
			//set animator for the big attack
			//enemyAnim.SetBool("enemyBigAttacking", true);
		}
		else{
			//move closer to the player
			isMoving = true;
			//set animator for moving
			enemyAnim.SetBool("enemyMoving", true);

			towardsPlayer.Normalize ();
			//towardsPlayer *= moveSpeed * Time.deltaTime;

			trans.position += towardsPlayer;
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player"){
			//set animator trigger for getting hit
			enemyAnim.SetTrigger ("enemyHit");
			//create script for causing damage to enemy (!!!)
		}
	}

	//Work on a health system for enemy (!!!)
	void enemyKilled(){
		isDead = true;
		enemyAnim.SetBool("enemyDead", true);
	}
}
