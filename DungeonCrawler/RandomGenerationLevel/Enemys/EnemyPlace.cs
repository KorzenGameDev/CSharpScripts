using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlace : MonoBehaviour
{
    public static EnemyPlace instance;

    public List<Transform> availablesPlaceForCommonCreatures = new List<Transform>();
    public List<Transform> availablesPlaceForMiniBossCreatures = new List<Transform>();
    public List<Transform> availablesPlaceForBossCreatures = new List<Transform>();

    public List<GameObject> placedCreatures = new List<GameObject>();

    int commonIteration = 0;
    int miniBossIteraition = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void StartPlace()
    {
        //Load creauture
        EnemyGeneratorController.instance.LoadCreatures();

        //Load iteration
        LoadIteration();
        //Debug.Log("Common creatures: " + commonIteration);
        //Debug.Log("Mini boss creatures: " + miniBossIteraition);

        if (availablesPlaceForCommonCreatures.Count > 0)
        {
            for (int i = 0; i < commonIteration; i++)
            {
                GameObject creature = EnemyGeneratorController.instance.commonCreatures[Random.Range(0, EnemyGeneratorController.instance.commonCreatures.Count)];
                PlaceCreature(ref availablesPlaceForCommonCreatures, creature);
            }
        }
        else Debug.Log("You dont have space for common creatures");

        if (availablesPlaceForMiniBossCreatures.Count > 0)
        {
            for (int i = 0; i < miniBossIteraition; i++)
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

        //Find room for place enmemy
        Transform placeForCreature = list[Random.Range(0, list.Count)];

        //istantiate chest
        GameObject placedCreature = Instantiate(creature) as GameObject;

        placedCreature.transform.parent = this.transform;
        placedCreature.transform.position = placeForCreature.transform.position;
        placedCreature.transform.rotation = placeForCreature.transform.rotation;
        //TODO add reference to Enemy
        //add to list
        list.Remove(placeForCreature);
        placedCreatures.Add(placedCreature);
    }

    void LoadIteration()
    {
        if(EnemyGeneratorController.instance.procentage)
        {
            commonIteration = (int)availablesPlaceForCommonCreatures.Count * EnemyGeneratorController.instance.procentageCommon / 100;
            miniBossIteraition = (int)availablesPlaceForMiniBossCreatures.Count * EnemyGeneratorController.instance.procentageMiniBoss / 100;
        }
        else if(EnemyGeneratorController.instance.numberCommon!=Vector3Int.zero && EnemyGeneratorController.instance.numberMiniBoss!=Vector3Int.zero && EnemyGeneratorController.instance.number)
        {
            if (EnemyGeneratorController.instance.numberCommon.x > 0)
            {
                commonIteration = EnemyGeneratorController.instance.numberCommon.x;
            }
            else if(EnemyGeneratorController.instance.numberCommon.y >= 0 && EnemyGeneratorController.instance.numberCommon.z>=0)
            {
                int min = 0;
                int max = 0;

                if (EnemyGeneratorController.instance.numberCommon.y <= EnemyGeneratorController.instance.numberCommon.z)
                {
                    min = EnemyGeneratorController.instance.numberCommon.y;
                    max = EnemyGeneratorController.instance.numberCommon.z;
                }
                else
                {
                    min = EnemyGeneratorController.instance.numberCommon.z;
                    max = EnemyGeneratorController.instance.numberCommon.y;
                }

                commonIteration = Random.Range(min, max);
            }
            else
            {
                commonIteration = (int)(availablesPlaceForCommonCreatures.Count * 0.5f);
            }

            if(EnemyGeneratorController.instance.numberMiniBoss.x>0)
            {
                miniBossIteraition = EnemyGeneratorController.instance.numberMiniBoss.x;
            }
            else if(EnemyGeneratorController.instance.numberMiniBoss.y>=0 && EnemyGeneratorController.instance.numberMiniBoss.z>=0)
            {
                int min = 0;
                int max = 0;

                if(EnemyGeneratorController.instance.numberMiniBoss.y <= EnemyGeneratorController.instance.numberMiniBoss.z)
                {
                    min = EnemyGeneratorController.instance.numberMiniBoss.y;
                    max = EnemyGeneratorController.instance.numberMiniBoss.z;
                }
                else
                {
                    min = EnemyGeneratorController.instance.numberMiniBoss.z;
                    max = EnemyGeneratorController.instance.numberMiniBoss.y;
                }

                miniBossIteraition = Random.Range(min, max);
            }
        }
        else
        {
            Debug.Log("ERROR! in EnemyGeneratorController, i cant Spawn any enemy");
        }
    }
}
