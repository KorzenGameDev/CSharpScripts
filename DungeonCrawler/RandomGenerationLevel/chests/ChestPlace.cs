using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPlace : MonoBehaviour
{
    public static ChestPlace instance;

    [Header("Procentage")]
    [Tooltip("If is true use procentage amount to spawn chest")]
    public bool procentage = false;
    [Tooltip("Procentage range determinate how meny chest can be spawn on map.")]
    [Range(10, 100)] public int chestAmount = 10;

    [Header("Numbers")]
    [Tooltip("If is true use numbers range to spawn chest")]
    public bool numbers = false;
    [Tooltip("Range determinate how many chest spawn on map. Range between x-y(min, max)")]
    public Vector2Int chestRange = new Vector2Int(0, 0);

    [Header("Lists")]
    [Tooltip("List placed chest.")]
    public List<Transform> placedChest = new List<Transform>();
    int iteration = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        numbers = !procentage;
    }

    public void PlaceChest()
    {
        LoadIteration();
        while(iteration>0)
        {
            Transform c = placedChest[Random.Range(0, placedChest.Count)];
            Destroy(c.gameObject);
            placedChest.Remove(c);
            iteration--;
        }

    }

    void LoadIteration()
    {
        if (procentage)
        {
            iteration = (int)(placedChest.Count*chestAmount)/100;
            iteration = placedChest.Count - iteration;
        }
        else if (numbers)
        {
            if(chestRange.x<=chestRange.y)
                iteration = Random.Range(chestRange.x, chestRange.y);
            else
                iteration = Random.Range(chestRange.y, chestRange.x);

            if (iteration > placedChest.Count) iteration = placedChest.Count;

            iteration = placedChest.Count - iteration;
        }
        else Debug.Log("You must chose type of spawn chests!");
    }
}
