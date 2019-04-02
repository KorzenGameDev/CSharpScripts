using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    static int nbEnemie = 3;
    public int typeEnemie;

    public int[] health = new int[nbEnemie];
    public float[] speed = new float[nbEnemie];
    public GameObject[] deadEffects = new GameObject[nbEnemie];
    int typeColorEnemie = 0;
    public bool disorientation = false;
    private float disorientationTime = 1f;
    Vector3 disorientationPos;

    public float timeBeforTargetPlayer=3f;
    PlayerController target;

    private void Start()
    {
        target = FindObjectOfType<PlayerController>();

        switch (gameObject.tag)
        {
            case "Red": typeColorEnemie = 0;
                break;
            case "Yellow":
                typeColorEnemie = 1;
                break;
            case "Blue":
                typeColorEnemie = 2;
                break;

            default:
                break;
        }
    }

    

    private void Update()
    {
        if (!disorientation)
        {
            if (transform.position.x < target.transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }

            if (timeBeforTargetPlayer <= 0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed[typeEnemie] * Time.deltaTime);
            }
            else
                timeBeforTargetPlayer -= Time.deltaTime;
        }
        else if (disorientation && disorientationTime == 1f) 
        {
            Disorientation();
        }

        if(disorientationTime<=0)
        {
            disorientation = false;
            disorientationTime = 1f;
        }
        else if(disorientation)
        {

            transform.position = Vector3.MoveTowards(transform.position, disorientationPos, speed[typeEnemie] * Time.deltaTime);
            disorientationTime -= Time.deltaTime;
        }
        

    }

    public void RandomTargetPosition(int verPos)
    {
        switch (verPos)
        {
            case 1:
                transform.position = new Vector3(Random.Range(-40, -27), Random.Range(-25, 25), transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(Random.Range(27, 40), Random.Range(-25, 25), transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(Random.Range(-40, 40), Random.Range(-25, -17), transform.position.z);
                break;
            case 4:
                transform.position = new Vector3(Random.Range(-40, 40), Random.Range(17, 25), transform.position.z);
                break;
            default:
                break;
        }

        Debug.Log("Spawn");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            player.SetHealth(-3 * typeEnemie);
        }

        BulletDestroyer bullet = collision.GetComponent<BulletDestroyer>();
        if (bullet != null && gameObject.tag == collision.tag)
        {
            TakeDemage();
        }
        else if (bullet != null && gameObject.tag!=collision.tag)
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            player.SetHealth(-2);
        }
    }

    void TakeDemage()
    {
        health[typeEnemie]--;
        if(health[typeEnemie] <=0)
        {
            GameObject effect = Instantiate(deadEffects[typeColorEnemie], transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }
    }

    void Disorientation()
    {
       disorientationPos = new Vector3(Random.Range(-24, 24), Random.Range(-14, 14), transform.position.z);
    }
}
