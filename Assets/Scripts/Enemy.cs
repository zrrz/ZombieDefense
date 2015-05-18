using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float movementSpeed = 3f;

	float x;
	float y;

	bool dragged = false;
	bool grounded = false;
	
	void Update () {
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;
		if(!dragged)
			transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
	}

	void OnMouseDrag() {
		dragged = true;
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x,y,10.0f));
	}

	void OnMouseUp() {
		dragged = false;
	}

	void CheckGrounded() {
		grounded = Physics2D.Raycast(transform.position, -Vector2.up, 2.0f, LayerMask.NameToLayer("Ground"));
	}
}
