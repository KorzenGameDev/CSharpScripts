using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoMenager : MonoBehaviour {

    public Text ammoMenager;
    public int ammo=10;

    private void Start()
    {
        //ammo = PlayerPrefs.GetInt("Ammo");
        if (ammo > 0)
            ammoMenager.text = "Ammo: " + ammo;
        else if(ammo<=0)
        {
            ammoMenager.text = "Ammo: Empty";
            ammo = 0;
        }
            
    }

    public bool Ammo()
    {
        if(ammo-->0)
        {
            ammoMenager.text = "Ammo: " + ammo;
            PlayerPrefs.SetInt("Ammo", ammo);
            return true;
        }
        else
        {
            PlayerPrefs.SetInt("Ammo", ammo);
            ammoMenager.text = "Ammo: Empty";
            return false;
        }
    }

}
