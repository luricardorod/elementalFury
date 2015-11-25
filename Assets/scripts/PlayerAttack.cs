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
	public float bulletSpeed = 7f;
	public Sprite spriteFire;
	public Sprite spriteEarth;
	public Sprite spriteMetal;
	public Sprite spriteWater;
	public Sprite spriteWood;


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
				cloneMagic = Instantiate(magicObject, transform.position, Quaternion.identity) as GameObject;
				bulletX = mousePosition.x - transform.position.x;
				bulletY = mousePosition.y - transform.position.y;
				factorUnitario = Mathf.Sqrt((bulletX * bulletX) + (bulletY * bulletY));
				cloneMagic.GetComponent<Rigidbody2D>().AddForce (new Vector2 (bulletX / factorUnitario, bulletY / factorUnitario) * velocidadDisparo);

				switch(magic){
					case "fire":
						cloneMagic.tag = "fireMagic";
						cloneMagic.GetComponent<SpriteRenderer>().sprite = spriteFire;
					break;
					case "earth":
						cloneMagic.tag = "earthMagic";
						cloneMagic.GetComponent<SpriteRenderer>().sprite = spriteEarth;
						Debug.Log("tierra");
					break;
					case "metal":
						cloneMagic.tag = "metalMagic";
						cloneMagic.GetComponent<SpriteRenderer>().sprite = spriteMetal;
						Debug.Log("metal");
					break;
					case "water":
						cloneMagic.tag = "waterMagic";
						cloneMagic.GetComponent<SpriteRenderer>().sprite = spriteWater;
						Debug.Log("agua");
					break;
					case "wood":
						cloneMagic.tag = "woodMagic";
						cloneMagic.GetComponent<SpriteRenderer>().sprite = spriteWood;
						Debug.Log("madera");
					break;
					default:
					break;
				}
			}
	}
}
