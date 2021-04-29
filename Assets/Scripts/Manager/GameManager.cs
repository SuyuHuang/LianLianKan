using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static bool IsPause = false;
        public static bool IsOver = false;
        public static bool IsEnemyKilled = false;
        public static bool IsFinished = false;
        public GameObject level2Pass;
        public ScriptableHero thisHero;
        public Slider EnemyHPSlider;
        public GameObject roshanReburnDialogue;
        public AudioSource RoshanDeath;





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
                    if (BattleManager.level == 3 && Roshan.canReburn == true)
                    {
                        Roshan.Dialogueing = true;
                        roshanReburnDialogue.SetActive(true);
                        thisHero.EnemyHP = Roshan.maxHP;
                        EnemyHPSlider.value = Roshan.maxHP;
                        Roshan.canReburn = false;
                        IsEnemyKilled = false;
                        
                    }
                    else if (BattleManager.level==3&&Roshan.canReburn==false)
                    {
                        RoshanDeath.Play();
                        level2Pass.SetActive(true);
                        IsEnemyKilled = false;


                    }
                    else
                    {
                        if (level2pass.dialogueFinished == false)
                        {
                            level2Pass.SetActive(true);
                        }
                        else
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                            BattleManager.level += 1;
                            IsEnemyKilled = false;
                        }
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