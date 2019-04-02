using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour {

    [SerializeField]private float fireRate = 4f;
    private float fireCountdown = 0f;

    public GameObject prefabBullet;
    [SerializeField]private Transform[] firePoint;
    private TurretLook targetLook;

    private void Start()
    {
        targetLook = GetComponent<TurretLook>();
    }
    private void Update()
    {
        //jesli target jest poza rangem zgub go
        if (targetLook.GetTarget() == null)
        {
            return;
        }

        //czas do wystrzału
        if(fireCountdown<=0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        //odliczanie do kolejnego wystrzalu
        fireCountdown -= Time.deltaTime;
        
    }

    //strzal
    void Shoot()
    {
        //jesli mamy tylko jedna lufe strzelaj jednym pociskiem
        for(int i=0; i<firePoint.Length;i++)
        {
            if (firePoint[i] != null)
            {
                GameObject bulletGO = (GameObject)Instantiate(prefabBullet, firePoint[i].position, firePoint[i].rotation);
                Bullet bullet = bulletGO.GetComponent<Bullet>();

                if (bullet != null)
                    bullet.Seek(targetLook.GetTarget());
            }
        }
        
    }
}
