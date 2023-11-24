using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

namespace ShadowChimera
{
    public class Pistol : AttackItem
    {
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_damage = 10.0f;
        [SerializeField] private GameObject m_decal;
        [SerializeField] private Vector3 m_offset = new Vector3(0,1.5f,0);
        public override void StartUse()
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
                Instantiate(m_decal, hit.point, Quaternion.LookRotation(Vector3.Project(m_muzzle.forward, hit.normal)));
            }
        }

        public override void EndUse()
        {
        }


    }
}
