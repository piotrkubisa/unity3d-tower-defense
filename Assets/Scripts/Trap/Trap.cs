using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    private MeshRenderer rend;
    private Material materialStandart;
    public Material materialHover;

	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
        materialStandart = rend.material;
    }

    void OnMouseEnter()
    {
        rend.material = materialHover;
    }

    void OnMouseExit()
    {
        rend.material = materialStandart;
	}

}
