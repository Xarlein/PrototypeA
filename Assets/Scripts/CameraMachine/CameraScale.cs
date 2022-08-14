using UnityEngine;

public sealed class CameraScale : MonoBehaviour
{
    [Header("Main")]
    [SerializeField]
    private Camera _observer;
    [SerializeField]
    private int _steps;
    [SerializeField]
    private float _stepScale;


    private void LateUpdate()
    {
        float scrollDirection = Input.GetAxis("Mouse ScrollWheel");

        _observer.orthographicSize = Mathf.Clamp(_observer.orthographicSize + (scrollDirection * _stepScale), 5, _steps * _stepScale);
    }
}
