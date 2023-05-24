using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField] private Transform[] _playerSpawns;
    [SerializeField] private GameObject _playerPrefabs;
    [SerializeField] private List<LayerMask> _playerLayers;

    public GameEvent<GameObject> _playerEvent;
    public GameEvent<GameObject> _staffEvent;

    private void Start()
    {
        var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();

        for (int i = 0; i < playerConfigs.Length; i++)
        {
            for (int j = 0; j < _playerSpawns.Length; j++)
            {
                if (playerConfigs[i].PlayerNum == j && playerConfigs[i].PlayerIndex == i)
                {
                    var player = Instantiate(_playerPrefabs, _playerSpawns[j].position, _playerSpawns[j].rotation, gameObject.transform);
                    player.GetComponentInChildren<PlayerController>().InitializePlayer(playerConfigs[i]);

                    // set camera
                    int layerToAdd = (int)Mathf.Log(_playerLayers[i].value, 2);
                    player.GetComponentInChildren<CinemachineVirtualCamera>().gameObject.layer = layerToAdd;
                    player.GetComponentInChildren<Camera>().cullingMask |= 1 << layerToAdd;

                    if (playerConfigs[i].PlayerNum == 0)
                    {
                        _playerEvent.Invoke(player);
                        player.GetComponentInChildren<CharacterMovement3D>().tag = "Player";
                    }
                    if (playerConfigs[i].PlayerNum == 1)
                    {
                        _staffEvent.Invoke(player);
                        player.GetComponentInChildren<CharacterMovement3D>().tag = "Staff";
                    }
                }
            }
        }
    }
}
