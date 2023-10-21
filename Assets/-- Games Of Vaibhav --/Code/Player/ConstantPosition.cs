using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    public class ConstantPosition : MonoBehaviour
    {
        public Transform TargetPosition;
        private void Start()
        {
            transform.SetParent(null);
            TargetPosition = PlayerInstance.Instance.Player;
        }

        private void Update()
        {
            Vector3 desiredPosition = new Vector3(TargetPosition.position.x, transform.position.y, TargetPosition.position.z);
            transform.position = desiredPosition;
        }
    }
}
