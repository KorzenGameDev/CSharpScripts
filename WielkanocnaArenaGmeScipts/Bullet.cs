using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Bullet : MonoBehaviour
{
    [SerializeField] bool isPlayerBullet = false;
    [SerializeField] GameObject destructionEffect = null;
    Rigidbody rb;
    float speed = 1000f;
    float dmg = 10f;
    Vector3 dir = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed *Time.deltaTime;
    }

    public void VelocityToBullet( Vector2 _dir, float speed)
    {
        this.speed = speed;
        dir = new Vector3(_dir.x, _dir.y, 0);
    }

    public void SetWhoIsBullet(bool whoIs) { isPlayerBullet = whoIs; }
    public void SetDmg(float dmg) { this.dmg = dmg; }

    private void OnTriggerEnter(Collider other)
    {
        if(isPlayerBullet && other.CompareTag("Enemy"))
        {
            IDamageable dEnemy = other.gameObject.GetComponent<IDamageable>();
            if(dEnemy!=null) {  dEnemy.TakeDamage(dmg);}

            CameraShaker.Instance.ShakeOnce(1f, 1f, .1f, .5f);
            Effect();
            return;
        }

        if (!isPlayerBullet && other.CompareTag("Player"))
        {
            IDamageable dPlayer = other.gameObject.GetComponent<IDamageable>();
            if (dPlayer != null){ dPlayer.TakeDamage(dmg);}

            CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, .5f);
            Effect();
            return;
        }

        if (other.CompareTag("Wall"))
        {
            Effect();
            return;
        }
    }

    void Effect()
    {
        
        GameObject e = Instantiate(destructionEffect, transform.position, Quaternion.identity);
        float time = destructionEffect.GetComponent<ParticleSystem>().main.duration;
        Destroy(e, time);
        Destroy(gameObject);
    }
}