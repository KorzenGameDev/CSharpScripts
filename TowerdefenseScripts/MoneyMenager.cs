using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyMenager : MonoBehaviour {

    public Text textMoney;

    [SerializeField]private int money;

    private void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        if (money < 1000)
            money = 1000;

        textMoney.text = money.ToString();
    }

    public void AddMoney(int _money)
    {
        money += _money;
        
        textMoney.text = money.ToString();

        PlayerPrefs.SetInt("Money", money);
    }

    public int GetMoney()
    {
        return money;
    }
}
