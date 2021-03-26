using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : Enemy
{
    protected static Animator Anim;
    public static bool isHurt = false;
    public static bool isNormal = true;
    public static float countime;
   
    public float attack = 0.02f;
    public float healAmount = 0.02f;
    public static Transform transform;

    public float hideTime;
    public Slider EnemyHPSlider;
    public Slider PlayerHPSlider;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        PlayerHPSlider = GameObject.FindGameObjectWithTag("playerTimer").GetComponent<Slider>();
        EnemyHPSlider = GameObject.FindGameObjectWithTag("enemyTimer").GetComponent<Slider>();
        Anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }
    new private void Awake()
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
    public void SwitchAnim()
    {
        if (isHurt)
        {
            Anim.SetBool("Hurt", true);
            isHurt = false;
        }
        else
        {
            Anim.SetBool("Hurt", false);
        }
      
    }
    public  void takeDamage(double damage)
    {
     /*   Instantiate(floatPoint, transform.position, Quaternion.identity);*/
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
                Anim.SetBool("Attack", false);
                break;
            case 2:
                Fire();
                break;
            case 3:
                Anim.SetBool("Fire", false);
                break;
            case 4:
                Heal();
                break;
            case 5:
                HealandDamage();
                break;



        }
    }
    public void Attack()
    {
        PlayerHPSlider.value -= attack;
        Anim.SetBool("Attack", true);
       
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
        PlayerHPSlider.value -= attack / 2;
        EnemyHPSlider.value += healAmount / 2;
    }
    public void Fire()
    {
        Anim.SetBool("Fire", true);
        TakeDamage(1, 5);

    }
    IEnumerator TakeDamage(float timeOff, int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(timeOff);
            PlayerHPSlider.value -= attack/3;
        }
    }

    public void ShowMap()
    {
    
        hideTime = 2f;

    }
    void backtoNormal()
    {
        Anim.SetBool("IsAttacked", false);
    }
}
