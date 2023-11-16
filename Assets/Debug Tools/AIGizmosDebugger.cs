using System;
using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace ShadowChimera
{
#if UNITY_EDITOR
    public class AIGizmosDebugger : MonoBehaviour
    {
        [SerializeField] private List<NavMeshAgent> m_agents = new List<NavMeshAgent>();

        private void OnDrawGizmos()
        {
            foreach (var agent in m_agents)
            {
                //как получить скрипт из дерева? нужно получить радиус атаки
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(agent.transform.position, agent.GetComponent<SearcherTarget>().radius);
            }
        }
    }
#endif
}
