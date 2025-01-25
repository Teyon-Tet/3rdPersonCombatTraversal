using UnityEngine;

namespace Scripts.StateMachine.Player
{
    public class PlayerTestState : PlayerBaseState
    {

        private float timer = 0f;
        
        public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.InputReader.JumpEvent += OnJump;
        }

        public override void Tick(float deltaTime)
        {
            stateMachine.InputReader.JumpEvent -= Enter;
            
            timer += deltaTime;
            Debug.Log(timer);
            
        }

        public override void Exit()
        {
            stateMachine.InputReader.JumpEvent -= OnJump;
        }

        private void OnJump()
        {
            stateMachine.SwitchState(new PlayerTestState(stateMachine));
        }
    }
}