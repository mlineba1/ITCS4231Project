using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
	public Image Healthbar;
	public float maxHealth;
	public float currentHealth;

    


    public void OnTakeDamage(int damage){
		currentHealth = currentHealth - damage;


        if(currentHealth <= 0)
        {
            Healthbar.fillAmount = 0;
        } else
        {
            Healthbar.fillAmount = currentHealth/maxHealth;
        }

		
	}

	public void restoreHealth(int amountRestored){
		if(currentHealth < maxHealth){
			currentHealth = currentHealth + amountRestored;
		}
	}
}
