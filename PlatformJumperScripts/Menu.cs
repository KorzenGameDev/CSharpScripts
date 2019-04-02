using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private Canvas menu;
    public Button btnStart;
    public Button btnExit;
    public Canvas lvlMenu;

	// Use this for initialization
	void Start ()
    {
        menu = (Canvas)GetComponent<Canvas>();
        lvlMenu = lvlMenu.GetComponent<Canvas>();

        btnStart = btnStart.GetComponent<Button>();
        btnExit = btnExit.GetComponent<Button>();

        lvlMenu.enabled = false; //menu z wyborem lvl jest schowane

        //Time.timeScale = 0.0f;  //pauza w rozgrywce

        Cursor.visible = menu.enabled;
        Cursor.lockState = CursorLockMode.Confined;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && lvlMenu.enabled)
        {
            lvlMenu.enabled = false;

            btnExit.enabled = true;
            btnStart.enabled = true;
        }
	}

    public void BtnStart()
    {
        lvlMenu.enabled = true;

        btnExit.enabled = false;
        btnStart.enabled = false;
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void Level6()
    {
        SceneManager.LoadScene("Level6");
    }
    public void Level7()
    {
        SceneManager.LoadScene("Level7");
    }
    public void Level8()
    {
        SceneManager.LoadScene("Level8");
    }
    public void Level9()
    {
        SceneManager.LoadScene("Level9");
    }
    public void Level10()
    {
        SceneManager.LoadScene("Level10");
    }
}
