using Scripts.Base;
using UnityEngine;

namespace Scripts.Tools
{
    /// <summary>
    /// 增加时间的道具
    /// </summary>
    public class TimePlusTool : SingleTemplate<TimePlusTool>, ToolBase
    {
        public void OnInit()
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Timer.Instance.SliderValue += 0.1f;
            Invoke("OnRelease", 0.8f);
        }

        public void OnRelease()
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}