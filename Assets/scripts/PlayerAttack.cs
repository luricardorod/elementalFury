using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	private string magic = "fire";
	public float refresh = 3f;
	private float startRefresh;
	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		startRefresh  = refresh;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("1")){
			magic = "fire";
		}
		if (Input.GetKeyDown ("2")){
			magic = "earth";
		}
		if (Input.GetKeyDown ("3")){
			magic = "metal";
		}
		if (Input.GetKeyDown ("4")){
			magic = "water";
		}
		if (Input.GetKeyDown ("5")){
			magic = "wood";
		}
		if (Input.GetKeyDown ("6")){
			magic = "special";
		}

	}

	void FixedUpdate(){
		var mousePosition = cam.ScreenToWorldPoint (Input.mousePosition);

			if (Input.GetMouseButtonDown(0) && Time.time > startRefresh){
				startRefresh = Time.time + refresh;
				switch(magic){
					case "fire":
						Debug.Log("fuego");
					break;
					case "earth":
						Debug.Log("tierra");
					break;
					case "metal":
						Debug.Log("metal");
					break;
					case "water":
						Debug.Log("agua");
					break;
					case "wood":
						Debug.Log("madera");
					break;
					default:
					break;
				}
			}
	}
}
