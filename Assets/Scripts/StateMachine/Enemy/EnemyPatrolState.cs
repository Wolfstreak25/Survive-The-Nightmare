using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrolState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        Debug.Log("Patrol State");
        Patrol();
    }
    public override void UpdateState() 
    {   
        if(PlayerDetected())
        {
            ChangeState(EnemyState.ChaseState);
        }
    }
    void Patrol()
    {
        Vector3 point;
        if (RandomPoint(enemy.View.transform.position, enemy.Model.PatrolRadius, out point)) //pass in our centre point and radius of area
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
            agent.SetDestination(point);
        }
        if(agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            ChangeState(EnemyState.IdleState);
        }
    }
    private bool PlayerDetected()
    {
        Vector3 origin = enemy.View.transform.position;
        var inCollid = Physics.OverlapSphere(origin, enemy.Model.EngageRadius);
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
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
