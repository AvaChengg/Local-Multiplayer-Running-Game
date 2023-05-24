using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerController : MonoBehaviour
{
    private PlayerConfiguration _playerConfig;
    private CharacterMovement3D _characterMovement;
    private PlayerAbilities _playerAbilities;

    [SerializeField] private SkinnedMeshRenderer _playerMesh;


    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement3D>();
        _playerAbilities = GetComponent<PlayerAbilities>();
    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        _playerConfig = pc;

        // change player clothes
        Material[] mats = _playerMesh.materials;
        mats[3] = pc.PlayerMaterial;
        _playerMesh.materials = mats;
    }

    public void OnMoveLeft()
    {
        _characterMovement.SetMoveDirection(false);
    }

    public void OnMoveRight()
    {
        _characterMovement.SetMoveDirection(true);
    }

    public void OnJump()
    {
        _characterMovement.TryJump(true);
    }

    public void OnRoll()
    {
        _characterMovement.TryRoll(true);
    }

    public void OnAttack()
    {
        _playerAbilities.Attack();
    }

    public void OnThrow()
    {
        _playerAbilities.Throw();
    }

}
