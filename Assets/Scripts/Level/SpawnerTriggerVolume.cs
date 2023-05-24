using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerTriggerVolume : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private KillZoneSpawner _killZoneSpawner;
    public UnityEvent<GameObject> OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterMovement3D player))
        {
            if (_spawner.IsSpawned && _killZoneSpawner.IsSpawned) return;
            OnEnter.Invoke(player.gameObject);
        }
    }
}
