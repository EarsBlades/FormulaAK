using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject pauseMenuUI;

    int sceneIndex;
    int LevelComplete;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        LevelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneIndex);
        PlayerPrefs.SetInt("LevelComplete", sceneIndex - 1);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void ToMineMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void ToLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
        Time.timeScale = 1f;
        GameIsPause = false;
    }
}
