using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public class AttackManager : MonoBehaviour
    {
        private List<AttackItem> m_items = new();
        private int m_currentIndex = -1;
        
        public AttackItem currentItem
        {
            get
            {
                return m_items[m_currentIndex];
            }
        }
        private void Start()
        {
            GetComponentsInChildren(true, m_items);

            m_currentIndex =  m_items.Count > 0 ? 0: -1;
        }

        public void Next()
        {
            if (m_items.Count > 0)
            {
                currentItem.TurnOff();
                m_currentIndex++;
                if (m_currentIndex >= m_items.Count)
                {
                    m_currentIndex = 0;
                }
                currentItem.TurnOn();
            }
        }

        public void StartUseWeapon()
        {
            if (m_currentIndex >= 0) 
            {
                currentItem.StartUse();
            }
        }

        public void EndUseWeapon()
        {
            currentItem.EndUse();
        }

        public void Reload()
        {
            currentItem.Reload();
        }
    }
}
