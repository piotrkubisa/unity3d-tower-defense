using UnityEngine;
using System.Collections;

public class WatchTower : Tower {

    public Transform parent;
    private float buildY = 1.25f;
    private float buildStartY;

	// Update is called once per frame
	void Update () {
	}

    public override void Build()
    {
        
        buildStartY = parent.position.y;
        StartCoroutine(Building());
    }

    IEnumerator Building()
    {
        float buildStep = (1 / buildCooldown);
        float buildTimeDuration = buildY / (buildStep / buildCooldown);
        while (parent.position.y < buildStartY + buildY)
        {
            parent.position += new Vector3(0, buildStep, 0);
            yield return new WaitForSeconds(buildCooldown / buildTimeDuration);
        }
    }

	public override void Attack() {
		if(target != null) {
			GameObject instance = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
			TowerProjectile tp = instance.GetComponent<TowerProjectile>();
//			tp.target = target;
			tp.tower = this;
			instance.transform.LookAt(target.transform.position);
		}
	}

}
