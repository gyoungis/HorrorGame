using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

    float elapsedTime;

	// Use this for initialization
	void Start () {
        elapsedTime = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime = Time.deltaTime;
        
        if (elapsedTime > 20.0f)
        {
            DestroyObject();
        }
	}

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
