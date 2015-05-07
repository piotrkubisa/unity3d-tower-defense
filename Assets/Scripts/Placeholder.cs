using UnityEngine;
using System.Collections;

public class Placeholder : MonoBehaviour {

	public GameObject towerPrefab;
	private bool is_used = false;


	void OnMouseDown() {
		// currentLayer==
		if(!is_used) createPrefab();
	}

	void createPrefab() {
		Renderer rend = GetComponent<Renderer>();
		Vector3 pos = new Vector3(transform.position.x, transform.position.y + rend.bounds.size.y, transform.position.z);
		rend.enabled = false;

		Instantiate(towerPrefab, pos, this.transform.rotation);
		this.is_used = true;		
	}
}
