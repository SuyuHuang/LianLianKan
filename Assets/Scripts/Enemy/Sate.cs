using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sate : Enemy
{
    protected static Animator Anim;
    public static bool ishurt=false;
    public static bool isnormal = true;
    public static float countime;
    public  GameObject floatPoint;
 

    public float attack = 0.02f;
    public float healAmount = 0.02f;
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
    }
   new  private void Awake()
    {
        base.Awake();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
     
     
            SwitchAnim();
       




        countime = Time.time;

        SwitchAction(countime % 6);
     

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
              
                break;
            case 1:
                /*Defend();*/
                break;
            case 2:
                HideMap();
                break;
            case 3:
                ShowMap();
                break;
            case 4:
                Heal();
                break;
            case 5:
                HealandDamage();
                break;

            

        }
    }
    public  void Attack()
    {
        PlayerHPSlider.value -= attack;
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
    public void Defend()
    {
        base.Defend();
    }
    public void HealandDamage()
    {
        PlayerHPSlider.value -= attack/2;
        EnemyHPSlider.value += healAmount/2;
    }
    public void HideMap()
    {
        if (BaseHero.darkpersist)
        {
            BaseHero.darkpersist = false;
        }
        else
        {
            Maps.SetActive(false);
            hideTime = 2f;
        }
    }
    public void ShowMap()
    {
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
