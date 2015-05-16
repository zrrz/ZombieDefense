using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Gonna rock a basic prototype here. It's gonna have way too much going on. Like the whore it is. 
	// I'll abstract later.

	public float maxHealth = 100f;
	float curHealth;

	public Image healthImage;

	void Start () {
		curHealth = maxHealth;

	}
	
	void Update () {
		Vector3 scale = healthImage.transform.localScale; //FIXME switch to RectTransform width scaling probably.
		scale.x = curHealth/maxHealth;
		healthImage.transform.localScale = scale;
	}
}
