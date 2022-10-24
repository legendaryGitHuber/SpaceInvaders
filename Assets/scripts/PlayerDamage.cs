using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public GameObject particleEffect;
    private HealthBar healthBar;
   
    //private GameObject deathText;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
	//deathText = GameObject.Find("EndText").GetComponent<Text>();
    }

    void OnTriggerEnter(Collider col)
     {
	if(col.gameObject.tag == "friendlyBullet")
	{
	    Destroy(col.gameObject);
	    Instantiate(particleEffect, transform.position, transform.rotation);
	}

	if(col.gameObject.tag == "Player")
	{
	    Instantiate(particleEffect, transform.position, transform.rotation);
	    col.gameObject.GetComponent<PlayerCharacter>().hp--;
	    healthBar.SetHealth(col.gameObject.GetComponent<PlayerCharacter>().hp);
	    //if(col.gameObject.GetComponent<PlayerCharacter>().hp <= 0)
	    //{
		//deathText = "you got shot to death";
      	    //}
	}
     }
}
