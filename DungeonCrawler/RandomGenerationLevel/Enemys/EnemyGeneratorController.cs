using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    public static EnemyGeneratorController instance;

    public EnemyType.Type enemyType;

    [Header("EnemyLists")]
    public List<EnemyListHolder> enemyLists = new List<EnemyListHolder>();
    //  1.Undeads
    //  2.Goblins
    //  3.All

    public List<GameObject> commonCreatures = new List<GameObject>();
    public List<GameObject> miniBossCreatures = new List<GameObject>();
    public List<GameObject> bossCratures = new List<GameObject>();

    [Header("Spawn Procentage")]
    // 0-100
    public bool procentage=false;
    [Range(10, 100)] public int procentageCommon = 10;
    [Range(10, 100)] public int procentageMiniBoss = 10;
    //public int procentageBoss=0;

    [Header("Spawn Numbers")]
    // x - Numbers of enemy to spown
    // y-z - Range btw two numbers
    public bool number=false;
    public Vector3Int numberCommon = new Vector3Int();
    public Vector3Int numberMiniBoss = new Vector3Int();
    //public Vector3 numberBoss = new Vector3();


    //Must be not null if you want not random boss
    public GameObject boss = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        // number more important then procentage
        procentage = !number;
    }

    public void LoadCreatures()
    {
        switch(enemyType)
        {
            case EnemyType.Type.Undead:
                AddEnemyToList(enemyLists[0]);
                break;
            case EnemyType.Type.Goblin:
                AddEnemyToList(enemyLists[1]);
                break;
            case EnemyType.Type.UndeadGoblin:
                AddEnemyToList(enemyLists[0]);
                AddEnemyToList(enemyLists[1]);
                break;
            case EnemyType.Type.All:
                foreach(EnemyListHolder lists in enemyLists)
                {
                    AddEnemyToList(lists);
                }
                break;

        }
    }

    void AddEnemyToList(EnemyListHolder enemyHolder)
    {
        foreach (GameObject enemy in enemyHolder.commonCreatures)
        {
            commonCreatures.Add(enemy);
        }
        foreach(GameObject miniBoss in enemyHolder.miniBossCreatures)
        {
            miniBossCreatures.Add(miniBoss);
        }
        foreach(GameObject boss in enemyHolder.bossCreatures)
        {
            bossCratures.Add(boss);
        }
    }

    void ResetEnemyList()
    {
        commonCreatures.Clear();
        miniBossCreatures.Clear();
        bossCratures.Clear();
    }
}
