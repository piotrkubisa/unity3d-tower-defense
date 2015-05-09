using UnityEngine;
using System.Collections;

public class TowerEvents : MonoBehaviour {

	private MeshRenderer rend;
	
	public Material materialHover;
	public Material materialStandart;

    private Tower tower;

	void Awake () {
		rend = GetComponent<MeshRenderer>();
        tower = GetComponentInChildren<Tower>();
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
