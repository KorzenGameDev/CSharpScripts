using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

    public GameObject[] destroyEffects=new GameObject[4];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            GameObject effect = Instantiate(destroyEffects[0], transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Red") && gameObject.tag == collision.tag)
        {
            GameObject effect = Instantiate(destroyEffects[1], transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Yellow") && gameObject.tag == collision.tag)
        {
            GameObject effect = Instantiate(destroyEffects[2], transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Blue") && gameObject.tag == collision.tag)
        {
            GameObject effect = Instantiate(destroyEffects[3], transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player")){ Debug.Log("Strzal"); }
        else
        {
            BadShot();
        }
        
    }

    public void BadShot()
    {
        GameObject effect = Instantiate(destroyEffects[0], transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
}
