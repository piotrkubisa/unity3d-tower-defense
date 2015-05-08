using UnityEngine;
using System.Collections;

public class TowerEvents : MonoBehaviour {

	private MeshRenderer rend;
	
	public Material materialHover;
	public Material materialStandart;

    private ConstructController cc;
    private Tower tower;


	// Use this for initialization
	void Awake () {
		rend = GetComponent<MeshRenderer>();
        cc = Camera.main.GetComponent<ConstructController>();
        tower = GetComponentInChildren<Tower>();
	}

    void OnMouseDown()
    {
        cc.ModifyTower(tower);
    }
	
	void OnMouseEnter() {
		rend.material = materialHover;
	}
	
	void OnMouseExit() {
		rend.material = materialStandart;
	} 

}
