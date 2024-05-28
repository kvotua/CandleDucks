using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events {

    public class UpdateDispatcher : MonoBehaviour {

        [SerializeField]
        private List<EventManager> _updateEventDispatcher;

        private void Update() {
            if (_updateEventDispatcher != null) {
                foreach (var e in _updateEventDispatcher) {
                    if (e != null) e.Dispatch();
                }
            }
        }
    }
}
