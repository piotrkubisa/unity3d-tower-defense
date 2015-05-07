using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	public StatsScript stats;
	public Text coinsText;

	// Use this for initialization
	void Start () {
		stats = new StatsScript();
		InvokeRepeating("LogMoney", 0, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate() {

	}

	public void LogMoney() {
//		Debug.Log("Coins: " + stats.coins);
		if (coinsText != null) {
			coinsText.text = "$" + stats.coins;
		}
	}

}
