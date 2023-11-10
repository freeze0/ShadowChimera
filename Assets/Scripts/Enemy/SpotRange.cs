using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class SpotRange : MonoBehaviour
    {
        public bool foundThePlayer = false;

        private void Awake()
        {
            foundThePlayer = false;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                foundThePlayer = true;
            }
        }
        
    }
}
