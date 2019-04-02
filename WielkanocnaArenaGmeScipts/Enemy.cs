using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Enemy : MonoBehaviour,IDamageable
{
    [Header("Healthing")]
    [SerializeField] float maxHealth;
    [SerializeField] GameObject splashSprite = null;
    float cHealth;
    [SerializeField] GameObject heartSprite = null;
    [SerializeField] GameObject bloodTrial = null;

    [Header("Sprite")]
    [SerializeField] SpriteRenderer cSprite = null;
    [SerializeField] Sprite[] aSprite = null;


    [Header("Move")]
    [SerializeField]Transform target = null;
    Rigidbody rb=null;
    [SerializeField] float speed = 300f;
    [SerializeField] float stopingDistance = 0.2f;
    [SerializeField] bool canLive = false;


    [Header("Points")]
    public float pointsToAddBeforeDead = 0f; //this param is use in spawner

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cHealth = maxHealth;
        BloodEffect();
    }

    public void SetTarget(Transform targetPos) { target = targetPos; }
    public void SetLive(bool live) { canLive = live; }
    public float GetLiveAsPercent(float own, float max) { return (own / max)*100; }

    private void FixedUpdate()
    {
        if(canLive)
            Move();
    }

    public void TakeDamage(float damage)
    {
        cHealth -= damage;
        if (cHealth <= 0) Dead();
        Instantiate(heartSprite, transform.position, Quaternion.identity);
        BloodEffect();
        ChangeSprite((int)cHealth);
    }

    void ChangeSprite(int _cHealth)
    {
        if (GetLiveAsPercent(cHealth, maxHealth) > 75)
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

    void BloodEffect()
    {
        if(GetLiveAsPercent(cHealth, maxHealth)>90) { bloodTrial.SetActive(false); }
        else {
            Color bodyCol = GetComponentInChildren<SpriteRenderer>().color;
            bloodTrial.GetComponent<ParticleSystem>().startColor = bodyCol; //change to difrent mhetod
            bloodTrial.SetActive(true); }
    }

    private void Dead()
    {
        CameraShaker.Instance.ShakeOnce(1.5f, 1.5f, .1f, .5f);
        Color bodyCol = GetComponentInChildren<SpriteRenderer>().color;
        bodyCol.a = .7f;
        splashSprite.GetComponent<SpriteRenderer>().color = bodyCol;
        Instantiate(splashSprite, transform.position, Quaternion.identity);
        target.GetComponent<PlayerUI>().AddPoint(pointsToAddBeforeDead); //add some points
        Destroy(gameObject);
    }

    void Move()
    {
        Vector2 dir = (target.position - transform.position).normalized;

        if(Vector3.Distance(transform.position, target.position) > stopingDistance)
        {
            rb.velocity = dir * speed * Time.deltaTime;
        }

    }

    
}
