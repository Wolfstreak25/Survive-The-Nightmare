using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : Singleton<PlayerFollow>
{
    private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothing = 5f;
    public void GetCamera(Transform player)
    {
        target = player;
        offset = transform.position - target.position;
    }
    private void FixedUpdate() 
    {
        if(target != null)
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}
