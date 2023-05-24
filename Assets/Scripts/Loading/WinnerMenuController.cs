using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerMenuController : MonoBehaviour
{

    [SerializeField] private float _showTime = 5f;

    [Header("Reference")]
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _panel;

    private bool _isShow;

    private void Update()
    {
        if (_isShow) return;
        StartCoroutine(ShowMenu());
    }

    private IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(_showTime);
        _isShow = true;
        _background.SetActive(true);
        _panel.SetActive(true);
    }
}
