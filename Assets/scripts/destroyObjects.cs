using UnityEngine;
using System.Collections;

public class destroyObjects : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerExit2D(Collider2D  other)
	{
		// If the Collider2D component is enabled on the object we collided with
		if (other.gameObject.tag == "bullet") {
			//coll.gameObject.GetComponent <health> = coll.gameObject.GetComponent <health> - damage;
			Destroy(other.gameObject);

		}

	}
}
