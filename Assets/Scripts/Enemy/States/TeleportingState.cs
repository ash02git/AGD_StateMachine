using StatePattern.StateMachine;
using UnityEngine;
using UnityEngine.AI;


namespace StatePattern.Enemy
{
    public class TeleportingState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public TeleportingState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            // Teleport the enemy to a random position.
            TeleportToRandomPosition();

            // Transition to the CHASING state after teleporting.
            stateMachine.ChangeState(States.CHASING);
        }

        public void Update() { }

        public void OnStateExit() { }

        private void TeleportToRandomPosition() => Owner.Agent.Warp(GetRandomNavMeshPoint());

        private Vector3 GetRandomNavMeshPoint()
        {
            // Calculate a random direction within the teleporting radius.
            Vector3 randomDirection = Random.insideUnitSphere * 5f + Owner.Position;
            NavMeshHit hit;

            // Try to find a valid NavMesh position within the radius, return spawn position if not found.
            if (NavMesh.SamplePosition(randomDirection, out hit, 5f, NavMesh.AllAreas))
                return hit.position;

            return Owner.Data.SpawnPosition;
        }
    }
}