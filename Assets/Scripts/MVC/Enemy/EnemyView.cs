using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyView : MonoBehaviour, IDamagable
{
    [SerializeField] private LayerMask playerLayer;
    private EnemyController Controller;
    private RaycastHit hitData;
    private Animator anim;
    private bool playerInRange;
    private float timer;
    private Transform Target;
    public void SetController(EnemyController _enemyController)
    {
        Controller = _enemyController;
        anim = gameObject.GetComponent<Animator>(); 
        Controller.layerMask = playerLayer;
    }
    private void Update() 
    {
        timer += Time.deltaTime;
        Controller.stateMachine.Update();
    }
    public void GetDamage(float damage, DamagableType type)
    {
        Controller.GetDamage(damage,type);
    }
    //Animation Event
    public void StartSinking()
    {
        // set as kinematic rigidbody
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        // Return Object
        Controller.DestroyObj();
    }
    // Editor purpose
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Controller.Model.EngageRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Controller.Model.AttackRadius);
    }
    private void OnTriggerEnter(Collider other) 
    {
        var player = other.gameObject.GetComponent<IDamagable>();
        if(player != null)
        {
            Debug.Log("In range");
        }
    }
    public bool isDead()
    {
        return Controller.isKilled;
    } 
}