using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class ProjectileManager : MonoBehaviour
    {
        public float lifeTime = 0.5f;

        private void Awake()
        {
            Destroy(gameObject, lifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Попал!");
            }
            Destroy(gameObject);
        }
    }
}
