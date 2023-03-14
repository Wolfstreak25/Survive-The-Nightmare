using UnityEngine.AI;
using UnityEngine;
public class EnemyIdleState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        enemy.thisState = EnemyState.IdleState;
        timeElapsed = 0f;
    }
    public override void UpdateState()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1)
        {
            base.ChangeState(EnemyState.PatrolState);
        }
    }
}
