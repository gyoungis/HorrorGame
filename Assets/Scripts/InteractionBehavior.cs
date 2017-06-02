using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBehavior : MonoBehaviour {

    public float interact_distance = 3f;
    private Camera fpsCam;

    // Debugging
    public GameObject hitMarker;
    private LineRenderer hitLine;
    private WaitForSeconds Duration = new WaitForSeconds(0.07f);

    //TODO: Don't do this here
    AudioSource[] audio;


    // Use this for initialization
    void Start () {
        fpsCam = this.GetComponent<Camera>();
        audio = GetComponentsInChildren<AudioSource>();

        // Debug
        hitLine = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(lineEffect());


            //Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, fpsCam.nearClipPlane));
            Vector3 rayOrigin = fpsCam.transform.position;
            hitLine.SetPosition(0, rayOrigin);
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.7f));
            RaycastHit hit;
            Debug.Log(rayOrigin);
            //Ray ray = new Ray(transform.position, transform.forward);
            //if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, interact_distance))
            if (Physics.Raycast(ray, out hit))
            {
                
                hitLine.SetPosition(1, hit.point);
                //if (hit.collider.CompareTag("Door"))
                //{
                //    hit.collider.transform.GetComponent<DoorBehavior>().ChangeDoorState();
                //    hit.collider.transform.GetComponent<DoorBehavior>().PlaySound();
                //    Instantiate(hitMarker, hit.point, Quaternion.identity);
                //}
                //if (hit.collider.CompareTag("Note"))
                //{
                //    Note state = hit.collider.GetComponent<Note>();
                //    Instantiate(hitMarker, hit.point, Quaternion.identity);
                //    audio[4].Play();
                //    if (state != null)
                //    {
                //        state.pickedUp(1);
                //        //state.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.0f;
                //    }
                //}

                DoorBehavior door = hit.collider.GetComponent<DoorBehavior>();
                if (door != null)
                {
                    hit.collider.transform.GetComponent<DoorBehavior>().ChangeDoorState();
                    hit.collider.transform.GetComponent<DoorBehavior>().PlaySound();
                    Instantiate(hitMarker, hit.point, Quaternion.identity);
                }

                Note hitNote = hit.collider.GetComponent<Note>();
                if (hitNote != null)
                {
                    Instantiate(hitMarker, hit.point, Quaternion.identity);
                    audio[4].Play();
                    hitNote.pickedUp(1);
                }
            }
            else
            {
                hitLine.SetPosition(1, fpsCam.transform.forward * interact_distance);
            }
        }
	}

    private IEnumerator lineEffect()
    {
        hitLine.enabled = true;

        yield return Duration;

        hitLine.enabled = false;
    }
}
