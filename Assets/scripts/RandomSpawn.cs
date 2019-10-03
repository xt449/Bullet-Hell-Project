using UnityEngine;

public class RandomSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float height = Camera.main.orthographicSize /* * 2F */;
		float width = height * Camera.main.aspect;

		gameObject.transform.position = new Vector2(Random.Range(-width, width), Random.Range(-height, height));
	}
}
