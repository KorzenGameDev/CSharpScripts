using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveMenager : MonoBehaviour {

    private int maxLive = 4;
    [SerializeField] private int actualLive = 4; 
    private bool changeNow = true;

    public Image[] images;

    private void Start()
    { 
        actualLive = PlayerPrefs.GetInt("Live");

        if (actualLive <= 0)
            actualLive = 4;

        
    }

    public void ChangeLive()
    {
        actualLive--;
        changeNow = true;
    }

    private void Update()
    {
        if(changeNow)
        {
            changeNow = false;

            for (int i = 0; i < maxLive ; i++)
            {
                if (i < actualLive)
                    images[i].enabled = true;
                else
                    images[i].enabled = false;
            }

            PlayerPrefs.SetInt("Live", actualLive);
        }

        if(actualLive<=0)
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            player.Dead();
        }
    }
              

}
