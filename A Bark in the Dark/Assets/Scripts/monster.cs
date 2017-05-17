using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour {

    int move = 20;
    float speed = 3.0f;
    Vector3 initialPos;

    //bool hunting = true;
    bool stop = false;

	// Use this for initialization
	void Start () {
        initialPos = transform.position;
	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("hider"))
        {
            var hscript = other.GetComponent<hide>();
            bool playerIsHidden = hscript.isHidden();
            if (!playerIsHidden)
            {
                Debug.Log("monster: D:<");
                // insert player dies here
                GameObject player = GameObject.Find("Player");
                var pscript = player.GetComponent<movement>();
                pscript.can_move = false;

                stop = true; // monster stops
            }
            else 
            {
                Debug.Log("monster: passing over...");
                
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        GameObject player = GameObject.Find("Player");
        var playerPos = player.transform.position;
        
        if (!stop) 
        {
            float diff = Mathf.Abs(playerPos.y - pos.y);
            if (diff <= move) // pos.y <= initialPos.y + move
            {
                transform.position = new Vector3(pos.x, pos.y + (speed * Time.deltaTime), pos.z);
            }
            else { Destroy(gameObject); }
        }
	}
}
