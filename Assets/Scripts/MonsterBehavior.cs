using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour {

    public GameObject Monster;
    public GameObject Player;

    public int keyProg;

    private bool spawned = false;
    private float nextSpawn;
    private float deSpawn;
    private Camera playerCam;
    

    private void Start()
    {
        nextSpawn = Time.time + 8f;
        deSpawn = nextSpawn + 30f;
        Debug.Log(Player);
    }

    private void Update()
    {
        keyProg = Player.GetComponentInChildren<InteractionBehavior>().mainKeys;

        if (spawned)
        {
            if (Time.time == deSpawn)
            {
                Destroy(Monster);
                nextSpawn = Time.time + 80f / (keyProg + 1);
                nextSpawn = Time.time + 30f;
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
