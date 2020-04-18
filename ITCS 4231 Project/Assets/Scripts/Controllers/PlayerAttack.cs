using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        public int damage = 5;

       public void PlayerLightAttackEvent()
       {
        Debug.Log("Player Light Attack executed");


       }

       public void PlayerStrongAttackEvent()
       {
        Debug.Log("Strong attack executed");

       }

    }

