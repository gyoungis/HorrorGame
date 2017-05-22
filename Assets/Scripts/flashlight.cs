using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour {

    Light flashLight;
    AudioSource soundSource;

    void Start()
    {
        flashLight = GetComponent<Light>();
        soundSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (flashLight.enabled == false)
            {
                flashLight.enabled = true;
                soundSource.Play();
            }
            else
            {
                flashLight.enabled = false;
                soundSource.Play();
            }
        }
    }
}
