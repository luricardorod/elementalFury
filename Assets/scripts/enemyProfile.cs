using UnityEngine;
using System.Collections;

public class enemyProfile : MonoBehaviour {
	public int damage;
	private float timer;
	public	float timerDamageCharly = 5;
	// Use this for initialization
	void Start () {
		timer = timerDamageCharly;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		// If the Collider2D component is enabled on the object we collided with
		if (coll.gameObject.name == "Charly") {
			//coll.gameObject.GetComponent <health> = coll.gameObject.GetComponent <health> - damage;
			gameObject.GetComponent<movementEnemy>().velocidad = 0f;
			if (timer > timerDamageCharly) {
				coll.gameObject.GetComponent <health>().healthPoints = coll.gameObject.GetComponent <health>().healthPoints - damage;
				timer = 0;
			}
		}


	}

	void OnCollisionExit2D(Collision2D coll)
	{
		// If the Collider2D component is enabled on the object we collided with
		if (coll.gameObject.name == "Charly") {
			//coll.gameObject.GetComponent <health> = coll.gameObject.GetComponent <health> - damage;
			gameObject.GetComponent<movementEnemy>().velocidad = 3f;

		}

	}
}
