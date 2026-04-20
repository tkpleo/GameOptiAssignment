using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public bool gamePaused = false;
    public float timeElapsed;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverTime;

    //enable gameover screen when player dies
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
        gameOverTime.text = timerText.text + " seconds!";
        timerText.gameObject.SetActive(false);
    }

    public void pause()
    {
        if (!gamePaused)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            gamePaused = true;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            gamePaused = false;
        }
    }


    void Update()
    {
        //pause game when escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
        // Increment the timer by the time passed since the last frame
        timeElapsed += Time.deltaTime;
        timerText.text = Mathf.FloorToInt(timeElapsed).ToString();

    }
}
