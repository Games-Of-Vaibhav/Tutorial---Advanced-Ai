using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    public class EnemyPetrol : EnemyStatesBase
    {
        public EnemyPetrol(Enemy enemy, EnemyStatesFactory enemyStateFactory) : base(enemy, enemyStateFactory)
        {
        }

        public override void EnterState()
        {
            Enemy.Agent.speed = Enemy.PetrolSpeed;
            SetRandomPoint();
            SetDestination(Enemy.CurrentWayPoint);
        }


        public override void UpdateState()
        {
            CheckAndSetDestination();
        }

        private void CheckAndSetDestination()
        {
            if (Enemy.Agent.hasPath && Enemy.CurrentWayPoint != null)
            {
                // calculate the distance between current target
                float distance = Vector3.Distance(Enemy.transform.position, Enemy.CurrentWayPoint.position);
                if (distance <= Enemy.Agent.stoppingDistance + Enemy.ExtraPetrolStopDistance)
                {
                    // Agent has reached the target
                    Enemy.CurrentWayPoint = null;
                    Enemy.Agent.ResetPath();
                    SwitchStates(EStateFactory.Wait());
                }
            }
        }

        private void SetRandomPoint()
        {
            int randomPoint = Random.Range(0, Enemy.WayPoints.Length);

            Transform target = Enemy.WayPoints[randomPoint];
            if (Enemy.CurrentWayPoint)
            {
                if (target == Enemy.CurrentWayPoint)
                {
                    if (randomPoint == 0)
                        randomPoint++;
                    else if (randomPoint == Enemy.WayPoints.Length - 1)
                        randomPoint--;
                    else
                        randomPoint++;
                }
            }
            target = Enemy.WayPoints[randomPoint];

            Enemy.CurrentWayPoint = target;
        }

        // Setting destination
        private void SetDestination(Transform point) => Enemy.Agent.SetDestination(point.position);
        private void SetDestination(Vector3 point) => Enemy.Agent.SetDestination(point);

        #region Unused Functions
        public override void ExitState()
        {

        }
            
        #endregion
    }
}
