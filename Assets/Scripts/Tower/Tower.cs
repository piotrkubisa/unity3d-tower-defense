using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    //private int cost = 0;
	// exactly: damage per (being) shot
    //private float dps = 5f;
	public float hp = 350f;
	public float rateOfFire = 0.75f;
	public float buildCooldown = 2f;

	public GameObject arrowPrefab;

    [HideInInspector]
	public GameObject target;
    [HideInInspector]
    public ConstructController cc;
    [HideInInspector]
    public GameObject towerPlaceholder;

    public Transform parent;
    private float buildY = 1.25f;
    private float buildStartY;

	void Start () {
        Construct();
		Build ();
		InvokeRepeating("Attack", buildCooldown, rateOfFire);        
    }

    void Construct()
    {
        if (cc == null)
        {
            cc = Camera.main.GetComponent<ConstructController>();
        }
    }

	void OnTriggerStay(Collider other) {
		if(other.gameObject.tag == Tag.Enemy) {
			target = other.gameObject;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == Tag.Enemy) {
			target = null;
		}
	}

    public void Build()
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

	public virtual void Attack() {
	}

    public virtual float GetDps()
    {
        return 0f;
    }
}
