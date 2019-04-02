using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    [Header("Healthing")]
    [SerializeField] float maxHealth;
    [SerializeField] GameObject bloodTrial=null;
    float cHealth;

    [Header("Sprite")]
    [SerializeField] SpriteRenderer cSprite = null;
    [SerializeField] Sprite[] aSprite = null;
    

    private void Start()
    {
        cHealth = maxHealth;
        BloodTrial();
    }

    public void TakeDamage(float damage)
    {
        cHealth -= damage;
        if (cHealth <= 0) Dead();
        ChangeSprite();
        BloodTrial();
    }

    private void Dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float GetLiveAsPercent(float own, float max) { return (own / max)*100; }

    void ChangeSprite()
    {
        if(GetLiveAsPercent(cHealth, maxHealth) > 75)
        {
            cSprite.sprite = aSprite[0];
            return;
        }
        if (GetLiveAsPercent(cHealth, maxHealth) > 50)
        {
            cSprite.sprite = aSprite[1];
            return;
        }
        if (GetLiveAsPercent(cHealth, maxHealth) > 25)
        {
            cSprite.sprite = aSprite[2];
            return;
        }
        if (GetLiveAsPercent(cHealth, maxHealth) > 0)
        {
            cSprite.sprite = aSprite[3];
            return;
        }
    }
    void BloodTrial()
    {
        if(cHealth>90){ bloodTrial.SetActive(false);}
        else{ bloodTrial.SetActive(true);}
    }


}
