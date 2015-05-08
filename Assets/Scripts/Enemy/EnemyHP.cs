using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	public float hp = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDamage(float attackDmg) {
		this.hp -= attackDmg;
		if (this.hp < 0) {
            DieEvent();
		}
	}

    void DieEvent()
    {
        Destroy(this.gameObject);
    }
}
