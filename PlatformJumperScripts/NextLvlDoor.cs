using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvlDoor : MonoBehaviour
{
    public string levelName;
    public AudioSource audioSource;
    public AudioClip audioClip;
    bool isDoorOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && !isDoorOpen)
        {
            audioSource.PlayOneShot(audioClip);
            StartCoroutine(NextLevel());   
        }
            
    }

    IEnumerator NextLevel()
    {
        isDoorOpen = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(levelName);
    }


}
