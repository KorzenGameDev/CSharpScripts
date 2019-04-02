using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemie : MonoBehaviour {

    public bool isActive = false; // determinuje czy na danym poziomie spawner bedzie tworzyc wrogów
    static int nbEnemyToSpawn = 18; //liczba prefabów wrogów jakich można stworzyć
    public GameObject[] enemies = new GameObject[nbEnemyToSpawn]; // Tablica tychrze prefabów
    public int enemyToSpawn = 20; //  ilosc wrogów na jeden spwaner na danym poziomie
    public float startTimeToSpawn=5f; //czas pomiedzy pojawieniami sie wrogów
    float timeToSpawn; //powyzszy czas prywatny


    private void Start()
    {
        timeToSpawn = startTimeToSpawn;
    }

    private void Update()
    {
        // wykonywanie tworzenie wrogów przez swaner
        if (isActive)
        {
            if (timeToSpawn <= 0)
            {
                GameObject enemy = Instantiate(enemies[Random.RandomRange(0, nbEnemyToSpawn)]);
                enemy.GetComponent<EnemyAI>().RandomTargetPosition(Random.RandomRange(1, 4));
                timeToSpawn = startTimeToSpawn;
                enemyToSpawn--;
            }
            else
            {
                timeToSpawn -= Time.deltaTime;
            }

            if (enemyToSpawn <= 0)
            {
                isActive = false;
            }
        }
    }
}
