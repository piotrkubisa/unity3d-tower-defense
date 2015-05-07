using UnityEngine;
using System.Collections;

public class EnemyHPBar : MonoBehaviour {

	private EnemyHP hp;

	public Material hp_0;
	public Material hp_25;
	public Material hp_50;
	public Material hp_75;
	public Material hp_100;

	private MeshRenderer rend;


	// Use this for initialization
	void Awake () {
		rend = GetComponent<MeshRenderer>();
		hp = GetComponentInParent<EnemyHP> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		setSphereMaterial ();
	}

	void setSphereMaterial()
	{
		if (rend) {
			if (hp.hp <= 0) {
				rend.material = hp_0;
			} else if (hp.hp > 0 && hp.hp <= 25) {
				rend.material = hp_25;
			} else if (hp.hp > 25 && hp.hp <= 50) {
				rend.material = hp_50;
			} else if (hp.hp > 50 && hp.hp <= 75) {
				rend.material = hp_75;
			} else {
				rend.material = hp_100;
			}
		}
	}
}
