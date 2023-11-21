using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class WeaponAttackItem : MonoBehaviour, IAttackItem
    {

        [SerializeField] private Transform m_prefab;
        [SerializeField] private Transform m_muzzle;

        public void EndUse()
        {
            Debug.Log("End Use", this);
        }

        public void StartUse()
        {
            Debug.Log("Start Use", this);

            Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
        }
    }
}
