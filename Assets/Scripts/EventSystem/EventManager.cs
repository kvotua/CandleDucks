using System;
using UnityEngine;

namespace Events {

    public class EventManager : MonoBehaviour {

        [SerializeField]
        private ScriptableEvent _someEvent;

        public event Action OnEventHappened = delegate { };

        private void OnEnable() {
            _someEvent.AddListener(EventHappened);
        }

        private void OnDisable() {
            _someEvent.RemoveListener(EventHappened);
        }

        public void Dispatch() {
            _someEvent.Dispatch();
        }

        private void EventHappened() {
            OnEventHappened.Invoke();
        }
    }
}