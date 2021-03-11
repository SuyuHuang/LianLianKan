using UnityEngine;

namespace Scripts.Base
{
    public enum ToolType
    {
        TimePlus,
        TimeDecrease,
    }

    /// <summary>
    /// 道具接口
    /// </summary>
    public interface ToolBase
    {
        /// <summary>
        /// 当被初始化
        /// </summary>
        void OnInit();

        /// <summary>
        /// 当被释放
        /// </summary>
        void OnRelease();
    }
}