using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameEvent<string> OnUpdateCoinNum;
    [SerializeField] private GameEvent<string> OnUpdateStaffCoinNum;
    [SerializeField] private GameEvent<bool> _countdownTime;

    [Header("Timer Setting")]
    [SerializeField] private float _timer = 180f;           // 3 min.

    public UnityEvent<string> OnUpdateTimer;

    public float Timer { get => _timer; set => _timer = value; }

    private void Update()
    {
        if (_countdownTime.CurrentValue == false) return;

        // check win
        if (_timer < 0)
        {
            _timer = 0;

            if (int.Parse(OnUpdateStaffCoinNum.CurrentValue) > int.Parse(OnUpdateCoinNum.CurrentValue))
            {
                SceneManager.LoadScene("PlayerWin");
            }
            else if (int.Parse(OnUpdateStaffCoinNum.CurrentValue) < int.Parse(OnUpdateCoinNum.CurrentValue))
            {
                SceneManager.LoadScene("StaffWin");
            }
            else if (int.Parse(OnUpdateCoinNum.CurrentValue) == int.Parse(OnUpdateStaffCoinNum.CurrentValue))
            {
                SceneManager.LoadScene("Peace");
            }
            return;
        }

        // counting time
        _timer -= Time.deltaTime;
        DisplayTime(_timer);
    }


    private void DisplayTime(float displayTime)
    {
        if (displayTime < 0) displayTime = 0;

        // counting minutes and seconds
        float minutes = Mathf.FloorToInt(displayTime / 60);
        float seconds = Mathf.FloorToInt(displayTime % 60);
        float milliseconds = displayTime % 1 * 1000;
        string timerText = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        // update timer text
        OnUpdateTimer.Invoke("" + timerText);
    }
}
