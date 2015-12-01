using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {

	private GameObject[] spawners;
	public GameObject Charly;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (gameObject.activeSelf) {
			if (Input.anyKeyDown) {
				Application.LoadLevel(0);
			}
		}
	}
}
