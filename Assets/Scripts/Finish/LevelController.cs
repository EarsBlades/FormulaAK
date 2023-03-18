using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    int sceneIndex;
    int LevelComplete;

    public GameObject MenuNextUI;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        LevelComplete = PlayerPrefs.GetInt("LevelComplete");

        MenuNextUI.SetActive(false);
    }

    public void isEndGame()
    {
        if (sceneIndex == 6)
            Invoke("LoadMainMenu", 1f);
        else
        {
            if (LevelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
                Invoke("MenuNext", 1f);
            }
        }
    }

    void MenuNext() => MenuNextUI.SetActive(true);
    
    void LoadMainMenu() => SceneManager.LoadScene("MainMenu");

    public void NextLvl() => SceneManager.LoadScene(sceneIndex + 1);

    public void ToMainMenu() => SceneManager.LoadScene("MainMenu");
    
    public void ToMenuLvl() => SceneManager.LoadScene("LevelMenu");
    
    public void Again()
    {
        SceneManager.LoadScene(sceneIndex);
        PlayerPrefs.SetInt("LevelComplete", sceneIndex - 1);
    }
}