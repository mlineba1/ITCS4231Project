using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA {
    public class Helper : MonoBehaviour
    {
       
        

         public string[] lightAttacks = new string[2];
        public string[] strongAttacks = new string[1];
        



        public  Animator anim;


    void Start()
        {
            anim = GetComponent<Animator>();

            //Populate Attack animation Names
            strongAttacks[0] = "atack1 0";
            lightAttacks[0] = "atack2 0";
            lightAttacks[1] = "atack3 0";
        }

        // Update is called once per frame
        void Update()
        {
          

            if (anim.GetBool("LightAttack"))
            {
                LightPlayerAttack();
            } else if(anim.GetBool("StrongAttack"))
            {
                StrongPlayerAttack();
            }

           
        }

        /// <summary>
        /// Chooses a random attack and sets "Attacking" back to false
        /// </summary>
        void LightPlayerAttack()
        {
            string targetAnim;
            int LA = Random.Range(0, 2); // range for number of attacks
            
            targetAnim = lightAttacks[LA];
            Debug.Log("Light Attack" + LA + " Used.");
         
            anim.CrossFade(targetAnim, 0.2f);
            anim.SetBool("LightAttack", false);
        }

        void StrongPlayerAttack()
        {
            string targetAnim;
            int SA = Random.Range(0, 0);// range for number of attacks
            
            targetAnim = strongAttacks[SA];
            Debug.Log("Strong Attack" + SA + " Used.");

            anim.CrossFade(targetAnim, 0.2f);
            anim.SetBool("StrongAttack", false);
        }

    }
}