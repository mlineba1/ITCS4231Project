using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA {
    public class Helper : MonoBehaviour
    {
       
        

         public string[] attacks = new string[3];
        


     

       public  Animator anim;


    void Start()
        {
            anim = GetComponent<Animator>();

            //Populate Attack animation Names
            attacks[0] = "atack1 0";
            attacks[1] = "atack2 0";
            attacks[2] = "atack3 0";
        }

        // Update is called once per frame
        void Update()
        {
          

            if (anim.GetBool("Attacking"))
            {
                PlayerAttack();
            }

           
        }

        /// <summary>
        /// Chooses a random attack and sets "Attacking" back to false
        /// </summary>
        void PlayerAttack()
        {
            string targetAnim;
            int r = Random.Range(0, attacks.Length);
            targetAnim = attacks[r];


           
            anim.CrossFade(targetAnim, 0.2f);
            anim.SetBool("Attacking", false);
        }

    }
}