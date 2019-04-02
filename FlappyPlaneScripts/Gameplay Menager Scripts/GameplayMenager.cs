using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameplayMenager : MonoBehaviour
{
    public static GameplayMenager instance;
    public GameObject pauseCanvas;
    public GameObject playerCanvas;
    public GameObject resumeBtn;
    public TextMeshProUGUI pauseScore;
    public TextMeshProUGUI pauseHighScore;
    public Image medalHolder;
    TextMeshProUGUI scoreText;
    public Sprite[] medalSprite;
    int score;
    public AudioClip endLevel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        scoreText = GameObject.Find("Player Score Text").GetComponent<TextMeshProUGUI>();
        DisplayScore();

        pauseCanvas = GameObject.Find("Pause");
        playerCanvas = GameObject.Find("Player UI");
        resumeBtn = GameObject.Find("Resume");
        medalHolder = GameObject.Find("Medal Value").GetComponent<Image>();
        pauseHighScore = GameObject.Find("Hight Score Pause Value").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        pauseCanvas.SetActive(false);
    }

    public void AddScore(int add)
    {
        score += add;
        DisplayScore();
    }
    public void SetScore(int score)
    {
        this.score = score;
        DisplayScore();
    }
    public int GetScore()
    {
        return score;
    }
    public void DisplayScore()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }
    public void Restart()
    {
        GameController.instance.PlayAnyClip(GameController.instance.pressBtn);
        SetHighScore(SceneManager.GetActiveScene().name);
        Medal(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Resume()
    {
        GameController.instance.PlayAnyClip(GameController.instance.pressBtn);
        playerCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        GameController.instance.PlayAnyClip(GameController.instance.pressBtn);
        playerCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        pauseScore.text = score.ToString();
        Medal(SceneManager.GetActiveScene().name);
        pauseHighScore.text = GameController.instance.GetHighScore(SceneManager.GetActiveScene().name).ToString();
    }
    public void EndLevel()
    {
        GameController.instance.PlayAnyClip(endLevel);
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
        resumeBtn.SetActive(false);
        playerCanvas.SetActive(false);
        pauseScore.text = score.ToString();
        SetHighScore(SceneManager.GetActiveScene().name);
        Medal(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        GameController.instance.PlayAnyClip(GameController.instance.quitBtn);
        SetHighScore(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(GameController.MAINMENU);
    }

    public void Medal(string name)
    {
        Color temp = medalHolder.color;
        temp.a = 1f;
        medalHolder.color = temp;
        int Hs = GameController.instance.GetHighScore(name);
        if (Hs >= 100 && Hs < 250) medalHolder.sprite = medalSprite[0];
        else if (Hs >= 250 && Hs < 500) medalHolder.sprite = medalSprite[1];
        else if (Hs >= 500) medalHolder.sprite = medalSprite[2];
        else
        {
            temp.a = 0f;
            medalHolder.color = temp;
            medalHolder.sprite = null;
        }
    }
    public void SetHighScore(string name)
    {
        if(score > GameController.instance.GetHighScore(name))
        {
            GameController.instance.SetHighScore(name, score);
        }
        pauseHighScore.text = GameController.instance.GetHighScore(name).ToString();
    }
}
