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

	public void restoreHealth(float amountRestored){
		if(currentHealth < maxHealth){
            Debug.Log("Healing Damage, current health: "+ currentHealth);
			currentHealth = currentHealth + amountRestored;
            Healthbar.fillAmount = currentHealth / maxHealth;
            Debug.Log("Healing Damage, current health: " + currentHealth);
        } else
        {
            Debug.Log("Healing no Damage! current health: "+ currentHealth);
            currentHealth = maxHealth;
            Healthbar.fillAmount = currentHealth / maxHealth;
            Debug.Log("Healing no Damage! current health: " + currentHealth);
        }
	}
}
