using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class SwordComponent : MonoBehaviour
    {
        [SerializeField] private float m_damage = 40.0f;


        /*private void OnCollisionEnter(Collision other)
        {
           
        }*/

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Collide:{other.tag}");
            var damageable = other.GetComponentInParent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(m_damage);
            }
        }
    }
}
