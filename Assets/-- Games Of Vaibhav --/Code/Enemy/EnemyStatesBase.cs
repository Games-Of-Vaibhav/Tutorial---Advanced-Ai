using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    public abstract class EnemyStatesBase
    {
        public EnemyStatesBase(Enemy enemy, EnemyStatesFactory enemyStateFactory)
        {
            Enemy = enemy;
            EStateFactory = enemyStateFactory;
        }

        public Enemy Enemy;
        public EnemyStatesFactory EStateFactory;

        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();

        public void SwitchStates(EnemyStatesBase newState)
        {
            // Exit the previous state
            Enemy.CurrentState.ExitState();

            // Set the new state
            Enemy.CurrentState = newState;

            // Enter the new state
            Enemy.CurrentState.EnterState();
        }
    }
}
