using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawningController : MonoBehaviour
{
    public Limits Limits;
    public GameObject pinkEnemy;
    public GameObject greenEnemy;
    public GameObject hugeEnemy;
    public float spawnTimer;
    float maxSpawnTimer;
    // Start is called before the first frame update
    void Start()
    {
	SpawnEnemy();
	maxSpawnTimer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        GameEnded();

	spawnTimer -= Time.deltaTime;
	if(spawnTimer <= 0)
	{
	    SpawnEnemy();
	    spawnTimer = maxSpawnTimer;
	}
    }

    void SpawnEnemy()
    {
	int randomNumber = Random.Range(0, 3);
	//int randomNumber = 2;
	switch(randomNumber)
	    {
            default: 
		 Instantiate(pinkEnemy, new Vector3(Random.Range(Limits.MinX, Limits.MaxX), 15, 0), pinkEnemy.transform.rotation); 
	         break;

	    case 0: {
	           Instantiate(pinkEnemy, new Vector3(Random.Range(Limits.MinX, Limits.MaxX), 15, 0), pinkEnemy.transform.rotation); 
	        } break;

	    case 1: {
	           Instantiate(greenEnemy, new Vector3(Random.Range(Limits.MinX, Limits.MaxX), 15, 0), greenEnemy.transform.rotation); 
	         } break;

	    case 2: { 
	          Instantiate(hugeEnemy, new Vector3(Random.Range(Limits.MinX, Limits.MaxX), 15, 0), hugeEnemy.transform.rotation);
	        } break; 

	    case 3: { 
	          Instantiate(hugeEnemy, new Vector3(Random.Range(Limits.MinX, Limits.MaxX), 15, 0), hugeEnemy.transform.rotation);
	        } break;
	    }  
    } 

    public void GameEnded()
    {
	if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>().hp <= 0)
	{
	    this.gameObject.SetActive(false);
	}
    }  
}
