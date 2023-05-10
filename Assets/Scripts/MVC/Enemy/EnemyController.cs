using UnityEngine;
using UnityEngine.AI;
using System;
public class EnemyController
{
    // MVC Data
    public EnemyModel Model{get; private set;}
    public EnemyView View{get; private set;}
    // DATA from View
    public Rigidbody rb;
    public NavMeshAgent navAI;
    public Animator animator{get;}
    public EnemyState thisState{get;set;}
    public bool isKilled{get;private set;}
    public LayerMask layerMask;
    public Transform Player;
    public bool playerDetected{get; private set;}
    public bool playerInRange{get; private set;}
    public Transform[] PatrolPoints;
    // Independent DATA
    private EnemyStateMachine currentState;
    public StateMachine<EnemyController> stateMachine;
    // Constructor for Initializing
    public EnemyController(EnemyModel _model, EnemyView _view)
    {
        // Set Model
        this.Model = _model;
        // Set view
        View = GameObject.Instantiate<EnemyView>(_view);
        // get rigidbody
        rb = View.GetComponent<Rigidbody>();
        // get NavMeshAgent
        navAI = View.GetComponent<NavMeshAgent>();
        // Set Controllers in Model And View
        this.View.SetController(this);
        this.Model.SetController(this);
        // Set Animator
        animator = View.GetComponent<Animator>();
        // set State machine
        stateMachine = new StateMachine<EnemyController>(this);
        currentState = new EnemyIdleState();
    }
    // Initial Activation of GameObject
    public void  ActivateEnemy(Transform[] spawn)
    {
        isKilled = false;
        PatrolPoints = spawn;
        // Activate View
        View.gameObject.SetActive(true);
        // Change to Spawn Location
        View.transform.position = PatrolPoints[UnityEngine.Random.Range(0,PatrolPoints.Length)].position;
        // Set Health to max
        Model.RestoreHealth();
        // Set CurrentState to Idle State
        
        stateMachine.ChangeState(currentState);

    }
    // Receiving Damage From 
    public void GetDamage(float damage, DamagableType type)
    {
        if(Model.Type == type)
            return;
        Model.Health -= damage;
        if(Model.Health <= 0)
        {
            EventManagement.Instance.EnemyDeath();
            isKilled = true;
            animator.SetTrigger("Dead");
            // Animation Event View.StartSinking Will be Called While Animation Is playing
            // set collider as disabled
            View.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    public bool PlayerDetected()
    {
        Vector3 origin = View.transform.position;
        var inCollid = Physics.OverlapSphere(origin, Model.EngageRadius,layerMask);
        foreach (var coll in inCollid)
        {
            if (coll.gameObject.transform.GetComponent<PlayerView>())
            {
                Player = coll.gameObject.transform;
                playerDetected = true;
                return playerDetected;
            }
        }
        return playerDetected = false;
    }
    public bool PlayerInRange()
    {
        Vector3 origin = View.transform.position;
        var inCollid = Physics.OverlapSphere(origin, Model.AttackRadius,layerMask);
        foreach (var coll in inCollid)
        {
            if (coll.gameObject.transform.GetComponent<PlayerView>())
            {
                playerInRange = true;
                return playerInRange;
            }
        }
        return playerInRange = false;
    }
    public Vector3 RandomPatrol()
    {
        return PatrolPoints[UnityEngine.Random.Range(0,PatrolPoints.Length)].position;
    }

    public void DestroyObj() 
    {
        currentState.ChangeState(EnemyState.DeathState);
    }
}
