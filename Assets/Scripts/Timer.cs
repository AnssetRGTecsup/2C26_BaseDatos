using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private bool runTime;
    [SerializeField] private float totalTime;
    [SerializeField] private int mins;
    [SerializeField] private int seconds;
    [SerializeField] private int milisecs;

    private void Start()
    {
        mins = (int)(totalTime / 60);
        seconds = (int)(totalTime % 60);
        milisecs = (int)((totalTime - seconds) * 1000);

        timerText.text = $"{mins.ToString("00")} : {seconds.ToString("00")} : {milisecs.ToString("000")}";
    }

    void Update()
    {
        if (!runTime) return;

        if(totalTime > 0)
        {
            totalTime -= Time.deltaTime;

            mins = (int)(totalTime / 60);
            seconds = (int)(totalTime % 60);
            milisecs = (int)((totalTime - seconds) * 1000);

            timerText.text = $"{mins.ToString("00")} : {seconds.ToString("00")} : {milisecs.ToString("000")}";
        }
        else
        {
            timerText.text = "Se acabo el tiempo";
        }
    }

    public void RunTimer()
    {
        runTime = true;
    }

    public void PauseTimer()
    {
        runTime = false;
    }

    public void RestartTimer()
    {
        totalTime = 120f;
    }
}
