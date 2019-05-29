using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorController : MonoBehaviour
{
    public static EnemyGeneratorController instance;

    [Tooltip("Enemy type to spawn creatures.")]
    public EnemyType.Type enemyType;

    [Header("EnemyLists")]
    [Tooltip("List of list enemy to spawn. 1.Undeads 2.Goblins")]
    public List<EnemyListHolder> enemyLists = new List<EnemyListHolder>();
    //  1.Undeads
    //  2.Goblins

    [Tooltip("List creatures to random spawn.")]
    public List<GameObject> commonCreatures = new List<GameObject>();
    [Tooltip("List creatures to random spawn.")]
    public List<GameObject> miniBossCreatures = new List<GameObject>();
    [Tooltip("List creatures to random spawn.")]
    public List<GameObject> bossCratures = new List<GameObject>();

    [Header("Spawn Procentage")]
    [Tooltip("If is true we spawn enemy random use procentage.")]
    public bool procentage=false;
    [Tooltip("Determines how meny creatures are spawn.")]
    [Range(10, 100)] public int procentageCommon = 10;
    [Tooltip("Determines how meny creatures are spawn.")]
    [Range(10, 100)] public int procentageMiniBoss = 10;
    //public int procentageBoss=0;

    [Header("Spawn Numbers")]
    // x - Numbers of enemy to spown
    // y-z - Range btw two numbers
    [Tooltip("If is true we spawn enemy random use numbers.")]
    public bool number=false;
    [Tooltip("Determinate how many creatures will be spawn on map. x-exacly number, y-z range beetween x-y(min, max)")]
    public Vector3Int numberCommon = new Vector3Int();
    [Tooltip("Determinate how many creatures will be spawn on map. x-exacly number, y-z range beetween x-y(min, max)")]
    public Vector3Int numberMiniBoss = new Vector3Int();
    //public Vector3 numberBoss = new Vector3();

    //Must be not null if you want not random boss
    [Tooltip("Boss who must be spawn on map. If is null boss is choose randomly.")]
    public GameObject boss = null;

    [Tooltip("Place for hold all enemy on map.")]
    public Transform enemyHolder = null;

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
                    AddEnemyToList(lists);
                break;
        }
    }

    void AddEnemyToList(EnemyListHolder enemyHolder)
    {
        AddEnemy(commonCreatures, enemyHolder.commonCreatures);
        AddEnemy(miniBossCreatures, enemyHolder.miniBossCreatures);
        AddEnemy(bossCratures, enemyHolder.bossCreatures);
    }

    void AddEnemy(List<GameObject> list ,List<GameObject> add)
    {
        foreach (GameObject enemy in add)
            list.Add(enemy);

    }
}
