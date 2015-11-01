using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	private Transform player;
	public float smoothing = 5f;

		void Start () {
			player = GameObject.Find ("Charly").transform;
		}

	     void FixedUpdate() {
	         if (player) {
	             var playerPos = player.position;
	             Vector3 trackPos = new Vector3(playerPos.x, playerPos.y, -10);
							 transform.position = Vector3.Lerp (transform.position, trackPos, smoothing * Time.deltaTime);
	         }
	     }
}
