using UnityEngine;
using System.Collections;

public class movementEnemy : MonoBehaviour {

	private Transform player;
	public float smoothing = 3f;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Charly").transform;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
			if (player) {

				transform.Rotate( Vector3.forward * 1);
				transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);

				transform.position = Vector3.Lerp(transform.position,  player.position, smoothing * Time.deltaTime);

			}
	}
}
