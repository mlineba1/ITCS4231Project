using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject checkpoint;
	public static int respawnSignal;

	void Start (){
		respawnSignal = Random.Range(0, 4);
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player"){
			Destroy(checkpoint);
		}
	}
}
