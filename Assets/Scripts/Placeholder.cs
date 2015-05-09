using UnityEngine;
using System.Collections;

public class Placeholder : MonoBehaviour {

	public bool disabled = false;
    public ConstructController constructController;

    private MeshRenderer rend;
    public Material materialHover;
    private Material materialStandart;

    // Use this for initialization
    void Start()
    {
        Construct();
    }

    void OnMouseEnter()
    {
        if (materialHover)
        {
            rend.material = materialHover;    
        }
    }

    void OnMouseExit()
    {
        rend.material = materialStandart;
    }

    protected void Construct()
    {
        rend = GetComponent<MeshRenderer>();
        materialStandart = rend.material;
        if (constructController == null)
        {
            constructController = Camera.main.GetComponent<ConstructController>();
        }
    }

	void OnMouseDown() {
		// currentLayer==
		if(!this.disabled) OnClick();
	}

	protected virtual void OnClick() { } 

}
