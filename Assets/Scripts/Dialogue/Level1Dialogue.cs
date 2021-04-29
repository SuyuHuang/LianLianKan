
using Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1Dialogue : MonoBehaviour
{
    [Header("UI")]

    public TMP_Text textLabel;
    public Text nameLabel;
    public Image faceImage;
    public GameObject Maps;
    public GameObject slider;
    public ScriptableHero thisHero;


    [Header("File")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("Image")]
    public Sprite face01, face02;
    public Camera camera1;


    bool textFinished;
    bool cancelTyping;
    public static bool dialogueFinished = false;
    List<string> textList = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        BattleManager.level = 0;
        GetTextFromFile(textFile);
        Maps.SetActive(false);

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
        TransferToNextScene();
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        /*if (Input.GetKeyDown(KeyCode.R)&&textFinished)
        {
            StartCoroutine(SetTextUI());
       *//*     textLabel.text = textList[index];
            index++;*//*
        }*/
        if (Input.GetKeyDown(KeyCode.R)||Input.GetKeyDown(KeyCode.Space))
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
        if (dialogueFinished)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            dialogueFinished = false;
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
            case "SHOPPER\r":
                nameLabel.text = "Shopper";
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
        if (index == 31)
        {
            Maps.SetActive(true);
        }
        if (index == 33)
        {
            slider.SetActive(true);
        }
        /*      for (int i = 0; i < textL
         *      ist[index].Length ; i++)
              {
                  textLabel.text += textList[index][i];
                  yield return new WaitForSeconds(textSpeed);
              }*/



        textFinished = true;
        if (index == 7 || index == 21)
        {
            camera1.GetComponent<ShakeCamera>().enabled = true;

        }
        if (index != 55)
        {
            index++;
        }
        else
        {
            if (GameManager.IsFinished)
            {
                index++;
            }
        }
        if (index == textList.Count)
        {
            thisHero.starterPassed = true;
            dialogueFinished = true;
            BattleManager.level = 1;
        }
    }
}
