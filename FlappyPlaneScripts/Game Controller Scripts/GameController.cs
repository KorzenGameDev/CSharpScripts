using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public static string ROCK = "Rock";
    public static string STAR = "Star";
    public static string BACKGROUND = "Background";
    public static string DOWN_GROUND = "Down Ground";

    public static string LEVEL1 = "Grass level";
    public static string LEVEL2 = "Rock level";
    public static string LEVEL3 = "Snow level";
    public static string LEVEL4 = "Ice level";
    public static string MAINMENU = "Main Menu";

    private const string HIGH_SCORE_1 = "High Score 1";
    private const string HIGH_SCORE_2 = "High Score 2";
    private const string HIGH_SCORE_3 = "High Score 3";
    private const string HIGH_SCORE_4 = "High Score 4";

    private const string SELECTED_PLANE = "Selected Plane";
    private const string SELECTED_MAP = "Selected Map";

    private const string VOLUME = "volume";

    AudioSource audioSource;
    public AudioClip pressBtn;
    public AudioClip quitBtn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
            Destroy(gameObject);
        IsTheGameStartedForTheFirstTime();

        audioSource = GetComponent<AudioSource>();
    }

    void IsTheGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsTheGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE_1, 0);
            PlayerPrefs.SetInt(HIGH_SCORE_2, 0);
            PlayerPrefs.SetInt(HIGH_SCORE_3, 0);
            PlayerPrefs.SetInt(HIGH_SCORE_4, 0);
            PlayerPrefs.SetInt(SELECTED_PLANE, 0);
            PlayerPrefs.SetInt(SELECTED_MAP, 0);
            PlayerPrefs.SetFloat(VOLUME, 0);
            PlayerPrefs.SetInt("IsTheGameStartedForTheFirstTime", 1);
        }
    }

    public int GetHighScore(string name)
    {
        if (name == LEVEL1)
            return PlayerPrefs.GetInt(HIGH_SCORE_1);
        else if (name == LEVEL2)
            return PlayerPrefs.GetInt(HIGH_SCORE_2);
        else if (name == LEVEL3)
            return PlayerPrefs.GetInt(HIGH_SCORE_3);
        else if (name == LEVEL4)
            return PlayerPrefs.GetInt(HIGH_SCORE_4);
        else return 0;
    }
    public void SetHighScore(string name,int score)
    {
        if (name == LEVEL1)
            PlayerPrefs.SetInt(HIGH_SCORE_1,score);
        else if (name == LEVEL2)
            PlayerPrefs.SetInt(HIGH_SCORE_2, score);
        else if (name == LEVEL3)
            PlayerPrefs.SetInt(HIGH_SCORE_3, score);
        else if (name == LEVEL4)
            PlayerPrefs.SetInt(HIGH_SCORE_4, score);
    }

    public void SetPlayer(int i)
    {
        PlayerPrefs.SetInt(SELECTED_PLANE, i);
    }
    public int GetPlayer()
    {
        return PlayerPrefs.GetInt(SELECTED_PLANE);
    }
    public void SetSelectedMap(int i)
    {
        PlayerPrefs.SetInt(SELECTED_MAP, i);
    }
    public int GetSelectedMap()
    {
        return PlayerPrefs.GetInt(SELECTED_MAP);
    }
    public void SetVolume(float value)
    {
        PlayerPrefs.SetFloat(VOLUME, value);
    }
    public float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME);
    }
    public void PlayAnyClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
