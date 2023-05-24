using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class PlayerMenuController : MonoBehaviour
{
    private int _playerIndex;

    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private GameObject _readyPanel;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private Button _playerOneButton;
    [SerializeField] private Button _playerTwoButton;
    [SerializeField] private MultiplayerEventSystem _eventSystem;
    [SerializeField] private GameObject _image;

    private float _ignoreInputTime = 1.5f;
    private bool _inputEnabled;
    private GameObject _multiplayerManager;
    private GameObject _playerOneRed;
    private GameObject _playerOneBlue;
    private GameObject _playerTwoRed;
    private GameObject _playerTwoBlue;
    private PlayerConfigurationManager _playerConfigurationManager;

    public Button PlayerOneButton { get => _playerOneButton; private set => _playerOneButton = value; }
    public Button PlayerTwoButton { get => _playerTwoButton; private set => _playerTwoButton = value; }
    public MultiplayerEventSystem EventSystems { get => _eventSystem; private set => _eventSystem = value; }

    private void Awake()
    {
        _multiplayerManager = GameObject.Find("MultiplayerManager");
        _playerOneRed = GameObject.Find("PlayerOneRed").gameObject;
        _playerOneBlue = GameObject.Find("PlayerOneBlue").gameObject;
        _playerTwoRed = GameObject.Find("PlayerTwoRed").gameObject;
        _playerTwoBlue = GameObject.Find("PlayerTwoBlue").gameObject;
        _playerConfigurationManager = _multiplayerManager.GetComponent<PlayerConfigurationManager>();
    }

    public void SetPlayerIndex(int pi)
    {
        _playerIndex = pi;
        _titleText.SetText("Player " + (pi + 1).ToString());
        _ignoreInputTime = Time.time + _ignoreInputTime;
    }

    private void Update()
    {
        if (Time.time > _ignoreInputTime)
        {
            _inputEnabled = true;
        }

    }

    public void SetColor(Material color)
    {
        if (_playerConfigurationManager.SelectedObjects.Count != 2)
        {
            _image.SetActive(true);
            StartCoroutine(TurnoffImage());
            return;
        }

        if (!_inputEnabled) return;

        PlayerConfigurationManager.Instance.SetPlayerColor(_playerIndex, color);
        _readyPanel.SetActive(true);
    }

    public void SetNumber(int number)
    {
        if (_playerConfigurationManager.SelectedObjects.Count != 2)
        {
            _image.SetActive(true);
            StartCoroutine(TurnoffImage());
            return;
        }

        if (!_inputEnabled) return;
        PlayerConfigurationManager.Instance.SetPlayerNumber(_playerIndex, number);
    }

    public void ReadyPlayer()
    {
        if (_playerConfigurationManager.SelectedObjects.Count != 2)
        {
            _image.SetActive(true);
            StartCoroutine(TurnoffImage());
            return;
        }

        if (!_inputEnabled) return;

        PlayerConfigurationManager.Instance.ReadyPlayer(_playerIndex);

    }

    public void ShowPlayerOne()
    {
        if (_playerConfigurationManager.SelectedObjects.Count != 2)
        {
            _image.SetActive(true);
            StartCoroutine(TurnoffImage());
            return;
        }
        if (!_inputEnabled) return;

        if (_playerIndex == 0)
        {
            _playerOneBlue.SetActive(false);
        }
        else if (_playerIndex == 1)
        {
            _playerTwoBlue.SetActive(false);
        }
    }

    public void ShowPlayerTwo()
    {
        if (_playerConfigurationManager.SelectedObjects.Count != 2)
        {
            _image.SetActive(true);
            StartCoroutine(TurnoffImage());
            return;
        }
        if (!_inputEnabled) return;

        if (_playerIndex == 0)
        {
            _playerOneRed.SetActive(true);
        }
        else if (_playerIndex == 1)
        {
            _playerTwoRed.SetActive(true);
        }
    }

    public void HidePlayerOneButtons()
    {
        if (_playerConfigurationManager.SelectedObjects.Count != 2)
        {
            _image.SetActive(true);
            StartCoroutine(TurnoffImage());
            return;
        }

        if (!_inputEnabled) return;

        if (_playerIndex == 0)
        {
            _playerConfigurationManager.SelectedObjects[1].GetComponent<PlayerMenuController>().PlayerOneButton.gameObject.SetActive(false);
            _playerConfigurationManager.SelectedObjects[1].GetComponent<PlayerMenuController>().EventSystems.SetSelectedGameObject(_playerConfigurationManager.SelectedObjects[1].GetComponent<PlayerMenuController>().PlayerTwoButton.gameObject);
            _readyPanel.SetActive(true);
            _menuPanel.SetActive(false);
        }
        else if (_playerIndex == 1)
        {
            _playerConfigurationManager.SelectedObjects[0].GetComponent<PlayerMenuController>().PlayerOneButton.gameObject.SetActive(false);
            _playerConfigurationManager.SelectedObjects[0].GetComponent<PlayerMenuController>().EventSystems.SetSelectedGameObject(_playerConfigurationManager.SelectedObjects[0].GetComponent<PlayerMenuController>().PlayerTwoButton.gameObject);
            _readyPanel.SetActive(true);
            _menuPanel.SetActive(false);
        }
    }
    public void HidePlayerTwoButtons()
    {
        if (_playerConfigurationManager.SelectedObjects.Count != 2)
        {
            _image.SetActive(true);
            StartCoroutine(TurnoffImage());
            return;
        }

        if (!_inputEnabled) return;

        if (_playerIndex == 0)
        {
            _playerConfigurationManager.SelectedObjects[1].GetComponent<PlayerMenuController>().PlayerTwoButton.gameObject.SetActive(false);
            _playerConfigurationManager.SelectedObjects[1].GetComponent<PlayerMenuController>().EventSystems.SetSelectedGameObject(_playerConfigurationManager.SelectedObjects[1].GetComponent<PlayerMenuController>().PlayerOneButton.gameObject);
            _readyPanel.SetActive(true);
            _menuPanel.SetActive(false);
        }
        else if (_playerIndex == 1)
        {
            _playerConfigurationManager.SelectedObjects[0].GetComponent<PlayerMenuController>().PlayerTwoButton.gameObject.SetActive(false);
            _playerConfigurationManager.SelectedObjects[0].GetComponent<PlayerMenuController>().EventSystems.SetSelectedGameObject(_playerConfigurationManager.SelectedObjects[0].GetComponent<PlayerMenuController>().PlayerOneButton.gameObject);
            _readyPanel.SetActive(true);
            _menuPanel.SetActive(false);
        }
    }

    private IEnumerator TurnoffImage()
    {
        yield return new WaitForSeconds(1);
        _image.SetActive(false);
    }
}
