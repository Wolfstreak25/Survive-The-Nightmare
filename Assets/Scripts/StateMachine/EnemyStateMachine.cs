// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;
// public class EnemyStateMachine : StateInterface<EnemyController>
// {
//     protected float timeElapsed = 0f;
//     protected EnemyController enemy;
//     protected NavMeshAgent enemyPlayer;
//     protected Animator Anim;
//     protected Transform Target;
//     protected void ObjectInitialization(EnemyController stateObject)
//     {
//         enemy = stateObject;
//         Anim = enemy.animator;
//     }
//     public virtual void OnEnterState(EnemyController ObjectState)
//     {
//         ObjectInitialization(ObjectState);
//     }
//     public virtual void UpdateState()
//     {}
//     public virtual void OnExitState(EnemyController ObjectState)
//     {}
// }