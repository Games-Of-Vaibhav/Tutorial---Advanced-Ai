using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    public class EnemyStatesFactory : MonoBehaviour
    {
        public Enemy Enemy;

        public EnemyStatesFactory(Enemy enemy)
        {
            Enemy = enemy;
        }

        // States
        public EnemyPetrol Petrol() { return new EnemyPetrol(Enemy, this); }
        public EnemyWait Wait() { return new EnemyWait(Enemy, this); }
        public EnemyChase Chase() { return new EnemyChase(Enemy, this); }
        public EnemyAttack Attack() { return new EnemyAttack(Enemy, this); }
    }
}
