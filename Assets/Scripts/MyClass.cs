using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass : ScriptableObject
{
    public static int[,] TestMap;
    public int time = 2;
    static MyClass instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        TestMap = MapManager.TestMap;
        
    }
    public void recover()
    {
        MapManager.TestMap = TestMap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
