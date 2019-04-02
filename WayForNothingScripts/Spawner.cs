using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform[] spawnPoint;
    public GameObject enemy;
    float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float offset=65f;

    PlayerMovment player;

    private void Start()
    {
        timeBtwSpawn = startTimeBtwSpawn;
        player=FindObjectOfType<PlayerMovment>();
    }

    private void Update()
    {
        transform.position = new Vector2(player.transform.position.x + offset, transform.position.y);

        if(timeBtwSpawn<=0f)
        {
            GameObject enemy1 = Instantiate(enemy, spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);
            GameObject enemy2 = Instantiate(enemy, spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);
            if(enemy1.transform.position==enemy2.transform.position)
            {
                Destroy(enemy2);
            }
            if (enemy1 != null)
                Destroy(enemy1, 10);
            if (enemy2 != null)
                Destroy(enemy2, 10);

            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

    }
}
