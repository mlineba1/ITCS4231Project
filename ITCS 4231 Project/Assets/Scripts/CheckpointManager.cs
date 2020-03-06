using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject checkpoint;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player"){
			Destroy(Checkpoint);
		}
	}
}
