using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static bool IsPause = false;
        public static bool IsOver = false;
        public static bool IsEnemyKilled = false;
        public static bool IsFinished = false;
        public GameObject level2Pass;
        
      


        /// <summary>
        /// 如果没时间。就让游戏结束
        /// </summary>
        private void Update()
        {
            if (BattleManager.level != 0)
            {
                if (IsOver)
                {
                    Debug.Log("GameOver");
                    /*if (IsOver)*/
                    UIManager.Instance.ShowOverPanel();
                }
                if (IsEnemyKilled)
                {
                    if (level2pass.dialogueFinished == false)
                    {
                        level2Pass.SetActive(true);
                    }
                    else {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        BattleManager.level += 1;
                        IsEnemyKilled = false;
                    } 
                }
            }
            else
            {

             
                Debug.Log(JudgeLink.level0count);
                if (JudgeLink.level0count == 8)
                {
                    IsFinished = true;
                    
                }
            }
        }
    }
}