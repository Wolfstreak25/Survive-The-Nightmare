public interface IDamagable
{
    void GetDamage(float damage, DamagableType type);
}
public enum DamagableType
{
    Player,
    Enemy,
    Bullet,
    Environment
}