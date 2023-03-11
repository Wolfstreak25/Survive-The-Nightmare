// using UnityEngine;
// using UnityEngine.AI;
// public class EnemyPatrolState : EnemyStateMachine
// {
//     public override void OnEnterState(EnemyController stateObject)
//     {
//         //base.OnEnterState(stateObject);
//         ObjectInitialization(stateObject);
//         Patrol();
//     }
//     public override void UpdateState() 
//     {   
//         if(PlayerDetected())
//         {
//             enemy.stateMachine.ChangeState(new EnemyChaseState());
//         }
//     }
//     void Patrol()
//     {
//     }
//     private bool PlayerDetected()
//     {
//         Vector3 origin = enemy.View.transform.position;
//         var inCollid = Physics.OverlapSphere(origin, enemy.Model.EngageRadius);
//         foreach (var collissions in inCollid)
//         {
//             if( collissions.GetComponent<PlayerView>())
//             {
//                 Target = collissions.gameObject.transform;
//                 return true;
//             }
//         }
//         return false;
//     }
// }
