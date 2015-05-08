using UnityEngine;
using System.Collections;

public class TrapPlaceholder : Placeholder {

    protected override void OnClick()
    {
        constructController.SpawnTrap(this.gameObject);
    }
}
