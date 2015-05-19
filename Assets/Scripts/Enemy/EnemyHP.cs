using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	public float hp = 100f;
    [HideInInspector]
    public float startHpVal;

	// Use this for initialization
	void Start () {
        startHpVal = hp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDamage(float attackDmg) {
		this.hp -= attackDmg;
		if (this.hp <= 0) {
            OnDie();
		}
	}

    void OnDie()
    {
		EnemyBehaviourScript ebs = GetComponent<EnemyBehaviourScript> ();
		Camera.main.GetComponent<StatsScript> ().AddCredits (ebs.coinsWorth);
        Destroy(this.gameObject);
    }
}
