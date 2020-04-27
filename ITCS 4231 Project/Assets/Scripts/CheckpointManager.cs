using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject checkpoint;
	public static int respawnSignal;
    public PotionScript pot;

	void Start (){
		respawnSignal = Random.Range(0, 4);
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player"){
            pot.refillPotions(2);
			Destroy(checkpoint);
		}
	}
}
