using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIteration : MonoBehaviour
{
    public static EnemyIteration instance;

    public int commonIteration = 0;
    public int miniBossIteraition = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LoadIteration(int commonPlaceCount, int miniBossPlaceCount)
    {
        if (EnemyGeneratorController.instance.procentage)
        {
            commonIteration =(int)(commonPlaceCount * EnemyGeneratorController.instance.procentageCommon)/100;
            miniBossIteraition = (int)(miniBossPlaceCount * EnemyGeneratorController.instance.procentageMiniBoss)/100;
        }
        else if (EnemyGeneratorController.instance.numberCommon != Vector3Int.zero && EnemyGeneratorController.instance.numberMiniBoss != Vector3Int.zero && EnemyGeneratorController.instance.number)
        {
            if (EnemyGeneratorController.instance.numberCommon.x > 0)
            {
                commonIteration = EnemyGeneratorController.instance.numberCommon.x;
            }
            else if (EnemyGeneratorController.instance.numberCommon.y >= 0 && EnemyGeneratorController.instance.numberCommon.z >= 0)
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
                commonIteration = (int)(commonPlaceCount * 0.5f);
            }

            if (EnemyGeneratorController.instance.numberMiniBoss.x > 0)
            {
                miniBossIteraition = EnemyGeneratorController.instance.numberMiniBoss.x;
            }
            else if (EnemyGeneratorController.instance.numberMiniBoss.y >= 0 && EnemyGeneratorController.instance.numberMiniBoss.z >= 0)
            {
                int min = 0;
                int max = 0;

                if (EnemyGeneratorController.instance.numberMiniBoss.y <= EnemyGeneratorController.instance.numberMiniBoss.z)
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
            else
            {
                miniBossIteraition = (int)(miniBossPlaceCount * 0.5f);
            }
        }
        else
        {
            Debug.Log("ERROR! in EnemyGeneratorController, i cant Spawn any enemy");
        }
    }

    public void Restart()
    {
        commonIteration = 0;
        miniBossIteraition = 0;
    }
}
