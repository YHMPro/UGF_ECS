
using UnityEngine;
namespace UGF_ECS
{
    /// <summary>
    /// 游戏世界
    /// </summary>
    public sealed class GameWorld : MonoBehaviour
    {
        /// <summary>
        /// 游戏世界实例
        /// </summary>
        public static GameWorld Instance { get; private set; }
        /// <summary>
        /// 游戏世界根节点
        /// </summary>
        public Transform GameWorldRoot { get; private set; }


        public static GameWorld Create()
        {
            GameObject gameWorld = new GameObject("[GameWorld]");
            Instance = gameWorld.AddComponent<GameWorld>();
            Instance.InitRoot();
            Instance.InitSystem();
            return Instance;
        }
        
        /// <summary>
        /// 初始化节点
        /// </summary>
        private void InitRoot()
        {

        }
        /// <summary>
        /// 初始化系统
        /// </summary>
        private void InitSystem()
        {

        }

        private void Update()
        {
            
        }

       

    }
}
