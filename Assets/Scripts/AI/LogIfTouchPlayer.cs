using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {
    [System.Serializable]
    public class LogIfTouchPlayer : ActionNode
    {
        public string message;

        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (blackboard.isTouchingPlayer)
            {
                Debug.Log($"{message}");
                return State.Success;
            }

            return State.Failure;

        }
    }
}
