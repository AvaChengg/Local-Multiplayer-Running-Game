using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollection : MonoBehaviour
{
    public UnityEvent OnCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterMovement3D player))
        {
            // play SFX or VFX
            OnCollected.Invoke();

            // increase the number
            player.Coin++;

            // update the UI text
            player.UpdateCoinNumber();

            // destroyit
            Destroy(gameObject);
        }
    }
}
