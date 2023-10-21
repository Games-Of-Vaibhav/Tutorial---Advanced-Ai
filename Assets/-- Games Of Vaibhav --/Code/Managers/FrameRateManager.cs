using UnityEngine;

namespace GamesOfVaibhav
{
    public class FrameRateManager : MonoBehaviour
    {
        [Tooltip("Frame rates set to be in start")]
        public int _frameRate = 60;

        private void Awake()
        {
            Application.targetFrameRate = _frameRate;
        }
    }
}
