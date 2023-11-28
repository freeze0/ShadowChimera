using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public enum WeaponState
    {
         Idle, Fire, Reload
    }
    public class AutomaticRifle :AttackItem
    {

        [SerializeField] private BulletComponent m_prefab;
        [SerializeField] private Transform m_muzzle;
        [SerializeField] private float m_delay = 0.1f;
        [SerializeField] private float m_reloadTime = 1f;

        
        [Space]
        [Header("CAGE")]
        private int m_bulletCount = 100;
        private int m_maxCage = 30;
        private int m_cage = 0;
        private bool m_autoFire = true;

        private Coroutine m_fireCoroutine;
        
        public bool canFire => m_cage > 0;

        private WeaponState m_State;

        private void Update()
        {
            switch(m_State) 
            { 
            case WeaponState.Idle:
                    break; 
            case WeaponState.Fire:
                    break;
            case WeaponState.Reload:
                    break;
            }
        }


        public override void EndUse()
        {         
            Debug.Log("End Use", this);

            if(m_fireCoroutine != null)
            {
                StopCoroutine(m_fireCoroutine);
                m_fireCoroutine = null;
            }
        }

        public override void StartUse()
        {
            Debug.Log("Start Use", this);

            m_fireCoroutine = StartCoroutine(StartFire());
        }

        private IEnumerator StartFire()
        {
            var waitForSeconds = new WaitForSeconds(m_delay);

            do
            {
                if (!canFire)
                {
                    yield return new WaitForSeconds(m_reloadTime);
                    Reload();
                }

                if (canFire)
                {
                    Instantiate(m_prefab, m_muzzle.position, m_muzzle.rotation);
                    m_cage--;
                    yield return waitForSeconds;
                }

            }
            while(m_autoFire &&  m_cage > 0);
        }

        public override void Reload()
        {
            m_bulletCount = Mathf.Max(m_bulletCount - m_maxCage, 0);
            m_cage = Mathf.Min(m_maxCage, m_bulletCount);
        }
    }
}
