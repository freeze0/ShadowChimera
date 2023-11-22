using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class Pistol : MonoBehaviour, IAttackItem
    {
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_damage = 10.0f;
        public void StartUse()
        {
            Debug.Log("Peef");
            RaycastHit hit;
            Vector3 pos = m_muzzle.position;
            Vector3 fwd = m_muzzle.TransformDirection(Vector3.forward);
            if (Physics.Raycast(pos, fwd, out hit, Mathf.Infinity))
            {
                var damageable = hit.collider.GetComponentInParent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(m_damage);
                }
            }
        }

        public void EndUse()
        {
        }
    }
}
