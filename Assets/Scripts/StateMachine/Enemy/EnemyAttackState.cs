using UnityEngine.AI;
using UnityEngine;
public class EnemyAttackState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        enemy.thisState = EnemyState.AttackState;
        timeElapsed = 0;
    }
    
    public override void UpdateState() 
    {
        if(enemy.PlayerInRange())
            {
                //attack player
                timeElapsed += Time.deltaTime;
                base.UpdateState();
                if(timeElapsed >= enemy.Model.AttackDelay)
                {
                    Attack(enemy.Player);
                }
            }
        else
        {
             base.ChangeState(EnemyState.ChaseState);
        }
        
    }
    void Attack(Transform target)
    {
        if(!target.GetComponent<IDamagable>().isDead())
        {
            timeElapsed = 0;
            target.GetComponent<IDamagable>().GetDamage(enemy.Model.damage, DamagableType.Enemy);
        }
        else
        {
            base.ChangeState(EnemyState.IdleState);
        }
    }
}
