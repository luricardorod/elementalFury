using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float spawnTime = 5f;
	public float timer = 5;
	public GameObject[] enemies;
	int enemyNumber = 1;


	public void Start ()
	{
		InvokeRepeating("TimeDeacrease", 0, 2);
	}
	public void Update(){
		timer += Time.deltaTime;
		if (timer > spawnTime){
			for (int i= 0; i < enemyNumber; i++) {
			Spawn();
			}
			timer = 0;
		}
	}

	void Spawn ()
	{
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);

	}
	void TimeDeacrease(){
		if (spawnTime > 0.5f){
					spawnTime -= 0.5f;
		}else{
			spawnTime = 5f;
			enemyNumber ++;
		}
	}
}
