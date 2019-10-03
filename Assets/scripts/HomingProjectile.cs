using System;
using UnityEngine;

public class HomingProjectile : MonoBehaviour {

	public new Collider2D collider;

	public Transform target;

	public int maxHomingDistance = 45;
	public int maxHomingAngle = 165;
	public int maxAlignmentAngle = 30;

	public float speedRatio = 0.2F;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update() {
		Vector2 positionOffset = target.position - gameObject.transform.position;
		Quaternion towardsPlayer = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(positionOffset.y, positionOffset.x));

		/*
		Debug.DrawRay(gameObject.transform.position, new Vector3(Mathf.Cos(Mathf.Deg2Rad * gameObject.transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * gameObject.transform.eulerAngles.z)), Color.blue);

		Debug.DrawRay(gameObject.transform.position, new Vector3(Mathf.Cos(Mathf.Deg2Rad * (gameObject.transform.eulerAngles.z - maxHomingAngle)), Mathf.Sin(Mathf.Deg2Rad * (gameObject.transform.eulerAngles.z - maxHomingAngle))), Color.black);
		Debug.DrawRay(gameObject.transform.position, new Vector3(Mathf.Cos(Mathf.Deg2Rad * (gameObject.transform.eulerAngles.z + maxHomingAngle)), Mathf.Sin(Mathf.Deg2Rad * (gameObject.transform.eulerAngles.z + maxHomingAngle))), Color.black);
		*/

		if(!GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(Camera.main), collider.bounds)) {
			Destroy(gameObject);
			return;
		}

		if(Vector2.Distance(gameObject.transform.position, target.position) < maxHomingDistance) {

			float angleSelf = gameObject.transform.eulerAngles.z;
			float angleTarget = towardsPlayer.eulerAngles.z;

			if(angleSelf > 180) {
				angleSelf = 360 - angleSelf;
			}

			if(angleTarget > 180) {
				angleTarget = 360 - angleTarget;
			}

			float angle = angleSelf - angleTarget;

			if(Mathf.Abs(angle) < maxHomingAngle) {
				gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, towardsPlayer, maxAlignmentAngle);

				Debug.DrawLine(gameObject.transform.position, target.position, Color.green);
			} else {
				Debug.DrawLine(gameObject.transform.position, target.position, Color.red);
			}
		}

		gameObject.transform.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * gameObject.transform.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * gameObject.transform.eulerAngles.z)) * speedRatio;
	}
}
