using UnityEngine;
using System.Collections;

public class IceTrap : Trap {

    public int cost = 350;
    public float iceSpeed = 0.75f;
    public float iceSpeedUpgrade = 0.1f;
    public int iceSpeedUpgradeCost = 200;

    public bool Upgrade() {
        if (iceSpeed > iceSpeedUpgrade)
        {
            iceSpeed -= iceSpeedUpgrade;
            return true;
        }
        return false;
    }

    void OnMouseDown()
    {
        cc.ModifyIceTrap(this.gameObject);
    }

    void OnTriggerStay(Collider col)
    {
        NavMeshAgent nav = col.gameObject.GetComponent<NavMeshAgent>();
        if (nav)
        {
            nav.speed = iceSpeed;
        }
    }
}
