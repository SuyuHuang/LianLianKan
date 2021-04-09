using System.Collections.Generic;
using Scripts.Base;
using UnityEngine;

namespace Scripts
{
    public class JudgeManager : Judge
    {
        private static JudgeManager _judgeManager;
       

        public static JudgeManager Instance
        {
            get
            {
                if (_judgeManager == null)
                {
                    _judgeManager = FindObjectOfType<JudgeManager>();
                }

                return _judgeManager;
            }
        }

        public bool IsLink(int x1, int y1, int x2, int y2)
        {
           Vector3 Z1 = new Vector3(0, 0, 0);
           Vector3 Z2 = new Vector3(0, 0, 0);
         
            if (x1 == x2)
            {
                if (Y_Link(x1, y1, y2))
                {
                    return true;
                }
            }
            else if (y1 == y2) 
            {
                if (X_Link(x1, x2, y1))
                {
                    return true;
                }
            }

        
            if (OneCornerLink(x1, y1, x2, y2,out Z1))
            {
                return true;
            }

       
            if (TwoCornerLink(x1, y1, x2, y2,out Z1,out Z2))
            {
                return true;
            }

            return false;
        }

    
        public void ChangeLinkMap(int x, int y)
        {
            if (x == -1 && y == -1) return;
            foreach (int value in MapManager.MapCollect.Keys)
            {
                LinkedListNode<HeroNode> tempNode = MapManager.MapCollect[value].First;
                while (tempNode != null)
                {
                    if ((tempNode.Value.X == x && tempNode.Value.Y == y))
                    {
                        MapManager.MapCollect[value].Remove(tempNode);
                        return;
                    }
                    else
                    {
                        tempNode = tempNode.Next;
                    }
                }
            }
         
        }
        public bool CheckMap(int x1, int y1, int x2, int y2)
        {
            ChangeLinkMap(x1, y1);
            ChangeLinkMap(x2, y2);
            foreach (int value in MapManager.MapCollect.Keys)
            {
               
                LinkedListNode<HeroNode> tempNode = MapManager.MapCollect[value].First;
                while (tempNode != null)
                {
                    LinkedListNode<HeroNode> tempNodeNext = tempNode.Next;
                    while (tempNodeNext != null)
                    {
                        if (IsLink(tempNode.Value.X, tempNode.Value.Y, tempNodeNext.Value.X, tempNodeNext.Value.Y))
                        {
                           
                            /*Debug.Log("Game continues");*/
                            return false;
                        }

                        tempNodeNext = tempNodeNext.Next;
                    }

                    tempNode = tempNode.Next;
                }
            }
            
          /*  GameManager.IsOver = true;*/
            return true;
        }
    }


}
