using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenager : MonoBehaviour
{
    [SerializeField]private int price = 0;

    MoneyMenager money;
    BuildMenager buildMenager;

    private void Start()
    {
        buildMenager = BuildMenager.buildMenager;
        money = FindObjectOfType<MoneyMenager>();
    }

    public void PurchaseTurret1()
    {
        price = 200;
        buildMenager.SetTurretToBuild(buildMenager.prefabTurret1);    
    }
    public void PurchaseTurret2()
    {
        price = 500;
        buildMenager.SetTurretToBuild(buildMenager.prefabTurret2);
    }
    public void PurchaseTurret3()
    {
        price = 1000;
        buildMenager.SetTurretToBuild(buildMenager.prefabTurret3);
    }
    public void PurchaseTurret4()
    {
        price = 2500;
        buildMenager.SetTurretToBuild(buildMenager.prefabTurret4);
    }
    public void PurchaseTurret5()
    {
        price = 4000;
        buildMenager.SetTurretToBuild(buildMenager.prefabTurret5);
    }

    public bool IsBuy()
    {
        if(money.GetMoney()-price>=0)
        {
            money.AddMoney(-price);
            return true;
        }
        else
        {
            return false;
        }
    }
}