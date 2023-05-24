using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMultiplayer : MonoBehaviour
{
    public void DestroyMultiplayerObject()
    {
        Destroy(GameObject.Find("MultiplayerManager"));
    }
}
