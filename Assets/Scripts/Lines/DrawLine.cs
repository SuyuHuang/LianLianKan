using System.Collections;
using System.Collections.Generic;
using Scripts;
using Scripts.Base;
using UnityEngine;

public class DrawLine : SingleTemplate<DrawLine>
{
    
    public Animator eliminated;

    
    LineRenderer _line1, _line2, _line3;


  
    public void CreatLine()
    {
     
        GameObject line = new GameObject("line1");
        _line1 = line.AddComponent<LineRenderer>();
        SetLineWidthAndvertex(2, 0.1f, 0.1f, _line1);

        line = new GameObject("line2");
        _line2 = line.AddComponent<LineRenderer>();
        SetLineWidthAndvertex(2, 0.1f, 0.1f, _line2);

        line = new GameObject("line3");
        _line3 = line.AddComponent<LineRenderer>();
        SetLineWidthAndvertex(2, 0.1f, 0.1f, _line3);
        _line1.SetPosition(0, Vector3.zero);
        _line1.SetPosition(1, Vector3.zero);

        _line2.SetPosition(0, Vector3.zero);
        _line2.SetPosition(1, Vector3.zero);

        _line3.SetPosition(0, Vector3.zero);
        _line3.SetPosition(1, Vector3.zero);
    }


    public void DrawLinkLine(GameObject g1, GameObject g2, int linkType, Vector3 z1, Vector3 z2)
    {
    
        if (BattleManager.level != 0)
        {
           
            z1 = z1 + new Vector3(MapManager.xdis, MapManager.ydis, 0);
            z2 = z2 + new Vector3(MapManager.xdis, MapManager.ydis, 0);
        }
        else
        {
            z1 = z1 + new Vector3(DialogueMap.xdis, DialogueMap.ydis, 0);
            z2 = z2 + new Vector3(DialogueMap.xdis, DialogueMap.ydis, 0);
        }
        eliminated.SetBool("Eliminate",true);
        switch (linkType)
        {
            case 0:
                _line1.SetPosition(0, g1.transform.position + new Vector3(0, 0, -0.01f));
                _line1.SetPosition(1, g2.transform.position + new Vector3(0, 0, -0.01f));
                break;
            case 1:
                _line1.SetPosition(0, g1.transform.position);
                _line1.SetPosition(1, z1);

                _line2.SetPosition(0, z1);
                _line2.SetPosition(1, g2.transform.position);
                break;
            case 2:
                _line1.SetPosition(0, g1.transform.position);
                _line1.SetPosition(1, z2);

                _line2.SetPosition(0, z2);
                _line2.SetPosition(1, z1);

                _line3.SetPosition(0, z1);
                _line3.SetPosition(1, g2.transform.position);
                break;
        }

        StartCoroutine(DestoryLine());
    }

    private IEnumerator DestoryLine()
    {
        yield return new WaitForSeconds(0.2f);
     /*   CreatTool();*/
        _line1.SetPosition(0, Vector3.zero);
        _line1.SetPosition(1, Vector3.zero);

        _line2.SetPosition(0, Vector3.zero);
        _line2.SetPosition(1, Vector3.zero);

        _line3.SetPosition(0, Vector3.zero);
        _line3.SetPosition(1, Vector3.zero);
    }

   
    private void SetLineWidthAndvertex(int vertex, float start, float end, LineRenderer lineRenderer)
    {
        lineRenderer.positionCount = vertex;
        lineRenderer.startWidth = start;
        lineRenderer.endWidth = end;
    }
}