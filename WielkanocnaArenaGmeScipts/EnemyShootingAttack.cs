using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingAttack : MonoBehaviour
{
    [SerializeField] Transform target=null;
    [SerializeField] float shootDistance = 10f;
    bool canLive = false;

    [Header("Bullet Settings")]
    [SerializeField] GameObject[] tiles = null;
    [SerializeField] float speed = 1000f; //bullet speed
    [SerializeField] float bulletLifeTime = 5f;
    [SerializeField] float damagePerHit = 10f;
    Vector2 dir = Vector2.zero;

    [Header("Gun Settings")]
    [SerializeField] Transform shotPoint = null;
    [SerializeField] float fireTime = 1f;
    [SerializeField] float fireRate = 4f;
    bool canShot = true; //is true when characters can shoot  

    public void Shot()
    {
        if (Vector3.Distance(transform.position, target.position) <= shootDistance)
        {
            DirectionTileToTarget();
            InstRandomTiles(tiles.Length);
            StartCoroutine(FireRate());
        }
    }
    public void SetTarget(Transform targetPos) { target = targetPos; }
    public void SetLive(bool live) { canLive = live; }

    private void FixedUpdate()
    {
        if (canShot && canLive)
            Shot();
    }

    float TimeWaitForShoot() { return fireTime / fireRate; }

    IEnumerator FireRate()
    {
        canShot = false;
        yield return new WaitForSeconds(TimeWaitForShoot());
        canShot = true;
    }


    // BULLET METHODS
    void DirectionTileToTarget()
    {
        dir = (target.position - transform.position).normalized;
    }

    void InstRandomTiles(int nb)
    {
        int cTile = 0;
        if (nb > 1) cTile = Random.Range(0, nb);

        BulletIns(cTile);
    }

    void BulletIns(int tile)
    {
        GameObject bullet = Instantiate(tiles[tile], shotPoint.position, Quaternion.identity);
        //Debug.Log("direction 2" + dir);

        // Przesyłąnie zmiennych do powstaęłgo obiektu bullet
        Bullet bul = bullet.GetComponent<Bullet>();
        bul.VelocityToBullet(dir, speed);
        bul.SetDmg(damagePerHit);
        bul.SetWhoIsBullet(false);

        Destroy(bullet, bulletLifeTime);
    }
    //END BULLET METHODS
}
