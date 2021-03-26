using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHero : MonoBehaviour
{
    // Start is called before the first frame update
    public   Slider EnemyHPSlider;
    public  Slider PlayerHPSlider;
    public  static float attack=0.02f;
    public static float healamount=0.005f;
    public static bool iscorrect = false;
    public static bool darkpersist = false;
    public static int value;
    public static float defend;
    public int coin;
   
   

    void Start()
    {
        
        PlayerHPSlider = GameObject.FindGameObjectWithTag("playerTimer").GetComponent<Slider>();
        EnemyHPSlider = GameObject.FindGameObjectWithTag("enemyTimer").GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
     
       
    }

    public  void Level1Battle(Slider PlayerHPSlider1, Slider EnemyHPSlider1)
    {
        PlayerHPSlider = PlayerHPSlider1;
        EnemyHPSlider = EnemyHPSlider1;
        if (iscorrect)
        {
            BaseDamage();


            switch (value)
            {
                case 1:
                    Clinkz();
                    break;
                case 2:
                    Hoodwink();
                    break;
                case 3:
                    Knight();
                    break;
                case 4:
                    Luna();
                    break;
                case 5:
                    Pagna();
                    break;

            }
        }
        iscorrect = false;
    }
    public  void Luna()
    {
        darkpersist = true;
        causeDamage(attack );
    }
    public   void Clinkz()
    {
        if (Enemy.immutablecount > 0)
        {
            Enemy.immutablecount -= 1;
        }
        else
        {
            causeDamage(attack*2);
        }
    }
    public  void BaseDamage()
    {
        if (Enemy.immutablecount > 0)
        {
            Enemy.immutablecount -= 1;
        }
        else
        {
            EnemyHPSlider.value -= attack;
           
        }
        if (EnemyHPSlider.value <= 0)
        {
           
            GameManager.IsEnemyKilled = true;
        }
    }
    public  void Knight()
    {
      
        PlayerHPSlider.value += healamount;
        causeDamage(attack);

    }
    public  void Hoodwink()
    {

        float Randomcount = Random.Range(0, 100);
        if (Randomcount > 50)
        {
            
            
            causeDamage(attack * 2);
        }
        else
        {

        }

    }
    public void causeDamage(float damage)
    {
        EnemyHPSlider.value -= damage;
 
        Dragon dragon = new Dragon();
        if (BattleManager.level == 1)
        {
            GameObject.FindGameObjectWithTag("enemy").GetComponent<Sate>().takeDamage(damage);
        }
        else if (BattleManager.level == 2)
        {
            dragon.takeDamage(damage);
        }

    }
  
    public  void Pagna()
    {
        if (Enemy.immutablecount > 0)
        {
            Enemy.immutablecount -= 1;
        }
        else
        {
            causeDamage(attack*3/2);
           
        }
        PlayerHPSlider.value += healamount/2;


    }

}
