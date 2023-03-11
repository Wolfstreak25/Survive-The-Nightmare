using UnityEngine;
using UnityEngine.AI;
using System;
public class EnemyController
{
    public EnemyModel Model{get; private set;}
    public EnemyView View{get; private set;}
    public Rigidbody rb;
    private NavMeshAgent navAI;
    private StateInterface<EnemyController> currentState;
    public Animator animator{get;private set;}
    private bool isDead = false;
    private bool isSinking = false;
    public EnemyController(EnemyModel _model, EnemyView _view)
    {
        this.Model = _model;
        View = GameObject.Instantiate<EnemyView>(_view);
        rb = View.GetComponent<Rigidbody>();
        navAI = View.GetComponent<NavMeshAgent>();
        this.View.SetController(this);
        this.Model.SetController(this);
        animator = View.GetComponent<Animator>();
    }
    public void GetDamage(float damage, DamagableType type)
    {
        if(Model.Type == type)
            return;
        Model.Health -= damage;
        if(Model.Health <= 0)
        {
            EventManagement.Instance.EnemyDeath();
            DestroyObj();
        }
    }
    private void DestroyObj() 
    {
        View.gameObject.SetActive(false);
        EnemyPool.Instance.ReturnItem(this);
    }
    public void  ActivateEnemy(Transform spawn)
    {
        View.gameObject.SetActive(true);
        View.transform.position = spawn.position;
        Model.RestoreHealth();
    }
    public void Attack(Transform target) 
    {
        target.gameObject.GetComponent<PlayerView>().GetDamage(Model.damage, Model.Type);
    }
    public void Chase(Transform target) 
    {
        animator.SetTrigger ("PlayerDetected");
        navAI.SetDestination(target.position);
    }
    
    
}
