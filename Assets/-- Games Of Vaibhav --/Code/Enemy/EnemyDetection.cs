using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    public class EnemyDetection : MonoBehaviour
    {
        [Header("Fields")]
        private Enemy _enemy;
        private bool _playerIsInArea;
        private Transform _player;
        [SerializeField] private Transform _detectionOrigin;

        [SerializeField] private float _detectionAngle = 5f;

        [Header("Raycheck")]
        [SerializeField] private LayerMask _detectionMask;

        private bool _playerFound = false;

        [Header("Editor")]
        public SphereCollider _sphereCollider;
        public float ColliderRadius { get { return _sphereCollider.radius; } }
        public Transform DetectionOrigin { get { return _detectionOrigin; } }
        public float DetectionAngle { get { return _detectionAngle; } }


        private void Start()
        {
            _player = PlayerInstance.Instance.PlayerHead;
            _enemy = GetComponentInParent<Enemy>();
        }

        private void Update()
        {
            DetectTheAngle();
        }

        private void DetectTheAngle() // detectin the agnle between player and enemy
        {
            // if (!_playerIsInArea || _playerFound) return;

            Vector3 direction = _player.position - _detectionOrigin.position;
            float targetAgnle = _detectionAngle * 0.5f;
            float angle = Vector3.Angle(direction, _detectionOrigin.forward);

            if (angle < targetAgnle)
            {
                if (RayCheck)
                {
                    // Player is found
                    _playerFound = true;
                    _enemy.PlayerFound(true);
                    Debug.Log($"{this.name} : Player Found!!");
                }
            }
        }

        private bool RayCheck
        {
            get
            {
                bool found = false;

                Ray ray = new Ray(_detectionOrigin.position, _detectionOrigin.forward);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 500, _detectionMask, QueryTriggerInteraction.Ignore))
                    found = true;

                return found;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                _playerIsInArea = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _playerIsInArea = false;
                _playerFound = false;
                _enemy.PlayerFound(false);
            }
        }
    }
}
