using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float speedUp = 5f;
	public float speedDown = 1f;
	private bool move;
	// Use this for initialization
	void Start () {
		move = true;
	}
	public void freeze() {
		Debug.Log("hey");
		move = false;
	}
	// Update is called once per frame
	void Update () {
		if (move) {
			if (Input.GetKey("space")) {
				transform.Translate(Vector3.up * Time.deltaTime * speedUp);
			} else {
				transform.Translate(Vector3.down * Time.deltaTime * speedDown);
			}
		}
	}
}
