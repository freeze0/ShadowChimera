using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Unity.VisualScripting;
using UnityEngine.Serialization;

[System.Serializable]
public class ChasePlayer : ActionNode
{
	//public float spotRange = 10.0f;
	public float attackRange = 2f;
	
	protected override void OnStart()
	{
		blackboard.isTouchingPlayer = false;
		context.agent.isStopped = false;
		context.agent.stoppingDistance = attackRange;
		context.agent.SetDestination(blackboard.target.position);
	}

	protected override void OnStop()
	{
		//context.agent.isStopped = true;
	}

	protected override State OnUpdate()
	{
		var agent = context.agent;
		agent.isStopped = false;
		/*if (agent.remainingDistance > spotRange)
		{
			return State.Failure;
		}*/

		if (agent.pathPending)
		{
			return State.Running;
		}

		if (agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
		{
			return State.Failure;
		}
		
		if (agent.remainingDistance <= attackRange)
		{
			blackboard.isTouchingPlayer = true; // уменьшать радиус атаки если рейкастом не попадаем по игроку
		}
		
		return State.Success;
	}

	
	/*private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(context.agent.transform.position, attackRange);
	}*/
}
