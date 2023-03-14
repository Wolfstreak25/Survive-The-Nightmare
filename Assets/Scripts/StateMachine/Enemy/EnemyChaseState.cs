using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        enemy.thisState = EnemyState.ChaseState;
        Chase();
    }
    public override void UpdateState() 
    { 
        if(agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
           base.ChangeState(EnemyState.AttackState);
        }
    }
    void Chase()
    {
        Anim.SetTrigger("PlayerDetected");
        agent.SetDestination(enemy.Player.position);
    }
}