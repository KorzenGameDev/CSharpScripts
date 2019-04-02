using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    private Canvas menu;
    public Canvas game;
    public Button start;
    public Button back;
    public Button outbutton;

    private void Start()
    {
        menu = GetComponent<Canvas>();
        game.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Exit();

            menu.enabled = !menu.enabled;

            if(menu.enabled)
            {
                Time.timeScale = 0;
                game.enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                game.enabled = true;
            }

        }
    }

    public void NewGame()
    {
        game.enabled = true;
        Shop newGame = FindObjectOfType<Shop>();
        newGame.isNewGame = true;
        menu.enabled = false;
        Time.timeScale = 1;
    }

    public void ContinueButton()
    {
        menu.enabled = false;
        Time.timeScale = 1;
        game.enabled = true;
    }

    public void Exit()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }

}
