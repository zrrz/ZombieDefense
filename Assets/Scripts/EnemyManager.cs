using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	// TODO build out a table or scriptableObject for each level that details how many and what type of enemies spawn. This guy will then draw from that on LevelLoad

	public float spawnIncrement = 1.0f; // FIXME 
	float timer = 0f;

	public GameObject[] enemies;
	public Transform spawnPos;

	void Start () {
	
	}
	
	void Update () {
		timer += Time.deltaTime;
		if(timer > spawnIncrement) {
			timer = 0f;
			SpawnEnemy();
		}
	}

	void SpawnEnemy() {
		if(enemies.Length < 1) {
			Debug.LogWarning("Enemies are empty", this);
			return;
		}

		GameObject enemy = (GameObject)Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos.position, Quaternion.identity);
	}
}
