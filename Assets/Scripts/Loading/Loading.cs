using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameEvent<bool> _countdownTime;

    public UnityEvent OnFreeze;
    public UnityEvent OnPlay;
    public UnityEvent<string> OnUpdateCountdownTime;

    private float _elapstime = 5f;
    private bool _isFreezed;

    private void Start()
    {
        _countdownTime.Invoke(false);
    }

    private void FixedUpdate()
    {
        if (_isFreezed) return;
        _isFreezed = true;

        OnFreeze.Invoke();
    }

    private void Update()
    {
        _elapstime -= Time.deltaTime;
        int elapstime = (int) _elapstime;
        OnUpdateCountdownTime.Invoke("" + elapstime);

        if (_elapstime <= 0)
        {
            _countdownTime.Invoke(true);
            OnPlay.Invoke();
            Destroy(gameObject);
        }
    }
}
