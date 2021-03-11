using Scripts.Base;
using Scripts.Tools;
using UnityEngine;

namespace Scripts
{
    public class ToolManager : MonoBehaviour
    {
        /// <summary>
        /// 根据传来的参数来让道具进行响应
        /// </summary>
        /// <param name="toolType"></param>
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