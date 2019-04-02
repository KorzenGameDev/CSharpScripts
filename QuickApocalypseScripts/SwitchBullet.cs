using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBullet : MonoBehaviour {

    int currentBullet = 0; 

	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBullet = 0;
            Debug.Log("Yellow bullet active");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBullet = 1;
            Debug.Log("Red bullet active");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentBullet = 2;
            Debug.Log("Blue bullet active");
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            currentBullet++;
            if (currentBullet > 2) currentBullet = 0;
        }
    }

    public int GetTypeBullet()
    {
        return currentBullet;
    }
}
