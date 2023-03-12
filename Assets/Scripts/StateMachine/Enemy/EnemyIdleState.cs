using UnityEngine.AI;
using UnityEngine;
public class EnemyIdleState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        Debug.Log("Idle State");
        base.OnEnterState(stateObject);
        timeElapsed = 0f;
    }
    public override void UpdateState()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 1)
        {
            ChangeState(EnemyState.PatrolState);
        }
    }
}
