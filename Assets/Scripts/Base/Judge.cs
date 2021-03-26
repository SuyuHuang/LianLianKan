using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Base
{

    public class Judge : MonoBehaviour
    {
     

        public bool X_Link(int x1, int x2, int y2)
        {
           
            if (x1 > x2)
            {
                int n = x1;
                x1 = x2;
                x2 = n;
            }

            
            for (int i = x1 + 1; i <= x2; i++)
            {
                if (i == x2)
                {
                    return true;
                }
                if (BattleManager.level != 0)
                {

                    if (MapManager.TestMap[i, y2] != -1)
                    {
                        break;
                    }
                }
                else
                {
                    if (DialogueMap.TestMap[i, y2] != -1)
                    {
                        break;
                    }
                }
            }

            return false;
        }

    
        public bool Y_Link(int x1, int y1, int y2)
        {
            if (y1 > y2)
            {
                int n = y1;
                y1 = y2;
                y2 = n;
            }

            for (int i = y1 + 1; i <= y2; i++)
            {
                if (i == y2)
                {
                    return true;
                }
                if (BattleManager.level != 0)
                {
                    if (MapManager.TestMap[x1, i] != -1)
                    {
                        break;
                    }
                }
                else
                {
                    if (DialogueMap.TestMap[x1, i] != -1)
                    {
                        break;
                    }
                }
            }

            return false;
        }

    
        public bool OneCornerLink(int x1, int y1, int x2, int y2, out Vector3 Z1)
        {
            if (BattleManager.level != 0) { 

            if (MapManager.TestMap[x1, y2] == -1)
            {
                if (X_Link(x1, x2, y2) && Y_Link(x1, y1, y2))
                {
                    Z1 = new Vector3(x1 * MapManager.XMove, -y2 * MapManager.YMove, 0);
                    return true;
                }
            }

            if (MapManager.TestMap[x2, y1] == -1)
            {
                if (X_Link(x1, x2, y1) && Y_Link(x2, y1, y2))
                {
                    Z1 = new Vector3(x2 * MapManager.XMove, -y1 * MapManager.YMove, 0);
                    return true;
                }
            }
            }
            else
            {

                if (DialogueMap.TestMap[x1, y2] == -1)
                {
                    if (X_Link(x1, x2, y2) && Y_Link(x1, y1, y2))
                    {
                        Z1 = new Vector3(x1 * DialogueMap.XMove, -y2 * DialogueMap.YMove, 0);
                        return true;
                    }
                }

                if (DialogueMap.TestMap[x2, y1] == -1)
                {
                    if (X_Link(x1, x2, y1) && Y_Link(x2, y1, y2))
                    {
                        Z1 = new Vector3(x2 * DialogueMap.XMove, -y1 * DialogueMap.YMove, 0);
                        return true;
                    }
                }
            }


            Z1 = new Vector3(0, 0, 0);
            return false;
        }

      
        public bool TwoCornerLink(int x1, int y1, int x2, int y2, out Vector3 Z1, out Vector3 Z2)
        {
            if (BattleManager.level != 0)
            {
                for (int i = x1 + 1; i < MapManager.ColumNum + 2; i++)
                {
                    if (MapManager.TestMap[i, y1] == -1)
                    {
                        if (OneCornerLink(i, y1, x2, y2, out Z1))
                        {
                            Z2 = new Vector3(i * MapManager.XMove, -y1 * MapManager.YMove, 0);
                            return true;
                        }
                    }

                    if (MapManager.TestMap[i, y1] != -1)
                    {
                        break;
                    }
                }


                for (int i = x1 - 1; i > -1; i--)
                {
                    if (MapManager.TestMap[i, y1] == -1)
                    {
                        if (OneCornerLink(i, y1, x2, y2, out Z1))
                        {
                            Z2 = new Vector3(i * MapManager.XMove, -y1 * MapManager.YMove, 0);
                            return true;
                        }
                    }

                    if (MapManager.TestMap[i, y1] != -1)
                    {
                        break;
                    }
                }


                for (int i = y1 + 1; i < MapManager.RowNum + 2; i++)
                {
                    if (MapManager.TestMap[x1, i] == -1)
                    {
                        if (OneCornerLink(x1, i, x2, y2, out Z1))
                        {
                            Z2 = new Vector3(x1 * MapManager.XMove, -i * MapManager.YMove, 0);
                            return true;
                        }
                    }

                    if (MapManager.TestMap[x1, i] != -1)
                    {
                        break;
                    }
                }


                for (int i = y1 - 1; i > -1; i--)
                {
                    if (MapManager.TestMap[x1, i] == -1)
                    {
                        if (OneCornerLink(x1, i, x2, y2, out Z1))
                        {
                            Z2 = new Vector3(x1 * MapManager.XMove, -i * MapManager.YMove, 0);
                            return true;
                        }
                    }

                    if (MapManager.TestMap[x1, i] != -1)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = x1 + 1; i < DialogueMap.ColumNum + 2; i++)
                {
                    if (DialogueMap.TestMap[i, y1] == -1)
                    {
                        if (OneCornerLink(i, y1, x2, y2, out Z1))
                        {
                            Z2 = new Vector3(i * DialogueMap.XMove, -y1 * DialogueMap.YMove, 0);
                            return true;
                        }
                    }

                    if (DialogueMap.TestMap[i, y1] != -1)
                    {
                        break;
                    }
                }


                for (int i = x1 - 1; i > -1; i--)
                {
                    if (DialogueMap.TestMap[i, y1] == -1)
                    {
                        if (OneCornerLink(i, y1, x2, y2, out Z1))
                        {
                            Z2 = new Vector3(i * DialogueMap.XMove, -y1 * DialogueMap.YMove, 0);
                            return true;
                        }
                    }

                    if (DialogueMap.TestMap[i, y1] != -1)
                    {
                        break;
                    }
                }


                for (int i = y1 + 1; i < DialogueMap.RowNum + 2; i++)
                {
                    if (DialogueMap.TestMap[x1, i] == -1)
                    {
                        if (OneCornerLink(x1, i, x2, y2, out Z1))
                        {
                            Z2 = new Vector3(x1 * DialogueMap.XMove, -i * DialogueMap.YMove, 0);
                            return true;
                        }
                    }

                    if (DialogueMap.TestMap[x1, i] != -1)
                    {
                        break;
                    }
                }


                for (int i = y1 - 1; i > -1; i--)
                {
                    if (DialogueMap.TestMap[x1, i] == -1)
                    {
                        if (OneCornerLink(x1, i, x2, y2, out Z1))
                        {
                            Z2 = new Vector3(x1 * DialogueMap.XMove, -i * DialogueMap.YMove, 0);
                            return true;
                        }
                    }

                    if (DialogueMap.TestMap[x1, i] != -1)
                    {
                        break;
                    }
                }
            }

            Z1 = new Vector3(0, 0, 0);
            Z2 = new Vector3(0, 0, 0);
            return false;
        }
    }
}
