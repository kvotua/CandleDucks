using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events {

    [CreateAssetMenu(fileName = "Event", menuName = "Event")]
    public class ScriptableEvent : ScriptableObject {

        private List<Action> _followers;

        public void AddListener(Action action) {
            if (_followers == null) {
                _followers = new List<Action>();
            }

            if (_followers.IndexOf(action) == -1) {
                _followers.Add(action);
            }
        }

        public void RemoveListener(Action action) {
            if (_followers == null || _followers.IndexOf(action) == -1) {
                return;
            }

            _followers.Remove(action);
        }

        public void Dispatch() {
            if (_followers == null) {
                return;
            }
            for (int i = _followers.Count - 1; i > -1; i--) {
                _followers[i]();
            }
        }
    }
}