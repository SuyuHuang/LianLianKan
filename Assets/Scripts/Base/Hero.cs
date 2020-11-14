using System;
using UnityEngine;

namespace Scripts.Base
{
    /// <summary>
    /// 水果身份标识(挂载游戏物体身上)
    /// </summary>
    public class Hero : MonoBehaviour
    {
        /// <summary>
        /// X位置
        /// </summary>
        public int X;

        /// <summary>
        /// Y位置
        /// </summary>
        public int Y;

        /// <summary>
        /// 指定牌面
        /// </summary>
        public int Value;
    }
}