using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform target;

	public GameObject projectilePrefab;
	public float wait = 1.5F;

	// Use this for initialization
	void Start () {
		if(projectilePrefab.GetComponent<HomingProjectile>()) {
			projectilePrefab.GetComponent<HomingProjectile>().target = target;
		}

		for(int i = 0; i < 10; i++) {
			Spawn();
		}
	}

	private float lastTime = 0;

	public bool allowSpawning = true;

	// Update is called once per frame
	void Update () {
		/*if(Input.GetMouseButtonDown(0)) {
			allowSpawning = !allowSpawning;
		}*/

		if(allowSpawning) {
			if(Time.time - lastTime > wait) {
				lastTime = Time.time;

				Spawn();
			}
		}
	}

	void Spawn() {
		float width = Camera.main.orthographicSize * Camera.main.aspect;
		Vector2 spawn = new Vector2(Random.Range(-width, width), gameObject.transform.position.y);

		Instantiate(projectilePrefab, spawn, Quaternion.Euler(0, 0, -90));
	}
}
