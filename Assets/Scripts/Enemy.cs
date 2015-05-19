using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	const float GROUND_CHECK_DISTANCE = 0.8f;

	public float movementSpeed = 3f;

	float x;
	float y;

	public bool dragged = false;
	public bool grounded = false;

	Vector3 prevPos;

	Rigidbody2D rigidbody2D;

	public LayerMask groundMask;

	void Start() {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update () {
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;
	
		if(!grounded)
			rigidbody2D.velocity += new Vector2(0f, Physics.gravity.y*Time.deltaTime);
		else 
			rigidbody2D.velocity = new Vector3(movementSpeed, 0f, 0f);
		prevPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		CheckGrounded();
	}

	void OnMouseDrag() {
		dragged = true;
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x,y,10.0f));
	}
	
	void OnMouseUp() {
		dragged = false;
		rigidbody2D.velocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - prevPos)/Time.deltaTime;
		print (transform.position + " " + prevPos);
	}

	void CheckGrounded() {
		grounded = Physics2D.Raycast(transform.position, -Vector2.up, GROUND_CHECK_DISTANCE, groundMask);
		Debug.DrawRay(transform.position, -Vector3.up*GROUND_CHECK_DISTANCE, Color.red, 1.0f);
	}
}
