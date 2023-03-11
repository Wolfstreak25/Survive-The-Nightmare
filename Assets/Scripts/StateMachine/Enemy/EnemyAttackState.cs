// using UnityEngine.AI;
// using UnityEngine;
// public class EnemyAttackState : EnemyStateMachine
// {
//     public override void OnEnterState(EnemyController stateObject)
//     {
//         base.OnEnterState(stateObject);
//         ObjectInitialization(stateObject);
//     }
    
//     public override void UpdateState() 
//     {
//         //attack player
//         timeElapsed += Time.deltaTime;
//         base.UpdateState();
//         if(timeElapsed >= 1)
//         {
//             Attack(Target);
//         }
//     }
//     void Attack(Transform target)
//     {
//         timeElapsed = 0;
//         Target.GetComponent<IDamagable>().GetDamage(enemy.Model.damage, DamagableType.Enemy);
//     }
// }
