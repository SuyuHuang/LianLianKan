using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHero : MonoBehaviour
{
    // Start is called before the first frame update
    public  Slider EnemyHPSlider;
    public Slider PlayerHPSlider;
    public  static float attack=0.02f;
    public float healamount=0.005f;
    public static bool iscorrect = false;
    public static bool darkpersist = false;
    public static int value;
    public float defend;
    public int coin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
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
    public void Luna()
    {
        darkpersist = true;
    }
    public  void Clinkz()
    {
        if (Enemy.immutablecount > 0)
        {
            Enemy.immutablecount -= 1;
        }
        else
        {
            EnemyHPSlider.value -= attack;
        }
    }
    public void BaseDamage()
    {
        if (Enemy.immutablecount > 0)
        {
            Enemy.immutablecount -= 1;
        }
        else
        {
            EnemyHPSlider.value -= attack;
        }
    }
    public void Knight()
    {
      
        PlayerHPSlider.value += healamount;

    }
    public void Hoodwink()
    {

        float Randomcount = Random.Range(0, 100);
        Debug.Log(Randomcount);
        if (Randomcount > 50)
        {
            
            EnemyHPSlider.value -= attack *2;
        }
        else
        {

        }

    }
    public void Pagna()
    {
        if (Enemy.immutablecount > 0)
        {
            Enemy.immutablecount -= 1;
        }
        else
        {
            EnemyHPSlider.value -= attack / 2;
        }
        PlayerHPSlider.value += healamount/2;


    }

}
