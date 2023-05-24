using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerOnePanel;
    [SerializeField] private GameObject _playerTwoPanel;
    [SerializeField] private GameObject _joinTextOne;
    [SerializeField] private GameObject _joinTextTwo;

    private List<PlayerConfiguration> _playerConfigs;
    public List<GameObject> SelectedObjects = new List<GameObject>();

    [SerializeField] private int _maxPlayers = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("SINGLETON - Trying to create another instance of singleton!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            _playerConfigs = new List<PlayerConfiguration>();
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return _playerConfigs;
    }

    public void SetPlayerColor(int index, Material color)
    {
        _playerConfigs[index].PlayerMaterial = color;
    }

    public void SetPlayerNumber(int index, int number)
    {
        _playerConfigs[index].PlayerNum = number;
    }

    public void ReadyPlayer(int index)
    {
        _playerConfigs[index].IsReady = true;
        if (_playerConfigs.Count == _maxPlayers && _playerConfigs.All(p => p.IsReady == true))
        {
            SceneManager.LoadScene("Level");
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("Player Joined " + pi.playerIndex);
        if (!_playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            //pi.transform.SetParent(transform);
            _playerConfigs.Add(new PlayerConfiguration(pi));
        }

        if (pi.playerIndex == 0 && _playerOnePanel != null)
        {
            _playerOnePanel.SetActive(false);
            _joinTextOne.SetActive(false);
        }
        if (pi.playerIndex == 1 && _playerTwoPanel != null)
        {
            _playerTwoPanel.SetActive(false);
            _joinTextTwo.SetActive(false);
        }
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }

    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public int PlayerNum { get; set; }
    public bool IsReady { get; set; }
    public Material PlayerMaterial { get; set; }
}
