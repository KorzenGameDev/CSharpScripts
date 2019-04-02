using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour {

    public int demage = 1;
    public GameObject effectDead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerLife player = FindObjectOfType<PlayerLife>();
            player.TakeDemage(demage);

            GameObject effect = Instantiate(effectDead, transform.position, Quaternion.identity);
            Destroy(effect, 3);
            Destroy(gameObject);
        }
    }
}
