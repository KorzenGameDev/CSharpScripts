using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="sphere")
        {
            string levelName = Application.loadedLevelName;
            Application.LoadLevel(levelName);
        }
    }

}
