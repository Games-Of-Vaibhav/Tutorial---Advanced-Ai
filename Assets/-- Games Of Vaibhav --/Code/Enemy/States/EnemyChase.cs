using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    public class EnemyChase : EnemyStatesBase
    {
        public EnemyChase(Enemy enemy, EnemyStatesFactory enemyStateFactory) : base(enemy, enemyStateFactory)
        {
        }

        public override void EnterState()
        {
            Enemy.Agent.ResetPath();
            Enemy.Agent.speed = Enemy.ChaseSpeed;
        }

        public override void ExitState()
        {

        }

        public override void UpdateState()
        {
            if (Enemy.CanAttack) return;
            CheckAndSetDestination();
            SetDestination(Enemy.PlayerGround);
        }

        private void CheckAndSetDestination()
        {
            if (!Enemy.CanAttack)
            {
                // calculate the distance between current target
                float distance = Vector3.Distance(Enemy.transform.position, Enemy.PlayerGround.position);
                if (distance <= Enemy.Agent.stoppingDistance + Enemy.ExtraStopingDistanceAttack)
                {
                    // Agent has reached the target
                    Enemy.Agent.ResetPath();
                    SwitchStates(EStateFactory.Attack());
                    Enemy.CurrentWayPoint = null;
                    Enemy.CanAttack = true;
                }
            }
        }

        // Setting destination
        private void SetDestination(Transform point) => Enemy.Agent.SetDestination(point.position);
        private void SetDestination(Vector3 point) => Enemy.Agent.SetDestination(point);
    }
}
