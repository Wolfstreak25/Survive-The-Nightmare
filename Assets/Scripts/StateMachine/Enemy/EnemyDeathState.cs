using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyStateMachine
{
    private bool isSinking;
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        Debug.Log("Change State");
        timeElapsed = 0;
    }
    public override void UpdateState() 
    { 
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= 2f)
        {
            Sinking();
        }
        if(timeElapsed >= 1f && isSinking)
        {
            RemoveSequence();
        }
    }
    private void RemoveSequence()
    {
        enemy.View.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        enemy.View.gameObject.SetActive(false);
        EnemyPool.Instance.ReturnItem(enemy);
    }
    private void Sinking()
    {
        timeElapsed = 0;
        isSinking = true;
        enemy.rb.isKinematic = false; // Start sinking
    }
}
