using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public UnityEngine.UI.Text damageText;

	public float speedRatio = 0.3F;

	private int damage = 0;

	// Use this for initialization
	void Start() {
		damageText.text = damage.ToString();
	}
	
	// Update is called once per frame
	void Update() {
		gameObject.transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speedRatio;
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		Destroy(collision.gameObject);

		damage++;
		damageText.text = damage.ToString();
	}
}
