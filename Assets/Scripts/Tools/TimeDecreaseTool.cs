using Scripts.Base;
using UnityEngine;

namespace Scripts.Tools
{

    public class TimeDecreaseTool : SingleTemplate<TimeDecreaseTool>, ToolBase
    {
        public void OnInit()
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Timer.Instance.SliderValue -= 0.03f;
            Invoke("OnRelease", 0.8f);
        }

        public void OnRelease()
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}