using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

	private bool is_on;
	private Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// movement
		bool right = Input.GetKey ("e");
		bool left = Input.GetKey ("q");

		if (right) 
		{
			Vector3 move = new Vector3 (0.0f, 0.0f, -2.0f);
			transform.Rotate (move);
		}

		if (left) 
		{
			Vector3 move = new Vector3 (0.0f, 0.0f, 2.0f);
			transform.Rotate (move);
		}

		this.transform.position = this.transform.parent.transform.position;

		// animation
		anim = gameObject.GetComponent<Animator> ();
		is_on = GetComponentInParent<PlayerFlashlight> ().flashlight_on;

		anim.SetBool ("FlashlightOn", is_on);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("entered");
		if (col.CompareTag ("Monster")) {
			Debug.Log("a monster");
			Object.Destroy (col.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Monster")) {
			Object.Destroy (col.gameObject);
		}
	}
}
