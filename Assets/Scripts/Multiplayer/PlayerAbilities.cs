using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class PlayerAbilities : MonoBehaviour
{
    [Header("Attacking Setting")]
    [SerializeField] private float _attackCoolDown = 5f;
    [SerializeField] private GameObject _tsunamiWave;
    [SerializeField] private Transform _spawner;

    [Header("Throwing Setting")]
    [SerializeField] private float _throwCoolDown = 3f;
    [SerializeField] GameObject _poop;
    [SerializeField] private Transform _poopSpawner;

    private float _attackElapstime;
    private float _throwElapstime;
    private PlayerInput _playerInput;

    public UnityEvent<GameObject> Runner_Tsunami_FillBackground;
    public UnityEvent<GameObject> Runner_Poop_FillBackground;
    public UnityEvent<GameObject> Staff_Tsunami_FillBackground;
    public UnityEvent<GameObject> Staff_Poop_FillBackground;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void Attack()
    {
        if (_attackElapstime < _attackCoolDown) return;
        _attackElapstime = 0;

        if (_playerInput.playerIndex == 1)
        {
            Runner_Tsunami_FillBackground.Invoke(gameObject);
        }
        else if (_playerInput.playerIndex == 0)
        {
            Staff_Tsunami_FillBackground.Invoke(gameObject);
        }

        GameObject tsunamiWave = Instantiate(_tsunamiWave, _spawner.position, _spawner.rotation) as GameObject;
        tsunamiWave.GetComponent<VisualEffect>().Play();
    }

    public void Throw()
    {
        if (_throwElapstime < _throwCoolDown) return;
        _throwElapstime = 0;

        if (_playerInput.playerIndex == 1)
        {
            Runner_Poop_FillBackground.Invoke(gameObject);
        }
        else if (_playerInput.playerIndex == 0)
        {
            Staff_Poop_FillBackground.Invoke(gameObject);
        }

        Instantiate(_poop, _poopSpawner.position, _poopSpawner.rotation);
    }

    private void Update()
    {
        _attackElapstime += Time.deltaTime;
        _throwElapstime += Time.deltaTime;
    }
}
