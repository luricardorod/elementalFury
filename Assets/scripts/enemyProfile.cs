using UnityEngine;
using System.Collections;

public class enemyProfile : MonoBehaviour {
	public int damage;
	private float timer;
	public	float timerDamageCharly = 2;

	public string enemyElement;
	public int life = 2;

	private Animator anim;

	// Use this for initialization
	void Start () {
		timer = timerDamageCharly;
		anim = GetComponent <Animator>();
		anim.SetBool("moving",true);
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		// If the Collider2D component is enabled on the object we collided with
		if (coll.gameObject.name == "Charly") {
			gameObject.GetComponent<movementEnemy>().velocidad = 0f;
			anim.SetBool("moving",false);
			anim.SetBool("attacking",true);
			if (timer > timerDamageCharly) {
				coll.gameObject.GetComponent <health>().healthPoints = coll.gameObject.GetComponent <health>().healthPoints - damage;
				timer = 0;
			}
		}


	}

	void OnTriggerExit2D(Collider2D coll)
	{
		// If the Collider2D component is enabled on the object we collided with
		if (coll.gameObject.name == "Charly") {
			//coll.gameObject.GetComponent <health> = coll.gameObject.GetComponent <health> - damage;
			gameObject.GetComponent<movementEnemy>().velocidad = 3f;
			anim.SetBool("moving",true);
			anim.SetBool("attacking",false);

		}
}
	//Enemy takes damage
	void OnTriggerEnter2D(Collider2D bullet)
	{
		// If the Collider2D component is enabled on the object we collided with
		if (bullet.gameObject.name == "magicBullet(Clone)") {
			Destroy(bullet.gameObject);
			TakeDamage(bullet);

		}
	}
	void TakeDamage (Collider2D bullet){
		if (bullet.gameObject.tag == enemyElement){
			life ++;
		} else if( enemyElement == "fireMagic") {
			if (bullet.gameObject.tag == "waterMagic") {
				life --;
			}
		} else if( enemyElement == "waterMagic") {
			if (bullet.gameObject.tag == "earthMagic") {
				life --;
			}
		} else if( enemyElement == "earthMagic") {
			if (bullet.gameObject.tag == "woodMagic") {
				life --;
			}
		} else if( enemyElement == "woodMagic") {
			if (bullet.gameObject.tag == "metalMagic") {
				life --;
			}
		} else if( enemyElement == "metalMagic") {
			if (bullet.gameObject.tag == "fireMagic") {
				life --;
			}
		}
		if (life < 1) {
			anim.SetBool ("dead",true);
			Destroy(gameObject,1f);
		}
	}

}
