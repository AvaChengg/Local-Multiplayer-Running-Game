using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadBlockTriggerVolume : MonoBehaviour
{
    [SerializeField] private float _decreaseSpeed = 2f;
    [SerializeField] private int _slowDownTime = 1;

    public UnityEvent<GameObject> OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterMovement3D player))
        {
            Transform playerParent = player.GetComponentInParent<Transform>();

            OnEnter.Invoke(player.gameObject);

            if (!player.IsSlowdown) player.ChangeSpeed(_decreaseSpeed, _slowDownTime);
        }
    }
}
