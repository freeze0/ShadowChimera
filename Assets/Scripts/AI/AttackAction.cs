using System.Collections;
using System.Collections.Generic;
using ShadowChimera;
using UnityEngine;

namespace TheKiwiCoder {
    [System.Serializable]
    public class AttackAction : ActionNode
    {
        private EnemyAttack atk;
        protected override void OnStart()
        {
            var atk = context.agent.GetComponent<EnemyAttack>();
            atk.Shoot();
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            
            return State.Success;
        }
    }
}
