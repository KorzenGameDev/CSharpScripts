using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDMenu : MonoBehaviour
{
    public Text text;
    public int currentGold;

    private void Start()
    {

        // sprawdzanie czy PlayerPrefs istnieje jesli tak to ustawić wartosc w nim przechowywana
        if (PlayerPrefs.GetInt("CurrentGold") != 0)
            currentGold = PlayerPrefs.GetInt("CurrentGold");
        else
            currentGold = 0;

        // wypisanie poczatkowe zlota
        text.text = "Gold: " + currentGold;
    }


    // funkcja dodajaca publicznie pieniadze
    public void AddGold(int gold)
    {
        currentGold += gold;
        text.text = "Gold: "+currentGold;
        PlayerPrefs.SetInt("CurrentGold", currentGold);
    }
}
