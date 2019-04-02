using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    public TextMesh point;
    float points;
    public TextMesh life;
    PlayerLife _life;

    private void Start()
    {
        _life = FindObjectOfType<PlayerLife>();
        point.text = ((int)points).ToString();
        life.text = "Life: " + _life.Life;
    }

    private void Update()
    {
        points += (Time.deltaTime * 10);
        point.text = ((int)points).ToString();
    }

    public void ChangeLife()
    {
        life.text = "Life: " + _life.Life;
    }
}
