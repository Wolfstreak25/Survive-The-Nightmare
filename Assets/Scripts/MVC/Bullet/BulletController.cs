using UnityEngine;
public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;
    private Rigidbody rb;
    private Vector3 spawnposition;
    private DamagableType shooterType;
    public BulletController(BulletModel _bulletmodel, BulletView _bulletview, Transform SpawnTransform)
    {
        bulletModel = _bulletmodel;
        spawnposition = SpawnTransform.position;
        bulletView =  GameObject.Instantiate<BulletView>(_bulletview, SpawnTransform.position, SpawnTransform.rotation);
        rb = bulletView.GetComponent<Rigidbody>();
        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);
    }
    private void Launch()
    {
        rb.velocity = rb.transform.forward * bulletModel.BulletSpeed;
    }
    public BulletModel GetBulletModel()
    {
        return bulletModel;
    }
    public void bulletContact()
    {
        Collider[] colliders = Physics.OverlapSphere(rb.transform.position, bulletModel.ExplosionRadius);
        for(int i = 0; i<colliders.Length; i++)
        {
            var targetPlayer = colliders[i].GetComponent<EnemyView>();
            if(!targetPlayer)
            {
                continue;
            }
            if(targetPlayer != null)
            {
                Debug.Log("enemy hit");
                targetPlayer.GetDamage(bulletModel.Damage,shooterType);
            }
            bulletView.DestroyBullet();
        }
    }
    public void ActivateObject(Transform spawn, DamagableType type)
    {
        shooterType = type;
        this.bulletView.gameObject.SetActive(true);
        bulletView.transform.position = spawn.position;
        bulletView.transform.rotation = spawn.rotation;
        bulletView.GetComponent<MeshRenderer>().enabled = true;
        Launch();
    }
}
    
