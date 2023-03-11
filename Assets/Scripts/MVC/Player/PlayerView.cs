using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerView : MonoBehaviour, IDamagable
{
    [SerializeField] private Transform Barrel;
    private PlayerController Controller;
    public Transform bulletSpawner;
    private Vector3 movement;
    private float rotation;
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Controller.Fire();
        }
    }
    private void FixedUpdate()
    {
        float side = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");
        Controller.Move(side,forward);
        Controller.Turn();
    }
    public void SetController(PlayerController _controller)
    {
        Controller = _controller;
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
    public void GetDamage(float damage, DamagableType type)
    {
       Controller.GetDamage(damage, type);
    }
}