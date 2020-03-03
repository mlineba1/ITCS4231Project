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
	[SerializeField] private float moveSpeed;
	public int maxHealth;
	public int currentHealth;
	private bool isAggro;
	private bool isMoving;
	private bool isAttacking;
	private Vector3 spawnPoint;
	private int attackType;
	private bool isDead;
	private PlayerAttack pAttack;
	private int playerDamage;

	//private static CharacterManager character; (connect character script to this script !!!)

    // Start is called before the first frame update
    void Start()
    {
		pAttack = GetComponent<PlayerAttack>();
		playerDamage = pAttack.damage;
        spawnPoint = transform.position;
		isDead = false;
		isAggro = false;
		isMoving = false;
		currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
		StartCoroutine (CheckForAggro ());

        if (isAggro==true){
			followPlayer();

			//Debug.Log("enemy is aggro");
		}
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
		if (towardsPlayer.magnitude < attackRange) {
			//set animator to not move
			isMoving = false;
			enemyAnim.SetBool("enemyMoving", false);

			//insert some attacking code here (!!!)

			//set the animator to attacking 
			isAttacking = true;
			enemyAnim.SetBool("enemyAttacking", true);

			//Debug.Log("enemy attack!");

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
			towardsPlayer *= moveSpeed * Time.deltaTime;

			trans.position += towardsPlayer;
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player"){
			//set animator trigger for getting hit
			enemyAnim.SetTrigger ("enemyHit");
			//create script for causing damage to enemy (!!!)
			//TakeDamage(playerDamage);
		}
	}

	public void TakeDamage(int amount){
		//nothing happens if enemy is dead
		if(isDead)
			return;

		currentHealth -= amount;

		//if enemy health drops to zero they're dead
		if (currentHealth <= 0){
			enemyKilled();
		}
	}

	void enemyKilled(){
		isDead = true;
		enemyAnim.SetBool("enemyDead", true);
	}

	public void EnemyRespawn(){
	
	}
}
