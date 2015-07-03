using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// TODO 
	// cleaner drag method over multiple frames.
	// Dying to fall damage and "throwing" into ground
	// Attacking base
	// Inheritance for different zombie types

	const float GROUND_CHECK_DISTANCE = 0.8f;
	const float ATTACK_DISTANCE = 1.0f;

	public float movementSpeed = 3f;
	public float throwSpeed = 0.5f;

	float x;
	float y;

	public bool dragged = false;
	public bool grounded = false;

	Vector3 prevPos;

	Rigidbody2D thisRigidbody2D;

	public LayerMask groundMask;
	public LayerMask attackMask;

	public float velocityToKill = 20f;

	public int moneyValue = 20;

	Vector3 prevVelocity;

	public GameObject deathParticle;

	protected virtual void Start() {
		thisRigidbody2D = GetComponent<Rigidbody2D>();
	}

	protected virtual void Update () {
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;
	
		if(!grounded)
			thisRigidbody2D.velocity += new Vector2(0f, Physics.gravity.y*Time.deltaTime);
		else {
			Debug.DrawRay(transform.position, Vector3.right, Color.red);
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, ATTACK_DISTANCE, attackMask);
			if(null != hit.collider) {
				GameManager.Instance.TakeDamage(5.0f * Time.deltaTime);
			} else {
				thisRigidbody2D.velocity = new Vector3(movementSpeed, 0f, 0f);
			}
		}
		prevPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		prevVelocity = thisRigidbody2D.velocity;
	}

	protected virtual void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Ground") {
			grounded = true;
			print(prevVelocity.magnitude);
			if(prevVelocity.magnitude > velocityToKill) {
				Die();
			}
		}
	}

	void Die() {
		// TODO play anim
		Instantiate(deathParticle, transform.position, Quaternion.identity);
		GameManager.Instance.AddMoney(moneyValue);
		Destroy(gameObject);
	}

	void OnMouseDrag() {
		grounded = false;
		dragged = true;
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x,y,10.0f));
	}
	
	void OnMouseUp() {
		dragged = false;
		thisRigidbody2D.velocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - prevPos)/Time.deltaTime * throwSpeed;
	}
}