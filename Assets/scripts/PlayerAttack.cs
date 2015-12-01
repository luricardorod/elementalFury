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
	public GameObject magicSelected;
	public float bulletSpeed = 7f;

	private Animator anim;

	public Sprite spriteFire;
	public Sprite spriteEarth;
	public Sprite spriteMetal;
	public Sprite spriteWater;
	public Sprite spriteWood;
	public Sprite spriteSpecial;


	// Use this for initialization
	void Start () {
		cam = Camera.main;
		startRefresh  = refresh;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("1")){
			magicSelected.GetComponent<SpriteRenderer>().sprite = spriteFire;
			magic = "fire";
		}
		if (Input.GetKeyDown ("2")){
			magic = "earth";
			magicSelected.GetComponent<SpriteRenderer>().sprite = spriteEarth;
		}
		if (Input.GetKeyDown ("3")){
			magic = "metal";
			magicSelected.GetComponent<SpriteRenderer>().sprite = spriteMetal;
		}
		if (Input.GetKeyDown ("4")){
			magic = "water";
			magicSelected.GetComponent<SpriteRenderer>().sprite = spriteWater;
		}
		if (Input.GetKeyDown ("5")){
			magic = "wood";
			magicSelected.GetComponent<SpriteRenderer>().sprite = spriteWood;
		}
		if (Input.GetKeyDown ("6")){
			magic = "special";
			magicSelected.GetComponent<SpriteRenderer>().sprite = spriteSpecial;
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
				cloneMagic.GetComponent<Rigidbody2D>().AddForce (new Vector2 (bulletX / factorUnitario, bulletY / factorUnitario) * velocidadDisparo);
			}
	}
}
