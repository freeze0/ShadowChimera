using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class MoveToPositionOffset : ActionNode
{
	public float stoppingDistance = 1f;

	protected override void OnStart()
	{
		context.agent.isStopped = false;
		context.agent.stoppingDistance = stoppingDistance;
		context.agent.destination = blackboard.moveToPosition;
	}

	protected override void OnStop()
	{
		context.agent.isStopped = true;
	}

	protected override State OnUpdate()
	{
		context.agent.isStopped = false;
		Debug.Log($"MoveTo{context.agent.destination}");
		
		if (context.agent.pathPending)
		{
			Debug.Log($"MoveTo pathPending");
			return State.Running;
		}

		if (context.agent.remainingDistance < stoppingDistance)
		{
			Debug.Log($"RemainingDistance {context.agent.remainingDistance}");
			return State.Success;
		}

		if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
		{
			return State.Failure;
		}
		
		return State.Running;
	}
}
