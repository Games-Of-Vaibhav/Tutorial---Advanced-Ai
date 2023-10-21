using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    public class EnemyWait : EnemyStatesBase
    {
        public EnemyWait(Enemy enemy, EnemyStatesFactory enemyStateFactory) : base(enemy, enemyStateFactory)
        {
        }

        public override void EnterState()
        {
            Enemy.LastWaitRoutine = Enemy.StartCoroutine(DelayWaitForPetrol());
        }


        IEnumerator DelayWaitForPetrol()
        {
            float randomWaitTime = Random.Range(Enemy.MinWaitTime, Enemy.MaxWaitTime);
            yield return new WaitForSeconds(randomWaitTime);
            SwitchStates(EStateFactory.Petrol());
        }

        #region UnUsed Functions
        public override void ExitState()
        {

        }

        public override void UpdateState()
        {

        }
            
        #endregion
    }
}
