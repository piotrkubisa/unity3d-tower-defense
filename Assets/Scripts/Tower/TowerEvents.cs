using UnityEngine;
using System.Collections;

public class TowerEvents : MonoBehaviour {

	private MeshRenderer rend;
	
	public Material materialHover;
	public Material materialStandart;


	// Use this for initialization
	void Awake () {
		rend = GetComponent<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		rend.material = materialHover;
	}
	
	void OnMouseExit() {
		rend.material = materialStandart;
	} 

}
