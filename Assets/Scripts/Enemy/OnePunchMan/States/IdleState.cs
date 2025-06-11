using UnityEngine;

namespace StatePattern.Enemy
{
    public class IdleState : IState
    {
        //reference to the owner
        public OnePunchManController Owner { get; set; }

        //reference to state machine
        private OnePunchManStateMachine stateMachine;

        private float timer;//this variable is specific to idle state

        public IdleState(OnePunchManStateMachine stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter() => ResetTimer();

        public void Update()
        {
            timer -= Time.deltaTime;
            if(timer<=0)
                stateMachine.ChangeState(OnePunchManStates.ROTATING);
        }

        public void OnStateExit() => timer = 0;

        private void ResetTimer() => timer = Owner.Data.IdleTime;
    }
}