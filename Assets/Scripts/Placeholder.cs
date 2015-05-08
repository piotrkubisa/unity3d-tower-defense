using UnityEngine;
using System.Collections;

public class Placeholder : MonoBehaviour {

	public bool disabled = false;
    public ConstructController constructController;

    // Use this for initialization
    void Start()
    {
        Construct();        
    }

    protected void Construct()
    {
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
