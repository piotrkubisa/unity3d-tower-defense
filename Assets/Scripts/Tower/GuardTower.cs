using UnityEngine;
using System.Collections;

public class GuardTower : Tower {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Attack() {
		if(target != null) {
			GameObject instance = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
			TowerProjectile tp = instance.GetComponent<TowerProjectile>();
			tp.target = target;
			tp.tower = this;
			instance.transform.LookAt(target.transform.position);
		}
	}
}
