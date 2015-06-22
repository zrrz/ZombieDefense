using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Gonna rock a basic prototype here. It's gonna have way too much going on. Like the whore it is. 
	// I'll abstract later.

	static GameManager s_instance;

	public float maxHealth = 100f;
	float curHealth;

	public Image healthImage;
	public Text moneyImage;

	int money = 0;

	void Start () {
		s_instance = this;
		curHealth = maxHealth;
		UpdateHealthImage();
		UpdateMoneyImage();
	}
	
	void Update () {
	
	}

	public void AddMoney(int amount) {
		money += amount;
		UpdateMoneyImage();
	}

	public void TakeDamage(float amount) {
		curHealth -= amount;
		UpdateHealthImage();
	}

	void UpdateHealthImage() {
		Vector3 scale = healthImage.transform.localScale; //FIXME switch to RectTransform width scaling probably.
		scale.x = curHealth/maxHealth;
		healthImage.transform.localScale = scale;
	}

	void UpdateMoneyImage() {
		moneyImage.text = money.ToString(); // TODO break text into "k"s if > 1,000, and "m" if > 1,000,000
	}

	public static GameManager Instance {
		get {
			return s_instance;
		}
	}
}
