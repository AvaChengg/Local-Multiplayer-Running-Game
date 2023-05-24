using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopTriggerVolume : MonoBehaviour
{
    [SerializeField] private float _decreaseSpeed = 2f;
    [SerializeField] private int _slowDownTime = 2;
    [SerializeField] private int _distroyTime = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterMovement3D player))
        {
            player.ChangeSpeed(_decreaseSpeed, _slowDownTime);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(_distroyTime);
        Destroy(gameObject);
    }
}
