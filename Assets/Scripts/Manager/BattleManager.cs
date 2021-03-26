using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static int level = 1;
    public  Slider EnemyHPSlider;
    public  Slider PlayerHPSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (level == 1)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<BaseHero>().Level1Battle(PlayerHPSlider,EnemyHPSlider);
        }
    }
}
