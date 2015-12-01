using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	private string magic = "fire";
	public float refresh = 1f;
	private float bulletX, bulletY;
	private float startRefresh;
	public float velocidadDisparo;
	private float factorUnitario;
	private Camera cam;
	public GameObject magicObject;
	private GameObject cloneMagic;
	public GameObject shootPoint;
	public float bulletSpeed = 7f;

	private Animator anim;


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
				cloneMagic = Instantiate(magicObject, shootPoint.transform.position, Quaternion.identity) as GameObject;
				cloneMagic.transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z - 90);
				bulletX = mousePosition.x - transform.position.x;
				bulletY = mousePosition.y - transform.position.y;
				factorUnitario = Mathf.Sqrt((bulletX * bulletX) + (bulletY * bulletY));
				cloneMagic.GetComponent<Rigidbody2D>().AddForce (new Vector2 (bulletX / factorUnitario, bulletY / factorUnitario) * velocidadDisparo);
				anim = cloneMagic.GetComponent<Animator>();
				switch(magic){
					case "fire":
						cloneMagic.tag = "fireMagic";
						anim.SetInteger("magic",1);
					break;
					case "earth":
						cloneMagic.tag = "earthMagic";
						anim.SetInteger("magic",2);
					break;
					case "metal":
						cloneMagic.tag = "metalMagic";
						anim.SetInteger("magic",3);
					break;
					case "water":
						cloneMagic.tag = "waterMagic";
						anim.SetInteger("magic",4);
					break;
					case "wood":
						cloneMagic.tag = "woodMagic";
						anim.SetInteger("magic",5);
					break;
					default:
					break;
				}
			}
	}
}
