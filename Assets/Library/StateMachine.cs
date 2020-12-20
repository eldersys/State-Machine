namespace Library
{
    /// <summary>
    /// State Machine class
    /// </summary>
    public class StateMachine
    {
        /// <summary> The current state </summary>
        IState m_currentState;
        
        /// <summary>
        /// Handle the change of state
        /// </summary>
        /// <param name="newState"> Pass in the new state IState to change</param>
        public void ChangeState(IState newState)
        {
            m_currentState?.Exit();

            m_currentState = newState;
            m_currentState.Enter();
        }
        
        /// <summary> Update of the state's execution method </summary>
        public void Update()
        {
            m_currentState?.Execute();
        }
    }
}
