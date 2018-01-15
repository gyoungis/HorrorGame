using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBehavior : MonoBehaviour {

    public float interact_distance = 3f;
    public int mainKeys = 0;

    private Camera fpsCam;
    

    // Debugging
    //public GameObject hitMarker;
    //private LineRenderer hitLine;
    //private WaitForSeconds Duration = new WaitForSeconds(0.07f);

    //TODO: Don't do this here
    AudioSource[] audio;


    // Use this for initialization
    void Start () {
        fpsCam = this.GetComponent<Camera>();
        audio = GetComponentsInChildren<AudioSource>();

        // Debug
        //hitLine = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {

            //Debugging
            //StartCoroutine(lineEffect());
            //hitLine.SetPosition(0, rayOrigin);

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            
            RaycastHit hit;

            Debug.Log(rayOrigin);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, interact_distance))
            {
                //Debugging
                //hitLine.SetPosition(1, hit.point);

                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.GetComponent<DoorBehavior>().ChangeDoorState();
                    hit.collider.transform.GetComponent<DoorBehavior>().PlaySound();

                    //Debugging
                    //Instantiate(hitMarker, hit.point, Quaternion.identity);
                }
                if (hit.collider.CompareTag("Note"))
                {

                    Note state = hit.collider.GetComponent<Note>();
                    
                    audio[3].Play();
                    if (state != null)
                    {
                        state.pickedUp(1);
                    }

                    //Debugging
                    //Instantiate(hitMarker, hit.point, Quaternion.identity);
                }
                if (hit.collider.CompareTag("mainKey"))
                {
                    mainKeys += 1;

                    keyScript keyState = hit.collider.GetComponent<keyScript>();

                    if (keyState != null)
                    {
                        keyState.pickedUp(1);
                    }
                }


            }

            // Debugging Raycasts
            //else
            //{
            //    hitLine.SetPosition(1, fpsCam.transform.forward * interact_distance);
            //}
        }
	}


    // Debug line render
    //private IEnumerator lineEffect()
    //{
    //    hitLine.enabled = true;

    //    yield return Duration;

    //    hitLine.enabled = false;
    //}
}
