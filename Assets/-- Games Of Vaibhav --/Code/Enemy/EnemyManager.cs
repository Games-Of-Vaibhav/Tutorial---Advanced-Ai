using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    public class EnemyManager : MonoBehaviour
    {
        #region Singlton

        public static EnemyManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        public Transform[] WayPoints;
    }
}
