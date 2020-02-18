using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private Transform trans;
	private int maxHealth;
	private int currentHealth;
	private bool isAggro;
	private float aggroRadius;
	private float attackRange;
	private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	//following player
	private void followPlayer(){
		Vector3 towardsPlayer = character.trans.position - trans.position;
		Vector3 towardsSpawnPoint = trans.position - originalSpawnPoint;

		// Are we close enough to attack -> Attack state
		if (towardsPlayer.magnitude < attackRange) {
			//insert some attacking code here (!!!)
			//set the animator to attacking (!!!)
		}
		else{
			//move closer to the player
			//set animator moving (!!!)

			towardsPlayer.Normalize ();
			towardsPlayer *= moveSpeed * Time.deltaTime;

			trans.position += towardsPlayer;
		}
	}
}
