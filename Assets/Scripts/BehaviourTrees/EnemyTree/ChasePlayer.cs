using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ChasePlayer : ActionNode
{
    public float stoppingDistance = 0.1f;

    protected override void OnStart()
    {
        // а как считывать позицию игрока каждый кадр?
        context.agent.isStopped = false;
        context.agent.stoppingDistance = stoppingDistance;
        context.agent.destination = blackboard.moveToPosition;
        //context.agent.destination = blackboard.moveToPosition;
    }

    protected override void OnStop()
    {
        context.agent.isStopped = true;
    }

    protected override State OnUpdate()
    {
        context.agent.isStopped = false;

        if (context.agent.pathPending)
        {
            //context.agent.destination = blackboard.moveToPosition;
            return State.Running;
        }

        if (context.agent.remainingDistance < stoppingDistance)
        {
            return State.Success;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            return State.Failure;
        }

        return State.Running;
    }
}
