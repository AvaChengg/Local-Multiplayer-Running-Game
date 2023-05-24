using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFillBackground : MonoBehaviour
{
    private Image _image;
    private bool _isUsed;
    private float _coolDown;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void UpdateTsnamiFillImage(float coolDown)
    {
        _coolDown = coolDown;
        _isUsed = true;
    }
    public void UpdatePoopFillImage(float coolDown)
    {
        _coolDown = coolDown;
        _isUsed = true;
    }

    private void Update()
    {
        if (_isUsed)
        {
            _image.fillAmount -= 1 / _coolDown * Time.deltaTime;
            if (_image.fillAmount <= 0)
            {
                _image.fillAmount = 0;
                _isUsed = false;
            }
        }
    }
}
