using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using Scripts.Base;

public class GameSaveManager : MonoBehaviour
{

    public ScriptableHero thisHero;
    public GameObject enemy;
    public Inventory myInventory;
    /*    public GameObject maps;
        public Slider heroSlider;
        public Slider enemySlider;*/

    void Start()
    {
        
    }
    public void SaveGame (){
   
        Debug.Log(Application.persistentDataPath);
        if (!Directory.Exists(Application.persistentDataPath + "/game_SaveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveData");

        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/game_SaveData/saveData.txt");

       
        var json = JsonUtility.ToJson(myInventory);
        formatter.Serialize(file, json);
     
        file.Close();

        BinaryFormatter formatter2 = new BinaryFormatter();
        FileStream file2 = File.Create(Application.persistentDataPath + "/game_SaveData/playerData.txt");


        var json2 = JsonUtility.ToJson(thisHero);
        formatter2.Serialize(file2, json2);

        file2.Close();

    }

    public void LoadGame()
    {

        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/game_SaveData/saveData.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveData/saveData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), myInventory);
            file.Close();
        }
        if (File.Exists(Application.persistentDataPath + "/game_SaveData/playerData.txt"))
        {
            FileStream file2 = File.Open(Application.persistentDataPath + "/game_SaveData/playerData.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file2), thisHero);
            ItemOnSale.coinChanged = true;
            file2.Close();
        }

    }
    // Start is called before the first frame update
   
}
