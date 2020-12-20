namespace Library
{
    public interface IState
    {
        /// <summary>
        /// Called once at the beginning of the state
        /// </summary>
        void Enter();
        
        /// <summary>
        /// Called each frame
        /// </summary>
        void Execute();
        
        /// <summary>
        /// Called at the end of the state
        /// </summary>
        void Exit();
    }
}
