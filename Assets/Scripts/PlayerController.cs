using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShadowChimera
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Character m_character;
        
        [SerializeField] private InputActionAsset m_inputActionAsset;
        [SerializeField] private CharacterController m_characterController;
        [SerializeField] private float m_speedMove = 5f;

        private InputActionMap m_playerMap;
        private InputAction m_moveAction;
        private InputAction m_jumpAction;
        private InputAction m_fireAction;

        private void Awake()
        {
            m_playerMap = m_inputActionAsset.FindActionMap("Player");
            m_moveAction = m_playerMap.FindAction("Move");
            m_jumpAction = m_playerMap.FindAction("Jump");
            m_fireAction = m_playerMap.FindAction("Fire");
        }

        private void OnEnable()
        {
            m_playerMap.Enable();
           // m_jumpAction.performed += Jump();
           m_fireAction.performed += OnFireInput;
        }

        private void OnFireInput(InputAction.CallbackContext obj)
        {
            Debug.Log("Fire!");
        }


        private void OnDisable()
        {
            m_playerMap.Disable();
            m_fireAction.performed -= OnFireInput;
        }

        private void Update()
        {
            Vector2 move = m_moveAction.ReadValue<Vector2>();
            
            if (move != Vector2.zero)
            {
                Vector3 dir = new Vector3(move.x, 0f, move.y);
                m_characterController.SimpleMove(dir * m_speedMove);
            }
        }

        private void Jump()
        {
            
        }
    }
}
