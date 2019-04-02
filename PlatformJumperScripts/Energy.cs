using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Energy : MonoBehaviour
{
    public float energy;
    
    //obiekty energi
    public GameObject Energy1;
    public GameObject Energy2;
    public GameObject Energy3;
    public GameObject Energy4;
    public GameObject Energy5;


    // Use this for initialization
    void Start ()
    {
        energy = 3f;
        //szukanie obiektów po nazwie i przypisanie
        Energy1 = GameObject.Find("1");
        Energy2 = GameObject.Find("2");
        Energy3 = GameObject.Find("3");
        Energy4 = GameObject.Find("4");
        Energy5 = GameObject.Find("5");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Live();	
	}

    void Live() //funkcja odpowaiada za wyswietlanie zycia
    {
        if (energy >= 5)
            Energy5.GetComponent<Renderer>().enabled = true;    //jesli enable = true widac obiekt
        else
            Energy5.GetComponent<Renderer>().enabled = false;
        if (energy >= 4)
            Energy4.GetComponent<Renderer>().enabled = true;
        else
            Energy4.GetComponent<Renderer>().enabled = false;
        if (energy >= 3)
            Energy3.GetComponent<Renderer>().enabled = true;
        else
            Energy3.GetComponent<Renderer>().enabled = false;
        if (energy >= 2)
            Energy2.GetComponent<Renderer>().enabled = true;
        else
            Energy2.GetComponent<Renderer>().enabled = false;
        if (energy >= 1)
            Energy1.GetComponent<Renderer>().enabled = true;
        else
            Energy1.GetComponent<Renderer>().enabled = false;
        if (energy < 1)
            SceneManager.LoadScene(Application.loadedLevelName);
        
    }
    
}
