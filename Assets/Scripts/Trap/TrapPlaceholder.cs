using UnityEngine;
using System.Collections;

public class TrapPlaceholder : Placeholder {

	// Update is called once per frame
	void Update () {
	
	}

    protected override void OnClick()
    {
        bool hasBeenSpawned = constructController.SpawnTrap(this.gameObject);
        this.disabled = hasBeenSpawned;
    }
}
