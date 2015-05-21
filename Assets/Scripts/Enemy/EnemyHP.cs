using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	public float hp = 100f;
    [HideInInspector]
    public float startHpVal;
    public EnemyBehaviourScript ebs;

	// Use this for initialization
	void Start () {
        startHpVal = hp;
        ebs = GetComponent<EnemyBehaviourScript>();
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

    public void OnDie()
    {
        if (ebs.wave != null)
        {
            ebs.wave.waveController.OnEnemyKilled();    
        }        
		Camera.main.GetComponent<StatsScript> ().AddCredits (ebs.coinsWorth);
        Destroy(this.gameObject);
    }
}
