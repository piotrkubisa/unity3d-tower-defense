using UnityEngine;
using System.Collections;

public class Placeholder : MonoBehaviour {

	public bool disabled = false;

	void OnMouseDown() {
		// currentLayer==
		if(!this.disabled) OnClick();
	}

	protected virtual void OnClick() { } 

}
