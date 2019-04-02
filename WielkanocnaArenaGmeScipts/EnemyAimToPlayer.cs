using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimToPlayer : MonoBehaviour
{
    [SerializeField] Transform target = null;
    bool canLive = false;

    void FixedUpdate()
    {
        if(canLive)
            RotateTowardPlayer();
    }

    public void SetTarget(Transform targetPos) { target = targetPos; }
    public void SetLive(bool live) { canLive = live; }

    void RotateTowardPlayer()
    {
        float angle = AngleBetweenTwoPoints(transform.position, target.position);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 180f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
