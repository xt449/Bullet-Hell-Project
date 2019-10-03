using System;
using UnityEngine;

public class PointMouse : MonoBehaviour {

	// Use this for initialization
	void Start() {
		
	}

	private bool showDebug;

	// Update is called once per frame
	void Update() {
		/*if(Input.GetMouseButtonDown(0)) {
			showDebug = !showDebug;
		}

		if(showDebug) {
			Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), gameObject.transform.position, Color.blue);
		}*/

		Vector2 positionOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;

		gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(positionOffset.y, positionOffset.x));

	}
}
