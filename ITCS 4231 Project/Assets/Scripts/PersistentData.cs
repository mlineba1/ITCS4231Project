using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData instance;

        private void Awake()
        {
                //If it doesnt exist, this is the first
                if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
                //If it does exist, delete the duplicate
                else
            {
            Destroy(gameObject);
            }

        }
   
}
