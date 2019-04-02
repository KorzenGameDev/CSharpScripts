using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddedPointPerSec : MonoBehaviour {

    private float pointsToAdd = 0f;
    private float timeAdd = 1f;
    AddPoints add;

    private void Start()
    {
        add = FindObjectOfType<AddPoints>();
    }

    private void Update()
    {
        if(timeAdd<=0)
        {
            add.AddPoint(pointsToAdd);
            timeAdd = 1f;
        }

        timeAdd -= Time.deltaTime;
    }

    public void AddPointToPull(float toAdd)
    {
        pointsToAdd += toAdd;
    }
}
