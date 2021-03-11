using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float HP;

    public static int immutablecount = 0;
   protected void Start()
    {
        
    }
    protected void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
   protected void Defend()
    {
        immutablecount = 1;
    }
    
}
