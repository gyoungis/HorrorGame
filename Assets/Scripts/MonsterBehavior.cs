using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour {

    public GameObject Monster;
    public GameObject Player;

    private bool spawned = false;
    private float keyProg;
    private float nextSpawn;
    private float deSpawn;
    private Camera playerCam;
    

    private void Start()
    {
        Monster = GetComponent<GameObject>();
        Player = GetComponent<GameObject>();
        nextSpawn = Time.time + 8f;
        deSpawn = nextSpawn + 30f;
    }

    private void Update()
    {
        keyProg = Player.GetComponentInChildren<InteractionBehavior>().mainKeys;

        if (spawned)
        {
            if (Time.time == deSpawn)
            {
                Destroy(Monster);
                nextSpawn = Time.time + 80f / keyProg;
            }
        }
        else
        {
            if (Time.time == nextSpawn)
            {

            }
        }
    }
}
