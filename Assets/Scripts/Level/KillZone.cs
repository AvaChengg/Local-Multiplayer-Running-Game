using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterMovement3D player))
        {
            if (player.tag == "Staff")
            {
                SceneManager.LoadScene("StaffWin");
            }
            else
            {
                SceneManager.LoadScene("PlayerWin");
            }
        }
    }
}
