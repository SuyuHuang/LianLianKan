using UnityEngine;

namespace Scripts.Base
{
    public enum ToolType
    {
        TimePlus,
        TimeDecrease,
    }

  
    public interface ToolBase
    {
      
        void OnInit();

     
        void OnRelease();
    }
}