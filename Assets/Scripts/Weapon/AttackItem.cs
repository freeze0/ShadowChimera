using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowChimera
{
    public abstract class AttackItem: MonoBehaviour
    {
        public abstract void StartUse();
        public abstract void EndUse();
        public abstract void Reload();

        public void TurnOff()
        {
            gameObject.SetActive(false);
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
        }

    }
}
