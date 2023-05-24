using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{

    public GameEvent<GameObject> Player;
    public GameEvent<GameObject> Staff;

    public void HidePlayer()
    {
        Time.timeScale = 0f;
        Player.GetComponentInChildren<CharacterMovement3D>().enabled = false;
        Staff.GetComponentInChildren<CharacterMovement3D>().enabled = false;
    }

    public void ShowPlayer()
    {
        Time.timeScale = 1f;
        Player.GetComponentInChildren<CharacterMovement3D>().enabled = true;
        Staff.GetComponentInChildren<CharacterMovement3D>().enabled = true;
    }
}
