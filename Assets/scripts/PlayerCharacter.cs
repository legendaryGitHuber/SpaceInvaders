using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PlayerCharacter : MonoBehaviour
{
    public float movementSpeed;
    public Limits limits;
    public GameObject bullet;
    public Transform SR;
    public Transform SL;
    public Transform SM;
    public float hp;
    private int maxHealth = 10;
    public float shotPower;
    private int power;
    private AudioSource audioS;
    public AudioClip shotSound;

    public int score;
    public int highScore;
    public Text scoreText;
    public Text textForScore;
    //public Text highScoreText;

    public HealthBar healthBar;
    //public Text DeathText;
    // Start is called before the first frame update
    void Start()
    {
       	power = 1;
	audioS = GetComponent<AudioSource>();
 	hp = maxHealth;
	healthBar.SetMaxHealth(maxHealth);

	//if(!PlayerPrefs.HasKey("highscore"))
	//{
	   //highScore = 0;
	    //PlayerPrefs.SetInt("highscore", highScore);
	//}
    }

    // Update is called once per frame
    void Update()
    {
	scoreText.text = score.ToString();
	//highScoreText.text = PlayerPrefs.GetInt("highscore").ToString();
  	//if(score > highScore)
	//{
	    //highScore = score;
	    //PlayerPrefs.SetInt("highscore", highScore);
	//}

        Movement();
        Shooting();
	if(hp <= 0)
	{
	    Destroy(gameObject);
	    EndScreen();    
	}
	transform.position = new Vector3(Mathf.Clamp(transform.position.x, limits.MinX, limits.MaxX), Mathf.Clamp(transform.position.y, limits.MinY, limits.MaxY), 0.0f);
    }

    void Movement()
    {
	if(Input.GetKey(KeyCode.A) || Input.GetKeyDown("left"))
     	{
	    transform.Translate(Vector3.right * -movementSpeed * Time.deltaTime);
	}
	else if(Input.GetKey(KeyCode.D) || Input.GetKeyDown("right"))
     	{
	    transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
	}
	else if(Input.GetKey(KeyCode.W) || Input.GetKeyDown("up"))
     	{
	    transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
	}
	else if(Input.GetKey(KeyCode.S) || Input.GetKeyDown("down"))
     	{
	    transform.Translate(Vector3.up * -movementSpeed * Time.deltaTime);
	}
    }

    void Shooting()
    {
	if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
	{
	    audioS.PlayOneShot(shotSound);
	    switch(power)
	    {
		case 1:
		    {
			GameObject newBullet = Instantiate(bullet, SM.position, transform.rotation);
			newBullet.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
		    }break;
		 case 2:
		    {
			GameObject Bullet1 = Instantiate(bullet, SL.position, transform.rotation);
			Bullet1.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;

			GameObject Bullet2 = Instantiate(bullet, SR.position, transform.rotation);
			Bullet2.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
		    } break;
		 case 3:
		    {
			GameObject Bullet1 = Instantiate(bullet, SL.position, transform.rotation);
			Bullet1.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;

			GameObject Bullet2 = Instantiate(bullet, SM.position, transform.rotation);
			Bullet2.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;

			GameObject Bullet3 = Instantiate(bullet, SR.position, transform.rotation);
			Bullet3.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
		    } break;
		  default:
		    {
			GameObject newBullet = Instantiate(bullet, SM.position, transform.rotation);
			newBullet.GetComponent<Rigidbody>().velocity = Vector3.up * shotPower;
		    } break;
	    }
	}
    }

    void OnTriggerEnter(Collider col)
    {
	if(col.gameObject.tag == "PowerUp")
	{
	    if(power < 3)
	    {
		 power++;
	    }
	    else if(power >= 3 && hp < maxHealth)
	    {
	        hp++;
	  	healthBar.SetHealth(hp);
	    }
	    Destroy(col.gameObject);
	}
	if(col.gameObject.tag == "PowerDown")
	{
	    if(power > 1)
	    {
		 power--;
	    }
	    Destroy(col.gameObject);
	}
    }

    public void EndScreen()
    {
	SceneManager.LoadScene("Start");
    }
}
























