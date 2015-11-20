using UnityEngine;
using System.Collections;

public class movementEnemy : MonoBehaviour {

	private Transform player;
	public float velocidad = 3f;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Charly").transform;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
			if (player) {

				float z = Mathf.Atan2 ((player.position.y - transform.position.y), (player.position.x - transform.position.x)) * Mathf.Rad2Deg -90;
				transform.eulerAngles = new Vector3 (0, 0, z);

				transform.position = Vector3.MoveTowards(transform.position,  player.position, velocidad * Time.deltaTime);
			}
	}
}
