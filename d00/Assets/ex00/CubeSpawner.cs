using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	public string key;
	public float speed = 1;
	public Vector3[] spawnAreas;
	public GameObject[] cubes;
	private GameObject[] cubesInGame;
	private float nextActionTime = 0.0f;
	public float period = 1;
	public float baseY;

	float abs(float value){
		return value >= 0 ? value : -value;
	}
	void Start(){
		cubesInGame = new GameObject[3];
	}

	bool spawnOne(int i){
		if (!cubesInGame[i]){
			GameObject toInstanciate = cubes[i];
			cubesInGame[i] = Instantiate(toInstanciate, spawnAreas[i], Quaternion.identity);
			return true;
		}
		return false;
	}

	void spawnCube(){
		if (!cubesInGame[0] || !cubesInGame[1] || !cubesInGame[2]){
			int i = Random.Range(0, cubes.Length);
			bool hasSpawn = false;
			while (!hasSpawn){
				hasSpawn = spawnOne(i);
				i = i == 2 ? 0 : i + 1;
			}
		}
	}

	void moveCubes(){
		foreach (GameObject cube in cubesInGame){
			if (cube){
				cube.transform.Translate(Vector3.down * Time.deltaTime * speed);
			}
		}
	}

	void handleAction(int i){
		if (cubesInGame[i]){
			float distance = baseY - cubesInGame[i].transform.position.y; 
			Debug.Log("Precision: " + abs(distance));
			Destroy(cubesInGame[i]);
		}
	}

	void handleInput(){
		if (Input.GetKeyDown("a"))
			handleAction(0);
		if (Input.GetKeyDown("s"))
			handleAction(1);
		if (Input.GetKeyDown("d"))
			handleAction(2);
	}

	void cleanCubes(){
		foreach(GameObject cube in cubesInGame){
			if (cube && cube.transform.position.y < 0){
				Destroy(cube);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
    	if (Time.time > nextActionTime ) {
			spawnCube();
			nextActionTime += period;
		}
		moveCubes();
		handleInput();
		cleanCubes();
	}
}
