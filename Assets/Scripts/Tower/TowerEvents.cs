using UnityEngine;
using System.Collections;

public class TowerEvents : MonoBehaviour {

	private MeshRenderer rend;
	
	public Material materialHover;
	private Material materialStandart;

    //[HideInInspector]
    public Tower tower;

	void Awake () {
		rend = GetComponent<MeshRenderer>();
        tower = GetComponentInChildren<Tower>();
        materialStandart = rend.material;
	}

    void OnMouseDown()
    {
        if (Tag.WatchTower == gameObject.tag)
        {
            tower.cc.ModifyWatchTower(tower.gameObject);
        }
        else if (Tag.GuardTower == gameObject.tag)
        {
            tower.cc.ModifyGuardTower(tower.gameObject);
        }
        
    }
	
	void OnMouseEnter() {
		rend.material = materialHover;
	}
	
	void OnMouseExit() {
		rend.material = materialStandart;
	} 

}
