using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {

	public Ball ball; 
	[SerializeField]
	private float maxForce = 10;
	private float force;
	[SerializeField]	
	private float speed = 1;
	private bool prepareShoot = false;
	private Vector3 initialPosition;
	private bool onShot;
	private int score;
	private string direction;
	// Use this for initialization
	void Start () {
		force = 0;
		score = -15;
		direction = "up";
		initialPosition = transform.position;
	}

	public void respawn (Vector3 position, string direction){
		if (onShot){
			if (this.direction != direction){
				transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y *  -1, 1);
				this.direction = direction;
			}
			score += 5;
			force = 0;
			Debug.Log("Score: " + score);
			transform.position = position;
			initialPosition = position;
			onShot = false;
		}
	}

	void Shoot(){
		transform.position = initialPosition;
		ball.onShoot(this.force, direction);
		prepareShoot = false;
		onShot = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space") && ! onShot){
			if (force < maxForce){
				prepareShoot = true;
				force += speed;
				if (direction == "up")
					transform.Translate(Vector3.down * Time.deltaTime * speed);
				else
					transform.Translate(Vector3.up * Time.deltaTime * speed);
			}
		} else if (prepareShoot){
			Shoot();
		}
	}
}
