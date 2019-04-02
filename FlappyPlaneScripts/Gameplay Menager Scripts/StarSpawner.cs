using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public static StarSpawner instance;
    [SerializeField] GameObject[] star;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SpawnStar(float x, float y)
    {
        x += 0.2f;
        if (y < 0)
        {
            y += 3.5f;
            y = Random.Range(y, 4.5f);
        }
        else if (y > 0)
        {
            y -= 3.5f;
            y = Random.Range(-3f, y);
        }
            
        Vector3 spawnPosition = new Vector3(x, y, 0f);
        TakeStar(spawnPosition);
    }
    public void SpawnStar(float x)
    {
        x += 0.2f;
        float y = Random.Range(-3f, 4.5f);
        Vector3 spawnPosition = new Vector3(x, y, 0f);
        TakeStar(spawnPosition);
    }

    void TakeStar(Vector3 spawnPosition)
    {
        int index = 0;
        float changeForStar = Random.Range(0f, 100f);
        if (changeForStar <= 60f) index = 0;
        else if (changeForStar > 60f && changeForStar <= 80f) index = 1;
        else if (changeForStar > 80f && changeForStar <= 90f) index = 2;
        else if (changeForStar > 90f && changeForStar <= 100f) index = 3;
        switch (index)
        {
            case 0:
                Instantiate(star[index], spawnPosition, Quaternion.identity);
                break;
            case 1:
                Instantiate(star[index], spawnPosition, Quaternion.identity);
                break;
            case 2:
                Instantiate(star[index], spawnPosition, Quaternion.identity);
                break;
        default: break;

        }
    }
}
