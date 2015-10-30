using UnityEngine;
using System.Collections;

public class CarracterControl : MonoBehaviour {

	// Use this for initialization
	public float velocidad = 10f;
	private float moveX = 0f;
	private float moveY = 0f;

	void Start () {
	
	}
	
	void FixedUpdate () {
		moveX = Input.GetAxis ("Horizontal");
		moveY = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * velocidad, moveY * velocidad);

	}
	
}
