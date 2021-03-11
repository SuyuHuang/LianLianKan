using UnityEngine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static bool IsPause = false;
        public static bool IsOver = false;


        /// <summary>
        /// 如果没时间。就让游戏结束
        /// </summary>
        private void Update()
        {
            if (IsOver)
            {
                Debug.Log("GameOver");
                /*if (IsOver)*/
                UIManager.Instance.ShowOverPanel();
            }
        }
    }
}