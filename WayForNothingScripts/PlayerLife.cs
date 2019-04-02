using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

    public int Life = 3;
    HUD hudLife;

    public void TakeDemage(int _demage)
    {
        Life -= _demage;
        hudLife = FindObjectOfType<HUD>();
        hudLife.ChangeLife();

        if(Life <= 0)
        {
            SceneManager.LoadScene(Application.loadedLevelName);
        }
    }
}
