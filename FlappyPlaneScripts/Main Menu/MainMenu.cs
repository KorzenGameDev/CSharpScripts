using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public int indexMap=0;
    public int indexPlayer=0;
    [SerializeField] Sprite[] player;
    [SerializeField] Sprite[] map;
    GameObject mapHolder;
    GameObject playerHolder;

    public AudioMixer audioMixer;
    public Slider volumeSlider;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI levelNameText;
    public Sprite[] medalSprite;
    public Image medalHolder;

    private void Awake()
    {
        mapHolder = GameObject.Find("MapHolder");
        playerHolder = GameObject.Find("PlayerHolder");

        indexPlayer = GameController.instance.GetPlayer();
        indexMap = GameController.instance.GetSelectedMap();

        ChangeMapSprite(indexMap);
        ChangePlayerSprite(indexPlayer);
        Time.timeScale = 1f;
    }
    private void Start()
    {
        volumeSlider.value = GameController.instance.GetVolume();
        MainMenuHightScore();
    }

    public void Play()
    {
        GameController.instance.PlayAnyClip(GameController.instance.pressBtn);
        SceneManager.LoadScene(TakeLevelName(indexMap));
    }
    public void Quit()
    {
        GameController.instance.PlayAnyClip(GameController.instance.quitBtn);
        Application.Quit();
    }

    public void NextMap()
    {
        GameController.instance.PlayAnyClip(GameController.instance.pressBtn);
        indexMap++;
        if (indexMap > 3) indexMap = 0;
        ChangeMapSprite(indexMap);
    }
    public void PrevMap()
    {
        GameController.instance.PlayAnyClip(GameController.instance.pressBtn);
        indexMap--;
        if (indexMap < 0) indexMap = 3;
        ChangeMapSprite(indexMap);
    }
    public void NextPlayer()
    {
        GameController.instance.PlayAnyClip(GameController.instance.pressBtn);
        indexPlayer++;
        if (indexPlayer > 3) indexPlayer = 0;
        ChangePlayerSprite(indexPlayer);
    }
    public void PrevPlayer()
    {
        GameController.instance.PlayAnyClip(GameController.instance.pressBtn);
        indexPlayer--;
        if (indexPlayer < 0) indexPlayer = 3;
        ChangePlayerSprite(indexPlayer);
    }
    void ChangeMapSprite(int i)
    {
        mapHolder.GetComponent<Image>().sprite = map[i];
        GameController.instance.SetSelectedMap(i);
        MainMenuHightScore();
    }
    void ChangePlayerSprite(int i)
    {
        playerHolder.GetComponent<Image>().sprite = player[i];
        GameController.instance.SetPlayer(i)
;    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        GameController.instance.SetVolume(volume);
    }

    string TakeLevelName(int i)
    {
        string levelName = "";
        switch (i)
        {
            case 0:
                levelName = GameController.LEVEL1;
                levelNameText.text = "Grass";
                break;
            case 1:
                levelName = GameController.LEVEL2;
                levelNameText.text = "Rock";
                break;
            case 2:
                levelName = GameController.LEVEL3;
                levelNameText.text = "Snow";
                break;
            case 3:
                levelName = GameController.LEVEL4;
                levelNameText.text = "Ice";
                break;
        }

        return levelName;
    }

    public void MainMenuHightScore()
    {
        string tempName= TakeLevelName(indexMap);
        Color temp = medalHolder.color;
        temp.a = 1f;
        medalHolder.color = temp;
        int Hs = GameController.instance.GetHighScore(tempName);
        highScoreText.text = Hs.ToString();
        if (Hs >= 100 && Hs<250) medalHolder.sprite = medalSprite[0];
        else if (Hs >= 250 && Hs < 500) medalHolder.sprite = medalSprite[1];
        else if (Hs >= 500) medalHolder.sprite = medalSprite[2];
        else
        {
            temp.a = 0f;
            medalHolder.color = temp;
            medalHolder.sprite = null;
        }
        
    }

}
