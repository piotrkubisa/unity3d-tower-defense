﻿using UnityEngine;
using System.Collections;

public class GuardTower : Tower {

    public int cost = 500;
    public float dps = 75f;
    public float projectileSpeed = 2f;
    public float dpsUpgrade = 25f;
    public int dpsUpgradeCost = 500;

	public override void Attack() {
		if(target != null) {
			GameObject instance = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
			TowerProjectile tp = instance.GetComponent<TowerProjectile>();
			tp.target = target;
			tp.tower = this;
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
