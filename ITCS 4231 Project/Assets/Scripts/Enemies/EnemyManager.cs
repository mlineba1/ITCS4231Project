using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private Animator enemyAnim;
	[SerializeField] private Transform trans;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float attackRange;
	[SerializeField] private float aggroRadius;
    [SerializeField] private Transform playerTrans;
	[SerializeField] private float moveSpeed;
	[SerializeField] private int smallDamage;
	[SerializeField] private int bigDamage;
	[SerializeField] private int enemyType;
	public int attackDamage;
	private bool isAggro;
	private bool isMoving;
	public bool isAttacking;
	private Vector3 spawnPoint;
	private int attackType;
	private int respawnNum;
	private bool isDead;
    private bool attackCD;
	public PlayerAttack pAttack;
	private int playerLightDamage;
    private int playerHeavyDamage;
	private float turnSpeed;
	public HealthbarController enemyHealthbar;
    public HealthbarController playerHealthbar;

	//private static CharacterManager character; (connect character script to this script !!!)

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		
		playerLightDamage = pAttack.lightDamage;
        playerHeavyDamage = pAttack.heavyDamage;
        spawnPoint = transform.position;
		isDead = false;
		isAggro = false;
		isMoving = false;
		turnSpeed = 5f;
        attackCD = true;
		respawnNum = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
		StartCoroutine (CheckForAggro ());

        if (isAggro==true && !isDead){
			followPlayer();

            //Debug.Log("enemy is aggro");

            if (pAttack.lightHit)
            {
                Debug.Log("Enemy Takes damage");
                enemyHealthbar.OnTakeDamage(playerLightDamage);


                if (enemyHealthbar.currentHealth <= 0)
                {
                    enemyKilled();
                }

                pAttack.lightHit = false;
            }


            if (pAttack.heavyHit)
            {
                Debug.Log("Enemy Takes Heavy damage");
                enemyHealthbar.OnTakeDamage(playerHeavyDamage);


                if (enemyHealthbar.currentHealth <= 0)
                {
                    enemyKilled();
                }

                pAttack.heavyHit = false;
            }



        }

        

    }

	IEnumerator CheckForAggro(){
		while (isAggro == false){
			yield return new WaitForSeconds(1f);

			// Check distance to aggro (!!!)
			float d = Vector3.Distance (trans.position, playerTrans.position); 

			if (d < aggroRadius && isDead == false) {
				isAggro = true;
			}
		}
	
	}

	//following player
	private void followPlayer(){

        Vector3 towardsPlayer = playerTrans.position - trans.position;
		Vector3 towardsSpawnPoint = trans.position - spawnPoint;

		// Are we close enough to attack -> Attack state
		if (towardsPlayer.magnitude < attackRange) {
			//face the Player
			facePlayer();

			//set animator to not move
			isMoving = false;
			enemyAnim.SetBool("enemyMoving", false);

			//bigger enemy attack
			if (enemyType == 2){
			//	Debug.Log("Big enemy");
				//1 in 4 chance of a big attack from an enemy
				attackType = Random.Range(0, 4);

                if (attackType < 3)
                {
                    //Debug.Log("Small attack");
                    //set the animator to attacking 


                    if (attackCD)
                    {
                        enemyAnim.SetBool("enemyAttacking", true);
                        playerHealthbar.OnTakeDamage(smallDamage);
                        EnemySmallAttackEvent();
                        attackCD = false;
                        Invoke("attackCooldown", 2);
                    }
                }
				else {
					//Debug.Log("Big attack");
					//set the animator to attacking 
					
                    
                    if (attackCD)
                    {
                        enemyAnim.SetBool("enemyBigAttacking", true);
                        playerHealthbar.OnTakeDamage(bigDamage);
                        EnemyBigAttackEvent();
                        attackCD = false;
                        Invoke("attackCooldown", 2);
                    }


                }
			}
			//basic enemy attack
			else{
                //set the animator to attacking 
                if (attackCD)
                {
                    enemyAnim.SetBool("enemyAttacking", true);
                    playerHealthbar.OnTakeDamage(smallDamage);
                    EnemySmallAttackEvent();
                    attackCD = false;
                    Invoke("attackCooldown", 2);
                }
            }
			
		}
		else{
			//move closer to the player
			isMoving = true;

			if (enemyType == 2){
				enemyAnim.SetBool("enemyAttacking", false);
				enemyAnim.SetBool("enemyBigAttacking", false);
			}
			else{
				enemyAnim.SetBool("enemyAttacking", false);
			}

			//set animator for moving
			enemyAnim.SetBool("enemyMoving", true);

			towardsPlayer.Normalize ();
			//towardsPlayer *= moveSpeed * Time.deltaTime;

            //trans.position += towardsPlayer;

            rb.AddForce(towardsPlayer * moveSpeed);
        }
	}

    public void EnemySmallAttackEvent()
    {
        attackDamage = smallDamage;
        isAttacking = true;
    }

    public void EnemyBigAttackEvent()
    {
        attackDamage = bigDamage;
        isAttacking = true;
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Sword")
        {

            Debug.Log("Hit by player hitbox");
            pAttack.canHit = true;

            



        }



			
            
            
            
            
            //set animator trigger for getting hit
			//enemyAnim.SetTrigger ("enemyHit");
			
			//enemyHealthbar.OnTakeDamage(pAttack.damage);

			//if enemy health drops to zero they're dead
			
		
	}

     void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Sword")
        {
            Debug.Log("No longer in player hitbox");
            pAttack.canHit = false;
        }

    }



    void enemyKilled(){
		isDead = true;
		enemyAnim.SetBool("enemyDead", true);
	}

	public void EnemyRespawn(){
		if (respawnNum == CheckpointManager.respawnSignal){

			isDead = false;
			enemyHealthbar.currentHealth = enemyHealthbar.maxHealth;
			enemyAnim.SetBool("enemyDead", false);
		}
	}

	void facePlayer(){
		Vector3 towardsPlayer = playerTrans.position - trans.position;
		towardsPlayer.y = 0f;

		Quaternion targetRotation = Quaternion.LookRotation (towardsPlayer);
		trans.rotation = Quaternion.Lerp (trans.rotation, targetRotation, turnSpeed * Time.deltaTime);





	}

    public void attackCooldown()
    {
        attackCD = true;
    }


}
