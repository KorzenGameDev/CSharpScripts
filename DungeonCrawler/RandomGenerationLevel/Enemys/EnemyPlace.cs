using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlace : MonoBehaviour
{
    public static EnemyPlace instance;

    [Tooltip("Place for spawn common creatures.")]
    public List<Transform> availablesPlaceForCommonCreatures = new List<Transform>();
    [Tooltip("Place for spawn mini boss creatures.")]
    public List<Transform> availablesPlaceForMiniBossCreatures = new List<Transform>();
    [Tooltip("Place for spawn boss creatures")]
    public List<Transform> availablesPlaceForBossCreatures = new List<Transform>();

    [Tooltip("List placed creatures on map.")]
    public List<GameObject> placedCreatures = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        EnemyGeneratorController.instance.LoadCreatures();
    }

    public void StartPlace()
    {
        EnemyIteration.instance.LoadIteration(availablesPlaceForCommonCreatures.Count, availablesPlaceForMiniBossCreatures.Count);

        if (availablesPlaceForCommonCreatures.Count > 0)
        {
            for (int i = 0; i < EnemyIteration.instance.commonIteration; i++)
            {
                GameObject creature = EnemyGeneratorController.instance.commonCreatures[Random.Range(0, EnemyGeneratorController.instance.commonCreatures.Count)];
                PlaceCreature(ref availablesPlaceForCommonCreatures, creature);
            }
        }
        else Debug.Log("You dont have space for common creatures");

        if (availablesPlaceForMiniBossCreatures.Count > 0)
        {
            for (int i = 0; i < EnemyIteration.instance.miniBossIteraition; i++)
            {
                GameObject creature = EnemyGeneratorController.instance.miniBossCreatures[Random.Range(0, EnemyGeneratorController.instance.miniBossCreatures.Count)];
                PlaceCreature(ref availablesPlaceForMiniBossCreatures, creature);
            }
        }
        else Debug.Log("You dont have space for miniboss creatures");

        if (availablesPlaceForBossCreatures.Count > 0)
        {
            GameObject creature=null;

            if (EnemyGeneratorController.instance.boss == null)
            {
                creature = EnemyGeneratorController.instance.bossCratures[Random.Range(0, EnemyGeneratorController.instance.bossCratures.Count)];
            }
            else
            {
                creature = EnemyGeneratorController.instance.boss;
            }

            PlaceCreature(ref availablesPlaceForBossCreatures, creature);
        }
        else Debug.Log("You dont have space for boss creatures");
    }

    void PlaceCreature(ref List<Transform> list, GameObject creature)
    {
        Debug.Log("Enemy Placed!");
        Transform placeForCreature = list[Random.Range(0, list.Count)];

        GameObject placedCreature = Instantiate(creature) as GameObject;

        placedCreature.transform.parent = EnemyGeneratorController.instance.enemyHolder.transform;
        placedCreature.transform.position = placeForCreature.transform.position;
        placedCreature.transform.rotation = placeForCreature.transform.rotation;
        //placedCreature.GetComponent<Enemy>().

        list.Remove(placeForCreature);
        placedCreatures.Add(placedCreature);
    }

    public void Restart()
    {
        availablesPlaceForCommonCreatures.Clear();
        availablesPlaceForMiniBossCreatures.Clear();
        availablesPlaceForBossCreatures.Clear();

        foreach (GameObject creature in placedCreatures)
            Destroy(creature);

        placedCreatures.Clear();
    }
}
