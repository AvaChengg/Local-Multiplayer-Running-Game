using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SpawnPlayerSetupMenu : MonoBehaviour
{
    //public GameEvent<string> _playerSetupMenu;
    //public GameEvent<string> _staffSetupMenu;
    public GameObject PlayerSetupMenuPrefab;
    public PlayerInput Input;

    public UnityEvent OnSpawned;

    private void Awake()
    {
        var rootMenu = GameObject.Find("MainLayout");
        var multiplayerManager = GameObject.Find("MultiplayerManager");
        if (rootMenu != null)
        {
            var menu = Instantiate(PlayerSetupMenuPrefab, rootMenu.transform);
            Input.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
            menu.GetComponent<PlayerMenuController>().SetPlayerIndex(Input.playerIndex);
            multiplayerManager.GetComponent<PlayerConfigurationManager>().SelectedObjects.Add(menu);
            OnSpawned.Invoke();
            
            //if (Input.currentControlScheme == "Gamepad" && Input.playerIndex == 0)
            //{
            //    _playerSetupMenu.Invoke("Staff");
            //    _playerSetupMenu.Invoke("Runner");
            //}
        }
    }
}
