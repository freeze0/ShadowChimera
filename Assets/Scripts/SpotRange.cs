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
        
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("I collide");
            if (other.gameObject.CompareTag("Player"))
            {
                foundThePlayer = true; //?????
                Debug.Log("I Found The Player");
            }
        }
        
    }
}
