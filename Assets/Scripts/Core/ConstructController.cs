using UnityEngine;
using System.Collections;

public class ConstructController : MonoBehaviour {

	public GameObject towerPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool SpawnTower(GameObject placeholder)
	{
		bool isSpawned = true;

		// TowerPrefab Menu

		Renderer rend = placeholder.GetComponent<Renderer> ();
		Vector3 pos = new Vector3 (placeholder.transform.position.x, placeholder.transform.position.y + rend.bounds.size.y, placeholder.transform.position.z);
		rend.enabled = false; // should go to TowerPlaceholder

		Instantiate(towerPrefab, pos, Quaternion.identity);

		return isSpawned;
	}
}
