using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyMenager : MonoBehaviour {

    public Text textMoney;
    public int money;

    private void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        textMoney.text = "Money: " + money;
    }

    public void AddMoney()
    {
        money += Random.Range(3, 10);
        textMoney.text = "Money: " + money;
        PlayerPrefs.SetInt("Money", money);
    }
}
