using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float directionTimer;
    public float shotPower;
    public int scoreReward;
    public GameObject particleEffect;
    public GameObject powerUp;
    public GameObject powerDown;
    private float maxTimer;
    public float health;
    public bool canShoot;
    public Transform shotPosition;
    public GameObject bullet;
    private bool dirSwitch;
    private Rigidbody RB;
    float shootTimer;
    float maxShootTimer;
    public Limits limits;

    private HealthBar healthBar;
    private float hp;
    //public GameObject deathText;
    void Start()
    {
	shootTimer = 1.5f;
	maxShootTimer = shootTimer;
	maxTimer = directionTimer;
        RB = GetComponent<Rigidbody>();
	healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }


    void Update()
    {
	Timer();
        Movement();

     	if(transform.position.x == limits.MaxX) switchDir(dirSwitch);
        if(transform.position.x == limits.MinX) switchDir(dirSwitch);
	    transform.position = new Vector3(Mathf.Clamp(transform.position.x, limits.MinX, limits.MaxX), Mathf.Clamp(transform.position.y, limits.MinY, limits.MaxY), 0.0f);
        if(canShoot)
	    shootTimer -= Time.deltaTime;
	    if(shootTimer <= 0)
	    {
	        GameObject newBullet = Instantiate(bullet, shotPosition.transform.position, shotPosition.transform.rotation);
	        newBullet.GetComponent<Rigidbody>().velocity = Vector3.up * -shotPower;
	        shootTimer = maxShootTimer;
	    }

	if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>().hp <= 0)
	{
	    Destroy(gameObject);
	    Instantiate(particleEffect, transform.position, transform.rotation);
	}
    }

    void Movement()
    {
	if(dirSwitch)
	{
            RB.velocity = new Vector3(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
	} else 
	    RB.velocity = new Vector3(-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
    }

    void Timer()
    {
	directionTimer -= Time.deltaTime;
	if(directionTimer <= 0)
	{
	    switchDir(dirSwitch);
	    directionTimer = maxTimer;
	}
    }

     void OnTriggerEnter(Collider col)
     {
	if(col.gameObject.tag == "EnemyBullet")
	    return;
	if(col.gameObject.tag == "friendlyBullet")
	{
	    Destroy(col.gameObject);
	    Instantiate(particleEffect, transform.position, transform.rotation);
	    health--;
	    if(health <= 0)
	    {
		int randomNumber = Random.Range(0, 100);
		if(randomNumber < 30) Instantiate(powerUp, transform.position, powerUp.transform.rotation);
		if(randomNumber > 80) Instantiate(powerDown, transform.position, powerDown.transform.rotation);
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>().score += scoreReward;
	        Destroy(gameObject);
	    }
	}

	if(col.gameObject.tag == "Player")
	{
	    col.gameObject.GetComponent<PlayerCharacter>().hp--;
	    healthBar.SetHealth(col.gameObject.GetComponent<PlayerCharacter>().hp);
	    Instantiate(particleEffect, transform.position, transform.rotation);
	    health--;
	    if(health <= 0)
	 	col.gameObject.GetComponent<PlayerCharacter>().hp--;
	    	Destroy(gameObject);
		//deathText = "you got ramed to death";
	}
     }

     bool switchDir(bool dir)
     {
	  if(dir) dirSwitch = false;
	  else dirSwitch = true;
	  return dirSwitch;
     }
}










