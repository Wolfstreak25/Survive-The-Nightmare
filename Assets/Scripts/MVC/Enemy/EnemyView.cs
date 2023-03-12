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
    }
    private void Update() 
    {
        timer += Time.deltaTime;
        // if(PlayerDetected())
        // {
        //     if(!playerInRange)
        //     {
        //         Controller.Chase(Target);
        //     }
        //     if(timer >= Controller.Model.AttackDelay && playerInRange && Controller.Model.Health > 0)
        //     {
        //         timer = 0f;
        //         Controller.Attack(Target);
        //     }
        // }
        

        // if(Controller.Model.Health <= 0)
        // {
        //     anim.SetTrigger ("PlayerDead");
        // }
    }
    // private bool PlayerDetected()
    // {
        
    //         Vector3 origin = transform.position;
    //         var inCollid = Physics.OverlapSphere(origin, Controller.Model.EngageRadius, playerLayer);
    //         foreach (var collissions in inCollid)
    //         {
    //             if( collissions.GetComponent<PlayerView>())
    //             {
    //                 Target = collissions.gameObject.transform;
    //                 return true;
    //             }
    //         }
    //         return false;
    // }
    // private void OnCollisionEnter(Collision other) 
    // {
    //     var player = other.gameObject.GetComponent<PlayerView>();
    //     if(player)
    //     {
    //         playerInRange = true;
    //     }
    // }
    // private void OnCollisionExit(Collision other) 
    // {
    //     if(other.gameObject.GetComponent<PlayerView>())
    //     {
    //         playerInRange = false;
    //     }
    // }
    public void GetDamage(float damage, DamagableType type)
    {
        Controller.GetDamage(damage,type);
    }
    //Animation Event
    public void StartSinking()
    {
        // set as kinematic rigidbody
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        // set collider as trigger
        gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        // Return Object
        Controller.DestroyObj();
    }
    // Editor purpose
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Controller.Model.EngageRadius);
    }
}