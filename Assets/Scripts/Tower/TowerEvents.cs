using UnityEngine;
using System.Collections;

public class TowerEvents : MonoBehaviour {

	private MeshRenderer rend;
	
	public Material materialHover;
	private Material materialStandart;

    private Tower tower;

	void Awake () {
		rend = GetComponent<MeshRenderer>();
        tower = GetComponentInChildren<Tower>();
        materialStandart = rend.material;
	}

    void OnMouseDown()
    {
        tower.cc.ModifyTower(tower.gameObject);
    }
	
	void OnMouseEnter() {
		rend.material = materialHover;
	}
	
	void OnMouseExit() {
		rend.material = materialStandart;
	} 

}
