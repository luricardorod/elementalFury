using UnityEngine;
using System.Collections;

public class enemyProfile : MonoBehaviour {
	public int damage; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		// If the Collider2D component is enabled on the object we collided with
		if (coll.gameObject.name == "Charly") {
			//coll.gameObject.GetComponent <health> = coll.gameObject.GetComponent <health> - damage;
			coll.gameObject.GetComponent <health>().healthPoints = coll.gameObject.GetComponent <health>().healthPoints - damage;
		}
		
	}
}
