using UnityEngine;

namespace Scripts.StateMachine
{
    public abstract class StateMachine : MonoBehaviour
    {
        private State currentState;
    
        public void SwitchState(State newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }
        
        private void Update()
        {
            currentState?.Tick(Time.deltaTime);    
        }
    }
}