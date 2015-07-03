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
		moneyImage.text = "Gold: " + money.ToString(); // TODO break text into "k"s if > 1,000, and "m" if > 1,000,000
	}

	public void GoToBattleScene() {
		StartCoroutine("LerpCamera", new Vector3(0f, 0f, -10f));
	}

	public void GoToCastleScene() {
		StartCoroutine("LerpCamera", new Vector3(17.76f, 0f, -10f)); //FIXME
	}

	IEnumerator LerpCamera(Vector3 endPos) {
		Transform cam = Camera.main.transform;
		float timer = 0.0f;
		Vector3 startPos = cam.transform.position;
		while(timer < 1.0f) {
			timer += Time.deltaTime;
			cam.transform.position = Vector3.Lerp(startPos, endPos, timer);
			yield return null;
		}
		cam.transform.position = endPos;
	}

	public static GameManager Instance {
		get {
			return s_instance;
		}
	}
}
