using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMover : MonoBehaviour {

	public GameObject player;

		void Start()
		{ 
			DontDestroyOnLoad (transform.gameObject);
		}

		void Update () 
		{
			Vector3 newpos = new Vector3 (player.transform.position.x,
				                player.transform.position.y, -3.0f);
			this.transform.position = newpos;
		}
}
