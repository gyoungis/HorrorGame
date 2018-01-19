using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lantern : MonoBehaviour
{

    Light lantern;
    AudioSource soundSource;
    public Slider slider;
    public Image fillArea;
    public Color strongLight = Color.yellow;
    public Color weakLight = Color.red;
    float fuel = 100;


    void Start()
    {
        lantern = GetComponentInChildren<Light>();
        soundSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (lantern.enabled == false)
            {
                lantern.enabled = true;
                soundSource.Play();

            }
            else
            {
                lantern.enabled = false;
                soundSource.Play();

            }
        }

        if (lantern.enabled == true)
        {
            fuel = fuel - Time.fixedDeltaTime * 4.0f;

            if (fuel > 20)
            {
                lantern.intensity = 5.0f;
                fillArea.color = strongLight;
            }

            if (fuel > 0 && fuel < 21)
            {
                lantern.intensity = 2.5f;
                fillArea.color = weakLight;
            }

            if (fuel < 0)
            {
                lantern.enabled = false;
                fuel = 0;
            }
        }
        //else
        //{
        //    if (fuel < 100)
        //    {
        //        fuel = fuel + Time.fixedDeltaTime * 5.0f;

        //        if (fuel > 20)
        //        {
        //            fillArea.color = strongLight;
        //        }
        //    }
        //    else if (fuel > 100)
        //    {
        //        fuel = 100;
        //    }
        //}

        slider.value = fuel;
    }
}
