using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour {

    public bool isNewGame = false;
    public SpawnerEnemie[] spawner = new SpawnerEnemie[12];
    public static int nbActiveSpawner =2;
    int[] tabActiveSpawner = new int[nbActiveSpawner];

    private void Start()
    {
        for (int i = 0; i < nbActiveSpawner; i++)
        {
            tabActiveSpawner[i] = Random.RandomRange(0, 11);
            for (int j = 0; j < i; j++)
            {
                if(tabActiveSpawner[j]==tabActiveSpawner[i])
                {
                    i--;
                    break;
                }
            }
        }

        for (int i = 0; i < nbActiveSpawner; i++)
        {
            spawner[tabActiveSpawner[i]].isActive = true;
        }
    }
}
