using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour {

    public GameObject Monster;
    public GameObject Player;

    private bool spawned = false;

    private void Start()
    {
        Monster = GetComponent<GameObject>();
        Player = GetComponent<GameObject>();
    }

    private void Update()
    {
        
    }
}
