using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Scripts.Base;

using Scripts;
using UnityEngine;
using Scripts.Tools;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    public static int RowNum = 10;

    public static int ColumNum = 10;
    public static float xdis=1.5f;
    public static float ydis;

    public static int[,] TempMap;
    public GameObject[] nodeList;
    public Image[] PanelList;
    public Animator[] animatorList;
    public Sprite[] SpriteList;
    public static int[,] TestMap;
    public static Dictionary<int, LinkedList<HeroNode>> MapCollect = new Dictionary<int, LinkedList<HeroNode>>();
    public static Dictionary<int, int> CountCollect = new Dictionary<int, int>();


    public  Hero[] HeroPrefabs;
   
  

    public static float XMove = 1f;

   
    public static float YMove = 0.7f;

    public GameObject Maps;
    public static int value;
    public static bool isactive = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance!=this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
       
            InitAllMap();
            InitTools();
        
       
      
    }
    public void FixedUpdate()
    {
        activePicture();
    }
    private void InitTools()
    {
        TimeDecreaseTool.Instance.OnRelease();
        TimePlusTool.Instance.OnRelease();
    }
    private void InitAllMap()
    {
        TestMap = new int[ColumNum + 2, RowNum + 2];
        TempMap = new int[ColumNum, RowNum];
        for (int i = 0; i < RowNum; i++)
        {
            for (int 
                j = 0; j < ColumNum; j = j + 2)
            {
               
                int temp = Random.Range(0, HeroPrefabs.Length);
                TempMap[j, i] = temp;
                TempMap[j + 1, i] = temp;
            }
        }

        ChangeMap();
        CreateMapLink();
        updateImage();
        JudgeManager.Instance.CheckMap(-1, -1, -1, -1);
        DrawLine.Instance.CreatLine();



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
    private void AddItemToLinklist(int x, int y, int value)
    {
        if (MapCollect.ContainsKey(value))
        {
            HeroNode heroNode = new HeroNode(x, y);
            MapCollect[value].AddLast(heroNode);
            
        }
        else
        {
            HeroNode heroNode = new HeroNode(x, y);
            LinkedList<HeroNode> tempHeroNodes = new LinkedList<HeroNode>();
            tempHeroNodes.AddLast(heroNode);
            MapCollect.Add(value, tempHeroNodes);
            CountCollect.Add(value, 0);
           
        }
    }
    public void CreateMapLink()
    {
        for (int i = 1; i < RowNum + 1; i++)
        {
            for (int j = 1; j < ColumNum + 1; j++)
            {
                AddItemToLinklist(j, i, TestMap[j, i]);
            }
        }
    }

    public void updateImage()
    {
        for (int i = 0; i < HeroPrefabs.Length-1; i++) {
          
            animatorList[i] = nodeList[i].GetComponentInChildren<Animator>();

        }
    }

    public void activePicture()
    {
        if (isactive)
        {
            if (0 <= value && value <= 4)
            {
                animatorList[value].SetBool("isActive", true);
                isactive = false;
            }

        }
        else
        {
            animatorList[value].SetBool("isActive", false);
        }
    }


    public void BuildMap()
    {
        GameObject g;
        for (int y = 1; y < RowNum + 1; y++) 
        {
            for (int x = 1; x < ColumNum + 1; x++)
            {
                g = Instantiate(HeroPrefabs[TestMap[x, y]], new Vector3(x * XMove+xdis, -y * YMove+ydis, 0),
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
