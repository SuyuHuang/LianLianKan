using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Scripts.Base;

using Scripts;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static int RowNum = 6;

    public static int ColumNum = 6;

    public static int[,] TempMap;


    public static int[,] TestMap;



  
    public Hero[] HeroPrefabs;

    public static float XMove = 3f;

   
    public static float YMove = 3f;

    public GameObject Maps;



    private void Awake()
    {
        InitAllMap();
      
    }


    private void InitAllMap()
    {
        TestMap = new int[ColumNum + 2, RowNum + 2];
        TempMap = new int[ColumNum, RowNum];
        for (int i = 0; i < RowNum; i++)
        {
            for (int j = 0; j < ColumNum; j = j + 2)
            {
               
                int temp = Random.Range(0, HeroPrefabs.Length);
                TempMap[j, i] = temp;
                TempMap[j + 1, i] = temp;
            }
        }

        ChangeMap();
        
      
     
    }

   
    public void ChangeMap()
    {
        for (int i = 0; i < RowNum; i++)
        {
            for (int j = 0; j < ColumNum; j++)
            {
               
                int temp = TempMap[j, i];
                int randomRow = Random.Range(0, RowNum);
                int randomColum = Random.Range(0, ColumNum);
                TempMap[j, i] = TempMap[randomColum, randomRow];
                TempMap[randomColum, randomRow] = temp;
            }
        }

        
        for (int i = 0; i < RowNum + 2; i++)
        {
            for (int j = 0; j < ColumNum + 2; j++)
            {
                if (i == 0 || j == 0 || i == RowNum + 1 || j == ColumNum + 1)
                {
                    TestMap[j, i] = -1;
                }
                else
                {
                    TestMap[j, i] = TempMap[j - 1, i - 1];
                }
            }
        }

        BuildMap();
    }

   

   
    public void BuildMap()
    {
        GameObject g;
        for (int y = 1; y < RowNum + 1; y++) 
        {
            for (int x = 1; x < ColumNum + 1; x++)
            {
                g = Instantiate(HeroPrefabs[TestMap[x, y]], new Vector3(x * XMove, -y * YMove, 0),
                        Quaternion.identity)
                    .gameObject;
                g.GetComponent<Hero>().X = x; 
                g.GetComponent<Hero>().Y = y;
                g.GetComponent<Hero>().Value = TestMap[x, y];
                g.transform.SetParent(Maps.transform);
            }
        }
    }
}