using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private Transform _cam;
        [SerializeField] private float _moveSpeed = 6;
        [SerializeField] private float _jumpForce = 4;
        [SerializeField] private float _gravity = -9.81f;

        [Header("Private Fields")]
        private CharacterController _controller;
        private Vector3 _velocityY;
        private bool _isgrounded;

        [Header("Ground Check")]
        [SerializeField] private Transform _groundPoint;
        [SerializeField] private float _groundRadius = 0.1f;
        [SerializeField] private bool _drawGizmos;
        [SerializeField] private LayerMask _groundMask;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            Move();
        }

        /// <summary>
        /// Simple movement for first person
        /// </summary>
        private void Move()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            _isgrounded = Physics.CheckSphere(_groundPoint.position, _groundRadius, _groundMask);

            Vector3 delta = transform.right * x + transform.forward * z;
            _controller.Move(delta * _moveSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && _isgrounded)
            {
                _velocityY.y = Mathf.Sqrt(_jumpForce * -2 * _gravity);
            }

            if (!_controller.isGrounded)
            {
                _velocityY.y += _gravity * Time.deltaTime;
                _controller.Move(_velocityY * Time.deltaTime);
            }
            else
            {
                _velocityY.y = -2;
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (!_drawGizmos) return;
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(_groundPoint.position, _groundRadius);
        }
    }
}
