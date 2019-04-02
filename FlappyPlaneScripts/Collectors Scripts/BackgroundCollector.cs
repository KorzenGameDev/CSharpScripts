using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollector : MonoBehaviour
{
    GameObject[] backgrounds;
    float lastBackgroundX=0f;

    private void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag(GameController.BACKGROUND);
        foreach (var bg in backgrounds)
        {
            if (lastBackgroundX < bg.transform.position.x)
                lastBackgroundX = bg.transform.position.x;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(GameController.BACKGROUND))
        {
            Vector3 temp = collision.transform.position;
            temp.x = collision.GetComponent<BoxCollider2D>().size.x * collision.transform.localScale.x + lastBackgroundX;
            collision.transform.position = temp;
            lastBackgroundX = temp.x;
        }
    }
}
