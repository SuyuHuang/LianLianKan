using Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level2pass : MonoBehaviour
{
    public ScriptableHero thisHero;
    [Header("UI")]
    public TMP_Text textLabel;
    public Text nameLabel;
    public Image faceImage;
    public Camera camera1;



    [Header("File")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("Image")]
    public Sprite face01, face02;



    bool textFinished;
    bool cancelTyping;
    public static bool dialogueFinished ;
    List<string> textList = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        
        GetTextFromFile(textFile);


    }
    private void OnEnable()
    {
       
        textFinished = true;
        StartCoroutine(SetTextUI());
        /*    textLabel.text = textList[index];
            index++;*/
    }

    // Update is called once per frame
    void Update()
    {
        
       /* TransferToNextScene();*/
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            dialogueFinished = true;
            if (thisHero.level1Passed == true)
            {
                thisHero.level2Passed = true;
            }
            thisHero.level1Passed = true;
            thisHero.EnemyHP = 1.5f;
            thisHero.HP = thisHero.maxHP;
         

            BattleManager.level += 1;
            GameManager.IsEnemyKilled = false;
            dialogueFinished = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        /*if (Input.GetKeyDown(KeyCode.R)&&textFinished)
        {
            StartCoroutine(SetTextUI());
       *//*     textLabel.text = textList[index];
            index++;*//*
        }*/
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }

            else if (!textFinished)
            {
                cancelTyping = !cancelTyping;
            }
        }
    }
    void toNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
        }

    }

  /*  void TransferToNextScene()
    {
        if (dialogueFinished)
        {
            dialogueFinished = false;
            GameManager.IsEnemyKilled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            BattleManager.level += 1;
           
        }
    }*/
    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        if (thisHero.level1Passed == false)
        {
            switch (textList[index])
            {
                case "PLAYER\r":
                    nameLabel.text = "Player";
                    faceImage.sprite = face01;
                    index++;
                    break;
                case "Sate\r":
                    nameLabel.text = "Sate";
                    faceImage.sprite = face02;
                    index++;
                    break;




            }
        }
        else
        {
            switch (textList[index])
            {
                case "PLAYER\r":
                    nameLabel.text = "Player";
                    faceImage.sprite = face01;
                    index++;
                    break;
                case "Dragon\r":
                    nameLabel.text = "Dragon";
                    faceImage.sprite = face02;
                    index++;
                    break;




            }
        }
        int letter = 0;
        while (!cancelTyping && letter < textList[index].Length - 1)
        {


            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);

        }
        textLabel.text = textList[index];
        cancelTyping = false;

        /*      for (int i = 0; i < textL
         *      ist[index].Length ; i++)
              {
                  textLabel.text += textList[index][i];
                  yield return new WaitForSeconds(textSpeed);
              }*/



        textFinished = true;
        if (index == 9 || index == 17)
        {
            camera1.GetComponent<ShakeCamera>().enabled = true;

        }
       
       
    
      
        index++;
       



    }
}

