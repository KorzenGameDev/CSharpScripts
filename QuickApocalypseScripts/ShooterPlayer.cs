using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlayer : MonoBehaviour {

    public Rigidbody2D[] prefabBullet=new Rigidbody2D[2];
    public float speedAttack=0.2f;
    public float speedBullet = 1200f;
    public Transform pointShoot;
    SwitchBullet typeBullet;

    private float cooldown;

    private void Start()
    {
        typeBullet = GetComponent<SwitchBullet>();
    }

    void Update () {
		if(Time.time>=cooldown)
        {
            if(Input.GetMouseButton(0))
            {
                Shooting();
            }
        }
	}

    void Shooting()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z));

        Quaternion q = Quaternion.FromToRotation(Vector3.up, screenPos - transform.position);

        Rigidbody2D bullet;
        if(transform.localScale.x < 0)
        {
            bullet = Instantiate(prefabBullet[typeBullet.GetTypeBullet()], pointShoot.position, q) as Rigidbody2D;
        }
        else
        {
            bullet = Instantiate(prefabBullet[typeBullet.GetTypeBullet()], new Vector3(transform.position.x + pointShoot.localPosition.x, transform.position.y + pointShoot.localPosition.y, transform.position.z), q) as Rigidbody2D;
        }

        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * speedBullet);

        cooldown = Time.time + speedAttack;
    }
}
