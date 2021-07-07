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
    public Inventory myInventory;

    public void PlayGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/game_SaveData/playerData.txt"))
        {
            FileStream file2 = File.Open(Application.persistentDataPath + "/game_SaveData/playerData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file2), thisHero);

            ItemOnSale.coinChanged = true;
            file2.Close();
        }
        if (File.Exists(Application.persistentDataPath + "/game_SaveData/saveData.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveData/saveData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), myInventory);
            file.Close();
        }
        if (!thisHero.starterPassed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (thisHero.starterPassed == true && thisHero.level1Passed == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else if (thisHero.starterPassed == true && thisHero.level1Passed == true&&thisHero.level2Passed==false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
           
        }
        else if (thisHero.starterPassed == true && thisHero.level1Passed == true&&thisHero.level2Passed==true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
           
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

