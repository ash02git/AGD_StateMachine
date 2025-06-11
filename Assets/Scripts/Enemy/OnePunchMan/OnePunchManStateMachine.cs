using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine
    {
        //Reference to the owner of the state machine
        private OnePunchManController Owner;

        //A dictionary to store the different states mapped to an enum value for the states
        protected Dictionary<OnePunchManStates, IState> States = new Dictionary<OnePunchManStates, IState>();

        //reference to current state
        private IState currentState;

        //Constructor
        public OnePunchManStateMachine(OnePunchManController Owner)
        {
            this.Owner = Owner;
            CreateStates();//function to create instances of each state.
            SetOwner();//function to set the owner for each state
        }

        private void CreateStates()
        {
            States.Add(OnePunchManStates.IDLE, new IdleState(this));
            States.Add(OnePunchManStates.ROTATING, new RotatingState(this));
            States.Add(OnePunchManStates.SHOOTING,new ShootingState(this));
        }

        private void SetOwner()
        {
            foreach(IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }

        //call to update current state if it exists
        public void Update() => currentState?.Update();

        //code to transition from state
        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();//exit current state
            currentState = newState;//set newState as the current state
            currentState?.OnStateEnter();//enter the new current state
        }

        //this will act as the public function available to the codebase to change the state which receives the new state as an enum
        public void ChangeState(OnePunchManStates newState) => ChangeState(States[newState]);
    }
}