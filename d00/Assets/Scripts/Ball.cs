using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Use this for initialization
	private float speed;
	private string direction;
	public Club club;
	public Transform holeTransform;
	private bool win;
	void Start () {
		speed = 0;
		direction = "up";
		win = false;
	}
	public float borderTop;
	public float borderBottom;

	float abs(float value){
		return(value > 0 ? value : -value);
	}
	public void onShoot(float force, string direction){
		this.speed = force;
		this.direction = direction;
	}

	void gameOver(){
		speed = 0;
		win = true;
	}

	void handleHole(){
		float precision = abs(transform.position.y - holeTransform.position.y);
		if (precision < 0.3 && speed < 2){
			gameOver();
		}
	}
	void handleBorders(){
		if (transform.position.y >= borderTop){
			direction = "down";
		} else if (transform.position.y <= borderBottom){
			direction = "up";
		}
	}
	void Move(){
		if (direction == "up")
			transform.Translate(Vector3.up * Time.deltaTime * this.speed);
		else
			transform.Translate(Vector3.down * Time.deltaTime * this.speed);
		speed = speed > 0 ? speed - 0.1f : 0;
		handleHole();
		handleBorders();
	}
	void Update () {
		if (speed > 0)
			Move();
		else if (!win){
			string direction = transform.position.y > holeTransform.position.y ? "down" : "up";
			club.respawn(transform.position, direction);
		}
	}
}
