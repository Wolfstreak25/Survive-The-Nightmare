using UnityEngine.AI;
using UnityEngine;
public class EnemyAttackState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        Debug.Log("Attack State");
        timeElapsed = 0;
    }
    
    public override void UpdateState() 
    {
        if(PlayerInRange())
            {
                //attack player
                timeElapsed += Time.deltaTime;
                base.UpdateState();
                if(timeElapsed >= 1)
                {
                    Attack(Target);
                }
            }
        ChangeState(EnemyState.ChaseState);
    }
    void Attack(Transform target)
    {
        timeElapsed = 0;
        Target.GetComponent<IDamagable>().GetDamage(enemy.Model.damage, DamagableType.Enemy);
    }
    private bool PlayerInRange()
    {
        Vector3 origin = enemy.View.transform.position;
        var inCollid = Physics.OverlapSphere(origin, enemy.Model.AttackRadius); // layermask needed for precision
        foreach (var collissions in inCollid)
        {
            if( collissions.GetComponent<PlayerView>())
            {
                Target = collissions.gameObject.transform;
                return true;
            }
        }
        return false;
    }
}
