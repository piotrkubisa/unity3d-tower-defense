using UnityEngine;
using System.Collections;

public class DartTrap : MonoBehaviour {

    public float dps = 0.25f;

    public ParticleSystem darts;

	// Use this for initialization
	void Awake () {
        darts = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
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
