using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]private float speedBullet=1000f;
    [SerializeField] private float damage = 50f;

    public Rigidbody2D rb;
    public GameObject imactBulletParticle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // nadanie predkosci pociskowi
        rb.velocity = transform.right * speedBullet * Time.deltaTime;

        //niszczenie pocisku
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // jesli pocisk uderzy w podloze to zniszcz go i stworz particle na jego miejscu
        if (collision.CompareTag("Ground") && imactBulletParticle!=null)
        {
            GameObject effectImpact = (GameObject) Instantiate(imactBulletParticle, transform.position, transform.rotation);

            Destroy(effectImpact, 2f);
            Destroy(gameObject);
        }
            

        else
        {
            //podczas kolizji z danym obiektem enemy pobiera jego komponent
            Enemy enemy = collision.GetComponent<Enemy>();

            if(enemy!=null && imactBulletParticle!=null)
            {
                GameObject effectImpact = (GameObject)Instantiate(imactBulletParticle, transform.position, transform.rotation);

                // odniesienie do funkj znajdujacej sie w Enemy.cs odpowiedzialnej za smierc przeciwnika
                enemy.Damage(damage);

                Destroy(effectImpact, 2f);
                Destroy(gameObject);
            }
        }

    }

}
