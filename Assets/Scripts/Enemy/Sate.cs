using Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sate : Enemy
{
    protected static Animator Anim;
    public static bool ishurt=false;
    public static bool isnormal = true;
    public static float countime;
    public  GameObject floatPoint;
    public ScriptableHero thisHero;
    public TMP_Text nextAction;


    public float attack = 0.02f;
     float healAmount = 0.05f;
    public GameObject Maps;
    public float hideTime;
    public Slider EnemyHPSlider;
    public Slider PlayerHPSlider;






    // Start is called before the first frame update
    new void Start()
    {


/*        floatPoint = GameObject.FindGameObjectWithTag("floatPoint");*/
        PlayerHPSlider = GameObject.FindGameObjectWithTag("playerTimer").GetComponent<Slider>();
        EnemyHPSlider = GameObject.FindGameObjectWithTag("enemyTimer").GetComponent<Slider>();
        Anim = GetComponent<Animator>();
        Maps = GameObject.FindGameObjectWithTag("maps");
         EnemyHPSlider.value= thisHero.EnemyHP ;
    }
   new  private void Awake()
    {
        base.Awake();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (DialogueSystem.dialogueFinished == false)
        {
            thisHero.HP = thisHero.maxHP;
            PlayerHPSlider.value = thisHero.maxHP;
        }
        else
        {
            thisHero.EnemyHP = EnemyHPSlider.value;


            SwitchAnim();





            countime = Time.time;

            SwitchAction(countime % 6);

        }


    }
    public  void SwitchAnim()
    {
        if (ishurt)
        {
            Anim.SetBool("IsAttacked", true);
            ishurt = false;
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
                nextAction.text = "Defend";
                break;
            case 2:
                nextAction.text = "HideMap";
                HideMap();
                break;
            case 3:
                ShowMap();
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
    public  void Attack()
    {
        PlayerHPSlider.value -= attack - attack * thisHero.defend;
    }
    public  void takeDamage(double damage)
    {
  
        GameObject gb= Instantiate(floatPoint,new Vector3(-8,8,0), Quaternion.identity) as GameObject;
        gb.transform.GetComponent<TextMesh>().text = ((int)(damage * 1200)).ToString();
    }
    public void Heal()
    {
        EnemyHPSlider.value += healAmount;
    }
    
    public void HealandDamage()
    {
        PlayerHPSlider.value -= attack/2 - attack * thisHero.defend/2;
        EnemyHPSlider.value += healAmount/2;
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
                Maps.SetActive(false);
            hideTime = 2f;
        }
    }
    public void ShowMap()
    {
        if(!GameManager.IsPause)
        Maps.SetActive(true);
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
