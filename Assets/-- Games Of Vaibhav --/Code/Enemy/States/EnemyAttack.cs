using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    public class EnemyAttack : EnemyStatesBase
    {
        public EnemyAttack(Enemy enemy, EnemyStatesFactory enemyStateFactory) : base(enemy, enemyStateFactory)
        {
        }

        public override void EnterState()
        {
            if (Enemy.LastAttackRoutine != null) Enemy.StopCoroutine(Enemy.LastAttackRoutine);
            DelayAttackShort();
        }

        public override void ExitState()
        {

        }

        public override void UpdateState()
        {
        }

        IEnumerator DelayAttack()
        {
            Attack();
            yield return new WaitForSeconds(Enemy.AttackTime);
            Enemy.LastAttackRoutine = null;
            CheckAttackDistance();
        }

        private void Attack()
        {
            // Attack the player
            Debug.Log($"{Enemy.name} : Boom Baby");
            Vector3 lookTarget = new Vector3(Enemy.Player.position.x, Enemy.transform.position.y, Enemy.Player.position.z);
            Enemy.transform.LookAt(Enemy.Player);
        }

        private void CheckAttackDistance()
        {
            float distance = Vector3.Distance(Enemy.transform.position, Enemy.Player.position);
            if (distance >= Enemy.Agent.stoppingDistance + Enemy.ExtraStopingDistanceAttack)
            {
                // Player is way chase him back
                Enemy.Agent.ResetPath();
                SwitchStates(EStateFactory.Chase());
                Enemy.CanAttack = false;
            }
            else
            {
                DelayAttackShort();
            }
        }

        private void DelayAttackShort() => Enemy.LastAttackRoutine = Enemy.StartCoroutine(DelayAttack());
    }
}
