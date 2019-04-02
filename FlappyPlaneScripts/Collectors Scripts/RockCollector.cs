using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(GameController.ROCK))
        {
            RockSpawner.instance.Spawn();
            Destroy(collision.gameObject);
        }
    }
}
