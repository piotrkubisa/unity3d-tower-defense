using UnityEngine;
using System.Collections;

public class WatchTower : Tower {

    public int cost = 300;

	public override void Attack() {
		if(target != null) {
			GameObject instance = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
			TowerProjectile tp = instance.GetComponent<TowerProjectile>();
//			tp.target = target;
			tp.tower = this;
			instance.transform.LookAt(target.transform.position);
		}
	}

}
