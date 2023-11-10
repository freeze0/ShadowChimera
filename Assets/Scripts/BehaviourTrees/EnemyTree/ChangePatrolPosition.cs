using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ChangePatrolPosition : ActionNode
{

    private int m_index; 
    protected override void OnStart() {

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }

    private bool ChangePosition()
    {


        return false;
    }
}
