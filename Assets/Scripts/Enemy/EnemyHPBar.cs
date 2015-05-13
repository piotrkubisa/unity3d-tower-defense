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
    private float[] hpranges;

	void Awake () {
		rend = GetComponent<MeshRenderer>();
		hp = GetComponentInParent<EnemyHP> ();
        hpranges = new float[] { 
            0,
            0.25f * hp.startHpVal,
            0.50f * hp.startHpVal,
            0.75f * hp.startHpVal,
            hp.startHpVal,
        };
	}
	
	void LateUpdate () {
		setSphereMaterial ();
	}

	void setSphereMaterial()
	{
		if (rend) {
            if (hp.hp <= 0)
            {
                rend.material = hp_0;
            }
            else if (hp.hp > 0 && hp.hp <= hpranges[1])
            {
                rend.material = hp_25;
            }
            else if (hp.hp > hpranges[1] && hp.hp <= hpranges[2])
            {
                rend.material = hp_50;
            }
            else if (hp.hp > hpranges[2] && hp.hp <= hpranges[3])
            {
                rend.material = hp_75;
            }
            else
            {
                rend.material = hp_100;
            }
		}
	}
}
