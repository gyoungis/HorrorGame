using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour {

    public int state = 1;

    public void pickedUp(int picked)
    {
        state = state - picked;

        if (state < 1)
        {
            gameObject.SetActive(false);
        }
    }

}
