using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicer : MonoBehaviour {

    AddPoints addPoints;
    private float currentAddedPoint=1f;

    private void Start()
    {
        addPoints = FindObjectOfType<AddPoints>();
    }

    public void Click()
    {
        if (currentAddedPoint < 1) currentAddedPoint = 100;

        addPoints.AddPoint(currentAddedPoint);
    }

    public void SetAddPoints(float add)
    {
        currentAddedPoint = add;
            if (currentAddedPoint < 1f) currentAddedPoint = 1f;
    }
}
