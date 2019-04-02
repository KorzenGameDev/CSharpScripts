using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Star : MonoBehaviour
{

    public GameObject particle;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "sphere")
            return;
        
        if(leaveStar()==1)
        {
            string levelName = Application.loadedLevelName;
            PlayerPrefs.SetInt(levelName + "_finished", 1);
            SceneManager.LoadScene("Menu");
        }

        else
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject,0.1f);
        }
    }

    int leaveStar()
    {
        Star[] star = Component.FindObjectsOfType<Star>();
        return star.Length;
    }

}
