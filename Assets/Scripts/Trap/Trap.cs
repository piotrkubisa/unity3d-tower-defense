using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    private MeshRenderer rend;
    private Material materialStandart;
    public Material materialHover;
    public ConstructController cc;
    public GameObject trapPlaceholder;

	void Start () {
        rend = GetComponent<MeshRenderer>();
        materialStandart = rend.material;
        Construct();
    }

    void Construct()
    {
        if (cc == null)
        {
            cc = Camera.main.GetComponent<ConstructController>();
        }
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
