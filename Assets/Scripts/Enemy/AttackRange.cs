using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class AttackRange : MonoBehaviour
    {
        public bool playerIsNear = false;

        private void Awake()
        {
            playerIsNear = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player is near");
                playerIsNear = true;
            }
        }
    }
}
