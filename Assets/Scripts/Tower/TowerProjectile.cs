﻿using UnityEngine;
using System.Collections;

public class TowerProjectile : MonoBehaviour {

	public float dieTime = 5f;
	private float dieCounter = 0f;
	public GameObject target;
	public float speed = 3f;
	// struct
	public Tower tower;

    void FixedUpdate()
    {
        dieCounter += Time.deltaTime;
        if (dieCounter >= dieTime)
        {
            Destroy(this.gameObject);
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), 100f * Time.deltaTime);
        }

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void Attack(GameObject victim)
    {
        if (victim != null)
        {
            EnemyHP hp = victim.GetComponent<EnemyHP>();
            if (hp != null)
            {
                hp.OnDamage(tower.GetDps());
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == Tag.Enemy)
        {
            Attack(col.gameObject);
        }
        Destroy(this.gameObject);
    }
}
