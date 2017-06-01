using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBehavior : MonoBehaviour {

    public float interact_distance = 7f;
    private Camera fpsCam;
    public GameObject hitMarker;

    //TODO: Don't do this here
    AudioSource[] audio;


    // Use this for initialization
    void Start () {
        fpsCam = GetComponent<Camera>();
        audio = GetComponentsInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1.0f));
            RaycastHit hit;
            //Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, interact_distance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.GetComponent<DoorBehavior>().ChangeDoorState();
                    hit.collider.transform.GetComponent<DoorBehavior>().PlaySound();
                    Instantiate(hitMarker, hit.point, Quaternion.identity);
                }
                if (hit.collider.CompareTag("Note"))
                {
                    Note state = hit.collider.GetComponent<Note>();
                    Instantiate(hitMarker, hit.point, Quaternion.identity);
                    audio[4].Play();
                    if (state != null)
                    {
                        state.pickedUp(1);
                        //state.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.0f;
                    }
                }
            }
        }
	}
}
