using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int value;
    [SerializeField] GameObject particleEffect;
    [SerializeField] AudioClip starClip;
    public void Boom()
    {
        GameController.instance.PlayAnyClip(starClip);
        GameObject effect= Instantiate(particleEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }
}
