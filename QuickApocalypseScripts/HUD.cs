using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text score;
    public int points;

    public Text live;
    public int valueLive;

    public Text health;
    public int valueHealth;

    bool isBottom = false;

    public Image bullet;
    public Sprite[] spriteBullet=new Sprite[2];


    PlayerController player;
    SwitchBullet nbBullet;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        nbBullet = FindObjectOfType<SwitchBullet>();

        score.text = "Score: " + points;
        live.text = "x" + valueLive;
        health.text = "Health" + valueHealth;
    }

    private void Update()
    {
        if(player.transform.position.y < 0f && isBottom)
        {
            score.canvas.transform.position = new Vector3(score.transform.position.x, 440f, score.transform.position.z);
            isBottom = false;
        }
        if (player.transform.position.y > 0f && !isBottom)
        {
            score.canvas.transform.position = new Vector3(score.transform.position.x, -440f, score.transform.position.z);
            isBottom = true;
        }

        if(nbBullet.GetTypeBullet() == 0)
        {
            bullet.sprite = spriteBullet[nbBullet.GetTypeBullet()];
        }
        else if (nbBullet.GetTypeBullet() == 1)
        {
            bullet.sprite = spriteBullet[nbBullet.GetTypeBullet()];
        }
        else if (nbBullet.GetTypeBullet() == 2)
        {
            bullet.sprite = spriteBullet[nbBullet.GetTypeBullet()];
        }
    }
}
