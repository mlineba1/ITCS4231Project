using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
	public Image Healthbar;
	public float maxHealth;
	public float currentHealth;

    public void OnTakeDamage(int damage){
		currentHealth = maxHealth - damage;
		Healthbar.fillAmount = currentHealth/maxHealth;
	}
}
