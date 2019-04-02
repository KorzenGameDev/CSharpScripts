using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float damage = 25f;
    [SerializeField] private float explosionRadius = 0f;

    public GameObject particleBulletImapct;
    [SerializeField] private float speedBullet =70f;


    // funkcja pobierajaca pozycje przeciwnika od turretu ktory go sledzi
    public void Seek(Transform _target)
    {
        target = _target;
    }


    private void Update()
    {
        //jesli zgubisz target znisz sie
        if(target==null)
        {
            Destroy(gameObject);
            return;
        }

        //kierunek lotu i predkos dokladnei w tej klatce 
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speedBullet * Time.deltaTime;

        if(direction.magnitude<=distanceThisFrame)
        {
            //funkja trafienia
            HitTarget();
            return;
        }

        //poruszanie sie w wyznaczonym kierunku z podana predkoscia, SpaceWorld bierze wymiary i rotacje świata nie danego obiektu
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

        //pocisk podarza za enemy i zwraca sie w jego kierunku
        transform.LookAt(target);
    }

    //funkcjaa trafienia stworz efekt particle i zniszcz obiekty
    void HitTarget()
    {
        //efekt uderzenia pocisku
        GameObject effectsBulletImpact=(GameObject)Instantiate(particleBulletImapct, transform.position, transform.rotation);

        // jesli nie ma promienia eksplozi to atakuj pojedynczy target
        //misslie
        if(explosionRadius>0f)
        {
            Explode();
        }

        //standart bullet
        else
        {
            Damage(target);
        }

        //niszczenie wszystkiego po uderzeniu
        Destroy(effectsBulletImpact, 3f);
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        //niszczy wroga obecnie
        Enemy e = enemy.GetComponent<Enemy>();

        if(e!=null)
        {
            e.TakeDamage(damage);
        }
    } 
        


    void Explode()
    {
        // tworzenie niewidzialnej sfery wokol naszej pozycji i przypisanie jej kolidera 
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            //jesli w naszej sferza razenia znajduje sie wrogowie o tagu Enemi
            //przekaz ich pozycjie do funckcji obrazenia
            if(collider.tag=="Enemy")
            {

                //zadaj obrazenia wrogom
                Damage(collider.transform);
            }

        }
    }

    //rysuje pole razenia rakiety gdy wybierzemy rakiete
    private void OnDrawGizmosSelected()
    {
        //koloru czerwonego
        Gizmos.color = Color.red;

        //kształt rysowanego pola kula
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
