using StatePattern.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrolManStateMachine : GenericStateMachine<PatrolManController>
    {
        //private PatrolManController Owner;
        //private IState currentState;
        //protected Dictionary<States, IState> States = new Dictionary<States, IState>();

        public PatrolManStateMachine(PatrolManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            States.Add(StateMachine.States.IDLE, new IdleState<PatrolManController>(this));
            States.Add(StateMachine.States.PATROLLING, new PatrollingState<PatrolManController>(this));
            States.Add(StateMachine.States.CHASING, new ChasingState<PatrolManController>(this));
            States.Add(StateMachine.States.SHOOTING, new ShootingState<PatrolManController>(this));
        }

        //private void SetOwner()
        //{
        //    foreach (IState state in States.Values)
        //    {
        //        state.Owner = Owner;
        //    }
        //}

        //public void Update() => currentState?.Update();

        //protected void ChangeState(IState newState)
        //{
        //    currentState?.OnStateExit();
        //    currentState = newState;
        //    currentState?.OnStateEnter();
        //}

        //public void ChangeState(States newState) => ChangeState(States[newState]);
    }
}