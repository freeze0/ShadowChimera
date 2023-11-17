using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class EnemyAttack : MonoBehaviour
    {
        public Transform projectileSpawnPoint;
        public GameObject projectilePrefab;
        public float projectileSpeed;

        public void Shoot() 
        {
            Debug.Log("Fire");
            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody>().velocity = projectileSpawnPoint.forward * projectileSpeed;
        }
    }
}
