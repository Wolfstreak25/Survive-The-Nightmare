public interface IDamagable
{
    void GetDamage(float damage, DamagableType type);
    bool isDead();
}
public enum DamagableType
{
    Player,
    Enemy,
    Bullet,
    Environment
}