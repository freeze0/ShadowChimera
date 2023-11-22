using System.Collections;
using System.Collections.Generic;
using ShadowChimera;
using UnityEngine;

namespace TheKiwiCoder {
    [System.Serializable]
    public class AttackAction : ActionNode
    {
        private AttackManager m_attackManager;
        protected override void OnStart()
        {
            if (m_attackManager == null)
            {
                m_attackManager = context.gameObject.GetComponent<AttackManager>();
            }
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            if (m_attackManager != null)
            {
                m_attackManager.StartUse();
                m_attackManager.EndUse();
            }
            return State.Success;
        }
    }
}
