﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectibleController : MonoBehaviour {

	public Slider collectibleBar;
	public GameObject startScreenCanvas;
	public StatsScript stats;

	void Awake()
	{
		stats = Camera.main.GetComponent<StatsScript> ();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == Tag.Enemy) {
			EnemyBehaviourScript eb = col.gameObject.GetComponent<EnemyBehaviourScript>();
			stats.AddCredits(eb.coinsWorth);
			OnDamage(eb.enemyDamage);
			Destroy(col.gameObject);
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