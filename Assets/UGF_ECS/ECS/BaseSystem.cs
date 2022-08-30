namespace UGF_ECS
{
    /// <summary>
    /// 系统基类
    /// </summary>
    public abstract class BaseSystem
    {
        /// <summary>
        /// 游戏世界
        /// </summary>
        protected GameWorld gameWorld;
        /// <summary>
        /// 游戏世界
        /// </summary>
        public abstract GameWorld GWorld { get; protected set; }
        /// <summary>
        /// 是否释放
        /// </summary>
        public bool IsDispose { get; private set; }
        /// <summary>
        /// 是否启动
        /// </summary>
        public bool IsLanch { get; private set; }
        
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="gameWorld">游戏世界实例</param>
        /// <param name="isLanch">释放立即启动</param>
        public abstract void Init(GameWorld gameWorld,bool isLanuch = true);
        /// <summary>
        /// 启动
        /// </summary>
        public abstract void Lanuch();
        /// <summary>
        /// 更新
        /// </summary>
        public abstract void Update();       
        /// <summary>
        /// 停止
        /// </summary>
        public abstract void Stop();
        /// <summary>
        /// 释放
        /// </summary>
        public abstract void Dispose();
    }
}
