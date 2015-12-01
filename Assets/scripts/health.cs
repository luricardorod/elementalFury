using UnityEngine;
using System.Collections;



public class health : MonoBehaviour {
	public int healthPoints=6;
	private GameObject[] enemies;
	private GameObject[] spawners;
	public GameObject restart;
	public GameObject cameraPlayer;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (healthPoints < 0) {
			Debug.Log("muerto");
			enemies = GameObject.FindGameObjectsWithTag("enemies");
			foreach (GameObject enemy in enemies) {
      	Destroy(enemy);
      }
			spawners = GameObject.FindGameObjectsWithTag("spawner");
			foreach (GameObject spawner in spawners) {
				spawner.SetActive(false);
      	spawner.GetComponent<EnemySpawner>().spawnTime = 10f;
      	spawner.GetComponent<EnemySpawner>().timer = 10f;
      	spawner.GetComponent<EnemySpawner>().enemyNumber = 10;
      }
			healthPoints = 6;
			cameraPlayer.transform.position = new Vector3(0,0,-10);
			gameObject.transform.position= new Vector3(0,0,0);
			restart.transform.position= new Vector3(0,-2.18f,0);
			restart.SetActive(true);
			gameObject.SetActive(false);
		}
	}

}
