using TheKiwiCoder;
using TMPro;
using UnityEngine;

namespace ShadowChimera.AI
{
	public class LookAtTarget : ActionNode
	{
		private LayerMask m_layerMask;
		private Transform m_agentTransform;
        private float m_angularSpeed;

        protected override void OnStart()
		{
			m_layerMask = LayerMask.GetMask("Projectile");
			m_agentTransform = context.agent.transform;
            m_angularSpeed = context.agent ? context.agent.angularSpeed : 360f;
        }

		protected override void OnStop()
		{
		}

		protected override State OnUpdate()
		{
            var targetPosition = blackboard.target.position;
            RaycastHit hit;
			Vector3 fwd = m_agentTransform.TransformDirection(Vector3.forward);
			if (Physics.Raycast( m_agentTransform.position,  
				    m_agentTransform.TransformDirection(Vector3.forward), out hit, 100, ~m_layerMask))
			{
				if (!hit.transform.CompareTag("Player"))
				{
					blackboard.attackRange = 0.1f;
					Debug.DrawRay(m_agentTransform.position, 
						m_agentTransform.TransformDirection(Vector3.forward) * 100, Color.white);
					//Debug.Log("Did not Hit");
					
				}
				else
				{
					blackboard.attackRange = blackboard.reserveAttackRange;
					Debug.DrawRay(m_agentTransform.position, 
						m_agentTransform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
					//Debug.Log("Did Hit");
				}
			}

            var contextTr = context.transform;
            var contextPosition = contextTr.position;

            targetPosition.y = contextPosition.y;
            var dir = targetPosition - contextPosition;
            contextTr.rotation = Quaternion.RotateTowards(contextTr.rotation, Quaternion.LookRotation(dir), m_angularSpeed * Time.deltaTime);
            return State.Success;
		}
	}
}