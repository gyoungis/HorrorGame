﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    public int state = 1;
	// Use this for initialization
	public void pickedUp(int picked)
    {
        state = state - picked;

        if (state == 0)
        {
            gameObject.SetActive(false);
        }
    }
}