using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public int lightDamage = 10;
    public int heavyDamage = 17;
    public bool canHit;
    public bool lightHit;
    public bool heavyHit;
   

    public void PlayerLightAttackEvent()
    {

        if (canHit)
        {
          //  Debug.Log("Player Light Attack hit enemy");
            lightHit = true;

        } else
        {
            //Debug.Log("No enemy in front of player");
        }
        


    }

    public void PlayerStrongAttackEvent()
    {
        if (canHit)
        {
           // Debug.Log("Player Strong Attack hit enemy");
            heavyHit = true;
        }
        else
        {
           // Debug.Log("No enemy in front of player");
        }

    }

}

