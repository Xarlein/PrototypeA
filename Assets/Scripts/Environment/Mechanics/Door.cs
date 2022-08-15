using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Environment.Mechanics
{
    public sealed class Door : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField]
        private DoorStates _defaultState;
        [SerializeField]
        private bool _needKey;

        [Header("Events")]
        public UnityEvent OnDoorClosed;
        public UnityEvent OnDoorOpened;
        public UnityEvent OnStateChanged;

        public void OnDisable()
        {
            OnDoorClosed?.RemoveAllListeners();
            OnDoorOpened?.RemoveAllListeners();
            OnStateChanged?.RemoveAllListeners();
        }

        public void Open()
        {
            OnDoorOpened?.Invoke();
            OnStateChanged?.Invoke();
        }

        public void Close()
        {
            OnDoorClosed?.Invoke();
            OnStateChanged?.Invoke();
        }

    }
    
    public enum DoorStates
    {
        Close,
        Open
    }

}

