using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrolState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        enemy.thisState = EnemyState.PatrolState;
        Patrol();
    }
    public override void UpdateState() 
    {
        if(enemy.PlayerDetected())
        {
            base.ChangeState(EnemyState.ChaseState);
            // enemy.stateMachine.ChangeState(new EnemyChaseState());
        }
        else if(agent.remainingDistance <= agent.stoppingDistance)
        {
            base.ChangeState(EnemyState.IdleState);
        }
    }
    void Patrol()
    {
        agent.SetDestination(enemy.RandomPatrol());
    }
}
