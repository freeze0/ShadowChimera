using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace ShadowChimera
{
    public class FindTargetAction : ActionNode
    {
        private SearcherTarget m_searcherTarget;
        //public float maxDistance = 10;

        protected override void OnStart()
        {
            if (m_searcherTarget == null)
            {
                m_searcherTarget = context.gameObject.GetComponent<SearcherTarget>();
            }
        }

        protected override void OnStop()
        {	
        }

        protected override State OnUpdate()
        {
            blackboard.target = m_searcherTarget.FindTarget();
            
            /*if (blackboard.target)
            {
                if (Vector3.Distance(blackboard.target.position, context.transform.position) < maxDistance)
                {
                    Debug.Log("Нашли если таргет находится в радиусе");
                    return State.Success;
                }
            }*/
            
            if (blackboard.target)
            {
                //Debug.Log("Если функция вернула не null и поменяли таргет позицию");
                blackboard.moveToPosition = blackboard.target.position;
                return State.Success;
            }
            
            return State.Failure;
        }
    }
}