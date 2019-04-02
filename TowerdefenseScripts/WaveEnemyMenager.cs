using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyMenager : MonoBehaviour {

    public Transform prefabEnemy;
    [SerializeField]private Transform spawnPoint;

    [SerializeField]private int waveNumber = 1;
    [SerializeField] private float valueTimeSpawn=5f;
    [SerializeField] private float timeOneEnemySpawn = 0.35f;
    private float timeSpawn = 2f;

    [SerializeField]private int minGold = 0;
    [SerializeField]private int maxGold = 0;

    private void Update()
    {
        if (timeSpawn <= 0f)
        {
            timeSpawn = valueTimeSpawn;
            StartCoroutine(SpawnWaveEnemy());
        }

        StartCoroutine(GoldPerKill());
        timeSpawn -= Time.deltaTime; 
    }

    IEnumerator SpawnWaveEnemy()
    {
        for (int i = 0; i < waveNumber*EnemyInWave() ; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeOneEnemySpawn);
        }
        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(prefabEnemy, spawnPoint.position, spawnPoint.rotation);
    }

    float EnemyInWave()
    {
        return (float)Random.Range(1f,2.5f);
    }

    IEnumerator GoldPerKill()
    {
        minGold = 5;
        maxGold = 25;
        Debug.Log("1.stopien");
        yield return new WaitForSeconds(15f);
        minGold = 5;
        maxGold = 20;
        Debug.Log("2.stopien");
        yield return new WaitForSeconds(20f);
        minGold = 5;
        maxGold = 15;
        Debug.Log("3.stopien");
        yield return new WaitForSeconds(60f);
        minGold = 3;
        maxGold = 10;
        Debug.Log("4.stopien");
    }
    
    public int GetMinGold()
    {
        return minGold;
    }

    public int GetMaxGold()
    {
        return maxGold;
    }
}
