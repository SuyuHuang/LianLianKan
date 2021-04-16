using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static int level = 1;
    public  Slider EnemyHPSlider;
    public  Slider PlayerHPSlider;
    public ScriptableHero thisHero;
    // Start is called before the first frame update
    void Start()
    {
        if (thisHero.level1Passed == true)
        {
            level = 2;
            
        }
        if (thisHero.level2Passed == true)
        {
            level = 3;
        }


    }

    // Update is called once per frame
    void Update()
    {
       
        if (level != 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<BaseHero>().Level1Battle(PlayerHPSlider,EnemyHPSlider);
        }
    }
}
