﻿using UnityEngine;
using System.Collections;

public class WatchTower : Tower {

    public int cost = 250;
    public float dps = 25f;
    public float projectileSpeed = 15f;
    public float dpsUpgrade = 10f;
    public int dpsUpgradeCost = 250;

	public override void Attack() {
		if(target != null) {
			GameObject instance = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
			TowerProjectile tp = instance.GetComponent<TowerProjectile>();
//			tp.target = target;
			tp.tower = this;
            tp.speed = projectileSpeed;
			instance.transform.LookAt(target.transform.position);
		}
	}

    public override float GetDps()
    {
        return dps;
    }

    public void Upgrade()
    {
        dps += dpsUpgrade;
    }
}
