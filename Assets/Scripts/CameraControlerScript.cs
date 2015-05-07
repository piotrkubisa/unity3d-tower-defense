using UnityEngine;
using System.Collections;

public class CameraControlerScript : MonoBehaviour {

	public float speedVector = 5f;
	public float mapSize = 21f;

	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.moveDyn(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
	}

	void move(float v, float h) {
		if(h != 0f || v != 0f) {
		 	transform.position += new Vector3(
				h * speedVector * Time.deltaTime, 
				0f, 
				v * speedVector * Time.deltaTime
		 	);
		}
	}

	// @todo - fix limiters
	void moveDyn(float v, float h) {
		if(h != 0f || v != 0f) {
			if(transform.position.x < mapSize || transform.position.x > -mapSize) {
				moveDirection.x = h * speedVector * Time.deltaTime;
			}
			if(transform.position.z < mapSize || transform.position.z > -mapSize) {
				moveDirection.z = v * speedVector * Time.deltaTime;
			}
			transform.position += moveDirection;
		}
	}
}
