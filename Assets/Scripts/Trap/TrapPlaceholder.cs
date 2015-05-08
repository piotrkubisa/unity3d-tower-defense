using UnityEngine;
using System.Collections;

public class TrapPlaceholder : Placeholder {

	// Update is called once per frame
	void Update () {
	
	}

    protected override void OnClick()
    {
        constructController.SpawnTrap(this.gameObject);
    }
}
