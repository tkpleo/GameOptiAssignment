using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void StartGame()
    {
        if (Time.timeScale != 1f)
        { 
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene("GameplayScene");
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

