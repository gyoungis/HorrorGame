using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour {

    Light flashLight;
    AudioSource soundSource;
    float batteryLife = 100;


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

        if (flashLight.enabled == true)
        {
            batteryLife = batteryLife - Time.fixedDeltaTime;

            if (batteryLife > 25)
            {
                flashLight.intensity = 5.0f;
            }

            if (batteryLife > 0 && batteryLife < 26)
            {
                flashLight.intensity = 2.5f;
            }

            if (batteryLife < 0)
            {
                flashLight.enabled = false;
                batteryLife = 0;
            }
        }
        else
        {
            if (batteryLife < 100)
            {
                batteryLife = batteryLife + Time.fixedDeltaTime;
            }
            else if (batteryLife > 100)
            {
                batteryLife = 100;
            }
        }
        Debug.Log(batteryLife);
    }
}
