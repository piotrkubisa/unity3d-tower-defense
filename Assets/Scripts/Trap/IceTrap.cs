using UnityEngine;
using System.Collections;

public class IceTrap : Trap {

    public int cost = 350;

    void OnTriggerStay(Collider col)
    {
        // col.gameObject
        NavMeshAgent nav = col.gameObject.GetComponent<NavMeshAgent>();
        if (nav)
        {
            nav.speed = 0.2f;
        }
    }
}
