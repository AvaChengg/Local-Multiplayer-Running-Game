using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerVolume : MonoBehaviour
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

            if (player.Direction == 0 || player.Direction == 2) player.Direction = 1;
            else if (player.Direction == 1 && playerParent.position.x < 0) player.Direction = 0;
            else if (player.Direction == 1 && playerParent.position.x > 0) player.Direction = 2;

            if (!player.IsSlowdown) player.ChangeSpeed(_decreaseSpeed, _slowDownTime);
        }
    }
}

