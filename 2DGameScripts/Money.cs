using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {

    public MoneyMenager moneyMenager;
    public GameObject moneyParticle;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        moneyMenager = FindObjectOfType<MoneyMenager>();

        if(collision.CompareTag("Player"))
        {
            moneyMenager.AddMoney();
            GameObject effectMoney=(GameObject) Instantiate(moneyParticle, transform.position, transform.rotation);
            Destroy(effectMoney, 2f);
            Destroy(gameObject);
        }
    }
}
