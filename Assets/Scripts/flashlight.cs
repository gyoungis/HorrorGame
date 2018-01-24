using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashlight : MonoBehaviour {

    Light flashLight;
    AudioSource soundSource;
    public Slider slider;
    public Image fillArea;
    public Color strongLight = Color.yellow;
    public Color weakLight = Color.red;
    float batteryLife = 100;


    void Start()
    {
        flashLight = GetComponentInChildren<Light>();
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
            batteryLife = batteryLife - Time.fixedDeltaTime * 4.0f;

            if (batteryLife > 20)
            {
                flashLight.intensity = 5.0f;
                fillArea.color = strongLight;
            }

            if (batteryLife > 0 && batteryLife < 21)
            {
                flashLight.intensity = 2.5f;
                fillArea.color = weakLight;
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
                batteryLife = batteryLife + Time.fixedDeltaTime * 5.0f;

                if (batteryLife > 20)
                {
                    fillArea.color = strongLight;
                }
            }
            else if (batteryLife > 100)
            {
                batteryLife = 100;
            }
        }

        slider.value = batteryLife;
    }
}
