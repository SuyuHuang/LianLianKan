﻿using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : Enemy
{
    protected static Animator Anim;
    public static bool isHurt = false;
    public static bool isnormal = true;
    public static float countime;
    public GameObject floatPoint;
    public ScriptableHero thisHero;
    public TMP_Text nextAction;
    public AudioSource dragonFire;
    public AudioSource dragonRoar;
    public float currentTime = 2f;
    public Camera mainCanera;
    public float maxHP = 1.5f;
   
    // 弹幕计时
    private float invokeTime;


    public float attack = 0.03f;
    float healAmount = 0.05f;

    public float hideTime;
    public Slider EnemyHPSlider;
    public Slider PlayerHPSlider;
    public static bool Dialogueing;








    // Start is called before the first frame update
    new void Start()
    {
        
        invokeTime = currentTime;

        /*        floatPoint = GameObject.FindGameObjectWithTag("floatPoint");*/
        PlayerHPSlider = GameObject.FindGameObjectWithTag("playerTimer").GetComponent<Slider>();
        EnemyHPSlider = GameObject.FindGameObjectWithTag("enemyTimer").GetComponent<Slider>();
        Anim = GetComponent<Animator>();

        EnemyHPSlider.value = thisHero.EnemyHP;
    }
    new private void Awake()
    {
        DialogueSystem.dialogueFinished = false;


        EnemyHPSlider.maxValue = maxHP;
        EnemyHPSlider.value = thisHero.EnemyHP;
 
        PlayerHPSlider.value = thisHero.HP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Dialogueing)
        {
            attack = 0;
        }
        else
        {
            attack = 0.03f;
        }
        thisHero.EnemyHP = EnemyHPSlider.value;
        if (DialogueSystem.dialogueFinished == false)
        {
           
        }
        else
        {
            if (!GameManager.IsOver)
            {

                SwitchAnim();





                countime = Time.time;

                SwitchAction(countime % 6);
            }
        }





    }
    public void SwitchAnim()
    {
        if (isHurt)
        {
            Anim.SetBool("IsAttacked", true);
            isHurt = false;
        }
        else
        {
            Anim.SetBool("IsAttacked", false);
        }
    }
    public void SwitchAction(float changedtime)
    {
        switch (changedtime)
        {
            case 0:
                Attack();
                nextAction.text = "Attack";


                break;
            case 1:
                /*Defend();*/
                Anim.SetBool("Attack", false);
                nextAction.text = "Defend";
                break;
            case 2:
                Fire();
                nextAction.text = "Fire";
                break;
            case 3:
                Anim.SetBool("Fire", false);
                break;
            case 4:
               
                nextAction.text = "Heal";
                Heal();
                break;
            case 5:
                nextAction.text = "Heal and Damage";
                HealandDamage();
                break;



        }
    }

    private void Fire()
    {
        StartCoroutine(ChangeColor());
        StartCoroutine(TakeDamage(0.5f, 4));
        invokeTime += Time.deltaTime;

        dragonRoar.Play();
        dragonFire.Play();
        Anim.SetBool("Fire", true);
    }

    IEnumerator ChangeColor()
    {
        mainCanera.backgroundColor = Color.red;
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(2f);
        mainCanera.backgroundColor = Color.black;

    }

    IEnumerator TakeDamage(float timeOff, int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(timeOff);
            PlayerHPSlider.value -= attack / 2 - attack * thisHero.defend/2;
        }
    }



        public void Attack()
    {
        Anim.SetBool("Attack", true);
        PlayerHPSlider.value -= attack - attack * thisHero.defend;
    }
    public void takeDamage(double damage)
    {

        GameObject gb = Instantiate(floatPoint, new Vector3(-8, 8, 0), Quaternion.identity) as GameObject;
        gb.transform.GetComponent<TextMesh>().text = ((int)(damage * 1200)).ToString();
    }
    public void Heal()
    {
        EnemyHPSlider.value += healAmount;
    }

    public void HealandDamage()
    {
        PlayerHPSlider.value -= attack / 2;
        EnemyHPSlider.value += healAmount / 2;
    }
    public void HideMap()
    {
        if (thisHero.darkpersist)
        {
            thisHero.darkpersist = false;
        }
        else
        {
            if (!GameManager.IsPause)
         
            hideTime = 2f;
        }
    }
    public void ShowMap()
    {
        if (!GameManager.IsPause)
 
        hideTime = 2f;

    }

    public void backtoNormal()
    {
        Anim.SetBool("IsAttacked", false);
    }
    public void saySomething()
    {
        Debug.Log("something");
    }
}
