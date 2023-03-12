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
    private NavMeshAgent navAI;
    public Animator animator{get;}
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
    public void  ActivateEnemy(Transform spawn)
    {
        Debug.Log("Activating enemy State call");
        // Activate View
        View.gameObject.SetActive(true);
        // Change to Spawn Location
        View.transform.position = spawn.position;
        // Set Health to max
        Model.RestoreHealth();
        // Set CurrentState to Idle State
        
        stateMachine.ChangeState(currentState);
        Debug.Log("After Change State call");
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
            animator.SetTrigger("Dead");
            // Animation Event View.StartSinking Will be Called While Animation Is playing
        }
    }
    public void DestroyObj() 
    {
        currentState.ChangeState(EnemyState.DeathState);
    }
}
