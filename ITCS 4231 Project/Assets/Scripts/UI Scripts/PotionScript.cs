using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionScript : MonoBehaviour
{
	[SerializeField] private HealthbarController playerHealthbar;
	[SerializeField] private PlayerHealth ph;
	Text pText;
	public static int potionCount;

    // Start is called before the first frame update
    void Start()
    {
		pText = GetComponent<Text>();
        potionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
		if(potionCount<=0){
			pText.text = "x" + 0;
		}
		else{
			pText.text = "x" + potionCount;
		}

		if (Input.GetKeyDown(KeyCode.F)){
			usePotion();
		}

		if(ph.potionRestore == true){
			refillPotions(2);
			ph.potionRestore = false;
		}
        
    }

	void usePotion(){
		
		
        if (potionCount > 0)
        {
            potionCount = potionCount - 1;
            playerHealthbar.restoreHealth(25);
        } else
        {

        }
	}

	public void refillPotions(int refillAmount){
		potionCount = potionCount + refillAmount;
	}
}
