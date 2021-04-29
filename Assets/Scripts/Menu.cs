using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioMixer audioMixer;
    public ScriptableHero thisHero;

        public void PlayGame()
    {
        if (!thisHero.starterPassed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (thisHero.starterPassed == true && thisHero.level1Passed == false)
        {
            BinaryFormatter bf = new BinaryFormatter();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            if (File.Exists(Application.persistentDataPath + "/game_SaveData/playerData.txt"))
            {
                FileStream file2 = File.Open(Application.persistentDataPath + "/game_SaveData/playerData.txt", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file2), thisHero);
                ItemOnSale.coinChanged = true;
                file2.Close();
            }
        }
        else if (thisHero.starterPassed == true && thisHero.level1Passed == true&&thisHero.level2Passed==false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            BinaryFormatter bf = new BinaryFormatter();
        
            if (File.Exists(Application.persistentDataPath + "/game_SaveData/playerData.txt"))
            {
                FileStream file2 = File.Open(Application.persistentDataPath + "/game_SaveData/playerData.txt", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file2), thisHero);
                ItemOnSale.coinChanged = true;
                file2.Close();
            }
        }
        else if (thisHero.starterPassed == true && thisHero.level1Passed == true&&thisHero.level2Passed==true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
            BinaryFormatter bf = new BinaryFormatter();
           
            if (File.Exists(Application.persistentDataPath + "/game_SaveData/playerData.txt"))
            {
                FileStream file2 = File.Open(Application.persistentDataPath + "/game_SaveData/playerData.txt", FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file2), thisHero);
                ItemOnSale.coinChanged = true;
                file2.Close();
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void UIEnable()
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SetVolumn(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    }
}

