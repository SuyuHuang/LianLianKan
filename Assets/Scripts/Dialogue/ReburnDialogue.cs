using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ReburnDialogue : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textLabel;
    public Text nameLabel;
    public Image faceImage;
    public ScriptableHero thisHero;



    [Header("File")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("Image")]
    public Sprite face01, face02;






    bool textFinished;
    bool cancelTyping;
    bool levelpassed;
    public static bool dialogueFinished = false;
    List<string> textList = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.IsPause = true;
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
        /*   if(!thisHero.level1Passed)*/
        /* TransferToNextScene();*/

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space) && index == textList.Count)
        {
            GameManager.IsPause = false;
            Roshan.Dialogueing = false;
            gameObject.SetActive(false);
            index = 0;
            dialogueFinished = true;
            return;
        }
        /*if (Input.GetKeyDown(KeyCode.R)&&textFinished)
        {
            StartCoroutine(SetTextUI());
       *//*     textLabel.text = textList[index];
            index++;*//*
        }*/
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space))
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
    void TransferToNextScene()
    {
        if (thisHero.level1Passed == false)
        {
            if (dialogueFinished)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                dialogueFinished = false;
            }
        }

    }
    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";
     
       
        
            switch (textList[index])
            {
                case "PLAYER\r":
                    nameLabel.text = "Player";
                    faceImage.sprite = face01;
                    index++;
                    break;
                case "Roshan\r":
                    nameLabel.text = "Roshan";
                    faceImage.sprite = face02;
                    index++;
                    break;




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
        index++;




    }
}

