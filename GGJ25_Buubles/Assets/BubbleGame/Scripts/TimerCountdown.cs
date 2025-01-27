using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerCountdown : MonoBehaviour
{
    public float countdownTime = 180f;
    public TextMeshProUGUI countdownText;
    public event Action CountdownEnded;
    private Coroutine countdownRoutine;

    private void Start()
    {
        UpdateText();
        countdownRoutine = StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while(countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTime -= 1f;
            UpdateText();
        }

        countdownTime = 0f;
        UpdateText();
        CountdownEnded?.Invoke();
    }

    public void StopTimer()
    {
        StopCoroutine(countdownRoutine);
    }

    private void UpdateText()
    {
        int minutes = (int) (countdownTime / 60); // Get the number of whole minutes
        int seconds = (int) (countdownTime % 60); // Get the remaining seconds

        // Format the string with leading zeros for two digits
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds); ;
    }
}
