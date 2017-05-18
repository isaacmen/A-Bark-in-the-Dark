using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSpawner : MonoBehaviour {

    public bool can_spawn = true;
    public GameObject player;
    public GameObject monster_prefab;

    //int spawnRate = 5; // in percent

    float timer = 0;
    float next_time = 0;

    private GameObject currentMonster;


	// Use this for initialization
	void Start () {
        var playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y - 9, playerPos.z);
	}
	
	// Update is called once per frame
	void Update () {

        // keep spawner behind and certain distance from player
        var pos = transform.position;
        var playerPos = player.transform.position;
        transform.position = new Vector3(pos.x, playerPos.y - 9, pos.z);

        // random chance monster will spawn
        if (can_spawn && timer >= next_time && currentMonster == null)
        {
            Debug.Log("ping: " + next_time);
            float r = Random.Range(200.0f, 400.0f);
            //if (r < spawnRate)
            //{
            currentMonster = Instantiate(monster_prefab, pos, transform.rotation);
            //}
            next_time = r;
            timer = 0;

        }
        else { timer++; }

        var pscript = player.GetComponent<movement>();
        if (pscript.can_move == false)
        {
            can_spawn = false;
        }

	}
}
