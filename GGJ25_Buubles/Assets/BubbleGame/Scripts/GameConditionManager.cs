using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConditionManager : MonoBehaviour
{
    public static GameConditionManager instance;
    public TimerCountdown countdown;
    public float goalWorldScale = 0.5f;
    public GameObject retryCanvas;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        countdown.CountdownEnded += OnTimerReached;
        ScaleManager.instance.desiredWorldScaleReached += OnSizeReached;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    private void OnTimerReached()
    {
        retryCanvas.SetActive(true);
    }

    private void OnSizeReached()
    {
        SceneManager.LoadScene("");
    }
}
