using UnityEngine;

namespace Scripts.StateMachine.Player
{
    public class PlayerFreeLookState : PlayerBaseState
    {
        private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed") ;
        
        public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            Vector3 movement = CalculateMovement();

            stateMachine.Controller.Move(movement * stateMachine.FreeLookMovementSpeed * deltaTime);

            if (stateMachine.InputReader.MovementValue == Vector2.zero)
            {
                stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, 0.1f, deltaTime);
                return;
            }
            
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, 0.1f, deltaTime);
            stateMachine.transform.rotation = Quaternion.LookRotation(movement);

        }

        public override void Exit()
        {

        }

        private Vector3 CalculateMovement()
        {
            Vector3 forward = stateMachine.MainCameraTransform.forward;
            Vector3 right = stateMachine.MainCameraTransform.right;

            forward.y = 0f;
            right.y = 0f;
            
            forward.Normalize();
            right.Normalize();
            
            return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;
        }

    }
}