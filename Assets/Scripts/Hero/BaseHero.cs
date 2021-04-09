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
        thisHero.HP = PlayerHPSlider.value;
        OpenMyBag();
        UpdateCoinNumber();


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
            causeDamage(thisHero.attack *2);
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
            causeDamage(thisHero.attack *3/2);
           
        }
        PlayerHPSlider.value += thisHero.healamount /2;


    }

}
