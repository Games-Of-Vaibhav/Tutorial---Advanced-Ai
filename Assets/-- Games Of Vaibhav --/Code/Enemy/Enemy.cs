using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GamesOfVaibhav
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : MonoBehaviour
    {
        [Header("Agent")]
        [HideInInspector] public NavMeshAgent Agent;
        public float PetrolSpeed = 5, ChaseSpeed = 8;

        [Header("States")]
        private EnemyStatesFactory _enemyStatesFactory;
        private EnemyStatesBase _enemyStateBase;
        public EnemyStatesBase CurrentState { get { return _enemyStateBase; } set { _enemyStateBase = value; } }

        [Header("Petroling")]
        public Coroutine LastWaitRoutine;
        public float MinWaitTime = 1f, MaxWaitTime = 6f;
        [HideInInspector] public Transform[] WayPoints;
        [HideInInspector] public Transform CurrentWayPoint;
        public float ExtraPetrolStopDistance = 1.5f;

        [Header("Agent Attacks")]
        public bool FoundThePlayer;
        public bool CanAttack;
        public float AttackTime = 1f;
        public float ExtraStopingDistanceAttack = 2;
        public Coroutine LastAttackRoutine;

        public Transform Player { get; set; }
        public Transform PlayerGround { get; set; }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            InitializeStates();

            // Setting the player
            Player = PlayerInstance.Instance.Player;
            PlayerGround = PlayerInstance.Instance.GroundPlayer;
        }

        private void InitializeStates()
        {
            // Setting Waypoints
            WayPoints = EnemyManager.Instance.WayPoints;

            // Creating new instance of the states
            _enemyStatesFactory = new EnemyStatesFactory(this);
            _enemyStateBase = _enemyStatesFactory.Wait();
            _enemyStateBase.EnterState();
        }

        private void Update()
        {
            // Update the state
            _enemyStateBase.UpdateState();
        }

        public void PlayerFound(bool found)
        {
            FoundThePlayer = found;

            if (found)
            {
                _enemyStateBase.SwitchStates(_enemyStatesFactory.Chase());
            }
            else
            {
                _enemyStateBase.SwitchStates(_enemyStatesFactory.Wait());
            }
        }
    }
}
