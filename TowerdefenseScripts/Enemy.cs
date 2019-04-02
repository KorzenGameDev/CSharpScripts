using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    private Transform target;
    [SerializeField] private int wayPointIndex = 0;
    [SerializeField] private float startHealth = 100f;
    private float health;
    private float speedMove;

    [SerializeField] private int minGold = 0;
    [SerializeField] private int maxGold = 0;
    private int valueMoney;

    private bool isDead = false;

    public GameObject particleDead;
    private MoneyMenager moneyMenager;
    private WaveEnemyMenager wave;

    private void Start()
    {
        // ustalenie drogi w ktora ma isc przeciwnik do pkt 1
        target = Waypoints.points[0];
        health = startHealth;
        moneyMenager = FindObjectOfType<MoneyMenager>();
        wave = FindObjectOfType<WaveEnemyMenager>();

        minGold = wave.GetMinGold();
        maxGold = wave.GetMaxGold();

        speedMove = Random.Range(5f, 20f);
    }

    private void Update()
    {
        // ustalenie dokładnego kietunku ruchu wroga po wyznaczonej scieżce;
        Vector3 direction = target.position - transform.position;

        // predkosc ruchu w wyznaczonym kierunku 
        transform.Translate(direction.normalized *speedMove *Time.deltaTime, Space.World);


        //zmiana punktu podrozy dla wroga 
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            NextWayPoint();
        }
    }

    void NextWayPoint()
    {
        //jesli wrog osiagnie ostatni pkt zostanie zabity
        if(wayPointIndex>=Waypoints.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }

        //zmiana na kolejny punkt drogi wroga
        wayPointIndex++;
        target = Waypoints.points[wayPointIndex];
    }


    //zadaje obrazenia naszemu wrogowi
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    //odpowiada za zniszczenie i kreowanie efektow posmiertnych wroga
    void Die()
    {
        isDead = true;
        if(particleDead!=null)
        {
            GameObject effect = (GameObject)Instantiate(particleDead, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
        AddGoldPerKill();

        Destroy(gameObject);
    }

    //dodaje zloto po zabojstwie w przyszlosci przeniesc
    void AddGoldPerKill()
    {
        moneyMenager.AddMoney((int)Random.Range(minGold, maxGold));
    }
}
