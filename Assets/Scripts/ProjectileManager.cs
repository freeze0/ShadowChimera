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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                Debug.Log("Попал!");
            }
            Destroy(gameObject);
        }
    }
}
