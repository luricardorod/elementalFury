using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public int puntuacion = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = "Score: " + puntuacion.ToString();
	}
}
