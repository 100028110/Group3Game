using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthManger : MonoBehaviour
{
	public Image HealthBar;
	public float HealthAmount = 100f;
	private float lastHealth;
	public float damage_amount;
	public float Heal_amount;
    // Start is called before the first frame update
    void Start()
    {
		lastHealth = HealthAmount;
		StartCoroutine("Heal");
    }

    // Update is called once per frame
    void Update()
    {
		if(HealthAmount < lastHealth){
			takeDamage(damage_amount);
		}

		if (HealthAmount <= 0)
		{
			SceneManager.LoadScene("Death");
		}
    }

	public void takeDamage(float damage){
		HealthAmount -= damage;
		HealthBar.fillAmount = HealthAmount/100f;
		lastHealth = HealthAmount;
		
	}
	
	public IEnumerator  Heal(){
		while (true)
		{
			HealthAmount += Heal_amount;
			HealthAmount = Mathf.Clamp(HealthAmount,0,100);
			HealthBar.fillAmount = HealthAmount/100f;
			lastHealth = HealthAmount;
			yield return new WaitForSeconds(2);
		}
	}
}
