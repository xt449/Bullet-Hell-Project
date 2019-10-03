using System;
using UnityEngine;

public class RotateSlow : MonoBehaviour {

	// Use this for initialization
	void Start() {

	}

	bool rotateLeft;

	// Update is called once per frame
	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			rotateLeft = !rotateLeft;
		}

		if(rotateLeft) {
			gameObject.transform.Rotate(Vector3.forward, 1);
		} else {
			gameObject.transform.Rotate(Vector3.forward, -1);
		}
	}
}
