using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    private HUDMenu hudMenu;

    private void Start()
    {
        hudMenu = FindObjectOfType<HUDMenu>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // dodanie pieniedzy do huda 
            hudMenu.AddGold(Random.Range(1, 10));
            Destroy(gameObject);
        }
    }
}
