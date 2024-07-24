using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events {

    public class StartDispatcher : MonoBehaviour {

        [SerializeField]
        private List<EventManager> _startEventDispather;

        private void Start() {
            if (_startEventDispather != null) {
                foreach (var e in _startEventDispather) {
                    if (e != null) e.Dispatch();
                }
            }
        }
    }
}
