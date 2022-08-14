using System;
using UnityEngine;

public sealed class CameraMovement : MonoBehaviour
{
    [Header("Main")]
    [SerializeField]
    private Transform _observer;
    [SerializeField]
    private Transform _slave;
    [SerializeField]
    private Vector3 _offset;

    private void OnEnable()
    {
        if (_observer == null)
            throw new Exception("No observer found!");

        if (_slave == null)
            throw new Exception("Slave not found!");
    }

    private void Update()
    {
        MoveCameraBehindSlave();   
    }

    private void MoveCameraBehindSlave()
    {
        _observer.position = _slave.position + _offset + new Vector3(0, 0, _observer.position.z);
    }
}
