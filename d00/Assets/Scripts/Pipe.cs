using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
	public Transform bird;
	public Bird birdScript;
	private float gapUp = 1.55f;
	private float gapDown = 1.9f;
	public float speed = 1f;
	private float minY = 3;
	private float maxY = 8;
	private bool passed = false;
	private bool move = true;
	private int score = 0;

	void respawn() {
		Vector3 newPos = new Vector3(4, Random.Range(minY, maxY), 0);
		transform.position = newPos;
		passed = false;
	}

	void endGame() {
		move = false;
		Debug.Log("Score: " + score + "\nTime: 0s");
		birdScript.freeze();
	}
	
	void Update () {
		if (move) {
			transform.Translate(Vector3.left * Time.deltaTime * speed);
			if (transform.position.x < -3 ) {
				respawn();
			}
			if (transform.position.x < 0.8f && transform.position.x > -0.88f) {
				if (bird.position.y < transform.position.y - gapUp || bird.position.y > transform.position.y + gapDown){
					endGame();
				}
			}
			if (transform.position.x < -1 && !passed){
				score += 5;
				passed = true;
			}
		}
	}
}
