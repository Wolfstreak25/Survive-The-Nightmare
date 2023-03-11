
using UnityEngine;

public class PlayerModel
{
    public float TurnSpeed;
    private float health;
    private PlayerController PlayerController;
    private PlayerObject PlayerObject;
    
    public PlayerModel(PlayerObject _PlayerObject)
    {
        this.PlayerObject = _PlayerObject;
        TurnSpeed = PlayerObject.TurnSpeed;
        health = PlayerObject.Health;
    }

    public DamagableType Type
    {
        get{return PlayerObject.Type;}
    }
    public void SetController(PlayerController Playercontroller)
    {
        PlayerController = Playercontroller;
    }
    public float Speed
    {
        get
        {
            return PlayerObject.Speed;
        }
    }

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health =  (int)value;
        }
    }
    public PlayerType PlayerType
    {
        get
        {
            return PlayerObject.PlayerType;
        }
    }
    public int Ammo{get;set;}
   
}
