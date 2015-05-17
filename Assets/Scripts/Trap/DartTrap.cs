using UnityEngine;
using System.Collections;

public class DartTrap : Trap {

    public float dps = 0.25f;
    public int cost = 200;

    public ParticleSystem darts;

	// Use this for initialization
	void Awake () {
        darts = GetComponentInChildren<ParticleSystem>();
    } 
	
    void OnMouseDown()
    {
        cc.ModifyDartTrap(this.gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        transform.position = new Vector3(transform.position.x, -0.40f, transform.position.z);
        darts.Play();
    }

    void OnTriggerExit(Collider col)
    {
        transform.position = new Vector3(transform.position.x, -0.25f, transform.position.z);
        darts.Stop();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == Tag.Enemy)
        {
            GameObject enemy = col.gameObject;
            EnemyHP hp = enemy.GetComponent<EnemyHP>();
            hp.OnDamage(dps);
        }
    }
}
