using System.Collections;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using UnityEngine;
using UnityEngine.VFX;

public class ObjectsMovement : MonoBehaviour
{
    [Header("Movement Setting")]
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _descreaseSpeed = 2f;
    [SerializeField] private int _slowDownTime = 2;
    [SerializeField] private int _distroyTime = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterMovement3D player))
        {
            player.ChangeSpeed(_descreaseSpeed, _slowDownTime);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(_distroyTime);
        Destroy(gameObject);
    }
}
