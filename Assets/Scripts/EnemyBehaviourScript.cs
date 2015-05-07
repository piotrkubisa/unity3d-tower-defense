using UnityEngine;
using System.Collections;

public class EnemyBehaviourScript : MonoBehaviour {

	public NavMeshAgent nav;
	public GameObject targetCollectible;

	public float walkSpeed = 1f;
	public float runawaySpeed = 7f;
	public float collectWaitTime = 10f;
	private float collectTimer = 0;

	private bool hasSomething = false;

	// Use this for initialization
	void Start () {
		nav = this.GetComponent<NavMeshAgent>();
		if(targetCollectible == null) this.findClosestCollectible();
	}
	
	// Update is called once per frame
	void Update () {
		if(hasSomething || !targetCollectible) {
			runaway();
			// Debug.Log("runaway");
		} else {
			pursue();
			// Debug.Log("pursue");
		}
		// Debug.Log(collectTimer);
	}

	private void collect() {
		nav.Stop();

		this.collectTimer += Time.deltaTime;

	 	if (this.collectTimer >= this.collectWaitTime)
	 	{
	 		this.hasSomething = true;
	 		this.collectTimer = 0f;
	 	}
	}

	private void pursue() {
		nav.Resume();
		nav.speed = walkSpeed;
		nav.destination = targetCollectible.transform.position;
		Renderer rend = targetCollectible.GetComponent<Renderer>();

		 if (nav.remainingDistance <= nav.stoppingDistance + rend.bounds.size.x*2)
		 {
		 	collect();
		 } else {
		 	this.collectTimer = 0f;
		 }
	}

	private void runaway() {
		nav.speed = runawaySpeed;
		nav.Stop();
	}

    private void findClosestCollectible() {
        GameObject[] collectibles;
        collectibles = GameObject.FindGameObjectsWithTag(Tag.Collectible);

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        
        foreach (GameObject go in collectibles) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }

        if(closest != null) 
        	this.targetCollectible = closest;
    }
}
