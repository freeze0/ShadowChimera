using System.Collections;
using System.Collections.Generic;
using ShadowChimera;
using UnityEngine;
using TheKiwiCoder;
using Unity.VisualScripting;
using UnityEngine.ProBuilder.Shapes;

[System.Serializable]
public class WaitEnemy : ActionNode
{
    
    public float duration = 1;
    
    private float m_startTime;
    private bool m_flag;
    private Transform m_transform_spotRange; //у каждого енеми свой скрипт? если наплодить  
    private SpotRange m_spotRange;
    
    protected override void OnStart() 
    {
        m_startTime = Time.time;
        m_transform_spotRange = context.gameObject.transform.Find("SpotRange");
        m_spotRange = m_transform_spotRange.transform.GetComponent<SpotRange>();
    }
    
    
    protected override void OnStop() 
    {
    }

    protected override State OnUpdate() 
    {
        float timeRemaining = Time.time - m_startTime;

        m_flag = m_spotRange.foundThePlayer;
        if (m_flag)
        {
            Debug.Log("I Found The Player");
            return State.Failure;
        }
        
        if (timeRemaining > duration) 
        {
            return State.Success;
        }
        return State.Running;
    }
}
