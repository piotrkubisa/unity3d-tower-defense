using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectibleController : MonoBehaviour {

	public Slider collectibleBar;
	public GameObject startScreenCanvas;
	//public StatsScript stats;

	void Awake()
	{
		//stats = Camera.main.GetComponent<StatsScript> ();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == Tag.Enemy) {
            EnemyHP hp = col.gameObject.GetComponent<EnemyHP>();
            hp.OnDie();
            OnDamage(hp.ebs.enemyDamage);
		}
	}

	void OnDamage(float damage) {
		collectibleBar.value -= damage;
		if (collectibleBar.value == collectibleBar.minValue) {
			startScreenCanvas.SetActive(true);
			Time.timeScale = 0f;
		}
	}
}
