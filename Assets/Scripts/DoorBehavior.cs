using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour {

    public bool open = false;
    public float open_angle = 90f;
    public float close_angle = 0f;
    public float smooth = 2f;

	// Use this for initialization
	void Start () {
		
	}

    public void ChangeDoorState()
    {
        open = !open;
    }
	
	// Update is called once per frame
	void Update () {
        if (open) {
            Quaternion rot = Quaternion.Euler(0, open_angle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rot, smooth * Time.deltaTime);
        } else {
            Quaternion rot = Quaternion.Euler(0, close_angle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rot, smooth * Time.deltaTime);
        }
		
	}
}
