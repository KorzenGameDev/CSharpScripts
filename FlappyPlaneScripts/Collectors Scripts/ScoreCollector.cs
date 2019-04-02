using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(GameController.ROCK))
        {
            GameplayMenager.instance.AddScore(1);
        }
    }
}
