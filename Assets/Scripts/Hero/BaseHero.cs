using Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseHero : MonoBehaviour
{
    // Start is called before the first frame update
    public   Slider EnemyHPSlider;
    public  Slider PlayerHPSlider;
    public static bool iscorrect = false;
    public static bool maxHPChanged;
    public static float maxHPChangedNumber;
    public static bool updateHP;
    public static bool canCriticalStrike;
    public static bool criticalStrike;
    public static bool canLifeSteal;
    public static bool monkeyKingBarEquipped;
    public static float lifestealRate;

    bool isOpen;
    public GameObject myBag;
    public AudioSource CoinAudio;
    public TMP_Text CoinCount;
    public ScriptableHero thisHero;
    public static int value;



    void Start()
    {
        PlayerHPSlider.value= thisHero.HP ;

        PlayerHPSlider = GameObject.FindGameObjectWithTag("playerTimer").GetComponent<Slider>();
        EnemyHPSlider = GameObject.FindGameObjectWithTag("enemyTimer").GetComponent<Slider>();
        CoinCount.text = thisHero.coinnumber + "";
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (updateHP == false)
        {
            thisHero.HP = PlayerHPSlider.value;
        }
        else
        {
            if (thisHero.HP < PlayerHPSlider.maxValue)
            {
                PlayerHPSlider.value = thisHero.HP;
                updateHP = false;
            }
            else
            {
                thisHero.HP = PlayerHPSlider.maxValue;
                PlayerHPSlider.value = PlayerHPSlider.maxValue;
                updateHP = false;
            }
        }
        OpenMyBag();
        UpdateCoinNumber();
        ImproveMaxHP();

    }


   
   

    public  void UpdateCoinNumber()
    {
        if (ItemOnSale.coinChanged == true)
        {
            CoinCount.SetText(thisHero.coinnumber + "");
            ItemOnSale.coinChanged = false;

        }
    }
    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            myBag.SetActive(!myBag.activeSelf);
            InventoryManager.RefreshItem();
        }
    }

    public  void Level1Battle(Slider PlayerHPSlider1, Slider EnemyHPSlider1)
    {
        PlayerHPSlider = PlayerHPSlider1;
        EnemyHPSlider = EnemyHPSlider1;
        if (iscorrect)
        {
            if (canCriticalStrike)
            {
                int number = (int)Random.Range(0, 100);
                if (0 < number &&number< 30)
                {
                    thisHero.attack = thisHero.attack * 2.5f;
                    criticalStrike = true;
                }
            }
            BaseDamage();
            GetCoin();
       

            switch (value)
            {
                case 0:
                    Clinkz();
                    break;
                case 1:
                    Hoodwink();
                    break;
                case 2:
                    Knight();
                    break;
                case 3:
                    Luna();
                    break;
                case 4:
                    Pagna();
                    break;

            }
        }
        iscorrect = false;
        if (criticalStrike)
        {
            thisHero.attack = thisHero.attack / 2.5f;
            criticalStrike = false;
        }
    }
    public  void Luna()
    {
        thisHero.darkpersist = true;
        causeDamage(thisHero.attack );
    }

    public  void GetCoin()
    {
     
        if (value == 5)
        {
            int number = (int)Random.Range(77, 91);
            thisHero.coinnumber += number;
            CoinAudio.Play();

        }
        else
        {
            int number = (int)Random.Range(34, 39);
            thisHero.coinnumber += number;
        }
        CoinCount.SetText(thisHero.coinnumber +"");
    }

  
    public   void Clinkz()
    {
        if (Enemy.immutablecount > 0)
        {
            Enemy.immutablecount -= 1;
        }
        else
        {
            causeDamage(thisHero.attack *1.35f);
        }
    }
    public void ImproveMaxHP()
    {
       float changedNumber = maxHPChangedNumber;
        if (maxHPChanged)
        {
            PlayerHPSlider.maxValue += PlayerHPSlider.maxValue*changedNumber;
            thisHero.maxHP = PlayerHPSlider.maxValue;
            PlayerHPSlider.value += PlayerHPSlider.value*changedNumber;
            maxHPChanged = false;
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
            EnemyHPSlider.value -= thisHero.attack;
           
        }
        if (EnemyHPSlider.value <= 0)
        {
           
            GameManager.IsEnemyKilled = true;
        }
        if (canLifeSteal == true)
        {
            PlayerHPSlider.value += thisHero.attack * lifestealRate;
        }
        if (monkeyKingBarEquipped)
        {
            causeDamage(0.024f);
        }
    }
    public  void Knight()
    {
      
        PlayerHPSlider.value += thisHero.healamount;
        causeDamage(thisHero.attack);

    }
    public  void Hoodwink()
    {

        float Randomcount = Random.Range(0, 100);
        if (Randomcount > 50)
        {
            
            
            causeDamage(thisHero.attack * 2);
       
        }
        else
        {

        }

    }
    public void causeDamage(float damage)
    {
        if (canLifeSteal == true)
        {
            PlayerHPSlider.value += damage * lifestealRate;
        }
        EnemyHPSlider.value -= damage;
 
   
        if (BattleManager.level == 1)
        {
            GameObject.FindGameObjectWithTag("enemy").GetComponent<Sate>().takeDamage(damage);
        }
        else if (BattleManager.level == 2)
        {
            GameObject.FindGameObjectWithTag("enemy").GetComponent<Dragon>().takeDamage(damage);
        }
        else if (BattleManager.level == 3)
        {
            GameObject.FindGameObjectWithTag("enemy").GetComponent<Roshan>().takeDamage(damage);
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
            causeDamage(thisHero.attack *3/2);
           
        }
        PlayerHPSlider.value += thisHero.healamount /2;


    }

}
