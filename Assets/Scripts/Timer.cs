using UnityEngine;
using TMPro; // Use TextMeshPro for UI

public class TimerScript : MonoBehaviour
{
    public float timeElapsed;
    public TextMeshProUGUI timerText;

    void Update()
    {
        // Increment the timer by the time passed since the last frame
        timeElapsed += Time.deltaTime;

        // Display the time as a whole number
        timerText.text = Mathf.FloorToInt(timeElapsed).ToString();
    }
}