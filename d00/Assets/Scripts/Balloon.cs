using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	public float inflateSpeed = 0.1f;
	public float decreaseSpeed = 0.01f;
	public float breathMax = 10;
	public float breath = 10;
	public float breathLoss = 1;
	public float breathRegain = 0.5f;
	private bool outOfBreath = false;
	private float time = 0;
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(5, 5, 0);
	}

	void handleBreath(){
		breath = breath < 0 ? 0 : breath;
		breath = breath > 10 ? 10 : breath;
		if (breath == 0){ 
			outOfBreath = true;
		}
		if (breath >= 5)
			outOfBreath = false;
	}

	void handleBalloonState(){
		if (transform.localScale.x > 6 || transform.localScale.x < 0.3){
			Destroy(gameObject);
			Debug.Log("Balloon life time : " + Mathf.RoundToInt(time) + "s");
		}
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (Input.GetKeyDown("space") && !outOfBreath){
			transform.localScale += new Vector3(inflateSpeed, inflateSpeed, 0);
			breath -= breathLoss;
		}else{
			transform.localScale -= new Vector3(decreaseSpeed, decreaseSpeed, 0);
			breath += breathRegain;
		}
		handleBalloonState();
		handleBreath();
	}
}
