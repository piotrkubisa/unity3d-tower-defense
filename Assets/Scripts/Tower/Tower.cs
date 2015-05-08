using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public float cost;
	// exactly: damage per projectile / for being shot
	public float dps = 5f;
	public float attackDmg = 7f;
	public float hp = 350f;
	public float rateOfFire = 0.75f;
	public float buildCooldown = 2f;

	public GameObject arrowPrefab;

	public GameObject target;

	void Start () {
		Build ();
		InvokeRepeating("Attack", buildCooldown, rateOfFire);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == Tag.Enemy) {
			target = other.gameObject;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == Tag.Enemy) {
			target = null;
		}
	}

	public virtual void Build() {
	}

	public virtual void Attack() {
	}	
}
