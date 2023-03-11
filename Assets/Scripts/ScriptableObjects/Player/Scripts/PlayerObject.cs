using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Object", menuName = "Objects/New Player Object")]
public class PlayerObject : ScriptableObject
{
    [Header("Type")]
    public DamagableType Type;
    
    public PlayerView PlayerView;
    public PlayerType PlayerType;
    [Header("Speed")]
    public float Speed;
    public float TurnSpeed;
    [Header("Hitpoints")]
    public int Health;
    [Header("Power")]
    public int Damage;
    [Header("Material")]
    public Material color;
}
