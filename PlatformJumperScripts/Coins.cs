using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Score score;
    public PlayerControler player;
    public AudioSource audioSource;
    public AudioClip audioClip;
   

    void Start()
    {
        score = FindObjectOfType<Score>();
        player = FindObjectOfType<PlayerControler>();
        audioSource = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            audioSource.PlayOneShot(audioClip);
            score.score += 10;
            Destroy(gameObject, 0.1f);
        }
    }
}
