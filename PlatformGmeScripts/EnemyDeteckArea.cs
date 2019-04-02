using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeteckArea : MonoBehaviour
{
    public bool isAttacked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isAttacked = false;
    }
}
