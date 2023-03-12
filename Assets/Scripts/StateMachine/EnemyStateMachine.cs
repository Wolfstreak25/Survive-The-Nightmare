using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
public class EnemyStateMachine : StateInterface<EnemyController>
{
    protected float timeElapsed = 0f;
    protected EnemyController enemy;
    protected NavMeshAgent agent;
    protected Animator Anim;
    protected Transform Target;
    private EnemyStateMachine currentState;
    private StateMachine<EnemyController> stateMachine;
    private void Start() 
    {
        stateMachine = new StateMachine<EnemyController>(enemy);
    }
    
    protected void ObjectInitialization(EnemyController stateObject)
    {
        enemy = stateObject;
        Anim = enemy.animator;
        stateMachine = enemy.stateMachine;
    }
    public override void OnEnterState(EnemyController ObjectState)
    {
        ObjectInitialization(ObjectState);
    }
    public  override void OnExitState(EnemyController ObjectState)
    {
        GenericPool<EnemyStateMachine>.Release(currentState);
    }
    public void ChangeState(EnemyState newState)
    {
        Debug.Log("Change State");
        switch(newState)
        {
            case EnemyState.IdleState:
                currentState = GenericPool<EnemyIdleState>.Get();
                break;
            case EnemyState.PatrolState:
                currentState = GenericPool<EnemyPatrolState>.Get();
                break;
            case EnemyState.ChaseState:
                currentState = GenericPool<EnemyChaseState>.Get();
                break;
            case EnemyState.AttackState:
                currentState = GenericPool<EnemyAttackState>.Get();
                break;
            case EnemyState.DeathState:
                currentState = GenericPool<EnemyDeathState>.Get();
                break;
        }
        stateMachine.ChangeState(currentState);
    }
}