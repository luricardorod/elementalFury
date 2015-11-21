using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	private string magic = "fire";
	public float refresh = 1f;
	private float startRefresh;
	private Camera cam;
	public GameObject magicObject;
	private GameObject cloneMagic;
	public float bulletSpeed = 7f;


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

		shoot();

	}

	void shoot(){
		var mousePosition = cam.ScreenToWorldPoint (Input.mousePosition);

			startRefresh += Time.deltaTime;

			if (Input.GetMouseButtonDown(0) && startRefresh > refresh){
				startRefresh = 0;

				switch(magic){
					case "fire":
					cloneMagic = Instantiate(magicObject, transform.position, Quaternion.identity) as GameObject;

					float z = Mathf.Atan2 ((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg -90;
					cloneMagic.transform.eulerAngles = new Vector3 (0,0,z);
					cloneMagic.GetComponent<Rigidbody2D>().AddForce(cloneMagic.transform.up * bulletSpeed);

					cloneMagic.tag = "fireMagic";
					Destroy(cloneMagic.gameObject, 5f);

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
