using UnityEngine;

public class EnemyModel
{
    private EnemyController enemyController;
    private EnemyObject enemy;
    private float health;
    public EnemyModel (EnemyObject _enemy)
    {
        this.enemy = _enemy;
        health = enemy.Health;
    }
    public void SetController(EnemyController _enemyController)
        {enemyController = _enemyController;}
    public EnemyType type
        {get{return enemy.EnemyType;}}
    public float Health
        {get{return health;}set{health = value;}}
    public float speed
        {get{return enemy.Speed;}}
    public float AttackDelay
        {get{return enemy.attackDelay;}}
    public float EngageRadius
        {get{return enemy.EngageRadius;}}
    public void RestoreHealth()
        {health = enemy.Health;}
    public DamagableType Type
        {get{return enemy.Type;}}
    public float damage
        {get{return enemy.Damage;}}
    public float PatrolRadius
        {get{return enemy.EngageRadius;}}
    public float AttackRadius
        {get{return enemy.AttackRadius;}}
}
