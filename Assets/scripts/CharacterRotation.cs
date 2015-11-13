using UnityEngine;
using System.Collections;

public class CharacterRotation : MonoBehaviour {
	// Use this for initialization
	Camera cam;
	void Start () {
		cam = Camera.main;
	}

	// Update is called once per frame
	void FixedUpdate () {
		var mousePosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);

	}
}
