using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndDoorLevel : MonoBehaviour {

    [SerializeField] private string levelName = "Level1";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
