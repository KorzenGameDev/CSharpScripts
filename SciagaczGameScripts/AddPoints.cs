using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPoints : MonoBehaviour {

    public Text pointsText;
    private float points;

    private void Start()
    {
        points = PlayerPrefs.GetFloat("point");
    }

    void Update () {

        pointsText.text = "Test: " + (int)points;
	}

    private void FixedUpdate()
    {

        PlayerPrefs.SetFloat("point", points);
    }

    public float AddPoint(float add)
    {
        points += add;
        return points;
    }

    public void NewGamePoints()
    {
        points = PlayerPrefs.GetFloat("point");
    }
}
