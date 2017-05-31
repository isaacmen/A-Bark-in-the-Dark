using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFlashlight : MonoBehaviour {

	public bool flashlight_on;
	public Text battery_indicator;

	private int battery;
	private bool pickup;
	private int timer;
	private bool changing;
	// Use this for initialization
	void Start () {
		battery = 1000;
		flashlight_on = false;
		pickup = false;
		timer = 61;
	}
	
	// Update is called once per frame
	void Update () {
		battery_indicator.text = "battery: " + battery.ToString();

		if (flashlight_on) {
			battery--;
		}

		if (battery <= 0) {
			flashlight_on = false;
			battery = 0;
		}
			
		if (Input.GetKeyDown ("f")  && !flashlight_on && battery > 0 && !changing) {
			flashlight_on = true;
			Debug.Log ("on");
			changing = true;
		}

		if (Input.GetKeyDown ("f") && flashlight_on && !changing) {
			Debug.Log ("off");
			flashlight_on = false;
			timer = 0;
			changing = true;
		}

		if (changing) {
			timer++;
		}

		if (timer > 60) {
			changing = false;
		}


		if (Input.GetKeyDown ("v")) {
			Debug.Log ("is this on");
			pickup = true;
		}
		
	}
		

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Battery")) {
			if (pickup) {
				battery += 600;
				Object.Destroy (col.gameObject);
				pickup = false;
			}
		}
	}
}
