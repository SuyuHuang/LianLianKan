using System.Collections;
using System.Collections.Generic;
using Scripts;
using Scripts.Base;
using UnityEngine;
using UnityEngine.UI;

public class JudgeLink : Judge
{
    
    public Camera GameCamera;


    public static GameObject G1, G2;
   
    public Text[] Count;
 
    public int X1, X2, Y1, Y2, Value1, Value2;

  
    public bool Select = false;
    public int herocount;

    public int LinkType;

/*    BaseHero hero = new BaseHero();*/
    public Vector3 Z1, Z2;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            IsSelect();
        }
    }
    void Start()
    {
 
    }
    public void IsSelect()
    {
        Ray ray = GameCamera.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit = new RaycastHit(); 
        if (Physics.Raycast(ray, out hit))
        {
            if (Select == false)
            {
                G1 = hit.transform.gameObject; 
                G1.GetComponent<SpriteRenderer>().color = new Color(0.38f, 0.4f, 0.39f); 
                X1 = G1.GetComponent<Hero>().X; 
                Y1 = G1.GetComponent<Hero>().Y;
                Value1 = G1.GetComponent<Hero>().Value;
                Select = true;
            }
            else
            {
                G2 = hit.transform.gameObject;
                G1.GetComponent<SpriteRenderer>().color = Color.white;
                X2 = G2.GetComponent<Hero>().X; 
                Y2 = G2.GetComponent<Hero>().Y;
                Value2 = G2.GetComponent<Hero>().Value;
                Select = false;
                IsSame();
            }
        }
    }

    public void IsSame()
    {
       
        if ((Value1 == Value2) && (G1.transform.position != G2.transform.position))
        {
            if (IsLink(X1, Y1, X2, Y2))
            {
               
                MapManager.CountCollect[Value1]++;
                updateNumber(Value1, MapManager.CountCollect[Value1]);
                ToolManager.InitTool(ToolType.TimePlus);
                /*  hero.damage();*/
                Sate.ishurt = true;
                MapManager.value = Value1;
                MapManager.isactive = true;
                BaseHero.value = Value1;
                BaseHero.iscorrect = true;
                
            }
            else
            {
                ToolManager.InitTool(ToolType.TimeDecrease);
            }
            Debug.Log("The Same Value");
        }
     
        else
        {
            ToolManager.InitTool(ToolType.TimeDecrease);
            X1 = X2 = Y1 = Y2 = Value1 = Value2 = 0;
        }
    }
    public void updateNumber(int value,int count)
    {
        if(0<=value&&value<=4)
        Count[value].text = count.ToString();
    }
    public bool IsLink(int x1, int y1, int x2, int y2)
    {
     
        if (x1 == x2)
        {
            if (Y_Link(x1, y1, y2))
            {
                LinkType = 0;
                StartCoroutine(Destory(x1, y1, x2, y2));
                return true;
            }
        }
        else if (y1 == y2)
        {
            if (X_Link(x1, x2, y1))
            {
                LinkType = 0;
                StartCoroutine(Destory(x1, y1, x2, y2));
                return true;
            }
        }

     
        if (OneCornerLink(x1, y1, x2, y2, out Z1))
        {
            LinkType = 1;
            StartCoroutine(Destory(x1, y1, x2, y2));
            return true;
        }

        
        if (TwoCornerLink(x1, y1, x2, y2, out Z1, out Z2))
        {
            LinkType = 2;
            StartCoroutine(Destory(x1, y1, x2, y2));
            return true;
        }

        return false;
    }

   
    private IEnumerator Destory(int x1, int y1, int x2, int y2)
    {

        DrawLine.Instance.DrawLinkLine(G1, G2, LinkType, Z1, Z2);
        yield return new WaitForSeconds(0.2f);

        Destroy(G1);
        Destroy(G2);
        MapManager.TestMap[x1, y1] = -1; 
        MapManager.TestMap[x2, y2] = -1;
        JudgeManager.Instance.CheckMap(x1, y1, x2, y2);
        x1 = x2 = y1 = y2 = Value1 = Value2 = 0;
    }

  


}