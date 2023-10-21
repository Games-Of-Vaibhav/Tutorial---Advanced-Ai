using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamesOfVaibhav
{
    public class CameraMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private Transform _cam;
        [SerializeField] private Transform _player;
        [SerializeField] private float _sensitivity = 500;
        [SerializeField] private float _minClamp = -85f, _maxClamp = 80f;

        private float _rotateX, _rotateY;
        private Vector2 YawPitch;

        void Update()
        {
            CameraMove();
        }

        /// <summary>
        /// A simple camera rotation
        /// </summary>
        private void CameraMove()
        {
            YawPitch.x = Input.GetAxisRaw("Mouse X") * _sensitivity * Time.deltaTime;
            YawPitch.y = Input.GetAxisRaw("Mouse Y") * _sensitivity * Time.deltaTime;

            _rotateX -= YawPitch.y;
            _rotateX = Mathf.Clamp(_rotateX, _minClamp, _maxClamp);
            _rotateY += YawPitch.x;

            Vector3 rot = new Vector3(_rotateX, _rotateY);
            _player.rotation = Quaternion.Euler(0, rot.y, 0);
            _cam.rotation = Quaternion.Euler(rot);
        }
    }
}
