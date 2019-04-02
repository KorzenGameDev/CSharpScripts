using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("SpawnConfig")]
    [SerializeField] GameObject[] aEnemyToSpawn = null;
    [SerializeField] float startTimeBtwSpawn = 2f;
    [SerializeField] int nbEnemytoSpawn = 10;
    [SerializeField] GameObject player = null;
    [SerializeField] float heightUpDown = 0f; 
    [SerializeField] float widthRightLeft = 0f;
    [SerializeField] float spawnDistance = 10f;
    [SerializeField] GameObject effectForSpawn = null;
    [SerializeField] float timeLiveSpawnEffect = 2f;
    float type = 0;
    [SerializeField] float lvlMultiple = 1;
    float timeBtwSpawn = 0f;
    int cEnemy = 0;

    [Header("ChangeSpawn")]
    [SerializeField] float easy = 0;
    [SerializeField] float middle = 0;
    [SerializeField] float hard = 0;

    


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeBtwSpawn = startTimeBtwSpawn;
    }

    private void FixedUpdate()
    {
        if(nbEnemytoSpawn > 0 && timeBtwSpawn <=0)
        {
            timeBtwSpawn = startTimeBtwSpawn;
            nbEnemytoSpawn--;
            RandomEnemy();
            Vector3 spawnPos = RandomPositionForEnemyInst();
            

            GameObject spawnEffect = Instantiate(effectForSpawn, spawnPos, Quaternion.identity);
            Destroy(spawnEffect, timeLiveSpawnEffect);
            GameObject enemy = Instantiate(aEnemyToSpawn[cEnemy], spawnPos, Quaternion.identity);

            var e = enemy.GetComponent<Enemy>();
            var eatp = enemy.GetComponentInChildren<EnemyAimToPlayer>();
            var esa = enemy.GetComponent<EnemyShootingAttack>();

            if (e != null)
            {
                e.SetTarget(player.transform);
                e.SetLive(true);
            }

            if (eatp != null)
            {
                eatp.SetTarget(player.transform);
                eatp.SetLive(true);
            }

            if (esa!=null)
            {
                esa.SetTarget(player.transform);
                esa.SetLive(true);
            }

            e.pointsToAddBeforeDead = PointsToAdd();
        }
        timeBtwSpawn -= Time.deltaTime;
    }

    void RandomEnemy()
    {
        float all = easy + middle + hard;
        type = Random.Range(0, all);

        if(type <=easy)
        {
            cEnemy = Random.Range(0, 5);
            return;
        }
        if (type <= easy+middle)
        {
            cEnemy = Random.Range(6, 11);
            return;
        }
        if (type<=easy+middle+hard)
        {
            cEnemy = Random.Range(12, 17);
            return;
        }
    }

    Vector3 RandomPositionForEnemyInst()
    {
        float xPos = 0f;
        float yPos = 0f;

        while(true)
        {
            xPos = Random.Range(-widthRightLeft, widthRightLeft);
            yPos = Random.Range(-heightUpDown, heightUpDown);
            Vector3 pos = new Vector3(xPos, yPos, transform.position.z);

            if(Vector3.Distance(player.transform.position,pos) > spawnDistance)
            {
                return pos;
            }
        }
    }
    float PointsToAdd() {   return type * lvlMultiple; }

}
