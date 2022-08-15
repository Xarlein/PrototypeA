using UnityEngine;

namespace Assets.Scripts.CameraMachine
{
    [RequireComponent(typeof(Camera))]
    public sealed class CameraScale : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField]
        private Camera _observer;
        [SerializeField]
        private int _steps;
        [SerializeField]
        private float _stepScale;

        private float _originSize;

        private void Awake()
        {
            _originSize = _observer.orthographicSize;
        }

        private void LateUpdate()
        {
            float scrollDirection = Input.GetAxis("Mouse ScrollWheel");

            _observer.orthographicSize = Mathf.Clamp(_observer.orthographicSize + (scrollDirection * _stepScale), _originSize, _steps * _stepScale);
        }
    }

}

