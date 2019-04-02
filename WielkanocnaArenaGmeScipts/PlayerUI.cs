using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Text pointsSlot = null;
    [SerializeField] float points = 0f;


    private void Start()
    {
        UpdatePoints();
    }
    
    string WritePoints() { return ("Points: " + (int)points); }
    void UpdatePoints() { pointsSlot.text = WritePoints(); }
    public void AddPoint(float add) { points += add; UpdatePoints(); }
}
