using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour {

    public GameObject Monster;
    public GameObject Player;
    public GameObject spawnLoc;

    public int keyProg;

    private bool spawned = false;
    private float nextSpawnPoint;
    private float nextSpawn;
    private float deSpawn;
    private Camera playerCam;
    private Vector3 playerPos;
    

    private void Start()
    {
        nextSpawnPoint = Time.time + 8.0f;
        nextSpawn = Time.time + 16.0f;
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
                nextSpawnPoint = Time.time + 80f / (keyProg + 1);
            }
        }
        else
        {
            if (Time.time == nextSpawnPoint)
            {
                Instantiate(spawnLoc, playerPos, Quaternion.identity);
                nextSpawn = Time.time + 20f / (keyProg + 1);
            }
            if (Time.time == nextSpawn)
            {
                playerPos = Player.transform.position;
                Instantiate(Monster, spawnLoc.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                deSpawn = Time.time + 10.0f;
                Destroy(spawnLoc);
            }
        }
    }
}
