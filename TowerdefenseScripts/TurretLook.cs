using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLook : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private float range = 15f;
    [SerializeField] private float speedRotate = 10f;
    

    private void Start()
    {
        //powtarza dana funkcje co jakis czas
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        //robi tablice wrogów na scenie
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //petla przechodzaca po wszystkich wrogach
        foreach (var enemy in enemies)
        {
            //obliczanie dystansu do przeciwnika
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            //jesli dystans jest mniejszy niz najkrotszy dystans nakieruj na innego przeciwnika
            if (distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortDistance <= range)
        {
            target = nearestEnemy.transform;
        } 
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
            return;

        //ustalanie kierunku wwroga w stosunku do wiezy
        Vector3 direction = target.position - transform.position;

        //obracanie wrogiem w kierunku wroga
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation,lookRotation, speedRotate *Time.deltaTime).eulerAngles;

        //obraca sie tylko w poziomie nie w pionie
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
    }

    //rysuje linie pomocnicze zasiegu naszego turreta 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public Transform GetTarget()
    {
        return target;
    }

}
