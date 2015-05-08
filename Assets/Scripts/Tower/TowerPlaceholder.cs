using UnityEngine;
using System.Collections;

public class TowerPlaceholder : Placeholder {

	public ConstructController constructController;

	// Use this for initialization
	void Awake () {
		if (constructController == null) {
			constructController = Camera.main.GetComponent<ConstructController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void OnClick()
	{
		bool hasBeenSpawned = constructController.SpawnTower (this.gameObject);
		this.disabled = hasBeenSpawned;
	}
}
