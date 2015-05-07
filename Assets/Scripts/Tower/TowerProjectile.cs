using UnityEngine;
using System.Collections;

public class TowerProjectile : MonoBehaviour {

	public float dieTime = 5f;
	private float dieCounter = 0f;
	public GameObject target;
	private float travelSpeed = 3f;
	// struct
	public Tower tower;

	void FixedUpdate () {
		dieCounter += Time.deltaTime;
		if(dieCounter >= dieTime) {
			Destroy(this.gameObject);
		}
	}

	void LateUpdate () {
		if (target != null) {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), 100f * Time.deltaTime);
		}

		transform.position += transform.forward * travelSpeed * Time.deltaTime;		
	}

	void Attack() {
		if (tower) {
			EnemyHP hp = target.GetComponent<EnemyHP>();
			if(hp) {
				hp.OnDamage(tower.dps);
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == Tag.Enemy) {
			Attack();
		}

	}
}
