using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Score score;
    public Energy energy;
    private Animator animator;
    bool isOpen = false;
    public GameObject particle;
    public GameObject particleBlueChest;
    public bool liveChest;
    public AudioSource audioSource;
    public AudioClip audioClip;


    private void Start()
    {
        animator = GetComponent<Animator>();
        score = FindObjectOfType<Score>();
        energy = FindObjectOfType<Energy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="Player" && !isOpen)
        {
            if(!liveChest)
            {
                if (audioSource != null)
                    audioSource.PlayOneShot(audioClip);
                isOpen = true;
                animator.SetBool("isOpen", isOpen);
                score.score += 100;
                Instantiate(particle, transform.position, Quaternion.identity);
                
            }
            else if(energy.energy<5)
            {
                audioSource.PlayOneShot(audioClip);
                isOpen = true;
                animator.SetBool("isOpen", isOpen);
                energy.energy++;
                Instantiate(particleBlueChest, transform.position, Quaternion.identity);
                
            }
            
        }
    }
}
