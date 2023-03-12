using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        Chase();
    }
    public override void UpdateState() 
    { 
        if(agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            ChangeState(EnemyState.AttackState);
        }
    }
    void Chase()
    {
        Anim.SetTrigger("PlayerDetected");
        agent.stoppingDistance = 1; // Controller.Model.AttackDistance - 1;
        agent.SetDestination(Target.position);
    }
}

