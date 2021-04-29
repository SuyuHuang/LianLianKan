using Scripts.Base;
using Scripts.Tools;
using UnityEngine;

namespace Scripts
{
    public class ToolManager : MonoBehaviour
    {
       
        public static void InitTool(ToolType toolType)
        {
            switch (toolType)
            {
                case ToolType.TimePlus:
                    {
                        TimePlusTool.Instance.OnInit();
                        break;
                    }
                case ToolType.TimeDecrease:
                    {
                        TimeDecreaseTool.Instance.OnInit();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}