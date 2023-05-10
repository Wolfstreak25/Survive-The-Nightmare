using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyStateMachine
{
    private bool isSinking;
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        isSinking = false;
        timeElapsed = 0;
    }
    public override void UpdateState() 
    { 
        timeElapsed += Time.deltaTime;
        if(!isSinking && timeElapsed >= 2f)
        {
            Sinking();
        }
        if(isSinking && timeElapsed >= 1f)
        {
            RemoveSequence();
        }
    }
    private void RemoveSequence()
    {
        enemy.View.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        enemy.View.gameObject.SetActive(false);
        EnemyPool.Instance.ReturnItem(enemy);
        return;
    }
    private void Sinking()
    {
        timeElapsed = 0;
        isSinking = true;
        enemy.rb.isKinematic = false; // Start sinking
    }
}
