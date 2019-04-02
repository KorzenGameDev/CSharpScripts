using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public static RockSpawner instance;
    [SerializeField] GameObject[] rocks;
    float minY1, minY2, maxY1, maxY2;
    float LastX;
    int rocksInFirstWave;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        minY1 = -4f;
        minY2 = -2f;
        maxY1 = 2.5f;
        maxY2 = 4f;

        LastX = 10f;
        rocksInFirstWave = 20;
    }
    private void Start()
    {
        for (int i = 0; i < rocksInFirstWave; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        int index=Random.Range(0,2);
        Vector3 rockPosition=Vector3.zero;
        if (index==0)
        {
            rockPosition = RandomisePosition(minY1, minY2);
            Instantiate(rocks[index], rockPosition, Quaternion.identity );
        }else if (index == 1)
        {
            rockPosition = RandomisePosition(maxY1, maxY2);
            Instantiate(rocks[index], rockPosition, Quaternion.identity);
        }

        StarSpawner.instance.SpawnStar(rockPosition.x, rockPosition.y);
        StarSpawner.instance.SpawnStar(rockPosition.x+2.5f);
    }
    Vector3 RandomisePosition(float min, float max)
    {
        Vector3 temp = Vector3.zero;
        temp.x = LastX;
        LastX += 5f;
        temp.y = Random.Range(min, max);
        return temp;
    }
}
