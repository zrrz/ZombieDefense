using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float movementSpeed = 3f;

	void Start () {
	
	}
	
	void Update () {
		transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
	}
}
