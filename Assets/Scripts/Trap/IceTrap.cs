using UnityEngine;
using System.Collections;

public class IceTrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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
