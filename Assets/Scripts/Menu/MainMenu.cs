using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void LevelGame() => SceneManager.LoadScene("LevelMenu");

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Игра закрылась");
    }
}
