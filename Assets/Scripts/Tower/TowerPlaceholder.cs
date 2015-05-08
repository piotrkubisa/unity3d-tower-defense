using UnityEngine;
using System.Collections;

public class TowerPlaceholder : Placeholder {

	// Update is called once per frame
	void Update () {
	
	}

	protected override void OnClick()
	{
		bool hasBeenSpawned = constructController.SpawnTower (this.gameObject);
		this.disabled = hasBeenSpawned;
	}
}
