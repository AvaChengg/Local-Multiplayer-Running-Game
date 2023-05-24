using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _killZone;
    [SerializeField] private float _stayTime = 25f;

    // private
    private bool _isSpawned;
    private float _elapsedTime;

    public bool IsSpawned { get => _isSpawned; set => _isSpawned = value; }

    public void SpawnKillZone()
    {
        if (_killZone == null) return;

        _isSpawned = true;

        GameObject killZone = Instantiate(_killZone, transform.position, transform.rotation) as GameObject;

        killZone.name = killZone.name.Replace("(Clone)", "").Trim();
    }

    private void Update()
    {
        if (!_isSpawned) return;

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _stayTime)
        {
            _elapsedTime = 0;
            _isSpawned = false;
            Destroy(transform.parent.gameObject);
        }
    }

}
