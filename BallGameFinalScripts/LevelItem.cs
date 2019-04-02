using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelItem : MonoBehaviour
{
    public GameObject finishedLevel;
    public TextMesh textMesh;
    public string levelName;

	void Start ()
    {
        textMesh.text = levelName;

        if(PlayerPrefs.GetInt(levelName+"_finished",0)==0)
        {
            Destroy(finishedLevel);
        }
	}

    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene(levelName);
    }
	
}
